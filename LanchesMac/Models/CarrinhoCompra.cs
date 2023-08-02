using LanchesMac.Context;
using LanchesMac.Migrations;
using System.Data.Entity;

namespace LanchesMac.Models
{
    public class CarrinhoCompra
    {
        private readonly AppDbContext _appDbContext;

        public CarrinhoCompra(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public string CarrinhoCompraId { get; set; }

        public List<CarrinhoCompraItem> CarrinhoCompraItems { get; set; }

        public static CarrinhoCompra GetCarrinho(IServiceProvider services)
        {
            // definindo uma sessão
            ISession session =
                services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            // pegando um serviço do tipo do contexto
            var context = services.GetService<AppDbContext>();


            // pegando id do carrinho
            string carrinhoId = session.GetString("CarrinhoId") ?? Guid.NewGuid().ToString();

            // setando id do carrinho na session
            session.SetString("CarrinhoId", carrinhoId);

            return new CarrinhoCompra(context)
            {
                CarrinhoCompraId = carrinhoId
            };

        }


        public CarrinhoCompraItem GetCarrinhoCompraItem(Lanche lanche)
        {
            return
                _appDbContext.CarrinhoCompraItems.SingleOrDefault(
                    s => s.Lanche.LancheId == lanche.LancheId &&
                    s.CarrinhoCompraId == CarrinhoCompraId);
        }

        public void AdicionarAoCarrinho(Lanche lanche)
        {
            var carrinhoCompraItem = GetCarrinhoCompraItem(lanche);

            if (carrinhoCompraItem.isNull())
            {
                carrinhoCompraItem = new CarrinhoCompraItem
                {
                    CarrinhoCompraId = CarrinhoCompraId,
                    Lanche = lanche,
                    Quantidade = 1
                };

                _appDbContext.CarrinhoCompraItems.Add(carrinhoCompraItem);

            } else
            {
                carrinhoCompraItem.Quantidade++;
            }

            _appDbContext.SaveChanges();

        }

        public int RemoverDoCarrinho(Lanche lanche)
        {
            // pegando o carrinho compra item por meio do Linq
            var carrinhoCompraItem = GetCarrinhoCompraItem(lanche);

            var quantidadeLocal = 0;

            if (carrinhoCompraItem.isNull())
            {
                if (carrinhoCompraItem.Quantidade > 1)
                {
                    carrinhoCompraItem.Quantidade--;
                }
                else
                {
                    _appDbContext.CarrinhoCompraItems.Remove(carrinhoCompraItem);
                }
            }

            _appDbContext.SaveChanges();
            return quantidadeLocal;
        }

        // retorna instancia caso exista, caso não cria uma nova
        public List<CarrinhoCompraItem> GetCarrinhoCompraItems()
        {
            return CarrinhoCompraItems ?? (CarrinhoCompraItems =
                _appDbContext.CarrinhoCompraItems.Where(c => CarrinhoCompraId == CarrinhoCompraId)
                .Include(s => s.Lanche)
                .ToList());
        }

        public void LimparCarrinho()
        {
            var carrinhoItens = _appDbContext.CarrinhoCompraItems
                .Where(carrinho => carrinho.CarrinhoCompraId == CarrinhoCompraId);

            removeRangeOfCarrinhoCompra(carrinhoItens);
           
        }


        private void removeRangeOfCarrinhoCompra(IQueryable<CarrinhoCompraItem> carrinhoItens)
        {
            _appDbContext.CarrinhoCompraItems.RemoveRange(carrinhoItens);
            _appDbContext.SaveChanges();
        }

        public decimal GetCarrinhCompraTotal()
        {
            return (decimal) _appDbContext.CarrinhoCompraItems
                .Where(c => c.CarrinhoCompraId == CarrinhoCompraId)
                .Select(c => c.Lanche.Preco * c.Quantidade).Sum();           
        }

    }
}
