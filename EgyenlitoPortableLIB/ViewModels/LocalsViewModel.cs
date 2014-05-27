using EgyenlitoPortableLIB.Models;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgyenlitoPortableLIB.ViewModels
{
    public class LocalsViewModel : ViewModelBase
    {
        private static LocalsViewModel _instance;
        public static LocalsViewModel Instance
        {
            get 
            {
                if (_instance == null)
                    _instance = new LocalsViewModel();

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

        public LocalsViewModel()
        {
            Articles = Main.LocalDataManager.LocalArticles.ToList();
            Open = new RelayCommand<Article>((x) => ExecuteOpen(x));
        }

        private void ExecuteOpen(Article article)
        {
            Main.Article = article;
            Main.NavigationService.Navigate("EgyenlitoWin8.PDFReaderView");
        }
    }
}
