using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Umayadia.Kana
{
    public class KanaUtil
    {
        /// <summary>
        /// Shift_JISエンコーディングを返します。
        /// </summary>
        public static System.Text.Encoding ShiftJIS
        {
            get
            {
#if NETCOREAPP 
                System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
#endif

                return System.Text.Encoding.GetEncoding("shift_jis");
            }
        }
    }
}
