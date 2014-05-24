using EgyenlitoPortableLIB.Models;
using EgyenlitoPortableLIB.Models.DataManagers;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgyenlitoPortableLIB.ViewModels
{
    public class MainViewModel
    {
        private static MainViewModel _instance;
        public static MainViewModel Instance
        {
            get 
            {
                if (_instance == null)
                    _instance = new MainViewModel();

                return _instance; 
            }
        }


        public INavigationService NavigationService { get; set; }
        public IDataManager DataManager { get; set; }
        public IWebClient WebClient { get; set; }
        public IPDFRenderer PDFRenderer { get; set; }
        public LocalDataManager LocalDataManager { get; set; }
        public ILocalStorage LocalStorage { get; set; }
        public ITaskManager TaskManager { get; set; }
        public IFacebookManager FacebookManager { get; set; }

        public int NewspaperID { get; set; }
        public Newspaper Newspaper { get; set; }
        public Article Article { get; set; }


        public Uri FacebookUri { get; set; }


        public MainViewModel()
        {
            //DataManager = new SampleDataManager();
            LocalDataManager = new LocalDataManager();
        }
    }
}
