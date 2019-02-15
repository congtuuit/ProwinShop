using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppProwin
{
    public enum ErrorStatus
    {
        DatabaseError,
        Message,
        FirstLoad
    }
    public class ModelBase
    {
        public ModelBase()
        {
            Error = ErrorStatus.FirstLoad;
            Message = "Lỗi xảy ra khi thêm dữ liệu";
        }
        public ErrorStatus Error { set; get; }
        public string Message { set; get; }
        public string GetHTMLMessage()
        {
            string str;
            if (Error == ErrorStatus.FirstLoad)
            {
                return "";
            }
            else if (Error == ErrorStatus.Message)
            {
                str = "bg-success";
            }
            else
            {
                str = "bg-danger";
            }

            return "<p class=\"text-danger\">" + Message + "</p>";
            //return "<div class=\"alert " + str + "\">" +
            //    "<button type=\"button\" class=\"close\"><span>x</span></button>" + Message +
            //    "</div>";
        }
    }
}