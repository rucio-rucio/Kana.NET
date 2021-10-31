using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Umayadia.Kana
{
    public class DefaultKanaConverter
    {
        /// <summary>
        /// <see cref="ToHiragana(string)"/>メソッド実行時にカスタムな変換を行う場合に使用します。
        /// <para>
        /// To use this, you can define custome conversion when ToHiragana calling.
        /// </para>
        /// </summary>
        public virtual Action<System.Text.StringBuilder, string, string, string>? MapToHiragana { get; set; }

        /// <summary>
        /// <see cref="ToKatakana(string)"/>メソッド実行時にカスタムな変換を行う場合に使用します。
        /// <para>
        /// To use this, you can define custome conversion when ToKatakana calling.
        /// </para>
        /// </summary>
        public virtual Action<System.Text.StringBuilder, string, string, string>? MapToKatakana { get; set; }

        /// <summary>
        /// 文字列内のひらがなをカタカナに変換します。
        /// nullに対しては空文字を返します。
        /// <para>
        /// <see cref="MapToKatakana"/>に関数が設定されている場合、1文字ごとにその関数も呼び出されます。
        /// </para>
        /// <para>
        /// Convert hiragana to katakana. null to empty.
        /// </para>
        /// </summary>
        /// <param name="source">対象の文字列</param>
        /// <returns>変換結果</returns>
        public virtual string ToKatakana(string? source)
        {
            const int diff = 96; //Distance between CodePoint of Hiragana and CodePoint of Katakana.

            const char u3041 = 'ぁ';
            const char u3096 = 'ゖ';
            const char u309D = 'ゝ';
            const char u309E = 'ゞ';

            if (source == null)
            {
                return "";
            }

            var result = new System.Text.StringBuilder(source.Length);

            //For performance reason, I wrote same if. Imagine that this in one kind of inline expansion.
            if (MapToKatakana == null)
            {
                foreach (char current in source)
                {
                    if ((current >= u3041 && current <= u3096) || current == u309D || current == u309E)
                    {
                        char converted = (char)(current + diff);
                        result.Append(converted);
                    }
                    else
                    {
                        result.Append(current);
                    }
                } //foreach
            }
            else
            {
                foreach (char current in source)
                {
                    if ((current >= u3041 && current <= u3096) || current == u309D || current == u309E)
                    {
                        char converted = (char)(current + diff);
                        MapToKatakana!(result, current.ToString(), converted.ToString(), source);
                    }
                    else
                    {
                        MapToKatakana!(result, current.ToString(), current.ToString(), source);
                    }
                } //foreach

            } //if (MapToKatakana == null)

            return result.ToString();
        } // ToKatakana

        /// <summary>
        /// 文字列内のカタカナをひらがなに変換します。
        /// 変換対象のひらがなが存在しないワ行の濁点付き(ヷ、ヸ、ヹ、ヺ)は変換せずそのまま返します。
        /// nullに対しては空文字を返します。
        /// <para>
        /// <see cref="MapToHiragana"/>に関数が設定されている場合、1文字ごとにその関数も呼び出されます。
        /// </para>
        /// <para>
        /// Convert katakana to hiragana except for ヷ、ヸ、ヹ、ヺ. null to empty.
        /// </para>
        /// </summary>
        /// <param name="source">対象の文字列</param>
        /// <returns>変換結果</returns>
        public virtual string ToHiragana(string? source)
        {
            const int diff = 96; //Distance between CodePoint of Hiragana and CodePoint of Katakana.

            const char u30A1 = 'ァ';
            const char u30F6 = 'ヶ';
            const char u30FD = 'ヽ';
            const char u30FE = 'ヾ';

            if (source == null)
            {
                return "";
            }

            var result = new System.Text.StringBuilder(source.Length);

            //For performance reason, I wrote same if. Imagine that this in one kind of inline expansion.
            if (MapToHiragana == null)
            {
                foreach (char current in source)
                {
                    if ((current >= u30A1 && current <= u30F6) || current == u30FD || current == u30FE)
                    {
                        char converted = (char)(current - diff);
                        result.Append(converted);
                    }
                    else
                    {
                        result.Append(current);
                    }
                } //foreach
            }
            else
            {
                foreach (char current in source)
                {
                    if ((current >= u30A1 && current <= u30F6) || current == u30FD || current == u30FE)
                    {
                        char converted = (char)(current - diff);
                        MapToHiragana(result, current.ToString(), converted.ToString(), source);
                    }
                    else
                    {
                        MapToHiragana(result, current.ToString(), current.ToString(), source);
                    }
                } //foreach

            } //if (MapToHiragana == null)

            return result.ToString();
        } // ToHiragana

    } //class DefaultKanaConverter
}
