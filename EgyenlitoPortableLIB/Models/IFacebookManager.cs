using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgyenlitoPortableLIB.Models
{
    public interface IFacebookManager
    {
        void Authenticate();
        void Share(Uri uri);
    }
}
