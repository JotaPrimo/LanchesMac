using LanchesMac.Context;
using LanchesMac.Models;

namespace LanchesMac.Repositories.Interfaces
{
    public class PedidoRepository : IPedidoRepository
    {

        private readonly AppDbContext _appDbContext;
        private readonly CarrinhoCompra _carrinhoCompra;

        public PedidoRepository(AppDbContext appDbContext, CarrinhoCompra carrinhoCompra)
        {
            _appDbContext = appDbContext;
            _carrinhoCompra = carrinhoCompra;
        }

        public void CriarPedido(Pedido pedido)
        {
            pedido.PedidoEnviado = DateTime.Now;
        }


    }
}
