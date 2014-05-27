using EgyenlitoPortableLIB.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Windows.Storage;

namespace EgyenlitoWin8.Others
{
    public class LocalStorage : ILocalStorage
    {
        public async void Save(XDocument xDoc)
        {
            StorageFile file = await ApplicationData.Current.LocalFolder.CreateFileAsync("locals.xml", CreationCollisionOption.ReplaceExisting);

            await FileIO.WriteTextAsync(file, xDoc.ToString());
        }

        public async Task<XDocument> Load()
        {
            try
            {
                var file = await ApplicationData.Current.LocalFolder.GetFileAsync("locals.xml");
                var xDocStr = await FileIO.ReadTextAsync(file);

                return XDocument.Parse(xDocStr);
            }

            catch (FileNotFoundException)
            {
                XDocument xDoc = new XDocument();
                xDoc.Add(new XElement("Root"));

                return xDoc;
            }
        }

        public async void Delete(int id)
        {
            StorageFolder tempFolder = await ApplicationData.Current.TemporaryFolder.GetFolderAsync(id.ToString());
            await tempFolder.DeleteAsync(StorageDeleteOption.PermanentDelete);
        }
    }
}
