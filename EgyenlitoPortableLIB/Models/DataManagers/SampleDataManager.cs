using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgyenlitoPortableLIB.Models.DataManagers
{
    public class SampleDataManager : IDataManager
    {
        public async Task<List<Newspaper>> GetNewspapers()
        {
            var newspapers = from x in SampleDatas.Newspapers
                             select x;

            return newspapers.ToList();
        }

        public async Task<List<Article>> GetArticles()
        {
            var articles = from x in SampleDatas.Articles
                           select x;

            return articles.ToList();
        }

        public async Task<List<Article>> GetArticles(int newspaperID)
        {
            var articles = from x in SampleDatas.Articles
                           where x.NewspaperId == newspaperID
                           select x;

            return articles.ToList();
        }
    }
}
