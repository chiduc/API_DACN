﻿using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libs.Entities
{
    public class LiveRoom
    {
        [Key]
        public int ID_LR { get; set; }
        public string Name_Client { get; set; }
        public string Username_Client { get; set; }
        public int ID_Client { get; set; }
        public bool IsLive { get; set; }
    }
}
