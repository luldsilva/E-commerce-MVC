using CasaDoCodigo.Models;
using System.Collections.Generic;

namespace CasaDoCodigo.Repositories
{
    public interface IProductRepository
    {
        void SaveProducts(List<ProductRepository.Book> books);
        IList<Produto> GetAll();
    }
}