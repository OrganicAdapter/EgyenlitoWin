using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace EgyenlitoPortableLIB.Models
{
    public interface ILocalStorage
    {
        void Save(XDocument xDoc);
        Task<XDocument> Load();
        void Delete(int id);
    }
}
