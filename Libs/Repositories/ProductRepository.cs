using Libs.Data;
using Libs.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libs.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        public void insertProduct(Product product);
        public void updateProduct(Product product);
        public void deleteProduct(Product product);
    }
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public void deleteProduct(Product product)
        {
            if (product == null)
            {
                return;
            }
            else
            {
                _dbContext.Product.Remove(product);
            }
        }

        public void insertProduct(Product product)
        {
            _dbContext.Product.Add(product);
        }

        public void updateProduct(Product product)
        {
            if(product == null)
            {
                return;
            }
            else
            {
                _dbContext.Product.Update(product);
            }
        }
    }
}
