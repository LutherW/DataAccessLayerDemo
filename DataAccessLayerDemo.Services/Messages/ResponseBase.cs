using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayerDemo.Services.Messages
{
    public abstract class ResponseBase
    {
        /// <summary>
        /// 请求是否成功，而没有出现错误
        /// </summary>
        public bool Success { get; set; }
        /// <summary>
        /// 如果请求中发生任何错误，包含该错误的详细信息（而不是异常信息）
        /// 如果请求成功可以为空或包含一个确认消息
        /// </summary>
        public string Message { get; set; }
    }
}
