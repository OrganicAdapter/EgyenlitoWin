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
        public string ExtendedPermissions { get; set; }


        public FacebookHelper()
        {
            App_Id = "703145103066662";
            ExtendedPermissions = "publish_actions,user_about_me";
        }

        public bool IsInternetConnected()
        {
            ConnectionProfile connectionProfile = NetworkInformation.GetInternetConnectionProfile();

            return (connectionProfile != null && connectionProfile.GetNetworkConnectivityLevel() == NetworkConnectivityLevel.InternetAccess);
        }
    }
}
