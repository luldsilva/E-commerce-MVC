using CasaDoCodigo.Models;
using static CasaDoCodigo.Startup;
using static Microsoft.AspNetCore.Hosting.Internal.HostingApplication;
using System.Collections.Generic;
using System.Linq;

namespace CasaDoCodigo.Repositories
{
    public class ProductRepository : BaseRepository<Produto>, IProductRepository
    {
        public ProductRepository(ApplicationContext context) : base(context)
        {
        }

        public IList<Produto> GetProducts()
        {
            return dbSet.ToList();
        }

        public IList<Produto> GetAll()
        {
            return context.Set<Produto>().ToList();
        }

        public void SaveProducts(List<Book> books)
        {
            foreach (var book in books)
            {
                if(!dbSet.Where(p => p.Codigo== book.Codigo).Any()) {
                    dbSet.Add(new Produto(book.Codigo, book.Nome, book.Preco));
                }
            }
            context.SaveChanges();
        }
        public class Book
        {
            public string Codigo { get; set; }
            public string Nome { get; set; }
            public decimal Preco { get; set; }
        }
    }
}
