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
        private IPLiveRepository LiveRepository;
        private IProductRepository productRepository;
        private IStudentRepository studentRepository;

        public ProductService(ApplicationDbContext dbContext) { 
            this.dbContext = dbContext; 
            this.LiveRepository = new LiveRepository(dbContext);
            this.productRepository = new ProductRepository(dbContext);
            this.studentRepository = new StudentRepository(dbContext);
        }
        public void Save() { 
            this.dbContext.SaveChanges();
        }
        
        public List<Live> getLive()
        {
            return dbContext.Live.ToList();
        }
        public void insertLive(Live lie)
        {
            LiveRepository.insertLive(lie);
            Save();
            
        }

        public void delete_live(Live lie)
        {
            if (lie != null)
            {
                LiveRepository.delete_live(lie);
                Save();
            }

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
        public Live GetLiveByID(int id_live)
        {
           return dbContext.Live.FirstOrDefault(p => p.idLive == id_live); 

        }
        public List<Product> getProducts()
        {
            return dbContext.Product.ToList();
        }
        public List<Student> getStudents()
        {
            return dbContext.Student.ToList();
        }
    }
}
