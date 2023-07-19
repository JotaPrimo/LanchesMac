﻿using LanchesMac.Context;

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


        public void GetCarrinhoCompraItem(Lanche lanche)
        {
            return
                _appDbContext.CarrinhoCompraItems.SingleOrDefault(
                    s => s.Lanche.Id == lanche.Id &&
                    s.CarrinhoCompraId == CarrinhoCompraId);
        }

        public void AdicionarAoCarrinho(Lanche lanche)
        {
            var carrinhoCompraItem =
                _appDbContext.CarrinhoCompraItems.SingleOrDefault(
                    s => s.Lanche.Id == lanche.Id &&
                    s.CarrinhoCompraId == CarrinhoCompraId);

            if (carrinhoCompraItem == null)
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
            var carrinhoCompraItem =
                _appDbContext.CarrinhoCompraItems.SingleOrDefault(
                    s => s.Lanche.Id == lanche.Id &&
                    s.CarrinhoCompraId == CarrinhoCompraId);

            var quantidadeLocal = 0;

            if (carrinhoCompraItem != null)
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

    }
}
