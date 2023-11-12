using API_DACN.Models;
using Libs.Entities;
using Libs.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace API_DACN.Controllers.api
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private ProductService productService;

        public SalesController(ProductService productService)
        {
            this.productService = productService;
        }
        // AHUHU
//---------------------------------------------------------------------------------------------------------------------------------------------
//---------------------------------------------------------------------------------------------------------------------------------------------
        [HttpGet]
        [Route("get-Live-list")]
        public IActionResult getLiveList()
        {
            List<Live> lvietList = productService.getLive();
            return Ok(new { status = true, message = "", data = lvietList });
        }
        [HttpPost]
        [Route("insert-live")]
        public IActionResult insert_live(int idLive , string name)
        {
            Live lie = new Live();
            lie.idLive = idLive;
            lie.name = name;

            productService.insertLive(lie);
            return Ok(new { status = true, message = "" });
        }
        [HttpPost]
        [Route("delete-live")]
        public IActionResult delete_live(int idLive)
        {

            Live liveDelete = productService.GetLiveByID(idLive);

            if (delete_live == null)
            {
                return NotFound(new { status = false, message = "LIVE không tồn tại bbbbbb" });
            }

            productService.delete_live(liveDelete);

            return Ok(new { status = true, message = "" });
        }
//---------------------------------------------------------------------------------------------------------------------------------------------
//---------------------------------------------------------------------------------------------------------------------------------------------
        [HttpPost]
        [Route("delete-product")]
        public IActionResult deleteProduct(string id)
        {

            Product productToDelete = productService.GetProductById_S(id);

            if (productToDelete == null)
            {
                return NotFound(new { status = false, message = "Sản phẩm không tồn tại bbbbbb" });
            }

            productService.deleteProduct(productToDelete);

            return Ok(new { status = true, message = "" });
        }
        [HttpPost]
        [Route("update-product")]
        //string id, string name, decimal price , string url , string groupName
        public IActionResult updateProduct(ProductModel productModel)
        {
            Product Productt = productService.GetProductById_G(productModel.Id); // Đảm bảo rằng bạn có một phương thức để lấy sản phẩm dựa trên id


            if (Productt == null)
            {
                return NotFound(new { status = false, message = "Sản phẩm không tồn tại aaaaaaa" });
            }
            Productt.Name = productModel.Name;
            Productt.Price = productModel.Price;
            Productt.Url = productModel.Url;
            Productt.GroupName = productModel.GroupName;
            productService.updateProduct(Productt);
            return Ok(new { status = true, message = "" });
        }
        [HttpPost]
        [Route("insert-product")]
        public IActionResult insertProductv1(ProductModel productModel)
        {
            Product pro = new Product();
            pro.Id = Guid.NewGuid();
            pro.Name = productModel.Name;
            pro.Price = productModel.Price;          
            pro.Url = productModel.Url;
            pro.GroupName = productModel.GroupName;
            productService.insertProduct(pro);
            return Ok(new { status = true, message = "" });
        }

        [HttpGet]
        [Route("get-product-list")]
        public IActionResult getProductList()
        {
            List<Product> productList = productService.getProducts();
            return Ok(new { status = true, message = "", data = productList });
        }
//---------------------------------------------------------------------------------------------------------------------------------------------
        [HttpGet]
        [Route("get-student-list")]
        public IActionResult getStudentList()
        {
            List<Student> studentList = productService.getStudents();
            return Ok(new { status = true, message = "", data = studentList });
        }

    }
}
