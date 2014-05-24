using EgyenlitoPortableLIB.Models;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgyenlitoPortableLIB.ViewModels
{
    public class NewspapersViewModel : ViewModelBase
    {
        private static NewspapersViewModel _instance;
        public static NewspapersViewModel Instance
        {
            get 
            {
                if (_instance == null)
                    _instance = new NewspapersViewModel();

                return _instance; 
            }
        }


        private List<Newspaper> _newspapers;
        public List<Newspaper> Newspapers
        {
            get { return _newspapers; }
            set { _newspapers = value; OnPropertyChanged("Newspapers"); }
        }


        public RelayCommand<object> Open { get; set; }


        public NewspapersViewModel()
        {
            GetNewspapers();

            Open = new RelayCommand<object>((x) => ExecuteOpen(x));
        }

        private async void GetNewspapers()
        {
            Newspapers = await Main.DataManager.GetNewspapers();
        }

        private void ExecuteOpen(object newspaperID)
        {
            Main.NewspaperID = int.Parse(newspaperID.ToString());
            Main.Newspaper = Newspapers.FirstOrDefault((x) => x.NewspaperId.Equals(newspaperID));

            Main.NavigationService.Navigate("EgyenlitoWin8.ArticlesView");
        }
    }
}
