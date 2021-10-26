using Microsoft.VisualStudio.TestTools.UnitTesting;
using Umayadia.Kana;

namespace Umayadia.Kana.Test
{
    [TestClass]
    public class KanaConverterTest
    {
        [TestMethod]
        public void ConvertToSingleKatakanaTest()
        {
            Assert.AreEqual(KanaConverter.ToKatakana("ぁ"), "ァ");
            Assert.AreEqual(KanaConverter.ToKatakana("あ"), "ア");
            Assert.AreEqual(KanaConverter.ToKatakana("ぃ"), "ィ");
            Assert.AreEqual(KanaConverter.ToKatakana("い"), "イ");
            Assert.AreEqual(KanaConverter.ToKatakana("ぅ"), "ゥ");
            Assert.AreEqual(KanaConverter.ToKatakana("う"), "ウ");
            Assert.AreEqual(KanaConverter.ToKatakana("ぇ"), "ェ");
            Assert.AreEqual(KanaConverter.ToKatakana("え"), "エ");
            Assert.AreEqual(KanaConverter.ToKatakana("ぉ"), "ォ");
            Assert.AreEqual(KanaConverter.ToKatakana("お"), "オ");
            Assert.AreEqual(KanaConverter.ToKatakana("か"), "カ");
            Assert.AreEqual(KanaConverter.ToKatakana("が"), "ガ");
            Assert.AreEqual(KanaConverter.ToKatakana("き"), "キ");
            Assert.AreEqual(KanaConverter.ToKatakana("ぎ"), "ギ");
            Assert.AreEqual(KanaConverter.ToKatakana("く"), "ク");
            Assert.AreEqual(KanaConverter.ToKatakana("ぐ"), "グ");
            Assert.AreEqual(KanaConverter.ToKatakana("け"), "ケ");
            Assert.AreEqual(KanaConverter.ToKatakana("げ"), "ゲ");
            Assert.AreEqual(KanaConverter.ToKatakana("こ"), "コ");
            Assert.AreEqual(KanaConverter.ToKatakana("ご"), "ゴ");
            Assert.AreEqual(KanaConverter.ToKatakana("さ"), "サ");
            Assert.AreEqual(KanaConverter.ToKatakana("ざ"), "ザ");
            Assert.AreEqual(KanaConverter.ToKatakana("し"), "シ");
            Assert.AreEqual(KanaConverter.ToKatakana("じ"), "ジ");
            Assert.AreEqual(KanaConverter.ToKatakana("す"), "ス");
            Assert.AreEqual(KanaConverter.ToKatakana("ず"), "ズ");
            Assert.AreEqual(KanaConverter.ToKatakana("せ"), "セ");
            Assert.AreEqual(KanaConverter.ToKatakana("ぜ"), "ゼ");
            Assert.AreEqual(KanaConverter.ToKatakana("そ"), "ソ");
            Assert.AreEqual(KanaConverter.ToKatakana("ぞ"), "ゾ");
            Assert.AreEqual(KanaConverter.ToKatakana("た"), "タ");
            Assert.AreEqual(KanaConverter.ToKatakana("だ"), "ダ");
            Assert.AreEqual(KanaConverter.ToKatakana("ち"), "チ");
            Assert.AreEqual(KanaConverter.ToKatakana("ぢ"), "ヂ");
            Assert.AreEqual(KanaConverter.ToKatakana("っ"), "ッ");
            Assert.AreEqual(KanaConverter.ToKatakana("つ"), "ツ");
            Assert.AreEqual(KanaConverter.ToKatakana("づ"), "ヅ");
            Assert.AreEqual(KanaConverter.ToKatakana("て"), "テ");
            Assert.AreEqual(KanaConverter.ToKatakana("で"), "デ");
            Assert.AreEqual(KanaConverter.ToKatakana("と"), "ト");
            Assert.AreEqual(KanaConverter.ToKatakana("ど"), "ド");
            Assert.AreEqual(KanaConverter.ToKatakana("な"), "ナ");
            Assert.AreEqual(KanaConverter.ToKatakana("に"), "ニ");
            Assert.AreEqual(KanaConverter.ToKatakana("ぬ"), "ヌ");
            Assert.AreEqual(KanaConverter.ToKatakana("ね"), "ネ");
            Assert.AreEqual(KanaConverter.ToKatakana("の"), "ノ");
            Assert.AreEqual(KanaConverter.ToKatakana("は"), "ハ");
            Assert.AreEqual(KanaConverter.ToKatakana("ば"), "バ");
            Assert.AreEqual(KanaConverter.ToKatakana("ぱ"), "パ");
            Assert.AreEqual(KanaConverter.ToKatakana("ひ"), "ヒ");
            Assert.AreEqual(KanaConverter.ToKatakana("び"), "ビ");
            Assert.AreEqual(KanaConverter.ToKatakana("ぴ"), "ピ");
            Assert.AreEqual(KanaConverter.ToKatakana("ふ"), "フ");
            Assert.AreEqual(KanaConverter.ToKatakana("ぶ"), "ブ");
            Assert.AreEqual(KanaConverter.ToKatakana("ぷ"), "プ");
            Assert.AreEqual(KanaConverter.ToKatakana("へ"), "ヘ");
            Assert.AreEqual(KanaConverter.ToKatakana("べ"), "ベ");
            Assert.AreEqual(KanaConverter.ToKatakana("ぺ"), "ペ");
            Assert.AreEqual(KanaConverter.ToKatakana("ほ"), "ホ");
            Assert.AreEqual(KanaConverter.ToKatakana("ぼ"), "ボ");
            Assert.AreEqual(KanaConverter.ToKatakana("ぽ"), "ポ");
            Assert.AreEqual(KanaConverter.ToKatakana("ま"), "マ");
            Assert.AreEqual(KanaConverter.ToKatakana("み"), "ミ");
            Assert.AreEqual(KanaConverter.ToKatakana("む"), "ム");
            Assert.AreEqual(KanaConverter.ToKatakana("め"), "メ");
            Assert.AreEqual(KanaConverter.ToKatakana("も"), "モ");
            Assert.AreEqual(KanaConverter.ToKatakana("ゃ"), "ャ");
            Assert.AreEqual(KanaConverter.ToKatakana("や"), "ヤ");
            Assert.AreEqual(KanaConverter.ToKatakana("ゅ"), "ュ");
            Assert.AreEqual(KanaConverter.ToKatakana("ゆ"), "ユ");
            Assert.AreEqual(KanaConverter.ToKatakana("ょ"), "ョ");
            Assert.AreEqual(KanaConverter.ToKatakana("よ"), "ヨ");
            Assert.AreEqual(KanaConverter.ToKatakana("ら"), "ラ");
            Assert.AreEqual(KanaConverter.ToKatakana("り"), "リ");
            Assert.AreEqual(KanaConverter.ToKatakana("る"), "ル");
            Assert.AreEqual(KanaConverter.ToKatakana("れ"), "レ");
            Assert.AreEqual(KanaConverter.ToKatakana("ろ"), "ロ");
            Assert.AreEqual(KanaConverter.ToKatakana("ゎ"), "ヮ");
            Assert.AreEqual(KanaConverter.ToKatakana("わ"), "ワ");
            Assert.AreEqual(KanaConverter.ToKatakana("ゐ"), "ヰ");
            Assert.AreEqual(KanaConverter.ToKatakana("ゑ"), "ヱ");
            Assert.AreEqual(KanaConverter.ToKatakana("を"), "ヲ");
            Assert.AreEqual(KanaConverter.ToKatakana("ん"), "ン");
            Assert.AreEqual(KanaConverter.ToKatakana("ゔ"), "ヴ");
            Assert.AreEqual(KanaConverter.ToKatakana("ゕ"), "ヵ");
            Assert.AreEqual(KanaConverter.ToKatakana("ゖ"), "ヶ");
            //Assert.AreEqual(KanaConverter.ToKatakana("゗"), "ヷ");
            //Assert.AreEqual(KanaConverter.ToKatakana("゘"), "ヸ");
            Assert.AreEqual(KanaConverter.ToKatakana("   ゙"), "   ゙");
            Assert.AreEqual(KanaConverter.ToKatakana("   ゚"), "   ゚");
            Assert.AreEqual(KanaConverter.ToKatakana("゛"), "゛"); // Not match
            Assert.AreEqual(KanaConverter.ToKatakana("゜"), "゜"); // Not match
            Assert.AreEqual(KanaConverter.ToKatakana("ゝ"), "ヽ");
            Assert.AreEqual(KanaConverter.ToKatakana("ゞ"), "ヾ");
            Assert.AreEqual(KanaConverter.ToKatakana("ゟ"), "ゟ"); // Not match
        } //ConvertToSingleKatakanaTest

