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
            KanaConverter.ResetToInitialSettings();

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

            //No effect to other conversions.
            Assert.AreEqual(KanaConverter.ToKatakana("叫ぶところヷ～！"), "叫ブトコロヷ～！", "B700");
            Assert.AreEqual(KanaConverter.ToWide("叫ぶところヷ～！"), "叫ぶところヷ～！", "B700");
            Assert.AreEqual(KanaConverter.ToNarrow("叫ぶところヷ～！"), "叫ぶところﾜﾞ~!", "B800");


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
            KanaConverter.ResetToInitialSettings();

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

            //No effect to other conversions.
            Assert.AreEqual(KanaConverter.ToHiragana("たけやぶやけたね"), "たけやぶやけたね");
            Assert.AreEqual(KanaConverter.ToWide("たけやぶやけたね"), "たけやぶやけたね");
            Assert.AreEqual(KanaConverter.ToNarrow("たけやぶやけたね"), "たけやぶやけたね");

            KanaConverter.MapToKatakana = null;

            Assert.AreEqual(KanaConverter.ToKatakana("たけやぶやけたね"), "タケヤブヤケタネ");

        } //CustomKatakanaMapTest

        [TestMethod]
        public void CustomHiraganaMapParams()
        {
            KanaConverter.ResetToInitialSettings();

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
            KanaConverter.ResetToInitialSettings();

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
        } //CustomKatakanaMapParams


        [TestMethod]
        public void CustomWideMapTest()
        {
            KanaConverter.ResetToInitialSettings();

            Assert.AreEqual(KanaConverter.ToWide("Coocking ABCの直訳は料理のｲﾛﾊ"),
                                                 "Ｃｏｏｃｋｉｎｇ　ＡＢＣの直訳は料理のイロハ", "A1000");


            KanaConverter.MapToWide =
                (System.Text.StringBuilder builder, string letter, string suggestion, string source) =>
                {
                    builder.Append(letter switch
                    {
                        "A" => "Ⓐ",
                        "B" => "Ⓑ",
                        "C" => "Ⓒ",
                        "o" => "o", // o. keep half width.
                        "訳" => "言尺",
                        _ => suggestion
                    });
                };

            Assert.AreEqual(KanaConverter.ToWide("Coocking ABCの直訳は料理のｲﾛﾊ"), 
                                                 "Ⓒooｃｋｉｎｇ　ⒶⒷⒸの直言尺は料理のイロハ", "B1000");

            //No effect to other conversions.
            Assert.AreEqual(KanaConverter.ToKatakana("Coocking ABCの直訳は料理のｲﾛﾊ"), "Coocking ABCノ直訳ハ料理ノｲﾛﾊ","B2000");
            Assert.AreEqual(KanaConverter.ToHiragana("Coocking ABCの直訳は料理のｲﾛﾊ"), "Coocking ABCの直訳は料理のｲﾛﾊ","B3000");
            Assert.AreEqual(KanaConverter.ToNarrow("Coocking ABCの直訳は料理のｲﾛﾊ"), "Coocking ABCの直訳は料理のｲﾛﾊ","B4000");

            KanaConverter.MapToWide = null;

            Assert.AreEqual(KanaConverter.ToWide("Coocking ABCの直訳は料理のｲﾛﾊ"),
                                                 "Ｃｏｏｃｋｉｎｇ　ＡＢＣの直訳は料理のイロハ","C1000");

        } //CustomWideMapTest

        [TestMethod]
        public void CustomWideMapWithDiacritical()
        {
            KanaConverter.ResetToInitialSettings();

            Assert.AreEqual(KanaConverter.ToWide("ﾋﾞﾋﾞﾃﾞｨﾊﾞﾋﾞﾃﾞｨのﾌﾞｰﾃ!"),
                                                 "ビビディバビディのブーテ！", "A1000");


            KanaConverter.MapToWide =
                (System.Text.StringBuilder builder, string letter, string suggestion, string source) =>
                {
                    builder.Append(letter switch
                    {
                        "ﾋﾞ" => "★",
                        "ﾃ" => "💀", //It will only hit for last "ﾃ".(The other "ﾃ" will be "ﾃﾞ")
                        "の" => "の",
                        _ => suggestion
                    });
                };

            Assert.AreEqual(KanaConverter.ToWide("ﾋﾞﾋﾞﾃﾞｨﾊﾞﾋﾞﾃﾞｨのﾌﾞｰﾃ!"),
                                                 "★★ディバ★ディのブー💀！", "B1000");

            //No effect to other conversions.
            Assert.AreEqual(KanaConverter.ToKatakana("ﾋﾞﾋﾞﾃﾞｨﾊﾞﾋﾞﾃﾞｨのﾌﾞｰﾃ!"), "ﾋﾞﾋﾞﾃﾞｨﾊﾞﾋﾞﾃﾞｨノﾌﾞｰﾃ!", "B2000");
            Assert.AreEqual(KanaConverter.ToHiragana("ﾋﾞﾋﾞﾃﾞｨﾊﾞﾋﾞﾃﾞｨのﾌﾞｰﾃ!"), "ﾋﾞﾋﾞﾃﾞｨﾊﾞﾋﾞﾃﾞｨのﾌﾞｰﾃ!", "B3000");
            Assert.AreEqual(KanaConverter.ToNarrow("ﾋﾞﾋﾞﾃﾞｨﾊﾞﾋﾞﾃﾞｨのﾌﾞｰﾃ!"), "ﾋﾞﾋﾞﾃﾞｨﾊﾞﾋﾞﾃﾞｨのﾌﾞｰﾃ!", "B4000");

            KanaConverter.MapToWide = null;

            Assert.AreEqual(KanaConverter.ToWide("ﾋﾞﾋﾞﾃﾞｨﾊﾞﾋﾞﾃﾞｨのﾌﾞｰﾃ!"),
                                                 "ビビディバビディのブーテ！", "C1000");

        } //CustomWideMapWithDiacritical

        [TestMethod]
        public void CustomNarrowMapTest()
        {
            KanaConverter.ResetToInitialSettings();

            Assert.AreEqual(KanaConverter.ToNarrow("Ｃｏｏｃｋｉｎｇ　ＡＢＣの直訳は料理のイロハ"),
                                                   "Coocking ABCの直訳は料理のｲﾛﾊ", "A1000");


            KanaConverter.MapToNarrow =
                (System.Text.StringBuilder builder, string letter, string suggestion, string source) =>
                {
                    builder.Append(letter switch
                    {
                        "Ａ" => "À",
                        "Ｂ" => "ℬ",
                        "Ｃ" => "ℭ",
                        "ｏ" => "ｏ", // ｏ. keep full width.
                        "の" => "@",
                        _ => suggestion
                    });
                };

            Assert.AreEqual(KanaConverter.ToNarrow("Ｃｏｏｃｋｉｎｇ　ＡＢＣの直訳は料理のイロハ"),
                                                 "ℭｏｏcking Àℬℭ@直訳は料理@ｲﾛﾊ", "B1000");

            //No effect to other conversions.
            Assert.AreEqual(KanaConverter.ToKatakana("Ｃｏｏｃｋｉｎｇ　ＡＢＣの直訳は料理のイロハ"),
                                                 "Ｃｏｏｃｋｉｎｇ　ＡＢＣノ直訳ハ料理ノイロハ",
                                                 "B2000");

            Assert.AreEqual(KanaConverter.ToHiragana("Ｃｏｏｃｋｉｎｇ　ＡＢＣの直訳は料理のイロハ"),
                                                 "Ｃｏｏｃｋｉｎｇ　ＡＢＣの直訳は料理のいろは",
                                                 "B3000");

            Assert.AreEqual(KanaConverter.ToWide("Ｃｏｏｃｋｉｎｇ　ＡＢＣの直訳は料理のイロハ"),
                                                 "Ｃｏｏｃｋｉｎｇ　ＡＢＣの直訳は料理のイロハ",
                                                 "B4000");

            KanaConverter.MapToNarrow = null;

            Assert.AreEqual(KanaConverter.ToWide("Coocking ABCの直訳は料理のｲﾛﾊ"),
                                                 "Ｃｏｏｃｋｉｎｇ　ＡＢＣの直訳は料理のイロハ", "C1000");

        } //CustomNarrowMapTest

        [TestMethod]
        public void CustomWideMapParams()
        {
            KanaConverter.ResetToInitialSettings();

            int callCount = 0;

            KanaConverter.MapToWide =
                (System.Text.StringBuilder builder, string letter, string suggestion, string source) =>
                {
                    if (callCount == 0)
                    {
                        //When call with "ｶﾞ"
                        Assert.AreEqual("ｶﾞ", letter, "A1000");
                        Assert.AreEqual("ガ", suggestion, "A2000");
                        Assert.AreEqual("ｶﾞｱﾞ僧🐓", source, "A3000");
                    }
                    else if (callCount == 1)
                    {
                        //When call with "ｱ"
                        Assert.AreEqual("ｱ", letter, "B1000");
                        Assert.AreEqual("ア", suggestion, "B2000");
                        Assert.AreEqual("ｶﾞｱﾞ僧🐓", source, "B3000");
                    }
                    else if (callCount == 2)
                    {
                        //When call with "ﾞ"
                        Assert.AreEqual("ﾞ", letter, "C1000");
                        Assert.AreEqual("゛", suggestion, "C2000");
                        Assert.AreEqual("ｶﾞｱﾞ僧🐓", source, "C3000");
                    }
                    else if (callCount == 3)
                    {
                        //When call with "僧"
                        Assert.AreEqual("僧", letter, "D1000");
                        Assert.AreEqual("僧", suggestion, "D2000");
                        Assert.AreEqual("ｶﾞｱﾞ僧🐓", source, "D3000");
                    }
                    else if (callCount == 4)
                    {
                        //When call with first surrogate of "🐓" ( = U+D83D)
                        Assert.AreEqual("\uD83D", letter, "E1000");
                        Assert.AreEqual("\uD83D", suggestion, "E2000");
                        Assert.AreEqual("ｶﾞｱﾞ僧🐓", source, "E3000");
                    }
                    else if (callCount == 5)
                    {
                        //When call with second surrogate of "🐓" ( = U+DC13)
                        Assert.AreEqual("\uDC13", letter, "F1000");
                        Assert.AreEqual("\uDC13", suggestion, "F2000");
                        Assert.AreEqual("ｶﾞｱﾞ僧🐓", source, "F3000");
                    }
                    else
                    {
                        Assert.Fail("Too many call. expected 5 times call. but more.");
                    }

                    callCount++;
                    builder.Append(suggestion);
                };

            KanaConverter.MapToNarrow =
                (System.Text.StringBuilder builder, string letter, string suggestion, string source) =>
                {
                    Assert.Fail("Do not call this on this time, but it was called.");
                };

            KanaConverter.ToWide("ｶﾞｱﾞ僧🐓");
        } //        public void CustomWideMapParams()

        [TestMethod]
        public void CustomNarrowMapParams()
        {
            KanaConverter.ResetToInitialSettings();

            int callCount = 0;

            KanaConverter.MapToNarrow =
                (System.Text.StringBuilder builder, string letter, string suggestion, string source) =>
                {
                    if (callCount == 0)
                    {
                        //When call with "ジ"
                        Assert.AreEqual("ジ", letter, "A1000");
                        Assert.AreEqual("ｼﾞ", suggestion, "A2000");
                        Assert.AreEqual("ジャあ゙郡🦁", source, "A3000");
                    }
                    else if (callCount == 1)
                    {
                        //When call with "ャ"
                        Assert.AreEqual("ャ", letter, "B1000");
                        Assert.AreEqual("ｬ", suggestion, "B2000");
                        Assert.AreEqual("ジャあ゙郡🦁", source, "B3000");
                    }
                    else if (callCount == 2)
                    {
                        //When call with "あ"
                        Assert.AreEqual("あ", letter, "C1000");
                        Assert.AreEqual("あ", suggestion, "C2000");
                        Assert.AreEqual("ジャあ゙郡🦁", source, "C3000");
                    }
                    else if (callCount == 3)
                    {
                        //When call with " ゙"
                        Assert.AreEqual("\u3099", letter, "D1000");
                        Assert.AreEqual("ﾞ", suggestion, "D2000");
                        Assert.AreEqual("ジャあ゙郡🦁", source, "D3000");
                    }
                    else if (callCount == 4)
                    {
                        //When call with "郡"
                        Assert.AreEqual("郡", letter, "E1000");
                        Assert.AreEqual("郡", suggestion, "E2000");
                        Assert.AreEqual("ジャあ゙郡🦁", source, "E3000");
                    }
                    else if (callCount == 5)
                    {
                        //When call with first surrogate of "🦁" ( = U+D83E)
                        Assert.AreEqual("\uD83E", letter, "F1000");
                        Assert.AreEqual("\uD83E", suggestion, "F2000");
                        Assert.AreEqual("ジャあ゙郡🦁", source, "F3000");
                    }
                    else if (callCount == 6)
                    {
                        //When call with second surrogate of "🦁" ( = U+DD81)
                        Assert.AreEqual("\uDD81", letter, "G1000");
                        Assert.AreEqual("\uDD81", suggestion, "G2000");
                        Assert.AreEqual("ジャあ゙郡🦁", source, "G3000");
                    }
                    else
                    {
                        Assert.Fail("Too many call. expected 6 times call. but more.");
                    }

                    callCount++;
                    builder.Append(suggestion);
                };

            KanaConverter.MapToWide =
                (System.Text.StringBuilder builder, string letter, string suggestion, string source) =>
                {
                    Assert.Fail("Do not call this on this time, but it was called.");
                };

            KanaConverter.ToNarrow("ジャあ゙郡🦁");

        } // CustomNarrowMapParams
    }
}