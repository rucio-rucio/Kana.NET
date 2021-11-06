using System;
using System.Linq;

namespace Umayadia.Kana
{

    /// <summary>
    /// ひらがな と カタカナ を変換します。
    /// MapHiraganaとMapKatakanaを使って独自のマッパーを定義することもできます。
    /// <para>
    /// Convert Hiragana and Katakana.
    /// You can define custome mapper, using MapHiragana and MapKatakana. 
    /// </para>
    /// </summary>
    public class KanaConverter
    {
        private static DefaultKanaConverter? converterValue = null;
        public static DefaultKanaConverter Converter
        {
            get
            {
                if (converterValue == null)
                {
                    converterValue = new DefaultKanaConverter();
                }
                return converterValue;
            }
            set
            {
                converterValue = value;
            }
        }


        /// <summary>
        /// <see cref="ToHiragana(string?)"/>メソッド実行時にカスタムな変換を行う場合に使用します。
        /// <para>
        /// To use this, you can define custome conversion when ToHiragana calling.
        /// </para>
        /// </summary>
        public static Action<System.Text.StringBuilder, string, string, string>? MapToHiragana
        {
            get => Converter.MapToHiragana;
            set => Converter.MapToHiragana = value;
        }

        /// <summary>
        /// <see cref="ToKatakana(string?)"/>メソッド実行時にカスタムな変換を行う場合に使用します。
        /// <para>
        /// To use this, you can define custome conversion when ToKatakana calling.
        /// </para>
        /// </summary>
        public static Action<System.Text.StringBuilder, string, string, string>? MapToKatakana
        {
            get => Converter.MapToKatakana;
            set => Converter.MapToKatakana = value;
        }

        /// <summary>
        /// <see cref="ToWide(string?)"/>メソッド実行時にカスタムな変換を行う場合に使用します。
        /// <para>
        /// To use this, you can define custome conversion when ToWide calling.
        /// </para>
        /// </summary>
        [Obsolete("Experimental(Not obsolete but for compiler warning). Diacritical mark specification may change.")]
        public static Action<System.Text.StringBuilder, string, string, string>? MapToWide
        {
            get => Converter.MapToWide;
            set => Converter.MapToWide = value;
        }

        /// <summary>
        /// <see cref="ToNarrow(string?)"/>メソッド実行時にカスタムな変換を行う場合に使用します。
        /// <para>
        /// To use this, you can define custome conversion when ToNarrow calling.
        /// </para>
        /// </summary>
        public static Action<System.Text.StringBuilder, string, string, string>? MapToNarrow
        {
            get => Converter.MapToNarrow;
            set => Converter.MapToNarrow = value;
        }

        /// <summary>
        /// KanaConverterの状態を初期状態に戻します。
        /// カスタム変換(MapToXxxx)をすべて未設定状態(null)にします。Conveter および StrConverter はデフォルトに戻ります。
        /// </summary>
        public static void ResetToInitialSettings()
        {
            MapToHiragana = null;
            MapToKatakana = null;
            MapToWide = null;
            MapToNarrow = null;

            converterValue = null;
            strConvConverterValue = null;
        }

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
        public static string ToKatakana(string? source)
        {
            return Converter.ToKatakana(source);
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
        public static string ToHiragana(string? source)
        {
            return Converter.ToHiragana(source);
        } // ToHiragana

        public static string ToWide(string? source)
        {
            return Converter.ToWide(source);
        }

        public static string ToNarrow(string? source)
        {
            return Converter.ToNarrow(source);
        }


        private static StrConvConverter? strConvConverterValue = null;
        private static StrConvConverter strConvConverter
        {
            get
            {
                if (strConvConverterValue == null)
                {
                    strConvConverterValue = new StrConvConverter();
                }
                return strConvConverterValue;
            }
            set
            {
                strConvConverterValue = value;
            }
        }

        //Public Function StrConv (str As String, Conversion As VbStrConv, Optional LocaleID As Integer = 0) As String

        /// <summary>
        /// StrConv full compatible. Convert to Hiragana and Katakana. 
        /// Generally use <seealso cref="ToHiragana(string)"/> or <seealso cref="ToKatakana(string)"/> insted of StrConv.
        /// This StrConv is only for compatibility.
        /// <para>
        /// StrConvと完全に互換性があるカタカナ・ひらがな変換を行います。
        /// 通常は、StrConvではなく<seealso cref="ToHiragana(string)"/> または <seealso cref="ToKatakana(string)"/> を使用してください。
        /// StrConvとの互換性が必要な時のみこのStrConvを使用してください。
        /// </para>
        /// </summary>
        /// <param name="str">変換される文字列</param>
        /// <param name="Conversion">変換の方法。ひらがなに変換するかカタカナに変換するか指定します。</param>
        /// <returns>変換結果の文字列を返します。</returns>
        /// <exception cref="ArgumentException"></exception>
        public static string StrConv(string? str, umaStrConv Conversion)
        {
            if (strConvConverter == null)
            {
                strConvConverter = new StrConvConverter();
            }

            return Conversion switch
            {
                umaStrConv.Hiragana => strConvConverter.ToHiragana(str),
                umaStrConv.Katakana => strConvConverter.ToKatakana(str),
                _ => throw new ArgumentException()
            };

        }

        /// <summary>
        /// StrConv full compatible. Convert to Hiragana and Katakana. 
        /// Generally use <seealso cref="ToHiragana(string)"/> or <seealso cref="ToKatakana(string)"/> insted of StrConv.
        /// This StrConv is only for compatibility.
        /// <para>
        /// StrConvと完全に互換性があるカタカナ・ひらがな変換を行います。
        /// 通常は、StrConvではなく<seealso cref="ToHiragana(string)"/> または <seealso cref="ToKatakana(string)"/> を使用してください。
        /// StrConvとの互換性が必要な時のみこのStrConvを使用してください。
        /// </para>
        /// </summary>
        /// <param name="str">変換される文字列</param>
        /// <param name="Conversion">変換の方法。
        /// ひらがなに変換する場合、32 または vbHiragana または VbStrConv.Hiragana または umaStrConv.Hiragana を指定します。
        /// <para>
        /// カタカナに変換する場合、16 または vbKatakana または VbStrConv.Katakana または umaStrConv.Katakana を指定します。
        /// </para>
        /// <para>
        /// これ以外を指定するとArgumentExceptionになります。
        /// </para>
        /// </param>
        /// <returns>変換結果の文字列を返します。</returns>
        /// <exception cref="ArgumentException"></exception>
        public static string StrConv(string? str, int Conversion)
        {
            if (!Enum.IsDefined(typeof(umaStrConv), Conversion))
            {
                throw new ArgumentException("The value of 'Conversion' is not in umaStrConv enum.");
            }
            return StrConv(str, (umaStrConv)Conversion);
        }

    } // class KanaConverter

} //namespace