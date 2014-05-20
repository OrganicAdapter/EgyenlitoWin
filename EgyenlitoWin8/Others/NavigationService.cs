using EgyenlitoPortableLIB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace EgyenlitoWin8.Others
{
    public class NavigationService : INavigationService
    {
        private Frame RootFrame { get; set; }


        public NavigationService(Frame rootFrame)
        {
            RootFrame = rootFrame;
        }

        public void Navigate(string type)
        {
            RootFrame.Navigate(Type.GetType(type));
        }

        public void GoBack()
        {
            RootFrame.GoBack();
        }
    }
}
