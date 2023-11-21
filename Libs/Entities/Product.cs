using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libs.Entities
{ 
    public class Product
    {
        [Key]
        public int ID_Prod { get; set; }
        public int ID_Client { get; set; }
        public string Name_Client { get; set; }
        public string Name_prod { get; set; }  
        public string Image_Prod { get; set; }
        public int SL_Prod { get; set;}
        public int SL_Prod_Sale { get; set;}
        public int Gia_Prod { get; set;}
        public int Gia_Prod_Sale { get;set;}
        public int SL_Prod_Sell { get; set;}    
        public string MoTa { get; set;}
    }
}
