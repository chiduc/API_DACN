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
        public string Name_Client { get; set; }
        public string Pass_Client { get; set; }
        public bool IsClientLive { get; set; }
    }
}
