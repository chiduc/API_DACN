using API_DACN.Models;
using Libs.Entities;
using Libs.Services;
using Microsoft.AspNetCore.Mvc;

namespace API_DACN.Controllers.api
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private ProductService productService;
        private ClientService clientService;
        private LiveRoomService liveRoomService;


        public SalesController(ProductService productService)
        {
            this.productService = productService;
        }

        //---------------------------------------------------------------------------------------------------------------------------------------------
        //---------------------------------------------------------------------------------------------------------------------------------------------
        [HttpGet]
        [Route("get-Live-list")]
        public IActionResult getLiveList()
        {
            List<LiveRoom> lvietList = productService.getLive();
            return Ok(new { status = true, message = "", data = lvietList });
        }
        [HttpPost]
        [Route("insert-live")]
        public IActionResult insert_live(int id_client)
        {

            LiveRoom LR = new LiveRoom();
            LR.ID_Client = id_client;

            liveRoomService.insertLive(LR);
            return Ok(new { status = true, message = "" });
        }
        [HttpPost]
        [Route("delete-live")]
        public IActionResult delete_live(int idLive)
        {

            LiveRoom liveDelete = productService.GetLiveByID(idLive);

            if (delete_live == null)
            {
                return NotFound(new { status = false, message = "LIVE không tồn tại bbbbbb" });
            }

          //  productService.delete_live(liveDelete);

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

    }
}
