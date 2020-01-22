using Blog.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace Blog.Common
{


    public class WebUtil
    {
        /// <summary>
        /// post 请求
        /// </summary>
        /// <param name="url">请求地址</param>
        /// <param name="postData"></param>
        /// <returns></returns>
        public static string PostUrl(string url, string postData)
        {
            string result = "";
            try
            {
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);

                req.Method = "POST";

                req.ContentType = "application/x-www-form-urlencoded";

                req.Timeout = 8000;//请求超时时间

                byte[] data = Encoding.UTF8.GetBytes(postData);

                req.ContentLength = data.Length;

                using (Stream reqStream = req.GetRequestStream())
                {
                    reqStream.Write(data, 0, data.Length);

                    reqStream.Close();
                }

                HttpWebResponse resp = (HttpWebResponse)req.GetResponse();

                Stream stream = resp.GetResponseStream();

                //获取响应内容
                using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                {
                    result = reader.ReadToEnd();
                }
            }
            catch (Exception e)
            { }

            return result;
        }

        /// <summary>
        /// 反序列化
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="path"></param>
        /// <returns></returns>
        public static T DeserializeObject<T>(string path)
        {
            string data = null;
            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                StreamReader sr = new StreamReader(fs);
                data = sr.ReadToEnd();
            };
            if (string.IsNullOrWhiteSpace(data))
            {
                return default(T);
            }
            return JsonConvert.DeserializeObject<T>(data);
        }

        /// <summary>
        /// 提示信息
        /// </summary>
        /// <param name="code">code码</param>
        /// <param name="LanguageCode">语言</param>
        /// <returns></returns>
        public static string GetMsg(string code, string LanguageCode)
        {
            string resCode = code;
            if (ErrorCodeMsg.CodeMsg == null)
            {
                return resCode;
            }
            if (ErrorCodeMsg.CodeMsg.ContainsKey(LanguageCode))
            {
                var language = ErrorCodeMsg.CodeMsg[LanguageCode];
                if (language.Msg.ContainsKey(resCode))
                {
                    return language.Msg[resCode];
                }
                return resCode;
            }
            return resCode;
        }
    }
}
