using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libs.Entities
{
    public class BandManager
    {
        [Key]
        public int ID_RP { get; set; }

/*        [Required]*/
        public int ID_Client { get; set; }

/*        [Required]*/
        public int ID_LR { get; set; }

        public DateTime Time_RP { get; set; } = DateTime.Now;

        public string NoiDung { get; set; }

        public bool Status_Rp { get; set; } = true;

        public DateTime? Time_Band { get; set; } // Sử dụng kiểu DateTime? để cho phép giá trị null
    }
}
