using Libs.Entities;
using Libs.Repositories;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libs.Services
{
    public class ProductService
    {
        private ApplicationDbContext dbContext;
        private IProductRepository productRepository;

        public ProductService(ApplicationDbContext dbContext) { 
            this.dbContext = dbContext; 
           
            this.productRepository = new ProductRepository(dbContext);
        }
        public void Save() { 
            this.dbContext.SaveChanges();
        }
        
        public List<LiveRoom> getLive()
        {
            return dbContext.Liveroom.ToList();
        }



        // -----------------------------------------------------------
        public void insertProduct(Product product)
        {
            productRepository.insertProduct(product);
            Save();
        }
       
        public void updateProduct(Product product)
        {
            if(product != null)
            {
                productRepository.updateProduct(product);
                Save();
            }
        }
        public void deleteProduct(Product product)
        {
            if(product != null)
            {
                productRepository.deleteProduct(product);
                Save();
            }
        }

        public Product GetProductById_G(Guid id)

        {
             return dbContext.Product.FirstOrDefault(p => p.Id == id);
           
        }
        public Product GetProductById_S(string id)
        {
            if (Guid.TryParse(id, out Guid guidId))
            {
                return dbContext.Product.FirstOrDefault(p => p.Id == guidId);
            }
            else
            {
                return null;
            }

        } 
        public LiveRoom GetLiveByID(int id_live)
        {
           return dbContext.Liveroom.FirstOrDefault(p => p.ID_LR == id_live); 

        }
        public List<Product> getProducts()
        {
            return dbContext.Product.ToList();
        }

    }
}
