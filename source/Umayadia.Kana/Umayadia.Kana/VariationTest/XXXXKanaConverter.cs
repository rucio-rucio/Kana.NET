//Performance improvement test variations.
//V2 is the fastest.

#if false

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Umayadia.Kana
{
    public class XXXXKanaConverter
    {
        public static Action<System.Text.StringBuilder, string, string, string>? MapToHiragana { get; set; }

        public static string ToHiraganaV4(string? source)
        {
            const int diff = 96; //Distance between CodePoint of Hiragana and CodePoint of Katakana.

            const char cp30A1 = 'ァ';
            const char cp30F6 = 'ヶ';
            const char cp30FD = 'ヽ';
            const char cp30FE = 'ヾ';

            if (source == null)
            {
                return "";
            }


            if (MapToHiragana == null)
            {
                string result = new string(source.Select((current) =>
                {
                    if ((current >= cp30A1 && current <= cp30F6) || current == cp30FD || current == cp30FE)
                    {
                        return (char)(current - diff);
                    }
                    else
                    {
                        return current;
                    }
                }).ToArray());
                return result;
            }
            else
            {
                var result = new System.Text.StringBuilder(source.Length);

                foreach (char current in source)
                {
                    char converted;

                    //Map to hiragana if exists.
                    if ((current >= cp30A1 && current <= cp30F6) || current == cp30FD || current == cp30FE)
                    {
                        converted = (char)(current - diff);
                    }
                    else
                    {
                        converted = current;
                    }

                    MapToHiragana(result, current.ToString(), converted.ToString(), source);


                } //foreach


                return result.ToString();
            }
        } // ToHiraganaV4

        public static string ToHiraganaV3(string? source)
        {
            const int diff = 96; //Distance between CodePoint of Hiragana and CodePoint of Katakana.

            const char cp30A1 = 'ァ';
            const char cp30F6 = 'ヶ';
            const char cp30FD = 'ヽ';
            const char cp30FE = 'ヾ';

            if (source == null)
            {
                return "";
            }

            var result = new System.Text.StringBuilder(source.Length);

            foreach (char current in source)
            {
                char converted;

                //Map to hiragana if exists.
                if ((current >= cp30A1 && current <= cp30F6) || current == cp30FD || current == cp30FE)
                {
                    converted = (char)(current - diff);
                }
                else
                {
                    converted = current;
                }

                //Invoke custom mapper is exists.
                if (MapToHiragana == null)
                {
                    result.Append(converted);
                }
                else
                {
                    MapToHiragana(result, current.ToString(), converted.ToString(), source);
                }

            } //foreach

            return result.ToString();
        } // ToHiraganaV3


        public static string ToHiraganaV2(string? source)
        {
            const int diff = 96; //Distance between CodePoint of Hiragana and CodePoint of Katakana.

            const char cp30A1 = 'ァ';
            const char cp30F6 = 'ヶ';
            const char cp30FD = 'ヽ';
            const char cp30FE = 'ヾ';

            if (source == null)
            {
                return "";
            }

            var result = new System.Text.StringBuilder(source.Length);

            if (MapToHiragana == null)
            {
                foreach (char current in source)
                {
                    if ((current >= cp30A1 && current <= cp30F6) || current == cp30FD || current == cp30FE)
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
                    if ((current >= cp30A1 && current <= cp30F6) || current == cp30FD || current == cp30FE)
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
        } // ToHiraganaV2

        public static string ToHiraganaV1(string? source)
        {
            const int diff = 96; //Distance bitweeb CodePoint of Hiragana and CodePoint of Katakana.

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

                //Map to hiragana if exists.
                if ((codePoint >= 0x30A1 && codePoint <= 0x30F6) || codePoint == 0x30FD || codePoint == 0x30FE)
                {
                    codePoint = codePoint - diff;
                    converted = Char.ConvertFromUtf32(codePoint);
                }
                else
                {
                    converted = current.ToString();
                }

                //Invoke custom mapper is exists.
                if (MapToHiragana is null)
                {
                    result.Append(converted);
                }
                else
                {
                    MapToHiragana(result, current.ToString(), converted, source);
                }

            } //foreach

            return result.ToString();
        } // ToHiraganaV1
    }
}

#endif