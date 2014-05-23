using EgyenlitoPortableLIB.Models;
using EgyenlitoPortableLIB.ViewModels;
using Facebook;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Core;
using Windows.Security.Authentication.Web;
using Windows.System;
using Windows.UI.Core;
using Windows.UI.Popups;
using Windows.UI.Xaml;

namespace EgyenlitoWin8.Facebook
{
    public class FacebookManager : IFacebookManager
    {
        public FacebookClient Client { get; set; }
        public FacebookHelper Helper { get; set; }

        public CoreDispatcher Dispatcher { get; set; }

        public FacebookManager()
        {
            Helper = new FacebookHelper();
            Client = new FacebookClient();

            Dispatcher = Windows.UI.Core.CoreWindow.GetForCurrentThread().Dispatcher;
        }


        public async void Authenticate()
        {
            try
            {
                if (!Helper.IsInternetConnected())
                {
                    ShowMessage("Nincs internet kapcsolat!");
                }
                else
                {
                    var redirectUrl = "https://www.facebook.com/connect/login_success.html";

                    var loginUrl = Client.GetLoginUrl(new
                    {
                        client_id = Helper.App_Id,
                        redirect_uri = redirectUrl,
                        scope = Helper.ExtendedPermissions,
                        display = "popup",
                        response_type = "token"
                    });

                    var endUri = new Uri(redirectUrl);

                    WebAuthenticationResult WebAuthenticationResult = await WebAuthenticationBroker.AuthenticateAsync(WebAuthenticationOptions.None, loginUrl, endUri);

                    if (WebAuthenticationResult.ResponseStatus == WebAuthenticationStatus.Success)
                    {
                        var callbackUri = new Uri(WebAuthenticationResult.ResponseData.ToString());
                        var facebookOAuthResult = Client.ParseOAuthCallbackUrl(callbackUri);
                        var accessToken = facebookOAuthResult.AccessToken;
                        if (String.IsNullOrEmpty(accessToken))
                        {
                            // User is not logged in, they may have canceled the login
                        }
                        else
                        {
                            // User is logged in and token was returned
                            LoginSucceded(accessToken);
                        }
                    }
                }
            }
            catch
            {
                ShowMessage("Hiba történt!");
            }
        }

        async void ShowMessage(string message)
        {
            await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, async () =>
                {
                    MessageDialog mesg = new MessageDialog(message);
                    await mesg.ShowAsync();
                });
        }

        private async void LoginSucceded(string accessToken)
        {
            dynamic parameters = new ExpandoObject();
            parameters.access_token = accessToken;
            parameters.fields = "id";

            Client = new FacebookClient(accessToken);

            dynamic result = await Client.GetTaskAsync("me", parameters);
            parameters = new ExpandoObject();
            parameters.id = result.id;
            parameters.access_token = accessToken;

            Post();
        }

        public async void Post()
        {
            try
            {
                var parameters = new Dictionary<string, object>();
                var article = MainViewModel.Instance.Article;
                var newspapers = await MainViewModel.Instance.DataManager.GetNewspapers();
                var img = (from x in newspapers
                           where x.NewspaperId == MainViewModel.Instance.NewspaperID
                           select x).First();


                parameters["link"] = article.PdfUri;
                parameters["picture"] = img.CoverUri;
                parameters["name"] = article.Title;

                Client.PostCompleted += Client_PostCompleted;
                dynamic result = await Client.PostTaskAsync("me/feed", parameters);
            }
            catch
            {
                ShowMessage("Hiba történt!");
            }
        }

        void Client_PostCompleted(object sender, FacebookApiEventArgs e)
        {
            if (e.Error != null)
            {
                ShowMessage("Hiba történt!");
            }
            else
            {
                ShowMessage("A cikket sikeresen megosztottad!");
            }
        }
    }
}
