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
        /// <see cref="ToHiragana(string?)"/>メソッド実行時にカスタムな変換を行う場合に使用します。
        /// <para>
        /// To use this, you can define custome conversion when ToHiragana calling.
        /// </para>
        /// </summary>
        public virtual Action<System.Text.StringBuilder, string, string, string>? MapToHiragana { get; set; }

        /// <summary>
        /// <see cref="ToKatakana(string?)"/>メソッド実行時にカスタムな変換を行う場合に使用します。
        /// <para>
        /// To use this, you can define custome conversion when ToKatakana calling.
        /// </para>
        /// </summary>
        public virtual Action<System.Text.StringBuilder, string, string, string>? MapToKatakana { get; set; }

        /// <summary>
        /// <see cref="ToWide(string?)"/>メソッド実行時にカスタムな変換を行う場合に使用します。
        /// <para>
        /// To use this, you can define custome conversion when ToWide calling.
        /// </para>
        /// </summary>
        [Obsolete("Experimental(Not obsolete but for compiler warning). Diacritical mark specification may change.")]
        public virtual Action<System.Text.StringBuilder, string, string, string>? MapToWide { get; set; }

        /// <summary>
        /// <see cref="ToNarrow(string?)"/>メソッド実行時にカスタムな変換を行う場合に使用します。
        /// <para>
        /// To use this, you can define custome conversion when ToNarrow calling.
        /// </para>
        /// </summary>
        public virtual Action<System.Text.StringBuilder, string, string, string>? MapToNarrow { get; set; }

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


        /// <summary>
        /// 文字列内の半角文字を全角に変換します。
        /// <para>
        /// Convert half width characters to wide.
        /// </para>
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public virtual string ToWide(string? source)
        {
            if (source == null)
            {
                return "";
            }

            var result = new System.Text.StringBuilder(source.Length);

            for(int i = 0; i < source.Length; i++)
            {
                char current = source[i];
                char? next;
               
                if (i == source.Length - 1)
                {
                    next = null;
                }
                else
                {
                    next = source[i + 1];
                }

                
                char converted = this.BasicLatinToWide(current);

                //if next charcter is diacritical mark "ﾞ"(U+FF9E) or "ﾟ" (U+FF9F)
                //It's need to combinate.

                if (next == '\uFF9E' || next == '\uFF9F')
                {
                    //これに意味があるのは　converted が ｶ・ｻなどの半角カタカナの場合だが、
                    //ひとまずその判定はせず全部渡してしまう。結果が変わるわけではないので。

                    //variable 'combination' is "ｱﾞ", "ｶﾞ", "ｽﾞ", "ﾊﾟ", and so on.
                    string combination = new string(new char[] { converted, next.Value });

                    string kanaConverted = this.CombinationHalfWidthKatakanaToWide(combination);

                    //"ｱﾞ"のような対応する全角文字がない場合以外は"ｶﾞ"→"ガ"のように変換前後で文字が変わっている。
                    if (kanaConverted != combination)
                    {
                        i++;    //次の文字の分も含めて変換が済んだことになるので、カウンター変数をインクリメントする。

                        if (MapToWide == null)
                        {
                            result.Append(kanaConverted);
                        }
                        else
                        {
                            MapToWide(result, combination, kanaConverted, source);
                        }

                        continue; //そして、後続の変換は不要
                    }

                    //// "ｱﾞ"の場合でもカスタムマップが定義されていれば呼び出す。
                    //if (MapToWide != null)
                    //{
                    //    MapToWide(result, combination, "", source);
                    //    //カスタムマップ側でハンドルされた場合とされなかった場合の区別がつかない…。
                    //    //それに、ｱﾞ は ｱとﾞでそれぞれ別にカスタムマップするチャンスがあるのに、
                    //    //ｶﾞ は ｶﾞ としてカスタムマップするチャンスしかない。
                    //    //このあたり、仕様をしっかり考えたほうが良いように思う。
                    //}

                }

                converted = this.SingleHalfWidthKatakanaToWide(converted.ToString());
                

                converted = this.SpecialSymbolToWide(converted);

                if (MapToWide == null)
                {
                    result.Append(converted);
                }
                else
                {
                    MapToWide(result, current.ToString(), converted.ToString(), source);
                }


            } //for 

            return result.ToString();
        }

        /// <summary>
        /// U+0000からU+007Fの範囲で全角化できるものを全角にします。
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public virtual char BasicLatinToWide(char value)
        {
            //TODO:半角 \ マークは注意して確認せよ。FFE1 と 005C

            //U+005C は日本・韓国・ドイツ・フランスなどで各種通貨記号と混同される。
            //https://en.wikipedia.org/wiki/Backslash#Confusion_with_%C2%A5_and_other_characters

            //ヨーロッパのラテン文字系はU+0400付近にも定義されているが全角というわけではない？

            //22: ”(201D) ＂(FF02) 'キーボードから全角 " を入力すると U+201D
            //27: ’(2019) ＇(FF07) '同様に U+2019
                        
            char result = value switch
            {
                '\u005C' => '￥', //これをどう全角にするか悩みどころ。この機能を必要なのは日本語の処理がほとんどだと思うので"￥"とする。次点"＼"
                '"' => '”',         //U+0022 to 全角 " 。普通に日本語入力すると U+FF02 ではなく U+201D になる。U+FF02 も "FULLWIDTH QUOTATION MARK" と定義されているが、日本語環境で期待しているものではない。
                '\u0027' => '’',    //U+0027 to 全角 ' 。同様に U+2019。U+FF07にはしない。
                '\u0020' => '\u3000', // 半角スペース

                //It's need C# 9.0
                //>= '\u0021' and <= '\u007E' => (char)(value + '\uFF01' - '\u0021'),//主に半角記号・半角アルファベット
                _ => value
            };

            //この範囲でも 5C などは上記で先にヒットするので除外されるという体
            if (result >= '\u0021' && result <= '\u007E')
            {
                //mainly standard symbols and alphabet characters.
                result = (char)(value + '\uFF01' - '\u0021');
            }


            return result;
        } //BasicLatinToWide

       
        /// <summary>
        /// あまり一般的ではない記号の全角変換を行います。
        /// "¢"、"£"、"⸨" などです。U+00A5 の円マークも対象ですが、この円マークは通常使用される U+005C の円マークではありません。
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public virtual char SpecialSymbolToWide(char value)
        {
            char result = value switch
            {
                //▼Latin Supplement U+0080 to U+00FF (https://unicode.org/charts/PDF/U0080.pdf)
                //In this region, it's possible to convert more aggresive, for exambple "²" to "２", "©" to "ｃ"...
                //But I don't because its corrput character meanings. the "©" is not same meaning of "ｃ".
                //So, I choiced these three conversions only from this region.
                '¢' => '￠', //U+00A2 to U+FFE0
                '£' => '￡', //U+00A3 to U+FFE1
                '\u00A5' => '￥', //U+00A5 to . U+00A5 is just currency Yen mark. It's not same as U+005C (backslash).

                //▼Supplemental Puctuation (https://unicode.org/charts/PDF/U2E00.pdf)
                //These two characters as in fullwidth forms (U+FF5F, U+FF60)
                //And in unicode chart, there halfwidth forms are U+2E28 and U+2E29
                //so, I define these half width to fullwidth conversion.
                '⸨' => '｟', // U+2E28 to U+FF5F
                '⸩' => '｠', // U+2E29 to U+FF60
                _ => value
            };

            return result;
        } //SpecialSymbolToWide

        /// <summary>
        /// 半角カタカナを全角カタカナにします。
        /// "｢", "｣", "､", "｡", "･" も全角に変換します。
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public virtual string CombinationHalfWidthKatakanaToWide(string value)
        {
            //▼When with diacritical mark, then two characters convert to one character.

            string result = value switch
            {
                "ｶﾞ" => "ガ",
                "ｷﾞ" => "ギ",
                "ｸﾞ" => "グ",
                "ｹﾞ" => "ゲ",
                "ｺﾞ" => "ゴ",
                "ｻﾞ" => "ザ",
                "ｼﾞ" => "ジ",
                "ｽﾞ" => "ズ",
                "ｾﾞ" => "ゼ",
                "ｿﾞ" => "ゾ",
                "ﾀﾞ" => "ダ",
                "ﾁﾞ" => "ヂ",
                "ﾂﾞ" => "ヅ",
                "ﾃﾞ" => "デ",
                "ﾄﾞ" => "ド",
                "ﾊﾞ" => "バ",
                "ﾊﾟ" => "パ",
                "ﾋﾞ" => "ビ",
                "ﾋﾟ" => "ピ",
                "ﾌﾞ" => "ブ",
                "ﾌﾟ" => "プ",
                "ﾍﾞ" => "ベ",
                "ﾍﾟ" => "ペ",
                "ﾎﾞ" => "ボ",
                "ﾎﾟ" => "ポ",
                "ｳﾞ" => "ヴ",
                "ﾜﾞ" => "ヷ",
                "ｦﾞ" => "ヺ",
                _ => value
            };

            return result;

        } //CombinationHalfWidthKatakanaToWide

    public virtual char SingleHalfWidthKatakanaToWide(string value)
        {
            //U+FF61 to U+FF9F
            string result = value switch
            {
                "ｦ" => "ヲ",
                "｢" => "「",
                "｣" => "」",
                "､" => "、",
                "･" => "・",
                "｡" => "。",
                "ｧ" => "ァ",
                "ｨ" => "ィ",
                "ｩ" => "ゥ",
                "ｪ" => "ェ",
                "ｫ" => "ォ",
                "ｬ" => "ャ",
                "ｭ" => "ュ",
                "ｮ" => "ョ",
                "ｯ" => "ッ",
                "ｰ" => "ー",
                "ｱ" => "ア",
                "ｲ" => "イ",
                "ｳ" => "ウ",
                "ｴ" => "エ",
                "ｵ" => "オ",
                "ｶ" => "カ",
                "ｷ" => "キ",
                "ｸ" => "ク",
                "ｹ" => "ケ",
                "ｺ" => "コ",
                "ｻ" => "サ",
                "ｼ" => "シ",
                "ｽ" => "ス",
                "ｾ" => "セ",
                "ｿ" => "ソ",
                "ﾀ" => "タ",
                "ﾁ" => "チ",
                "ﾂ" => "ツ",
                "ﾃ" => "テ",
                "ﾄ" => "ト",
                "ﾅ" => "ナ",
                "ﾆ" => "ニ",
                "ﾇ" => "ヌ",
                "ﾈ" => "ネ",
                "ﾉ" => "ノ",
                "ﾊ" => "ハ",
                "ﾋ" => "ヒ",
                "ﾌ" => "フ",
                "ﾍ" => "ヘ",
                "ﾎ" => "ホ",
                "ﾏ" => "マ",
                "ﾐ" => "ミ",
                "ﾑ" => "ム",
                "ﾒ" => "メ",
                "ﾓ" => "モ",
                "ﾔ" => "ヤ",
                "ﾕ" => "ユ",
                "ﾖ" => "ヨ",
                "ﾗ" => "ラ",
                "ﾘ" => "リ",
                "ﾙ" => "ル",
                "ﾚ" => "レ",
                "ﾛ" => "ロ",
                "ﾜ" => "ワ",
                "ﾝ" => "ン",
                "ﾞ" => "゛",
                "ﾟ" => "゜",
                _ => value
            };

            return result[0];

        } //SingleHalfWidthKatakanaToWide

        public virtual string ToNarrow(string? source)
        {
            if (source == null)
            {
                return "";
            }

            var result = new System.Text.StringBuilder(source.Length);

            foreach (char current in source)
            {
               
                char latinConverted = this.BasicLatinToNarrow(current);
                char[] kanaConverted = this.WideWidthKatakanaToNarrow(latinConverted);

                string converted; // = current;

                //ここで２文字以上返ってきたら半角カタカナ(の濁音・半濁音)に変換したということなので
                //これ以上変換処理を続ける必要がない。
                if (kanaConverted.Length > 1)
                {
                    converted = new string(kanaConverted);
                }
                else
                {
                    //１文字の場合でも「ｱ」などの半角カタカナに変換されていて、これ以上変換処理を続ける必要が
                    //ないかもしれないが、それを確認するより変換処理を呼んだ方が早いようにも思うので続行する。
                    converted = SpecialSymbolToNarrow(kanaConverted[0]).ToString();
                }

                if (MapToNarrow == null)
                { 
                    result.Append(converted);
                }
                else
                {
                    MapToNarrow(result, current.ToString(), converted, source);
                }

            } //foreach

            return result.ToString();
        } //ToNarrow

        /// <summary>
        /// U+0000からU+007Fの範囲に半角化できるものを半角にします。
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public virtual char BasicLatinToNarrow(char value)
        {
            /*
            
            It's very difficult to choice what to convert to narrow.
            I decided not to intervene too much.
            U+2018 and U+2019 are sinple single quotation, so I decided to convert.
            U+201C, U+201D are too.
            Others have are a bit more extra meaning I think. so not to convert.
            U+FF02 and U+FF07 are handled latter half to convert.

            I'd like to point that you who read this comment can inherits this class to impement as you like. 

            General Punctuation
            https://unicode.org/charts/PDF/U2000.pdf
            U+2018 ‘	LEFT SINGLE QUOTATION MARK
            U+2019	’	RIGHT SINGLE QUOTATION MARK
            U+201A	‚	SINGLE LOW-9 QUOTATION MARK (used as opning single quoation mark in some languages)
            U+201B	‛	SINGLE HIGH-REVERSED-9 QUOATION MARK 
            U+201C	“	LEFT DOUBLE QUOTATION MARK
            U+201D	”	RIGHT DOUBLE QUOTATION MARK
            U+201E	„	DOUBLE LOW-9 QUOTATION MARK
            U+201F	‟	DOUBLE HIGH-REVERSED-9 QUOTATION MARK

            Halwidth and Fullwidth Forms
            https://unicode.org/charts/PDF/UFF00.pdf
            U+FF02	＂	FULLWIDTH QUOATION MARK
            U+FF07	＇	FULLWIDTH APOSTROPH
            */

            char result = value switch
            {
                '￥' => '\u005C', //U+FFE5 to U+005C。very difficult. But for Japanese use.
                
                '\u3000' => '\u0020', // 半角スペース

                '‘' => '\u0027', //U+2018 to U+0027
                '’' => '\u0027', //U+2019 to U+0027

                '“' => '\u0022', //U+201C to U+0022
                '”' => '"',      //U+201D to U+0022。普通に日本語入力すると U+FF02 ではなく U+201D になる。U+FF02 も "FULLWIDTH QUOTATION MARK" と定義されているが、日本語環境で期待しているものではない。

                _ => value
            };




            const int diff = '\uFF01' - '\u0021';
           
            if (result >= '\uFF01' && result <= '\uFF5E')
            {
                //mainly standard symbols and alphabet characters.
                result = (char)(value - diff);
            }

            return result;
        }

        /// <summary>
        /// あまり一般的ではない記号に半角変換を行います。
        /// "¢"、"£"、"⸨" などです。全角円マークはU+00A5に変換しません。
        /// 全角円マークは BasicLatinToNarrowによって　U+005C に変換されます。
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public virtual char SpecialSymbolToNarrow(char value)
        {
            char result = value switch
            {
                //▼Latin Supplement U+0080 to U+00FF (https://unicode.org/charts/PDF/U0080.pdf)
                //In this region, it's possible to convert more aggresive, for exambple "²" to "２", "©" to "ｃ"...
                //But I don't because its corrput character meanings. the "©" is not same meaning of "ｃ".
                //So, I choiced these three conversions only from this region.
                '￠' => '¢', //U+FFE0 to U+00A2
                '￡' => '£', //U+FFE1 to U+00A3
                //'￥' => '\u00A5', //0xFFE5 to U+00A5. U+00A5 is just currency Yen mark. It's not same as U+005C (backslash).

                //▼
                

                //▼Supplemental Puctuation (https://unicode.org/charts/PDF/U2E00.pdf)
                //These two characters as in fullwidth forms (U+FF5F, U+FF60)
                //And in unicode chart, there halfwidth forms are U+2E28 and U+2E29
                //so, I define these half width to fullwidth conversion.
                '｟' => '⸨', //U+FF5F to U+2E28
                '｠' => '⸩', //U+FF60 to U+2E29
                _ => value
            };

            return result;
        } //SpecialSymbolToWide

        /// <summary>
        /// 全角カタカナを半角カタカナにします。
        /// "｢", "｣", "､", "｡", "･" にも変換します。
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public virtual char[] WideWidthKatakanaToNarrow(char value)
        {
            const char nch = '\u0000'; // Char.MinValue

          
            //思い付きでタプルにしてしまったが、普通に文字列で良かったような…。
            //U + FF61 to U+FF9F
              (char c1, char c2) result = value switch
              {
                  '、' => ('､', nch), // U+3001 to U+FF64
                  '。' => ('｡', nch), // U+3002 to U+FF61
                  '「' => ('｢', nch), // U+300C to U+FF62
                  '」' => ('｣', nch), // U+300D to U+FF63
                  '\u3099' => ('ﾞ', nch), // U+3099 to U+FF9E
                  '\u309A' => ('ﾟ', nch), // U+309A to U+FF9F
                  '゛' => ('ﾞ', nch), // U+309B to U+FF9E
                  '゜' => ('ﾟ', nch), // U+309C to U+FF9F

                  'ァ' => ('ｧ', nch), // U+30A1 to U+FF67
                  'ア' => ('ｱ', nch), // U+30A2 to U+FF71
                  'ィ' => ('ｨ', nch), // U+30A3 to U+FF68
                  'イ' => ('ｲ', nch), // U+30A4 to U+FF72
                  'ゥ' => ('ｩ', nch), // U+30A5 to U+FF69
                  'ウ' => ('ｳ', nch), // U+30A6 to U+FF73
                  'ェ' => ('ｪ', nch), // U+30A7 to U+FF6A
                  'エ' => ('ｴ', nch), // U+30A8 to U+FF74
                  'ォ' => ('ｫ', nch), // U+30A9 to U+FF6B
                  'オ' => ('ｵ', nch), // U+30AA to U+FF75
                  'カ' => ('ｶ', nch), // U+30AB to U+FF76
                  'ガ' => ('ｶ', 'ﾞ'), // U+30AC to U+FF76
                  'キ' => ('ｷ', nch), // U+30AD to U+FF77
                  'ギ' => ('ｷ', 'ﾞ'), // U+30AE to U+FF77
                  'ク' => ('ｸ', nch), // U+30AF to U+FF78
                  'グ' => ('ｸ', 'ﾞ'), // U+30B0 to U+FF78
                  'ケ' => ('ｹ' ,nch), // U+30B1 to U+FF79
                  'ゲ' => ('ｹ', 'ﾞ'), // U+30B2 to U+FF79
                  'コ' => ('ｺ' ,nch), // U+30B3 to U+FF7A
                  'ゴ' => ('ｺ', 'ﾞ'), // U+30B4 to U+FF7A
                  'サ' => ('ｻ', nch), // U+30B5 to U+FF7B
                  'ザ' => ('ｻ', 'ﾞ'), // U+30B6 to U+FF7B
                  'シ' => ('ｼ', nch), // U+30B7 to U+FF7C
                  'ジ' => ('ｼ', 'ﾞ'), // U+30B8 to U+FF7C
                  'ス' => ('ｽ', nch), // U+30B9 to U+FF7D
                  'ズ' => ('ｽ', 'ﾞ'), // U+30BA to U+FF7D
                  'セ' => ('ｾ', nch), // U+30BB to U+FF7E
                  'ゼ' => ('ｾ', 'ﾞ'), // U+30BC to U+FF7E
                  'ソ' => ('ｿ', nch), // U+30BD to U+FF7F
                  'ゾ' => ('ｿ', 'ﾞ'), // U+30BE to U+FF7F
                  'タ' => ('ﾀ', nch), // U+30BF to U+FF80
                  'ダ' => ('ﾀ', 'ﾞ'), // U+30C0 to U+FF80
                  'チ' => ('ﾁ', nch), // U+30C1 to U+FF81
                  'ヂ' => ('ﾁ', 'ﾞ'), // U+30C2 to U+FF81
                  'ッ' => ('ｯ', nch), // U+30C3 to U+FF6F
                  'ツ' => ('ﾂ', nch), // U+30C4 to U+FF82
                  'ヅ' => ('ﾂ', 'ﾞ'), // U+30C5 to U+FF82
                  'テ' => ('ﾃ', nch), // U+30C6 to U+FF83
                  'デ' => ('ﾃ', 'ﾞ'), // U+30C7 to U+FF83
                  'ト' => ('ﾄ', nch), // U+30C8 to U+FF84
                  'ド' => ('ﾄ', 'ﾞ'), // U+30C9 to U+FF84
                  'ナ' => ('ﾅ', nch), // U+30CA to U+FF85
                  'ニ' => ('ﾆ', nch), // U+30CB to U+FF86
                  'ヌ' => ('ﾇ', nch), // U+30CC to U+FF87
                  'ネ' => ('ﾈ', nch), // U+30CD to U+FF88
                  'ノ' => ('ﾉ', nch), // U+30CE to U+FF89
                  'ハ' => ('ﾊ', nch), // U+30CF to U+FF8A
                  'バ' => ('ﾊ', 'ﾞ'), // U+30D0 to U+FF8A
                  'パ' => ('ﾊ', 'ﾟ'), // U+30D1 to U+FF8A
                  'ヒ' => ('ﾋ', nch), // U+30D2 to U+FF8B
                  'ビ' => ('ﾋ', 'ﾞ'), // U+30D3 to U+FF8B
                  'ピ' => ('ﾋ', 'ﾟ'), // U+30D4 to U+FF8B
                  'フ' => ('ﾌ', nch), // U+30D5 to U+FF8C
                  'ブ' => ('ﾌ', 'ﾞ'), // U+30D6 to U+FF8C
                  'プ' => ('ﾌ', 'ﾟ'), // U+30D7 to U+FF8C
                  'ヘ' => ('ﾍ', nch), // U+30D8 to U+FF8D
                  'ベ' => ('ﾍ', 'ﾞ'), // U+30D9 to U+FF8D
                  'ペ' => ('ﾍ', 'ﾟ'), // U+30DA to U+FF8D
                  'ホ' => ('ﾎ', nch), // U+30DB to U+FF8E
                  'ボ' => ('ﾎ', 'ﾞ'), // U+30DC to U+FF8E
                  'ポ' => ('ﾎ', 'ﾟ'), // U+30DD to U+FF8E
                  'マ' => ('ﾏ', nch), // U+30DE to U+FF8F
                  'ミ' => ('ﾐ', nch), // U+30DF to U+FF90
                  'ム' => ('ﾑ', nch), // U+30E0 to U+FF91
                  'メ' => ('ﾒ', nch), // U+30E1 to U+FF92
                  'モ' => ('ﾓ', nch), // U+30E2 to U+FF93
                  'ャ' => ('ｬ', nch), // U+30E3 to U+FF6C
                  'ヤ' => ('ﾔ', nch), // U+30E4 to U+FF94
                  'ュ' => ('ｭ', nch), // U+30E5 to U+FF6D
                  'ユ' => ('ﾕ', nch), // U+30E6 to U+FF95
                  'ョ' => ('ｮ', nch), // U+30E7 to U+FF6E
                  'ヨ' => ('ﾖ', nch), // U+30E8 to U+FF96
                  'ラ' => ('ﾗ', nch), // U+30E9 to U+FF97
                  'リ' => ('ﾘ', nch), // U+30EA to U+FF98
                  'ル' => ('ﾙ', nch), // U+30EB to U+FF99
                  'レ' => ('ﾚ', nch), // U+30EC to U+FF9A
                  'ロ' => ('ﾛ', nch), // U+30ED to U+FF9B
                  'ワ' => ('ﾜ', nch), // U+30EF to U+FF9C
                  //Note U+30F0 is 'ヰ', U+30F1 is 'ヱ',  these characters are fullwidth only.
                  'ヲ' => ('ｦ', nch), // U+30F2 to U+FF66
                  'ン' => ('ﾝ', nch), // U+30F3 to U+FF9D
                  'ヴ' => ('ｳ', 'ﾞ'), // U+30F4 to U+FF73
                  'ヷ' => ('ﾜ', 'ﾞ'), // U+30F7 to U+FF9C
                  'ヺ' => ('ｦ', 'ﾞ'), // U+30FA to U+FF66
                  '・' => ('･', nch), // U+30FB to U+FF65
                  'ー' => ('ｰ', nch), // U+30FC to U+FF70

                  _ => (value, nch)
              };

            //ヵ	ヶ	ヷ	ヸ	ヹ	ヺ

            if (result.c2 == nch)
            {
                return new char[] { result.c1 };
            }
            else
            {
                return new char[] { result.c1, result.c2 };
            }

        }

    } //class DefaultKanaConverter
}
