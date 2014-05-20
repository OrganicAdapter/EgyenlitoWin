using EgyenlitoPortableLIB.Models;
using EgyenlitoPortableLIB.Models.DataManagers;
using EgyenlitoWin8.DataProviderService;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgyenlitoWin8.Others
{
    public class OnlineDataManager : IDataManager
    {
        public DataProviderServiceClient Entities { get; set; }

        public OnlineDataManager()
        {
            Entities = new DataProviderServiceClient();
        }

        public async Task<List<Newspaper>> GetNewspapers()
        {
            var str = await Entities.GetNewspapersAsync();
            var newspapers = await JsonConvert.DeserializeObjectAsync<List<Newspaper>>(str);

            return newspapers;
        }

        public async Task<List<Article>> GetArticles()
        {
            var str = await Entities.GetAllArticlesAsync();
            var articles = await JsonConvert.DeserializeObjectAsync<List<Article>>(str);

            return articles;
        }

        public async Task<List<Article>> GetArticles(int newspaperID)
        {
            var str = await Entities.GetArticlesAsync(newspaperID);
            var articles = await JsonConvert.DeserializeObjectAsync<List<Article>>(str);

            return articles;
        }
    }
}
