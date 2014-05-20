using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgyenlitoPortableLIB.Models
{
    public interface IWebClient
    {
        Task DownloadFile(string uri);
    }
}
