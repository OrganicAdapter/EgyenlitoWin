using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgyenlitoPortableLIB.Models.DataManagers
{
    public class SampleDatas
    {
        public static List<Newspaper> Newspapers = new List<Newspaper>() 
        {
            new Newspaper(){NewspaperId = 00, Title = "Mi szebb a békénél?", Pages= 45, ReleaseDate = "2013. április", UploadDate = "2013.04.01.", CoverUri= "http://ujegyenlito.hu/wp-content/uploads/2013/10/elso-187x300.jpg"},
            new Newspaper(){NewspaperId = 01, Title = "Megtaláljuk a vékonyka józan kivezető utat", Pages = 50, ReleaseDate = "2013. augusztus", UploadDate = "2013.08.01.", CoverUri = "http://ujegyenlito.hu/wp-content/uploads/2013/10/17-189x300.jpg"},
            new Newspaper(){NewspaperId = 02, Title = "Az autonómia nem ajándék. Jog.", Pages = 48, ReleaseDate = "2013. november", UploadDate = "2013.11.01.", CoverUri = "http://ujegyenlito.hu/wp-content/uploads/2013/11/novemberi-sz%C3%A1m-bor%C3%ADt%C3%B3-honlapra.jpg"}
        };

        public static List<Article> Articles = new List<Article>()
        {
            new Article(){NewspaperId = 00, ArticleId = 00, Title = "Az önmagához hű Obama", Author = "Avar János", PdfUri = "http://ujegyenlito.hu/wp-content/uploads/2013/10/Az-%C3%B6nmag%C3%A1hoz-h%C5%B1-Obama.pdf"},
            new Article(){NewspaperId = 00, ArticleId = 01, Title = "A francia Tea Party születése", Author = "Balázs Gábor", PdfUri = "http://ujegyenlito.hu/wp-content/uploads/2013/10/A-francia-Tea-Party-sz%C3%BClet%C3%A9se.pdf"},
            new Article(){NewspaperId = 01, ArticleId = 02, Title = "Látlelet a magyarországi szegénységről", Author = "Totyik Tamás", PdfUri = "http://ujegyenlito.hu/wp-content/uploads/2014/04/totyik.pdf"},
            new Article(){NewspaperId = 02, ArticleId = 03, Title = "Az 53 kilométeres közösségi idegsejt", Author = "Bíró Béla", PdfUri = "http://ujegyenlito.hu/wp-content/uploads/2014/04/sz%C3%A9kely.pdf"}
        };
    }
}
