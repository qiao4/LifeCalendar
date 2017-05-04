using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeCalendar.Utils {
    public static class StringExtension {
        /// <summary>
        /// 將字符串包裝成數據庫查詢時需要的樣式
        /// 一定程度上防止SQL注入？(我覺得可以達到這個效果)
        /// </summary>
        /// <param name="str">
        /// 需要包裝的字符串
        /// </param>
        /// <returns>包裝後的字符串</returns>
        public static String Quote(this String str) {
            return "'" + str.Replace("'", "''") + "'";
        }
    }
}
