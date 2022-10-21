using CasaDoCodigo.Models;
using CasaDoCodigo.Repositories;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using static CasaDoCodigo.Repositories.ProductRepository;

namespace CasaDoCodigo
{
    public partial class Startup
    {
        public class DataService : IDataService
        {
            private readonly ApplicationContext _context;
            private readonly IProductRepository _productRepository;

            public DataService(ApplicationContext context, IProductRepository productRepository)
            {
                this._context = context;
                this._productRepository = productRepository;
            }

            public void InitializeDB()
            {
                _context.Database.Migrate();

                List<Book> books = GetBooks();

                _productRepository.SaveProducts(books);

            }

            private static List<Book> GetBooks()
            {
                var json = File.ReadAllText("livros.json");
                var books = JsonConvert.DeserializeObject<List<Book>>(json);
                return books;
            }
        }
    }
}
