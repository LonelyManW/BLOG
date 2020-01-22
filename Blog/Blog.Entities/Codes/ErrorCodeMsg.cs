using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Entities
{
    public class ErrorCodeMsg
    {
        public static Dictionary<string, CodeMessage> CodeMsg { get; set; }
    }

    public class CodeMessage
    {
        public string Language { get; set; }

        public Dictionary<string, string> Msg { get; set; }
    }
}
