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
    }
}