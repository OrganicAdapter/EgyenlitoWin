using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Networking.Connectivity;

namespace EgyenlitoWin8.Facebook
{
    public class FacebookHelper
    {
        public string App_Id { get; set; }
        public string App_Secret { get; set; }
        public string ExtendedPermissions { get; set; }
        public string NavigationUri { get; set; }


        public FacebookHelper()
        {
            App_Id = "592620517520164";
            App_Secret = "af0d03fb0cd7e7f9814c11e1bdee1813";
            ExtendedPermissions = "user_about_me,publish_actions";
            NavigationUri = "https://www.facebook.com/dialog/oauth?client_id=" + App_Id + "&redirect_uri=http://m.facebook.com/connect/login_success.html&response_type=token&scope=" + ExtendedPermissions;
        }

        public string GetAccesToken(string absoluteUri)
        {
            var uri = absoluteUri;
            var uri2 = uri.Substring(uri.IndexOf("access_token"));
            var uri3 = uri2.Substring(13);
            var accessToken = uri3.Substring(0, uri3.IndexOf("&"));

            return accessToken;
        }

        public bool IsInternetConnected()
        {
            ConnectionProfile connectionProfile = NetworkInformation.GetInternetConnectionProfile();

            return (connectionProfile != null && connectionProfile.GetNetworkConnectivityLevel() == NetworkConnectivityLevel.InternetAccess);
        }
    }
}
