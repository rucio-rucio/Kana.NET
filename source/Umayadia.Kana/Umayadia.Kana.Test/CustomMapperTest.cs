using Microsoft.VisualStudio.TestTools.UnitTesting;
using Umayadia.Kana;

namespace Umayadia.Kana.Test
{
    [TestClass]
    public class CustomMapperTest
    {
        [TestMethod]
        public void CustomHiraganaMapTest()
        {
            KanaConverter.MapToHiragana = null;
            KanaConverter.MapToKatakana = null;

            //既定ではこれらの4文字は対応する平仮名がないため変換されません。
            Assert.AreEqual(KanaConverter.ToHiragana("ヷ"), "ヷ");
            Assert.AreEqual(KanaConverter.ToHiragana("ヸ"), "ヸ");
            Assert.AreEqual(KanaConverter.ToHiragana("ヹ"), "ヹ");
            Assert.AreEqual(KanaConverter.ToHiragana("ヺ"), "ヺ");

            Assert.AreEqual(KanaConverter.ToHiragana("ドラキュラ伯爵"), "どらきゅら伯爵");
            Assert.AreEqual(KanaConverter.ToHiragana("叫ぶところヷ～！"), "叫ぶところヷ～！", "A600");

            //これらの４文字は結合文字に変換するカスタムなマップを定義します。
            KanaConverter.MapToHiragana =
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

            //変換結果はカスタムマップに変わります。
            Assert.AreEqual(KanaConverter.ToHiragana("ヷ"), "わ゙");
            Assert.AreEqual(KanaConverter.ToHiragana("ヸ"), "ゐ゙");
            Assert.AreEqual(KanaConverter.ToHiragana("ヹ"), "ゑ゙");
            Assert.AreEqual(KanaConverter.ToHiragana("ヺ"), "を゙");

            Assert.AreEqual(KanaConverter.ToHiragana("ドラキュラ伯爵"), "どらきゅら伯爵");
            Assert.AreEqual(KanaConverter.ToHiragana("叫ぶところヷ～！"), "叫ぶところわ゙～！", "B600");
            Assert.AreEqual(KanaConverter.ToKatakana("叫ぶところヷ～！"), "叫ブトコロヷ～！", "B700");

            //カスタムマップをクリアします。
            KanaConverter.MapToHiragana = null;
            Assert.AreEqual(KanaConverter.ToHiragana("ヷ"), "ヷ");
            Assert.AreEqual(KanaConverter.ToHiragana("ヸ"), "ヸ");
            Assert.AreEqual(KanaConverter.ToHiragana("ヹ"), "ヹ");
            Assert.AreEqual(KanaConverter.ToHiragana("ヺ"), "ヺ");

            Assert.AreEqual(KanaConverter.ToHiragana("ドラキュラ伯爵"), "どらきゅら伯爵");
            Assert.AreEqual(KanaConverter.ToHiragana("叫ぶところヷ～！"), "叫ぶところヷ～！", "C600");

        }

        [TestMethod]
        public void CustomKatakanaMapTest()
        {
            KanaConverter.MapToHiragana = null;
            KanaConverter.MapToKatakana = null;

            Assert.AreEqual(KanaConverter.ToKatakana("たけやぶやけたね"), "タケヤブヤケタネ");


            KanaConverter.MapToKatakana =
                (System.Text.StringBuilder builder, string letter, string suggestion, string source) =>
                {
                    builder.Append(letter switch
                    {
                        "た" => "TA",
                        "け" => "KE",
                        "や" => "YA",
                        "ぶ" => "BU",
                        _ => suggestion
                    });
                };

            Assert.AreEqual(KanaConverter.ToKatakana("たけやぶやけたね"), "TAKEYABUYAKETAネ");
            Assert.AreEqual(KanaConverter.ToHiragana("たけやぶやけたね"), "たけやぶやけたね");

            KanaConverter.MapToKatakana = null;

            Assert.AreEqual(KanaConverter.ToKatakana("たけやぶやけたね"), "タケヤブヤケタネ");

        }

