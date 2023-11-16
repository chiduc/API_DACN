using System;
using System.Collections.Generic;
using System.Data.SqlClient;

using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Libs.Entities
{
    public class Report
    {
        public int ID_RP { get; set; }
        public int ID_Client { get; set; }
        public int ID_LR { get; set; }
        public DateTime Time_RP { get; set; }
        public string NoiDung { get; set; }
        public bool Status_Rp { get; set; }
        public DateTime? Time_Band { get; set; }
        public string HinhAnh { get; set; }


    }
}
