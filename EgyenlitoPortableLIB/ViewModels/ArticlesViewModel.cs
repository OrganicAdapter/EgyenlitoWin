using EgyenlitoPortableLIB.Models;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgyenlitoPortableLIB.ViewModels
{
    public class ArticlesViewModel : ViewModelBase
    {
        private static ArticlesViewModel _instance;
        public static ArticlesViewModel Instance
        {
            get 
            {
                if (_instance == null)
                    _instance = new ArticlesViewModel();

                return _instance; 
            }
        }


        private List<Article> _articles;
        public List<Article> Articles
        {
            get { return _articles; }
            set { _articles = value; OnPropertyChanged("Articles"); }
        }


        public RelayCommand<Article> Open { get; set; }


        public ArticlesViewModel()
        {
            GetArticles(Main.NewspaperID);

            Open = new RelayCommand<Article>((x) => ExecuteOpen(x));
        }

        private async void GetArticles(int newspaperID)
        {
            if (newspaperID < 0)
                GetArticles();
            else
            {
                var all = await Main.DataManager.GetArticles();
                var articles = from x in all
                               where x.NewspaperId == newspaperID
                               select x;

                Articles = articles.ToList();
            }
        }

        private async void GetArticles()
        {
            Articles = await Main.DataManager.GetArticles();
        }

        private void ExecuteOpen(Article article)
        {
            Main.Article = article;
            Main.NavigationService.Navigate("EgyenlitoWin8.PDFReaderView");
        }
    }
}
