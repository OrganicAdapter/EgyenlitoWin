using EgyenlitoPortableLIB.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace EgyenlitoWin8
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class FacebookView : Page
    {
        public FacebookView()
        {
            this.InitializeComponent();
        }

        private void Webview_LoadCompleted(object sender, NavigationEventArgs e)
        {
            MainViewModel.Instance.FacebookManager.Share(e.Uri);   
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            Webview.Navigate(MainViewModel.Instance.FacebookUri);
        }
    }
}
