using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgyenlitoPortableLIB.Models
{
    public interface IPDFRenderer
    {
        Task<List<string>> RenderPDF(string articleID);
        Task<List<string>> RenderLocalPDF(int articleID);
    }
}
