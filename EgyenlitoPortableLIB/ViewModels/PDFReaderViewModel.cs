using EgyenlitoPortableLIB.Models;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgyenlitoPortableLIB.ViewModels
{
    public class PDFReaderViewModel : ViewModelBase
    {
        private static PDFReaderViewModel _instance;
        public static PDFReaderViewModel Instance
        {
            get 
            {
                if (_instance == null)
                    _instance = new PDFReaderViewModel();

                return _instance; 
            }
        }


        private List<string> _pdfPages;
        public List<string> PDFPages
        {
            get { return _pdfPages; }
            set { _pdfPages = value; OnPropertyChanged("PDFPages"); }
        }


        public RelayCommand<Uri> Post { get; set; }
        public RelayCommand Authenticate { get; set; }
        public RelayCommand Delete { get; set; }


        public PDFReaderViewModel()
        {
            DownloadPDF(Main.Article);

            Post = new RelayCommand<Uri>((x) => ExecutePost(x));
            Authenticate = new RelayCommand(ExecuteAuthenticate);
            Delete = new RelayCommand(ExecuteDelete);
        }

        private async void DownloadPDF(Article article)
        {
            if (Main.LocalDataManager.ArticleExists(article.ArticleId))
            {
                PDFPages = await Main.PDFRenderer.RenderLocalPDF(Main.Article.ArticleId);
            }
            else
            {
                await Main.WebClient.DownloadFile(article.PdfUri);
                PDFPages = await Main.PDFRenderer.RenderPDF(Main.Article.ArticleId.ToString());
            }
        }

        private void ExecutePost(Uri uri)
        {
            Main.FacebookManager.Post();   
        }

        private void ExecuteAuthenticate()
        {
            Main.FacebookManager.Authenticate();
        }

        private void ExecuteDelete()
        {
            Main.LocalDataManager.DeleteArticle(Main.Article.ArticleId);
            Main.LocalStorage.Delete(Main.Article.ArticleId);
            Main.NavigationService.GoBack();
        }
    }
}
