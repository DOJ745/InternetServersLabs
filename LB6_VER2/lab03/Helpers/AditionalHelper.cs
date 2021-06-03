using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace lab03.Helpers
{
    public static class CustomHelpers
    {
        public static MvcHtmlString AditionalHelp(this HtmlHelper html)
        {
            TagBuilder tag = new TagBuilder("form");
            tag.GenerateId("some");
            tag.Attributes.Add("action", "/dict/addsave");
            tag.Attributes.Add("method", "post");

            TagBuilder itemTag = new TagBuilder("input");
            itemTag.Attributes.Add("type", "text");
            itemTag.Attributes.Add("name", "surname");
            itemTag.Attributes.Add("placeholder", "surname");

            TagBuilder itemTag1 = new TagBuilder("input");
            itemTag1.Attributes.Add("type", "number");
            itemTag1.Attributes.Add("name", "telephone");
            itemTag1.Attributes.Add("placeholder", "telephone");

            TagBuilder itemTag2 = new TagBuilder("input");
            itemTag2.Attributes.Add("type", "submit");

            return new MvcHtmlString(tag.ToString());
        }
    }
}