        [TestMethod]
        public void CustomHiraganaMapParams()
        {
            KanaConverter.MapToHiragana = null;
            KanaConverter.MapToKatakana = null;

            int callCount = 0;

            KanaConverter.MapToHiragana =
                (System.Text.StringBuilder builder, string letter, string suggestion, string source) =>
                {
                    if (callCount == 0)
                    {
                        //When call with "ラ"
                        Assert.AreEqual("ラ", letter, "A1000");
                        Assert.AreEqual("ら", suggestion, "A2000");
                        Assert.AreEqual("ラぬ星🚙", source, "A3000");
                    }
                    else if (callCount == 1)
                    {
                        //When call with "ぬ"
                        Assert.AreEqual("ぬ", letter, "B1000");
                        Assert.AreEqual("ぬ", suggestion, "B2000");
                        Assert.AreEqual("ラぬ星🚙", source, "B3000");
                    }
                    else if (callCount == 2)
                    {
                        //When call with "星"
                        Assert.AreEqual("星", letter, "C1000");
                        Assert.AreEqual("星", suggestion, "C2000");
                        Assert.AreEqual("ラぬ星🚙", source, "C3000");
                    }
                    else if (callCount == 3)
                    {
                        //When call with first surrogate of "🚙" ( = U+D83D)
                        Assert.AreEqual("\uD83D", letter, "D1000");
                        Assert.AreEqual("\uD83D", suggestion, "D2000");
                        Assert.AreEqual("ラぬ星🚙", source, "D3000");
                    }
                    else if (callCount == 4)
                    {
                        //When call with second surrogate of "🚙" ( = U+DE99)
                        Assert.AreEqual("\uDE99", letter, "E1000");
                        Assert.AreEqual("\uDE99", suggestion, "E2000");
                        Assert.AreEqual("ラぬ星🚙", source, "E3000");
                    }
                    else
                    {
                        Assert.Fail("Too many call. expected 4 times call. but more.");
                    }

                    callCount++;
                    builder.Append(suggestion);
                };

            KanaConverter.MapToKatakana =
                (System.Text.StringBuilder builder, string letter, string suggestion, string source) =>
                {
                    Assert.Fail("Do not call this on this time, but it was called.");
                };

            KanaConverter.ToHiragana("ラぬ星🚙");
        }

        [TestMethod]
        public void CustomKatakanaMapParams()
        {
            KanaConverter.MapToHiragana = null;
            KanaConverter.MapToKatakana = null;

            int callCount = 0;

            KanaConverter.MapToKatakana =
                (System.Text.StringBuilder builder, string letter, string suggestion, string source) =>
                {
                    if (callCount == 0)
                    {
                        //When call with "ポ"
                        Assert.AreEqual("ポ", letter, "A1000");
                        Assert.AreEqual("ポ", suggestion, "A2000");
                        Assert.AreEqual("ポぎ熱🛩", source, "A3000");
                    }
                    else if (callCount == 1)
                    {
                        //When call with "ぎ"
                        Assert.AreEqual("ぎ", letter, "B1000");
                        Assert.AreEqual("ギ", suggestion, "B2000");
                        Assert.AreEqual("ポぎ熱🛩", source, "B3000");
                    }
                    else if (callCount == 2)
                    {
                        //When call with "熱"
                        Assert.AreEqual("熱", letter, "C1000");
                        Assert.AreEqual("熱", suggestion, "C2000");
                        Assert.AreEqual("ポぎ熱🛩", source, "C3000");
                    }
                    else if (callCount == 3)
                    {
                        //When call with first surrogate of "🛩" ( = U+D83D)
                        Assert.AreEqual("\uD83D", letter, "D1000");
                        Assert.AreEqual("\uD83D", suggestion, "D2000");
                        Assert.AreEqual("ポぎ熱🛩", source, "D3000");
                    }
                    else if (callCount == 4)
                    {
                        //When call with second surrogate of "🛩" ( = U+DE99)
                        Assert.AreEqual("\uDEE9", letter, "E1000");
                        Assert.AreEqual("\uDEE9", suggestion, "E2000");
                        Assert.AreEqual("ポぎ熱🛩", source, "E3000");
                    }
                    else
                    {
                        Assert.Fail("Too many call. expected 4 times call. but more.");
                    }

                    callCount++;
                    builder.Append(suggestion);
                };

            KanaConverter.MapToHiragana =
                (System.Text.StringBuilder builder, string letter, string suggestion, string source) =>
                {
                    Assert.Fail("Do not call this on this time, but it was called.");
                };
            KanaConverter.ToKatakana("ポぎ熱🛩");
        }
    }
}