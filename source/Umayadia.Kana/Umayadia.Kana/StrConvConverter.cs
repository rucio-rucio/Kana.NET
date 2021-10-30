using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Umayadia.Kana
{
    /// <summary>
    /// このクラスは直接使用するよりも<see cref="KanaConverter.StrConv(string, umaStrConv)"/>を利用する方が便利です。
    /// <para>
    /// It's better to use <see cref="KanaConverter.StrConv(string, umaStrConv)"/>.
    /// </para>
    /// </summary>
    public partial class StrConvConverter
    {
        public virtual string ToHiragana(string? source)
        {
            return ConvertAsMap(source, this.HiraganaSource);
        }

        public virtual string ToKatakana(string? source)
        {
            return ConvertAsMap(source, this.KatakanaSource);
        }


        protected virtual string ConvertAsMap(string? source, string map)
        {
            if (source == null)
            {
                return "";
            }

            var result = new System.Text.StringBuilder(source.Length);

            foreach (char current in source)
            {
                string converted;

                byte[] bytes = System.Text.Encoding.UTF32.GetBytes(current.ToString());
                int codePoint = BitConverter.ToInt32(bytes);

                if (codePoint <= 0x1f)
                {
                    converted = Char.ConvertFromUtf32(codePoint);
                }
                else if (codePoint >= 0x10000)
                {
                    converted = "?";
                }
                else
                {
                    converted = map[codePoint].ToString();
                }

                result.Append(converted);

            } //foreach

            return result.ToString();
        }

    }
}
