namespace Umayadia.Kana;

/// <summary>
/// カタカナと平仮名を変換します。
/// MapHiraganaとMapKatakanaを使って独自のマッパーを定義することもできます。
/// <para>
/// Convert Katakana and Hiragana.
/// You can define custome mapper, using MapHiragana and MapKatakana. 
/// </para>
/// </summary>
public class KanaConverter
{
    public static Action<System.Text.StringBuilder, string, string, string>? MapToHiragana { get; set; }
    public static Action<System.Text.StringBuilder, string, string, string>? MapToKatakana { get; set; }

    public static string ToKatakana(string source)
    {
        const int diff = 96; //Distance bitweeb CodePoint of Hiragana and CodePoint of Katakana.

        var result = new System.Text.StringBuilder();

        foreach (char current in source)
        {
            string converted;

            byte[] bytes = System.Text.Encoding.UTF32.GetBytes(current.ToString());
            int codePoint = BitConverter.ToInt32(bytes);

            //Map to katakana if exists.
            if ((codePoint >= 0x3041 && codePoint <= 0x3096) || codePoint == 0x309D || codePoint == 0x309E)
            {
                codePoint = codePoint + diff;
                converted = Char.ConvertFromUtf32(codePoint);
            }
            else
            {
                converted = current.ToString();
            }

            //Invoke custom mapper is exists.
            if (MapToKatakana is null)
            {
                result.Append(converted);
            }
            else
            {
                MapToKatakana!(result, current.ToString(), converted, source);
            }

        } //foreach

        return result.ToString();
    } // ToKatakana

    public static string ToHiragana(string source)
    {
        const int diff = 96; //Distance bitweeb CodePoint of Hiragana and CodePoint of Katakana.

        var result = new System.Text.StringBuilder();

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
    } // ToHiragana
} // class KanaConverter