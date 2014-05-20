using EgyenlitoPortableLIB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.System;

namespace EgyenlitoWin8.Others
{
    public class TaskManager : ITaskManager
    {
        public async void OpenWebpage(string uri)
        {
            var page = new Uri(uri);
            await Launcher.LaunchUriAsync(page);
        }

        public async void SendEmail()
        {
            var mailto = new Uri("mailto:?to=ujegyenlito2013@gmail.com&subject=Észrevétel");
            await Launcher.LaunchUriAsync(mailto);
        }

        public void PostToFacebook()
        {
            throw new NotImplementedException();
        }
    }
}
