using EgyenlitoPortableLIB.Models.DataManagers;
using EgyenlitoPortableLIB.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace EgyenlitoPortableLIB.Models
{
    public class LocalDataManager
    {
        public ObservableCollection<Article> LocalArticles { get; set; }


        public LocalDataManager()
        {
            LocalArticles = new ObservableCollection<Article>();
        }

        public async void GetArticles()
        {
            XDocument xDoc = await MainViewModel.Instance.LocalStorage.Load();

            var arts = (from x in xDoc.Root.Elements()
                           select x).ToList();

            ObservableCollection<Article> articles = new ObservableCollection<Article>();

            foreach (var item in arts)
            {
                Article art = new Article()
                {
                    ArticleId = int.Parse(item.Attribute("ArticleID").Value.ToString()),
                    Author = item.Attribute("Author").Value.ToString(),
                    Title = item.Attribute("Title").Value.ToString(),
                    PdfUri = item.Attribute("Link").Value.ToString(),
                    NewspaperId = int.Parse(item.Attribute("NewspaperID").Value.ToString())
                };

                articles.Add(art);
            }

            LocalArticles = articles;
        }

        public bool ArticleExists(int articleID)
        {
            var article = (from x in LocalArticles
                          where x.ArticleId == articleID
                          select x).ToList();

            return (article.Count == 0) ? false : true;
        }

        public void AddArticle(Article article)
        {
            LocalArticles.Add(article);
            SaveArticles();
        }

        public void SaveArticles()
        {
            XDocument xDoc = new XDocument();
            xDoc.Add(new XElement("Root"));

            foreach (var article in LocalArticles)
            {
                xDoc.Root.Add(new XElement("Article",
                    new XAttribute("ArticleID", article.ArticleId),
                    new XAttribute("Author", article.Author),
                    new XAttribute("Link", article.PdfUri),
                    new XAttribute("NewspaperID", article.NewspaperId),
                    new XAttribute("Title", article.Title)));
            }

            MainViewModel.Instance.LocalStorage.Save(xDoc);
        }
    }
}
