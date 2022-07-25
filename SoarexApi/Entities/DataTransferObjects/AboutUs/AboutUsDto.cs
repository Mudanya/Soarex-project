using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects.AboutUs
{
    public class AboutUsDto
    {
        public Guid Id { get; set; }
        public string MiniDesc { get; set; }
        public string Desc { get; set; }
        public string? ImageOne { get; set; }
        public string? ImageTwo { get; set; }
    }
}
