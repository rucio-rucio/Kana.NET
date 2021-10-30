using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Sample
    {
        public void DoSample()
        {
            //▼Sample1 Katakana to Hiragana
            //次のように１行記述するだけ カタカナ を ひらがな に変換できます。
            //You can convert Katakana to Hiragana, writing just only one following line.
            string hiragana = Umayadia.Kana.KanaConverter.ToHiragana("ドラえもん大好き");
            Console.WriteLine(hiragana);

            //▼Sample2 Hiragana to Katakana
            //次のように１行記述するだけ ひらがな を カタカナ に変換できます。
            //You can convert Hiragana to Katakana, writing just only one following line.
            string katakana = Umayadia.Kana.KanaConverter.ToKatakana("ドラえもん大好き");
            Console.WriteLine(katakana);

            //▼Sample3 Custome mapping to Hiragana
            //文字ごとに独自の変換を定義することもできます。
            //You can define custome conversion each character as following.
            Umayadia.Kana.KanaConverter.MapToHiragana =
                (System.Text.StringBuilder builder, string letter, string suggestion, string source) =>
                {
                    builder.Append(letter switch
                    {
                        "ド" => "★",
                        "ラ" => "ららら～",
                        _ => suggestion
                    });
                };

            string result1 = Umayadia.Kana.KanaConverter.ToHiragana("ドラえもん大好き");
            Console.WriteLine(result1); //★ららら～えもん大好き

            //▼Sample4 Custome mapping to Katakana
            //文字ごとに独自の変換を定義することもできます。
            //You can define custome conversion each character as following.
            Umayadia.Kana.KanaConverter.MapToKatakana =
                (System.Text.StringBuilder builder, string letter, string suggestion, string source) =>
                {
                    builder.Append(letter switch
                    {
                        "え" => "e",
                        "も" => "MO",
                        _ => suggestion
                    });
                };

            string result2 = Umayadia.Kana.KanaConverter.ToKatakana("ドラえもん大好き");
            Console.WriteLine(result2); //ドラeMOン大好キ

            //▼Sample5
            Umayadia.Kana.KanaConverter.MapToHiragana =
                (System.Text.StringBuilder builder, string letter, string suggestion, string source) =>
                {
                    builder.Append(letter switch
                    {
                        "ヷ" => "わ゙",
                        "ヸ" => "ゐ゙",
                        "ヹ" => "ゑ゙",
                        "ヺ" => "を゙",
                        _ => suggestion
                    });
                };

            string result5 = Umayadia.Kana.KanaConverter.ToHiragana("ワヷヰヸヱヹヲヺ");
            Console.WriteLine(result5); //わわ゙ゐゐ゙ゑゑ゙をを゙

            //▼Sample6
            //StrConv
            string result6 = Umayadia.Kana.KanaConverter.StrConv("ドラえもんは𩸽が大好き", Umayadia.Kana.umaStrConv.Hiragana);
            Console.WriteLine(result6); //どらえもんは??が大好き

            //▼Sample7
            //StrConv
            string result7 = Umayadia.Kana.KanaConverter.StrConv("ドラえもんは𩸽が大好き", Umayadia.Kana.umaStrConv.Katakana);
            Console.WriteLine(result7); //ドラエモンハ??ガ大好キ
        }
    }
}
