using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgyenlitoPortableLIB.Models
{
    public class Newspaper
    {
        public int NewspaperId { get; set; }
        public string Title { get; set; }
        public string ReleaseDate { get; set; }
        public int Pages { get; set; }
        public string CoverUri { get; set; }
        public string UploadDate { get; set; }
    }
}
