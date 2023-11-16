using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libs.Entities
{
    public class Client
    {
		[Key]
        public int ID_Client { get; set; }
        public string Name_Client { get; set; }    
        public string Pass_Client { get; set; }
		public DateTime NgaySinh { get; set; }
        public int SDT { get; set; }
        public string Bio { get; set; }
        public string Image_Client { get; set; }
        public int ID_Is_Live { get; set; }
        public int Count_RP { get; set; }
        public bool IsClientLive { get; set; }


    }
}
