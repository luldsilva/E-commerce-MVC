﻿using CasaDoCodigo.Models;
using static CasaDoCodigo.Startup;
using static Microsoft.AspNetCore.Hosting.Internal.HostingApplication;
using System.Collections.Generic;
using System.Linq;

namespace CasaDoCodigo.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationContext context;

        public ProductRepository(ApplicationContext context)
        {
            this.context = context;
        }

        public IList<Produto> GetAll()
        {
            return context.Set<Produto>().ToList();
        }

        public void SaveProducts(List<Book> books)
        {
            foreach (var book in books)
            {
                context.Set<Produto>().Add(new Produto(book.Codigo, book.Nome, book.Preco));
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
