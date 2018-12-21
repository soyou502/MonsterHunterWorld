﻿using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterHunterWorld.DAO
{
    class MonsterInfoHtmlDAO
    {
        private HtmlDocument GetHtmlDoc()
        {
            HtmlAgilityPack.HtmlDocument htmlDoc = new HtmlAgilityPack.HtmlDocument();
            HtmlWeb web = new HtmlWeb();
            string url = "http://mhf.inven.co.kr/dataninfo/mhw/monster";
            htmlDoc = web.Load(url);
            return htmlDoc;
        }
        private HtmlDocument GetHtmlDoc(string name)
        {
            HtmlAgilityPack.HtmlDocument htmlDoc = new HtmlAgilityPack.HtmlDocument();
            HtmlWeb web = new HtmlWeb();
            string url = "http://mhf.inven.co.kr/dataninfo/mhw/monster" + GetCodeString(name);
            htmlDoc = web.LoadFromBrowser(url);
            return htmlDoc;
        }

        /// <summary>
        /// 몬스터 상세정보 code값 찾는 메서드
        /// </summary>
        /// <param name="name">몬스터 닉+이름</param>
        /// <returns>코드 String</returns>
        private string GetCodeString(string name)
        {
            HtmlNode root = GetHtmlDoc().DocumentNode;
            HtmlNodeCollection table = root.SelectSingleNode("//body/div/div").FirstChild.NextSibling.NextSibling.NextSibling.FirstChild.NextSibling.FirstChild.NextSibling.FirstChild.NextSibling.NextSibling.NextSibling.FirstChild.NextSibling.FirstChild.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.FirstChild.NextSibling.FirstChild.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.SelectNodes("tr");
            foreach (var item in table)
            {
                if (item.Attributes["data-name"].Value.ToString().Contains(name))
                {
                    return item.SelectSingleNode("td/a").GetAttributeValue("href", String.Empty);
                }
            }
            return String.Empty;
        }

        /// <summary>
        /// 코멘트 테이블을 반환하는 메서드
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public DataTable GetCommentTable(string name)
        {
            HtmlNode root = GetHtmlDoc(name).DocumentNode;
            HtmlNodeCollection table = root.SelectSingleNode("//body/div/div").FirstChild.NextSibling.NextSibling.NextSibling.FirstChild.NextSibling.FirstChild.NextSibling.FirstChild.NextSibling.NextSibling.NextSibling.FirstChild.NextSibling.FirstChild.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.SelectNodes("div")[1].FirstChild.NextSibling.NextSibling.NextSibling.FirstChild.NextSibling.NextSibling.NextSibling.NextSibling.FirstChild.NextSibling.NextSibling.NextSibling.SelectNodes("tr");
            DataTable dt = new DataTable();
            dt.Columns.Add("NickName");
            dt.Columns.Add("Comment");
            dt.Columns.Add("Date");

            foreach (var item in table)
            {
                if (item.Attributes["class"].Value != "form")
                {
                    string nickName = String.Empty;
                    string comment = String.Empty;
                    string date = String.Empty;
                    if (item.Attributes["class"].Value != "item")
                    {
                        nickName = "└>   ";
                    }
                    HtmlNode ht = item.SelectSingleNode("td");
                    //ht.SelectSingleNode("span/span").FirstChild.Attributes["class"]
                    if (ht.SelectSingleNode("span/span").FirstChild.Attributes["class"] != null)
                    {
                        continue;
                    }
                    // 아이디 뽑기
                    nickName += ht.SelectSingleNode("span/span/a/span").InnerText;
                    // 코멘트 뽑기
                    comment += ht.NextSibling.SelectSingleNode("span/span").InnerText;
                    // 날짜 뽑기
                    date = ht.NextSibling.NextSibling.SelectSingleNode("span/span").InnerText;

                    DataRow row = dt.NewRow();
                    row["NickName"] = nickName;
                    row["Comment"] = comment;
                    row["Date"] = date;
                    dt.Rows.Add(row);
                }
            }

            return dt;
        }
    }
}
