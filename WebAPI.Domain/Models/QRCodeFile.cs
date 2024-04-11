﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI.Domain.Models
{
    public record QRCodeFile
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public string Content { get;set; }
    }
}
