using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterHunterWorld.DAO
{
    class MonsterInfoHtmlDAO
    {
        private HtmlDocument GetHtmlDoc()
        {            
            return GetHtmlDoc("");
        }

        private HtmlDocument GetHtmlDoc(string code)
        {
            HtmlAgilityPack.HtmlDocument htmlDoc = new HtmlAgilityPack.HtmlDocument();
            HtmlWeb web = new HtmlWeb();
            string url = "http://mhf.inven.co.kr/dataninfo/mhw/monster"+code;
            //htmlDoc = web.Load(url);
            htmlDoc = web.LoadFromBrowser(url);
            return htmlDoc;
        }

        private string GetCodeString(string name)
        {
            HtmlNode root = GetHtmlDoc().DocumentNode;
            HtmlNodeCollection table = root.SelectSingleNode("//body/div/div").FirstChild.NextSibling.NextSibling.NextSibling.FirstChild.NextSibling.FirstChild.NextSibling.FirstChild.NextSibling.NextSibling.NextSibling.FirstChild.NextSibling.FirstChild.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.FirstChild.NextSibling.FirstChild.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.SelectNodes("tr");
            foreach (var item in table)
            {

                if (item.Attributes["data-name"].Value.ToString().Contains(name))
                {
                    return item.SelectSingleNode("td/a").GetAttributeValue("href", "false");
                }
            }
            return "false";
        }

        private void GetCommentString()
        {
            
        }
    }
}
