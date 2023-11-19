using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libs.Entities
{
    public class ClientModel
    {
        [Key] 
        public string name_client { get; set; }
        public string Username_Client { get; set; }
        public string Password_Client { get; set; }
        public bool IsClientLive { get; set; }
    }
}