        [TestMethod]
        public void ConvertToSingleHiraganaTest()
        {
            Assert.AreEqual(KanaConverter.ToHiragana("゠"), "゠");
            Assert.AreEqual(KanaConverter.ToHiragana("ァ"), "ぁ");
            Assert.AreEqual(KanaConverter.ToHiragana("ア"), "あ");
            Assert.AreEqual(KanaConverter.ToHiragana("ィ"), "ぃ");
            Assert.AreEqual(KanaConverter.ToHiragana("イ"), "い");
            Assert.AreEqual(KanaConverter.ToHiragana("ゥ"), "ぅ");
            Assert.AreEqual(KanaConverter.ToHiragana("ウ"), "う");
            Assert.AreEqual(KanaConverter.ToHiragana("ェ"), "ぇ");
            Assert.AreEqual(KanaConverter.ToHiragana("エ"), "え");
            Assert.AreEqual(KanaConverter.ToHiragana("ォ"), "ぉ");
            Assert.AreEqual(KanaConverter.ToHiragana("オ"), "お");
            Assert.AreEqual(KanaConverter.ToHiragana("カ"), "か");
            Assert.AreEqual(KanaConverter.ToHiragana("ガ"), "が");
            Assert.AreEqual(KanaConverter.ToHiragana("キ"), "き");
            Assert.AreEqual(KanaConverter.ToHiragana("ギ"), "ぎ");
            Assert.AreEqual(KanaConverter.ToHiragana("ク"), "く");
            Assert.AreEqual(KanaConverter.ToHiragana("グ"), "ぐ");
            Assert.AreEqual(KanaConverter.ToHiragana("ケ"), "け");
            Assert.AreEqual(KanaConverter.ToHiragana("ゲ"), "げ");
            Assert.AreEqual(KanaConverter.ToHiragana("コ"), "こ");
            Assert.AreEqual(KanaConverter.ToHiragana("ゴ"), "ご");
            Assert.AreEqual(KanaConverter.ToHiragana("サ"), "さ");
            Assert.AreEqual(KanaConverter.ToHiragana("ザ"), "ざ");
            Assert.AreEqual(KanaConverter.ToHiragana("シ"), "し");
            Assert.AreEqual(KanaConverter.ToHiragana("ジ"), "じ");
            Assert.AreEqual(KanaConverter.ToHiragana("ス"), "す");
            Assert.AreEqual(KanaConverter.ToHiragana("ズ"), "ず");
            Assert.AreEqual(KanaConverter.ToHiragana("セ"), "せ");
            Assert.AreEqual(KanaConverter.ToHiragana("ゼ"), "ぜ");
            Assert.AreEqual(KanaConverter.ToHiragana("ソ"), "そ");
            Assert.AreEqual(KanaConverter.ToHiragana("ゾ"), "ぞ");
            Assert.AreEqual(KanaConverter.ToHiragana("タ"), "た");
            Assert.AreEqual(KanaConverter.ToHiragana("ダ"), "だ");
            Assert.AreEqual(KanaConverter.ToHiragana("チ"), "ち");
            Assert.AreEqual(KanaConverter.ToHiragana("ヂ"), "ぢ");
            Assert.AreEqual(KanaConverter.ToHiragana("ッ"), "っ");
            Assert.AreEqual(KanaConverter.ToHiragana("ツ"), "つ");
            Assert.AreEqual(KanaConverter.ToHiragana("ヅ"), "づ");
            Assert.AreEqual(KanaConverter.ToHiragana("テ"), "て");
            Assert.AreEqual(KanaConverter.ToHiragana("デ"), "で");
            Assert.AreEqual(KanaConverter.ToHiragana("ト"), "と");
            Assert.AreEqual(KanaConverter.ToHiragana("ド"), "ど");
            Assert.AreEqual(KanaConverter.ToHiragana("ナ"), "な");
            Assert.AreEqual(KanaConverter.ToHiragana("ニ"), "に");
            Assert.AreEqual(KanaConverter.ToHiragana("ヌ"), "ぬ");
            Assert.AreEqual(KanaConverter.ToHiragana("ネ"), "ね");
            Assert.AreEqual(KanaConverter.ToHiragana("ノ"), "の");
            Assert.AreEqual(KanaConverter.ToHiragana("ハ"), "は");
            Assert.AreEqual(KanaConverter.ToHiragana("バ"), "ば");
            Assert.AreEqual(KanaConverter.ToHiragana("パ"), "ぱ");
            Assert.AreEqual(KanaConverter.ToHiragana("ヒ"), "ひ");
            Assert.AreEqual(KanaConverter.ToHiragana("ビ"), "び");
            Assert.AreEqual(KanaConverter.ToHiragana("ピ"), "ぴ");
            Assert.AreEqual(KanaConverter.ToHiragana("フ"), "ふ");
            Assert.AreEqual(KanaConverter.ToHiragana("ブ"), "ぶ");
            Assert.AreEqual(KanaConverter.ToHiragana("プ"), "ぷ");
            Assert.AreEqual(KanaConverter.ToHiragana("ヘ"), "へ");
            Assert.AreEqual(KanaConverter.ToHiragana("ベ"), "べ");
            Assert.AreEqual(KanaConverter.ToHiragana("ペ"), "ぺ");
            Assert.AreEqual(KanaConverter.ToHiragana("ホ"), "ほ");
            Assert.AreEqual(KanaConverter.ToHiragana("ボ"), "ぼ");
            Assert.AreEqual(KanaConverter.ToHiragana("ポ"), "ぽ");
            Assert.AreEqual(KanaConverter.ToHiragana("マ"), "ま");
            Assert.AreEqual(KanaConverter.ToHiragana("ミ"), "み");
            Assert.AreEqual(KanaConverter.ToHiragana("ム"), "む");
            Assert.AreEqual(KanaConverter.ToHiragana("メ"), "め");
            Assert.AreEqual(KanaConverter.ToHiragana("モ"), "も");
            Assert.AreEqual(KanaConverter.ToHiragana("ャ"), "ゃ");
            Assert.AreEqual(KanaConverter.ToHiragana("ヤ"), "や");
            Assert.AreEqual(KanaConverter.ToHiragana("ュ"), "ゅ");
            Assert.AreEqual(KanaConverter.ToHiragana("ユ"), "ゆ");
            Assert.AreEqual(KanaConverter.ToHiragana("ョ"), "ょ");
            Assert.AreEqual(KanaConverter.ToHiragana("ヨ"), "よ");
            Assert.AreEqual(KanaConverter.ToHiragana("ラ"), "ら");
            Assert.AreEqual(KanaConverter.ToHiragana("リ"), "り");
            Assert.AreEqual(KanaConverter.ToHiragana("ル"), "る");
            Assert.AreEqual(KanaConverter.ToHiragana("レ"), "れ");
            Assert.AreEqual(KanaConverter.ToHiragana("ロ"), "ろ");
            Assert.AreEqual(KanaConverter.ToHiragana("ヮ"), "ゎ");
            Assert.AreEqual(KanaConverter.ToHiragana("ワ"), "わ");
            Assert.AreEqual(KanaConverter.ToHiragana("ヰ"), "ゐ");
            Assert.AreEqual(KanaConverter.ToHiragana("ヱ"), "ゑ");
            Assert.AreEqual(KanaConverter.ToHiragana("ヲ"), "を");
            Assert.AreEqual(KanaConverter.ToHiragana("ン"), "ん");
            Assert.AreEqual(KanaConverter.ToHiragana("ヴ"), "ゔ");
            Assert.AreEqual(KanaConverter.ToHiragana("ヵ"), "ゕ");
            Assert.AreEqual(KanaConverter.ToHiragana("ヶ"), "ゖ");
            Assert.AreEqual(KanaConverter.ToHiragana("ヷ"), "ヷ"); // Not match
            Assert.AreEqual(KanaConverter.ToHiragana("ヸ"), "ヸ"); // Not match
            Assert.AreEqual(KanaConverter.ToHiragana("ヹ"), "ヹ"); // Not match
            Assert.AreEqual(KanaConverter.ToHiragana("ヺ"), "ヺ"); // Not match
            Assert.AreEqual(KanaConverter.ToHiragana("・"), "・"); // Not match
            Assert.AreEqual(KanaConverter.ToHiragana("ー"), "ー"); // Not match
            Assert.AreEqual(KanaConverter.ToHiragana("ヽ"), "ゝ");
            Assert.AreEqual(KanaConverter.ToHiragana("ヾ"), "ゞ");
            Assert.AreEqual(KanaConverter.ToHiragana("ヿ"), "ヿ"); // Not match
        } //ConvertToSingleHiraganaTest

