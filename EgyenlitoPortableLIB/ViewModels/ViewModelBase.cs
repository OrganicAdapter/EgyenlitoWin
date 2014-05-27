using EgyenlitoPortableLIB.Models;
using GalaSoft.MvvmLight.Command;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgyenlitoPortableLIB.ViewModels
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public MainViewModel Main { get; set; }

        private float _zoomLevel;
        public float ZoomLevel
        {
            get { return _zoomLevel; }
            set { _zoomLevel = value; OnPropertyChanged("ZoomLevel"); }
        }


        public RelayCommand GoBack { get; set; }
        public RelayCommand SendEmail { get; set; }
        public RelayCommand<string> OpenWebPage { get; set; }


        public ViewModelBase()
        {
            Main = MainViewModel.Instance;

            ZoomLevel = 250;

            GoBack = new RelayCommand(ExecuteGoBack);
            SendEmail = new RelayCommand(ExecuteSendEmail);
            OpenWebPage = new RelayCommand<string>((x) => ExecuteOpenWebPage(x));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string e)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(e));
        }

        private void ExecuteGoBack()
        {
            Main.NavigationService.GoBack();
        }

        private void ExecuteSendEmail()
        {
            Main.TaskManager.SendEmail();
        }

        private void ExecuteOpenWebPage(string uri)
        {
            Main.TaskManager.OpenWebpage(uri);
        }
    }
}
