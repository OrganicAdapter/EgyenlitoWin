using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgyenlitoPortableLIB.Models
{
    public class Article
    {
        public int ArticleId { get; set; }
        public int NewspaperId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string PdfUri { get; set; }
    }
}
