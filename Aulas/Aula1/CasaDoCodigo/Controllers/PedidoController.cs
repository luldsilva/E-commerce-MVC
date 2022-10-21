using CasaDoCodigo.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CasaDoCodigo.Controllers
{
    public class PedidoController : Controller
    {
        private readonly IProductRepository _productRepository;

        public PedidoController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IActionResult Carrossel()
        {
            return View(_productRepository.GetAll());
        }

        public IActionResult Carrinho()
        {
            return View();
        }

        public IActionResult Cadastro()
        {
            return View();
        }

        public IActionResult Resumo()
        {
            return View();
        }
    }
}
