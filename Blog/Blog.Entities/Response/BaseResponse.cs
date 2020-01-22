using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Entities
{
    public class BaseResponse
    {
        /// <summary>
        /// 状态码
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }
        /// <summary>
        /// 提示码
        /// </summary>
        [JsonProperty(PropertyName = "code")]
        public string Code { get; set; }
        /// <summary>
        /// 提示信息
        /// </summary>
        [JsonProperty(PropertyName = "msg")]
        public string Msg { get; set; }
    }


    public class DataResponse<T> : BaseResponse
    {
        [JsonProperty(PropertyName = "data")]
        public T Data;
    }

    public class ListDataResponse<T> : BaseResponse
    {
        [JsonProperty(PropertyName = "data")]
        public List<T> Data;
    }
}
