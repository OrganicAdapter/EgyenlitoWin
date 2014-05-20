using EgyenlitoPortableLIB.Models;
using EgyenlitoPortableLIB.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Networking.BackgroundTransfer;
using Windows.Storage;
using Windows.Web.Http;

namespace EgyenlitoWin8.Others
{
    public class WebClient : IWebClient
    {
        public HttpClient Client { get; set; }

        public async Task DownloadFile(string uri)
        {
            var path = new Uri(uri);
            var downloader = new BackgroundDownloader();
            var file = await ApplicationData.Current.LocalFolder.CreateFileAsync("article.pdf", CreationCollisionOption.ReplaceExisting);
            var download = downloader.CreateDownload(path, file);
            await StartDownloadAsync(download);

            MainViewModel.Instance.LocalDataManager.AddArticle(MainViewModel.Instance.Article);
        }

        private async Task StartDownloadAsync(DownloadOperation download)
        {
            var progress = new Progress<DownloadOperation>();
            await download.StartAsync().AsTask(progress);
        }
    }
}
