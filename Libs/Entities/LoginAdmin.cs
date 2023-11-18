using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libs.Entities
{
    public class LoginAdmin
    {
        [Key]
/*        public int ID_Admin { get; set; }

        [Required]*/
        public int ID_AT { get; set; }
        public string Name_Admin { get; set; }
        public string Pass_Admin { get; set; }
    }
}
