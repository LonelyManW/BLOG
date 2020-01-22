using Snowflake.Core;

namespace Blog.Common
{
    /// <summary>
    /// 雪花ID（全局唯一ID）
    /// </summary>
    public class Snowflake
    {
        private static readonly IdWorker idWorker = new IdWorker(1, 1);
        private static readonly object lockObj = new object();

        /// <summary>
        /// 获取long类型唯一ID
        /// </summary>
        /// <returns></returns>
        public static long NextId()
        {
            lock (lockObj)
            {
                return idWorker.NextId();
            }
        }

        /// <summary>
        /// 获取字符串类型唯一ID
        /// </summary>
        /// <returns></returns>
        public static string NextStringId()
        {
            return NextId().ToString();
        }
    }
}
