using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace WebAppProwin.Helpers
{
    public class Helper
    {
        public static string CalculateMD5Hash(string input)

        {

            // step 1, calculate MD5 hash from input

            MD5 md5 = System.Security.Cryptography.MD5.Create();

            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);

            byte[] hash = md5.ComputeHash(inputBytes);

            // step 2, convert byte array to hex string

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < hash.Length; i++)

            {

                sb.Append(hash[i].ToString("X2"));

            }

            return sb.ToString();

        }

        public static string PrintMenuAdmin(string name)
        {
            string menu = "";
            JObject obj = JObject.Parse(File.ReadAllText(HttpContext.Current.Server.MapPath("/Helpers/MenuAdmin.json")));
            var Nodes = obj["Nodes"];
            for (int i = 0; i < Nodes.Count(); i++)
            {
                string strActive = "";
                if (Nodes[i]["Name"].ToString() == name)
                {
                    strActive = "active";
                }
                string menuChild = "";
                if (Nodes[i]["Child"].Count() > 0)
                {


                    var Childs = Nodes[i]["Child"];
                    for (int j = 0; j < Childs.Count(); j++)
                    {
                        string strChildActive = "";
                        if (Childs[j]["Name"].ToString() == name)
                        {
                            strChildActive = "active";
                            strActive = strChildActive;

                        }
                        else
                        {
                            strChildActive = "";
                        }
                        menuChild += "<li class=\"" + strActive + "\"><a href=\"" + Childs[j]["url"] + "\" class=\"waves-effect waves-block " + ((strChildActive != "") ? "toggled active" : "") + "\">";
                        menuChild += Childs[j]["Name"];
                        menuChild += "</li></a>";
                    }
                    menuChild = "<ul class=\"ml-menu\" style=\"" + ((strActive == "") ? "display:none" : "display:block") + "\">" + menuChild;

                    menuChild += "</ul>";
                }
                menu += "<li class=\"" + strActive + "\">";
                menu += "<a href=\"" + ((Nodes[i]["url"].ToString() == "") ? "javascript:void(0)" : Nodes[i]["url"].ToString()) + "\" class=\"" + ((menuChild != "") ? "menu-toggle" : "") + " " + ((strActive != "") ? "toggled" : "") + " waves-effect waves-block\">";
                menu += "<i class=\"material-icons\">" + Nodes[i]["Icon"] + "</i>";
                menu += "<span>" + Nodes[i]["Name"] + "</span>";
                menu += "</a>";
                menu += menuChild;
                menu += "</li>";
            }
            return menu;
        }
        public static string ConvertVN(string chucodau)
        {
            const string FindText = "áàảãạâấầẩẫậăắằẳẵặđéèẻẽẹêếềểễệíìỉĩịóòỏõọôốồổỗộơớờởỡợúùủũụưứừửữựýỳỷỹỵÁÀẢÃẠÂẤẦẨẪẬĂẮẰẲẴẶĐÉÈẺẼẸÊẾỀỂỄỆÍÌỈĨỊÓÒỎÕỌÔỐỒỔỖỘƠỚỜỞỠỢÚÙỦŨỤƯỨỪỬỮỰÝỲỶỸỴ";
            const string ReplText = "aaaaaaaaaaaaaaaaadeeeeeeeeeeeiiiiiooooooooooooooooouuuuuuuuuuuyyyyyAAAAAAAAAAAAAAAAADEEEEEEEEEEEIIIIIOOOOOOOOOOOOOOOOOUUUUUUUUUUUYYYYY";
            int index = -1;
            char[] arrChar = FindText.ToCharArray();
            while ((index = chucodau.IndexOfAny(arrChar)) != -1)
            {
                int index2 = FindText.IndexOf(chucodau[index]);
                chucodau = chucodau.Replace(chucodau[index], ReplText[index2]);
            }
            return chucodau;
        }
        private static CultureInfo CultureVN = CultureInfo.GetCultureInfo("vi-VN");
        public static string GetCurrencyVND(double d)
        {
            if ((d == 0))
            {
                return "0đ";
            }
            return d.ToString("#,###", CultureVN.NumberFormat) + "đ";
        }

        //public static string KichThuocToJson(List<KichThuoc> a)
        //{
        //    string res = "[";
        //    foreach (var item in a)
        //    {
        //        res += "{";
        //        res += "\"MaKT\":\"" + item.MaKT + "\",\"Ten\":\"" + item.KichThuoc1 + "\"},";
        //    }
        //    res = res.Remove(res.Length - 1);
        //    res += "]";
        //    return res;
        //}
    }
}