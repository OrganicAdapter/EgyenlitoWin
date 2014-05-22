using EgyenlitoPortableLIB.Models;
using EgyenlitoPortableLIB.ViewModels;
using Facebook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.System;
using Windows.UI.Popups;

namespace EgyenlitoWin8.Facebook
{
    public class FacebookManager : IFacebookManager
    {
        public FacebookClient Client { get; set; }
        public FacebookHelper Helper { get; set; }

        public string Access_Token { get; set; }

        public FacebookManager()
        {
            Helper = new FacebookHelper();
        }


        public async void Authenticate()
        {
            if (!Helper.IsInternetConnected())
            {
                MessageDialog message = new MessageDialog("Nincs internet kapcsolat!");
                await message.ShowAsync();
            }
            else
            {
                MainViewModel.Instance.NavigationService.Navigate("EgyenlitoWin8.FacebookView");
                MainViewModel.Instance.FacebookUri = new Uri(Helper.NavigationUri);
            }
        }

        public void Share(Uri uri)
        {
            if (uri.AbsoluteUri.Contains("access_token"))
            {
                string url = uri.AbsoluteUri;
                Access_Token = Helper.GetAccesToken(url);
                Client = new FacebookClient(Access_Token);

                Client.GetCompleted += Client_GetCompleted;
            }
        }

        async void Client_GetCompleted(object sender, FacebookApiEventArgs e)
        {
            var parameters = new Dictionary<string, object>();

            parameters["access_token"] = Access_Token;
            parameters["client_id"] = Helper.App_Id;
            parameters["scope"] = Helper.ExtendedPermissions;
            
            await Task.Factory.StartNew(() =>
            {
                Client.GetTaskAsync("me");
            });

            Post();
        }

        async void Post()
        {
            var parameters = new Dictionary<string, object>();

            var pdfUri = MainViewModel.Instance.Article.PdfUri;

            parameters["message"] = pdfUri;
            await Client.PostTaskAsync("me/feed", parameters);
            Client.PostCompleted += Client_PostCompleted;

            MainViewModel.Instance.NavigationService.GoBack();
        }

        async void Client_PostCompleted(object sender, FacebookApiEventArgs e)
        {
            if (e.Error != null)
            {
                MessageDialog msd = new MessageDialog("Hiba történt!");
                await msd.ShowAsync();

                MainViewModel.Instance.NavigationService.GoBack();
            }
            else
                MainViewModel.Instance.NavigationService.GoBack();
        }
    }
}
