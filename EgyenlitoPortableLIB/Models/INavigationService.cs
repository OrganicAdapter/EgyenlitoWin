using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgyenlitoPortableLIB.Models
{
    public interface INavigationService
    {
        void Navigate(string type);
        void GoBack();
    }
}