        [TestMethod]
        public void SpecialCharacters()
        {
            //結合文字
            Assert.AreEqual(KanaConverter.ToHiragana("あ゙"), "あ゙","A100");
            Assert.AreEqual(KanaConverter.ToKatakana("あ゙"), "ア゙", "A200");
           

        }



        [TestMethod]
        public void VariousSentences()
        {
            //using System.IO.StreamWriter writer = new(@"C:\temp\tests.txt");


            string value = "";
            string expected = "";
            string actual = "";

            //▼
            value = "Unicode（ユニコード）は、符号化文字集合や文字符号化方式などを定めた、文字コードの業界規格。";
            expected = "Unicode（ゆにこーど）は、符号化文字集合や文字符号化方式などを定めた、文字こーどの業界規格。";    
               
            actual = KanaConverter.ToHiragana(value);
            Assert.AreEqual(expected, actual);
            //writer.WriteLine(actual);

            //▼
            expected = "Unicode（ユニコード）ハ、符号化文字集合ヤ文字符号化方式ナドヲ定メタ、文字コードノ業界規格。";
            actual = KanaConverter.ToKatakana(value);
            Assert.AreEqual(expected, actual);
            //writer.WriteLine(actual);

            //▼
            value = "文字集合（文字セット）が単一の大規模文字セットであること（「Uni」という名はそれに由来する）などが特徴である。";
            expected = "文字集合（文字せっと）が単一の大規模文字せっとであること（「Uni」という名はそれに由来する）などが特徴である。";

            actual = KanaConverter.ToHiragana(value);
            Assert.AreEqual(expected, actual);
            //writer.WriteLine(actual);

            //▼
            expected = "文字集合（文字セット）ガ単一ノ大規模文字セットデアルコト（「Uni」トイウ名ハソレニ由来スル）ナドガ特徴デアル。";
            actual = KanaConverter.ToKatakana(value);
            Assert.AreEqual(expected, actual);
            //writer.WriteLine(actual);


            //▼
            value = "東京タワー🗼富士山🗻モアイ🗿かに座♋ゆきだるま⛄𩸽🐡";
            expected = "東京たわー🗼富士山🗻もあい🗿かに座♋ゆきだるま⛄𩸽🐡";

            actual = KanaConverter.ToHiragana(value);
            Assert.AreEqual(expected, actual);
            //writer.WriteLine(actual);

            //▼
            expected = "東京タワー🗼富士山🗻モアイ🗿カニ座♋ユキダルマ⛄𩸽🐡";
            actual = KanaConverter.ToKatakana(value);
            Assert.AreEqual(expected, actual);
            //writer.WriteLine(actual);

            //▼
            value = "الإيموجي (بالروماجي: Emoji، 絵文字えもじ تُنطق تلفظ ياباني: ‎[emodʑi]‏(أيه‌موجي))هو مصطلح ياباني الأصل ويعني اصطلاحًا الصور";
            expected = "الإيموجي (بالروماجي: Emoji، 絵文字えもじ تُنطق تلفظ ياباني: ‎[emodʑi]‏(أيه‌موجي))هو مصطلح ياباني الأصل ويعني اصطلاحًا الصور";

            actual = KanaConverter.ToHiragana(value);
            Assert.AreEqual(expected, actual);
            //writer.WriteLine(actual);

            //▼
            expected = "الإيموجي (بالروماجي: Emoji، 絵文字エモジ تُنطق تلفظ ياباني: ‎[emodʑi]‏(أيه‌موجي))هو مصطلح ياباني الأصل ويعني اصطلاحًا الصور";
            actual = KanaConverter.ToKatakana(value);
            Assert.AreEqual(expected, actual);
            //writer.WriteLine(actual);

            //▼
            value = "例如U+1F468男人、U+200D ZWJ、U+1F469女人、U+200D ZWJ、U+1F467女孩(👨‍👩‍👧)在系统支持的情况下会显示为一个男人一个女人和一个女孩组成的家庭绘文字，而不支持的系统则会顺序显示这三个绘文字(👨👩👧)。";
            expected = "例如U+1F468男人、U+200D ZWJ、U+1F469女人、U+200D ZWJ、U+1F467女孩(👨‍👩‍👧)在系统支持的情况下会显示为一个男人一个女人和一个女孩组成的家庭绘文字，而不支持的系统则会顺序显示这三个绘文字(👨👩👧)。";


            actual = KanaConverter.ToHiragana(value);
            Assert.AreEqual(expected, actual);
            //writer.WriteLine(actual);

            //▼
            expected = "例如U+1F468男人、U+200D ZWJ、U+1F469女人、U+200D ZWJ、U+1F467女孩(👨‍👩‍👧)在系统支持的情况下会显示为一个男人一个女人和一个女孩组成的家庭绘文字，而不支持的系统则会顺序显示这三个绘文字(👨👩👧)。";

            actual = KanaConverter.ToKatakana(value);
            Assert.AreEqual(expected, actual);
            //writer.WriteLine(actual);
        }
    }
}