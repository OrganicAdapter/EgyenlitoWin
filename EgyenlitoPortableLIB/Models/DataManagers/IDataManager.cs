using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgyenlitoPortableLIB.Models.DataManagers
{
    public interface IDataManager
    {
        Task<List<Newspaper>> GetNewspapers();
        Task<List<Article>> GetArticles();
        Task<List<Article>> GetArticles(int newspaperID);
    }
}
