using EgyenlitoPortableLIB.Models;
using EgyenlitoPortableLIB.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Data.Pdf;
using Windows.Storage;
using Windows.Storage.Streams;

namespace EgyenlitoWin8.Others
{
    public class PDFRenderer : IPDFRenderer
    {
        public PdfDocument PDFDocument { get; set; }


        async Task<List<string>> IPDFRenderer.RenderPDF(string pdfFileName)
        {
            var list = new List<string>();

            try
            {
                StorageFile pdfFile = await ApplicationData.Current.LocalFolder.GetFileAsync("article.pdf");

                PDFDocument = await PdfDocument.LoadFromFileAsync(pdfFile); ;

                if (PDFDocument != null && PDFDocument.PageCount > 0)
                {
                    StorageFolder tempFolder = await ApplicationData.Current.TemporaryFolder.CreateFolderAsync(pdfFileName);

                    for (int i = 0; i < PDFDocument.PageCount; i++)
                    {
                        var pdfPage = PDFDocument.GetPage(Convert.ToUInt32(i));

                        if (pdfPage != null)
                        {
                            StorageFile jpgFile = await tempFolder.CreateFileAsync(i.ToString() + ".png", CreationCollisionOption.ReplaceExisting);

                            if (jpgFile != null)
                            {
                                IRandomAccessStream randomStream = await jpgFile.OpenAsync(FileAccessMode.ReadWrite);

                                await pdfPage.RenderToStreamAsync(randomStream);

                                await randomStream.FlushAsync();

                                randomStream.Dispose();
                                pdfPage.Dispose();

                                list.Add(jpgFile.Path);
                            }
                            else
                                return null;
                        }
                        else
                            return null;
                    }

                    return list;
                }
                else
                    return null;
            }
            catch
            {
                return null;
            }
        }

        async Task<List<string>> IPDFRenderer.RenderLocalPDF(int articleID)
        {
            StorageFolder tempFolder = await ApplicationData.Current.TemporaryFolder.GetFolderAsync(articleID.ToString());

            var files = await tempFolder.GetFilesAsync();

            List<string> fileNames = new List<string>();

            foreach (var file in files)
            {
                fileNames.Add(file.Path);
            }

            return fileNames;
        }
    }
}
