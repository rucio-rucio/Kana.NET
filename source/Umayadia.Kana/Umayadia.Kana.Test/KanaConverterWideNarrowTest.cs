using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Umayadia.Kana.Test
{
    [TestClass]
    public class KanaConverterWideNarrowTest
    {
        [TestMethod]
        public void ConvertToWide()
        {
            KanaConverter.MapToHiragana = null;
            KanaConverter.MapToKatakana = null;

            //▼Basic Latin
            Assert.AreEqual(KanaConverter.ToWide("\u005C"), "￥");
            Assert.AreEqual(KanaConverter.ToWide("\u201D"), "”");
            Assert.AreEqual(KanaConverter.ToWide("\u0027"), "’");
            Assert.AreEqual(KanaConverter.ToWide(" "), "\u3000"); // "\u3000" = "　"
            Assert.AreEqual(KanaConverter.ToWide("!"), "！");
            Assert.AreEqual(KanaConverter.ToWide("#"), "＃");
            Assert.AreEqual(KanaConverter.ToWide("$"), "＄");
            Assert.AreEqual(KanaConverter.ToWide("%"), "％");
            Assert.AreEqual(KanaConverter.ToWide("&"), "＆");
            Assert.AreEqual(KanaConverter.ToWide("'"), "’");
            Assert.AreEqual(KanaConverter.ToWide("("), "（");
            Assert.AreEqual(KanaConverter.ToWide(")"), "）");
            Assert.AreEqual(KanaConverter.ToWide("*"), "＊");
            Assert.AreEqual(KanaConverter.ToWide("+"), "＋");
            Assert.AreEqual(KanaConverter.ToWide(","), "，");
            Assert.AreEqual(KanaConverter.ToWide("-"), "－");
            Assert.AreEqual(KanaConverter.ToWide("."), "．");
            Assert.AreEqual(KanaConverter.ToWide("/"), "／");
            Assert.AreEqual(KanaConverter.ToWide("0"), "０");
            Assert.AreEqual(KanaConverter.ToWide("1"), "１");
            Assert.AreEqual(KanaConverter.ToWide("2"), "２");
            Assert.AreEqual(KanaConverter.ToWide("3"), "３");
            Assert.AreEqual(KanaConverter.ToWide("4"), "４");
            Assert.AreEqual(KanaConverter.ToWide("5"), "５");
            Assert.AreEqual(KanaConverter.ToWide("6"), "６");
            Assert.AreEqual(KanaConverter.ToWide("7"), "７");
            Assert.AreEqual(KanaConverter.ToWide("8"), "８");
            Assert.AreEqual(KanaConverter.ToWide("9"), "９");
            Assert.AreEqual(KanaConverter.ToWide(":"), "：");
            Assert.AreEqual(KanaConverter.ToWide(";"), "；");
            Assert.AreEqual(KanaConverter.ToWide("<"), "＜");
            Assert.AreEqual(KanaConverter.ToWide("="), "＝");
            Assert.AreEqual(KanaConverter.ToWide(">"), "＞");
            Assert.AreEqual(KanaConverter.ToWide("?"), "？");
            Assert.AreEqual(KanaConverter.ToWide("@"), "＠");

            Assert.AreEqual(KanaConverter.ToWide("A"), "Ａ");
            Assert.AreEqual(KanaConverter.ToWide("B"), "Ｂ");
            Assert.AreEqual(KanaConverter.ToWide("C"), "Ｃ");
            Assert.AreEqual(KanaConverter.ToWide("D"), "Ｄ");
            Assert.AreEqual(KanaConverter.ToWide("E"), "Ｅ");
            Assert.AreEqual(KanaConverter.ToWide("F"), "Ｆ");
            Assert.AreEqual(KanaConverter.ToWide("G"), "Ｇ");
            Assert.AreEqual(KanaConverter.ToWide("H"), "Ｈ");
            Assert.AreEqual(KanaConverter.ToWide("I"), "Ｉ");
            Assert.AreEqual(KanaConverter.ToWide("J"), "Ｊ");
            Assert.AreEqual(KanaConverter.ToWide("K"), "Ｋ");
            Assert.AreEqual(KanaConverter.ToWide("L"), "Ｌ");
            Assert.AreEqual(KanaConverter.ToWide("M"), "Ｍ");
            Assert.AreEqual(KanaConverter.ToWide("N"), "Ｎ");
            Assert.AreEqual(KanaConverter.ToWide("O"), "Ｏ");
            Assert.AreEqual(KanaConverter.ToWide("P"), "Ｐ");
            Assert.AreEqual(KanaConverter.ToWide("Q"), "Ｑ");
            Assert.AreEqual(KanaConverter.ToWide("R"), "Ｒ");
            Assert.AreEqual(KanaConverter.ToWide("S"), "Ｓ");
            Assert.AreEqual(KanaConverter.ToWide("T"), "Ｔ");
            Assert.AreEqual(KanaConverter.ToWide("U"), "Ｕ");
            Assert.AreEqual(KanaConverter.ToWide("V"), "Ｖ");
            Assert.AreEqual(KanaConverter.ToWide("W"), "Ｗ");
            Assert.AreEqual(KanaConverter.ToWide("X"), "Ｘ");
            Assert.AreEqual(KanaConverter.ToWide("Y"), "Ｙ");
            Assert.AreEqual(KanaConverter.ToWide("Z"), "Ｚ");

            Assert.AreEqual(KanaConverter.ToWide("["), "［");
            Assert.AreEqual(KanaConverter.ToWide("]"), "］");
            Assert.AreEqual(KanaConverter.ToWide("^"), "＾");
            Assert.AreEqual(KanaConverter.ToWide("_"), "＿");
            Assert.AreEqual(KanaConverter.ToWide("`"), "｀");

            Assert.AreEqual(KanaConverter.ToWide("a"), "ａ");
            Assert.AreEqual(KanaConverter.ToWide("b"), "ｂ");
            Assert.AreEqual(KanaConverter.ToWide("c"), "ｃ");
            Assert.AreEqual(KanaConverter.ToWide("d"), "ｄ");
            Assert.AreEqual(KanaConverter.ToWide("e"), "ｅ");
            Assert.AreEqual(KanaConverter.ToWide("f"), "ｆ");
            Assert.AreEqual(KanaConverter.ToWide("g"), "ｇ");
            Assert.AreEqual(KanaConverter.ToWide("h"), "ｈ");
            Assert.AreEqual(KanaConverter.ToWide("i"), "ｉ");
            Assert.AreEqual(KanaConverter.ToWide("j"), "ｊ");
            Assert.AreEqual(KanaConverter.ToWide("k"), "ｋ");
            Assert.AreEqual(KanaConverter.ToWide("l"), "ｌ");
            Assert.AreEqual(KanaConverter.ToWide("m"), "ｍ");
            Assert.AreEqual(KanaConverter.ToWide("n"), "ｎ");
            Assert.AreEqual(KanaConverter.ToWide("o"), "ｏ");
            Assert.AreEqual(KanaConverter.ToWide("p"), "ｐ");
            Assert.AreEqual(KanaConverter.ToWide("q"), "ｑ");
            Assert.AreEqual(KanaConverter.ToWide("r"), "ｒ");
            Assert.AreEqual(KanaConverter.ToWide("s"), "ｓ");
            Assert.AreEqual(KanaConverter.ToWide("t"), "ｔ");
            Assert.AreEqual(KanaConverter.ToWide("u"), "ｕ");
            Assert.AreEqual(KanaConverter.ToWide("v"), "ｖ");
            Assert.AreEqual(KanaConverter.ToWide("w"), "ｗ");
            Assert.AreEqual(KanaConverter.ToWide("x"), "ｘ");
            Assert.AreEqual(KanaConverter.ToWide("y"), "ｙ");
            Assert.AreEqual(KanaConverter.ToWide("z"), "ｚ");

            Assert.AreEqual(KanaConverter.ToWide("{"), "｛");
            Assert.AreEqual(KanaConverter.ToWide("|"), "｜");
            Assert.AreEqual(KanaConverter.ToWide("}"), "｝");
            Assert.AreEqual(KanaConverter.ToWide("~"), "～");

            //▼Special Symbols
            Assert.AreEqual(KanaConverter.ToWide("¢"), "￠");
            Assert.AreEqual(KanaConverter.ToWide("£"), "￡");
            Assert.AreEqual(KanaConverter.ToWide("\u00A5"), "￥");

            Assert.AreEqual(KanaConverter.ToWide("⸨"), "｟");    // U+2E28 to U+FF5F
            Assert.AreEqual(KanaConverter.ToWide("⸩"), "｠");    // U+2E29 to U+FF60

            //▼Half width Katakana
            Assert.AreEqual(KanaConverter.ToWide("ｦ"), "ヲ");
            Assert.AreEqual(KanaConverter.ToWide("｢"), "「");
            Assert.AreEqual(KanaConverter.ToWide("｣"), "」");
            Assert.AreEqual(KanaConverter.ToWide("､"), "、");
            Assert.AreEqual(KanaConverter.ToWide("･"), "・");
            Assert.AreEqual(KanaConverter.ToWide("｡"), "。");
            Assert.AreEqual(KanaConverter.ToWide("ｧ"), "ァ");
            Assert.AreEqual(KanaConverter.ToWide("ｨ"), "ィ");
            Assert.AreEqual(KanaConverter.ToWide("ｩ"), "ゥ");
            Assert.AreEqual(KanaConverter.ToWide("ｪ"), "ェ");
            Assert.AreEqual(KanaConverter.ToWide("ｫ"), "ォ");
            Assert.AreEqual(KanaConverter.ToWide("ｬ"), "ャ");
            Assert.AreEqual(KanaConverter.ToWide("ｭ"), "ュ");
            Assert.AreEqual(KanaConverter.ToWide("ｮ"), "ョ");
            Assert.AreEqual(KanaConverter.ToWide("ｯ"), "ッ");
            Assert.AreEqual(KanaConverter.ToWide("ｰ"), "ー");
            Assert.AreEqual(KanaConverter.ToWide("ｱ"), "ア");
            Assert.AreEqual(KanaConverter.ToWide("ｲ"), "イ");
            Assert.AreEqual(KanaConverter.ToWide("ｳ"), "ウ");
            Assert.AreEqual(KanaConverter.ToWide("ｴ"), "エ");
            Assert.AreEqual(KanaConverter.ToWide("ｵ"), "オ");
            Assert.AreEqual(KanaConverter.ToWide("ｶ"), "カ");
            Assert.AreEqual(KanaConverter.ToWide("ｷ"), "キ");
            Assert.AreEqual(KanaConverter.ToWide("ｸ"), "ク");
            Assert.AreEqual(KanaConverter.ToWide("ｹ"), "ケ");
            Assert.AreEqual(KanaConverter.ToWide("ｺ"), "コ");
            Assert.AreEqual(KanaConverter.ToWide("ｻ"), "サ");
            Assert.AreEqual(KanaConverter.ToWide("ｼ"), "シ");
            Assert.AreEqual(KanaConverter.ToWide("ｽ"), "ス");
            Assert.AreEqual(KanaConverter.ToWide("ｾ"), "セ");
            Assert.AreEqual(KanaConverter.ToWide("ｿ"), "ソ");
            Assert.AreEqual(KanaConverter.ToWide("ﾀ"), "タ");
            Assert.AreEqual(KanaConverter.ToWide("ﾁ"), "チ");
            Assert.AreEqual(KanaConverter.ToWide("ﾂ"), "ツ");
            Assert.AreEqual(KanaConverter.ToWide("ﾃ"), "テ");
            Assert.AreEqual(KanaConverter.ToWide("ﾄ"), "ト");
            Assert.AreEqual(KanaConverter.ToWide("ﾅ"), "ナ");
            Assert.AreEqual(KanaConverter.ToWide("ﾆ"), "ニ");
            Assert.AreEqual(KanaConverter.ToWide("ﾇ"), "ヌ");
            Assert.AreEqual(KanaConverter.ToWide("ﾈ"), "ネ");
            Assert.AreEqual(KanaConverter.ToWide("ﾉ"), "ノ");
            Assert.AreEqual(KanaConverter.ToWide("ﾊ"), "ハ");
            Assert.AreEqual(KanaConverter.ToWide("ﾋ"), "ヒ");
            Assert.AreEqual(KanaConverter.ToWide("ﾌ"), "フ");
            Assert.AreEqual(KanaConverter.ToWide("ﾍ"), "ヘ");
            Assert.AreEqual(KanaConverter.ToWide("ﾎ"), "ホ");
            Assert.AreEqual(KanaConverter.ToWide("ﾏ"), "マ");
            Assert.AreEqual(KanaConverter.ToWide("ﾐ"), "ミ");
            Assert.AreEqual(KanaConverter.ToWide("ﾑ"), "ム");
            Assert.AreEqual(KanaConverter.ToWide("ﾒ"), "メ");
            Assert.AreEqual(KanaConverter.ToWide("ﾓ"), "モ");
            Assert.AreEqual(KanaConverter.ToWide("ﾔ"), "ヤ");
            Assert.AreEqual(KanaConverter.ToWide("ﾕ"), "ユ");
            Assert.AreEqual(KanaConverter.ToWide("ﾖ"), "ヨ");
            Assert.AreEqual(KanaConverter.ToWide("ﾗ"), "ラ");
            Assert.AreEqual(KanaConverter.ToWide("ﾘ"), "リ");
            Assert.AreEqual(KanaConverter.ToWide("ﾙ"), "ル");
            Assert.AreEqual(KanaConverter.ToWide("ﾚ"), "レ");
            Assert.AreEqual(KanaConverter.ToWide("ﾛ"), "ロ");
            Assert.AreEqual(KanaConverter.ToWide("ﾜ"), "ワ");
            Assert.AreEqual(KanaConverter.ToWide("ﾝ"), "ン");
            Assert.AreEqual(KanaConverter.ToWide("ﾞ"), "゛");
            Assert.AreEqual(KanaConverter.ToWide("ﾟ"), "゜");

            //▼Combination
            Assert.AreEqual(KanaConverter.ToWide("ｶﾞ"), "ガ");
            Assert.AreEqual(KanaConverter.ToWide("ｷﾞ"), "ギ");
            Assert.AreEqual(KanaConverter.ToWide("ｸﾞ"), "グ");
            Assert.AreEqual(KanaConverter.ToWide("ｹﾞ"), "ゲ");
            Assert.AreEqual(KanaConverter.ToWide("ｺﾞ"), "ゴ");
            Assert.AreEqual(KanaConverter.ToWide("ｻﾞ"), "ザ");
            Assert.AreEqual(KanaConverter.ToWide("ｼﾞ"), "ジ");
            Assert.AreEqual(KanaConverter.ToWide("ｽﾞ"), "ズ");
            Assert.AreEqual(KanaConverter.ToWide("ｾﾞ"), "ゼ");
            Assert.AreEqual(KanaConverter.ToWide("ｿﾞ"), "ゾ");
            Assert.AreEqual(KanaConverter.ToWide("ﾀﾞ"), "ダ");
            Assert.AreEqual(KanaConverter.ToWide("ﾁﾞ"), "ヂ");
            Assert.AreEqual(KanaConverter.ToWide("ﾂﾞ"), "ヅ");
            Assert.AreEqual(KanaConverter.ToWide("ﾃﾞ"), "デ");
            Assert.AreEqual(KanaConverter.ToWide("ﾄﾞ"), "ド");
            Assert.AreEqual(KanaConverter.ToWide("ﾊﾞ"), "バ");
            Assert.AreEqual(KanaConverter.ToWide("ﾊﾟ"), "パ");
            Assert.AreEqual(KanaConverter.ToWide("ﾋﾞ"), "ビ");
            Assert.AreEqual(KanaConverter.ToWide("ﾋﾟ"), "ピ");
            Assert.AreEqual(KanaConverter.ToWide("ﾌﾞ"), "ブ");
            Assert.AreEqual(KanaConverter.ToWide("ﾌﾟ"), "プ");
            Assert.AreEqual(KanaConverter.ToWide("ﾍﾞ"), "ベ");
            Assert.AreEqual(KanaConverter.ToWide("ﾍﾟ"), "ペ");
            Assert.AreEqual(KanaConverter.ToWide("ﾎﾞ"), "ボ");
            Assert.AreEqual(KanaConverter.ToWide("ﾎﾟ"), "ポ");
            Assert.AreEqual(KanaConverter.ToWide("ｳﾞ"), "ヴ");
            Assert.AreEqual(KanaConverter.ToWide("ﾜﾞ"), "ヷ");
            Assert.AreEqual(KanaConverter.ToWide("ｦﾞ"), "ヺ");

        } //ConvertToWide

        [TestMethod]
        public void ConvertNotToWide()
        {
            //Note: Surroage region is U+D800 to U+DFFF
            for (int codePoint = 0; codePoint < 0xFFFF; codePoint++)
            {
                char c = (char)codePoint;

                if (c == '\u005C'
                    || c >= '\u0020' && c <= '\u007E'
                    || c == '\u00A2' || c == '\u00A3' || c == '\u00A5' || c == '\u2E28' || c == '\u2E29'
                    || c >= '\uFF61' && c <= '\uFF9F')
                {
                    continue;
                }

                string actual = KanaConverter.ToWide(c.ToString());
                Assert.AreEqual(c.ToString(), actual, $"{c}({codePoint:X})");
            }

         
        } //ConvertNotToWide

        [TestMethod]
        public void ConvertToNarrow()
        {
            Assert.AreEqual(KanaConverter.ToNarrow("‘"), "'"); // U+2018
            Assert.AreEqual(KanaConverter.ToNarrow("’"), "'"); // U+2019
            Assert.AreEqual(KanaConverter.ToNarrow("“"), "\""); // U+201C
            Assert.AreEqual(KanaConverter.ToNarrow("”"), "\""); // U+201D
            Assert.AreEqual(KanaConverter.ToNarrow("　"), " "); // U+3000
            Assert.AreEqual(KanaConverter.ToNarrow("、"), "､"); // U+3001
            Assert.AreEqual(KanaConverter.ToNarrow("。"), "｡"); // U+3002
            Assert.AreEqual(KanaConverter.ToNarrow("「"), "｢"); // U+300C
            Assert.AreEqual(KanaConverter.ToNarrow("」"), "｣"); // U+300D
            Assert.AreEqual(KanaConverter.ToNarrow("゙"), "ﾞ"); // U+3099
            Assert.AreEqual(KanaConverter.ToNarrow("゚"), "ﾟ"); // U+309A
            Assert.AreEqual(KanaConverter.ToNarrow("゛"), "ﾞ"); // U+309B
            Assert.AreEqual(KanaConverter.ToNarrow("゜"), "ﾟ"); // U+309C
            Assert.AreEqual(KanaConverter.ToNarrow("ァ"), "ｧ"); // U+30A1
            Assert.AreEqual(KanaConverter.ToNarrow("ア"), "ｱ"); // U+30A2
            Assert.AreEqual(KanaConverter.ToNarrow("ィ"), "ｨ"); // U+30A3
            Assert.AreEqual(KanaConverter.ToNarrow("イ"), "ｲ"); // U+30A4
            Assert.AreEqual(KanaConverter.ToNarrow("ゥ"), "ｩ"); // U+30A5
            Assert.AreEqual(KanaConverter.ToNarrow("ウ"), "ｳ"); // U+30A6
            Assert.AreEqual(KanaConverter.ToNarrow("ェ"), "ｪ"); // U+30A7
            Assert.AreEqual(KanaConverter.ToNarrow("エ"), "ｴ"); // U+30A8
            Assert.AreEqual(KanaConverter.ToNarrow("ォ"), "ｫ"); // U+30A9
            Assert.AreEqual(KanaConverter.ToNarrow("オ"), "ｵ"); // U+30AA
            Assert.AreEqual(KanaConverter.ToNarrow("カ"), "ｶ"); // U+30AB
            Assert.AreEqual(KanaConverter.ToNarrow("ガ"), "ｶﾞ"); // U+30AC
            Assert.AreEqual(KanaConverter.ToNarrow("キ"), "ｷ"); // U+30AD
            Assert.AreEqual(KanaConverter.ToNarrow("ギ"), "ｷﾞ"); // U+30AE
            Assert.AreEqual(KanaConverter.ToNarrow("ク"), "ｸ"); // U+30AF
            Assert.AreEqual(KanaConverter.ToNarrow("グ"), "ｸﾞ"); // U+30B0
            Assert.AreEqual(KanaConverter.ToNarrow("ケ"), "ｹ"); // U+30B1
            Assert.AreEqual(KanaConverter.ToNarrow("ゲ"), "ｹﾞ"); // U+30B2
            Assert.AreEqual(KanaConverter.ToNarrow("コ"), "ｺ"); // U+30B3
            Assert.AreEqual(KanaConverter.ToNarrow("ゴ"), "ｺﾞ"); // U+30B4
            Assert.AreEqual(KanaConverter.ToNarrow("サ"), "ｻ"); // U+30B5
            Assert.AreEqual(KanaConverter.ToNarrow("ザ"), "ｻﾞ"); // U+30B6
            Assert.AreEqual(KanaConverter.ToNarrow("シ"), "ｼ"); // U+30B7
            Assert.AreEqual(KanaConverter.ToNarrow("ジ"), "ｼﾞ"); // U+30B8
            Assert.AreEqual(KanaConverter.ToNarrow("ス"), "ｽ"); // U+30B9
            Assert.AreEqual(KanaConverter.ToNarrow("ズ"), "ｽﾞ"); // U+30BA
            Assert.AreEqual(KanaConverter.ToNarrow("セ"), "ｾ"); // U+30BB
            Assert.AreEqual(KanaConverter.ToNarrow("ゼ"), "ｾﾞ"); // U+30BC
            Assert.AreEqual(KanaConverter.ToNarrow("ソ"), "ｿ"); // U+30BD
            Assert.AreEqual(KanaConverter.ToNarrow("ゾ"), "ｿﾞ"); // U+30BE
            Assert.AreEqual(KanaConverter.ToNarrow("タ"), "ﾀ"); // U+30BF
            Assert.AreEqual(KanaConverter.ToNarrow("ダ"), "ﾀﾞ"); // U+30C0
            Assert.AreEqual(KanaConverter.ToNarrow("チ"), "ﾁ"); // U+30C1
            Assert.AreEqual(KanaConverter.ToNarrow("ヂ"), "ﾁﾞ"); // U+30C2
            Assert.AreEqual(KanaConverter.ToNarrow("ッ"), "ｯ"); // U+30C3
            Assert.AreEqual(KanaConverter.ToNarrow("ツ"), "ﾂ"); // U+30C4
            Assert.AreEqual(KanaConverter.ToNarrow("ヅ"), "ﾂﾞ"); // U+30C5
            Assert.AreEqual(KanaConverter.ToNarrow("テ"), "ﾃ"); // U+30C6
            Assert.AreEqual(KanaConverter.ToNarrow("デ"), "ﾃﾞ"); // U+30C7
            Assert.AreEqual(KanaConverter.ToNarrow("ト"), "ﾄ"); // U+30C8
            Assert.AreEqual(KanaConverter.ToNarrow("ド"), "ﾄﾞ"); // U+30C9
            Assert.AreEqual(KanaConverter.ToNarrow("ナ"), "ﾅ"); // U+30CA
            Assert.AreEqual(KanaConverter.ToNarrow("ニ"), "ﾆ"); // U+30CB
            Assert.AreEqual(KanaConverter.ToNarrow("ヌ"), "ﾇ"); // U+30CC
            Assert.AreEqual(KanaConverter.ToNarrow("ネ"), "ﾈ"); // U+30CD
            Assert.AreEqual(KanaConverter.ToNarrow("ノ"), "ﾉ"); // U+30CE
            Assert.AreEqual(KanaConverter.ToNarrow("ハ"), "ﾊ"); // U+30CF
            Assert.AreEqual(KanaConverter.ToNarrow("バ"), "ﾊﾞ"); // U+30D0
            Assert.AreEqual(KanaConverter.ToNarrow("パ"), "ﾊﾟ"); // U+30D1
            Assert.AreEqual(KanaConverter.ToNarrow("ヒ"), "ﾋ"); // U+30D2
            Assert.AreEqual(KanaConverter.ToNarrow("ビ"), "ﾋﾞ"); // U+30D3
            Assert.AreEqual(KanaConverter.ToNarrow("ピ"), "ﾋﾟ"); // U+30D4
            Assert.AreEqual(KanaConverter.ToNarrow("フ"), "ﾌ"); // U+30D5
            Assert.AreEqual(KanaConverter.ToNarrow("ブ"), "ﾌﾞ"); // U+30D6
            Assert.AreEqual(KanaConverter.ToNarrow("プ"), "ﾌﾟ"); // U+30D7
            Assert.AreEqual(KanaConverter.ToNarrow("ヘ"), "ﾍ"); // U+30D8
            Assert.AreEqual(KanaConverter.ToNarrow("ベ"), "ﾍﾞ"); // U+30D9
            Assert.AreEqual(KanaConverter.ToNarrow("ペ"), "ﾍﾟ"); // U+30DA
            Assert.AreEqual(KanaConverter.ToNarrow("ホ"), "ﾎ"); // U+30DB
            Assert.AreEqual(KanaConverter.ToNarrow("ボ"), "ﾎﾞ"); // U+30DC
            Assert.AreEqual(KanaConverter.ToNarrow("ポ"), "ﾎﾟ"); // U+30DD
            Assert.AreEqual(KanaConverter.ToNarrow("マ"), "ﾏ"); // U+30DE
            Assert.AreEqual(KanaConverter.ToNarrow("ミ"), "ﾐ"); // U+30DF
            Assert.AreEqual(KanaConverter.ToNarrow("ム"), "ﾑ"); // U+30E0
            Assert.AreEqual(KanaConverter.ToNarrow("メ"), "ﾒ"); // U+30E1
            Assert.AreEqual(KanaConverter.ToNarrow("モ"), "ﾓ"); // U+30E2
            Assert.AreEqual(KanaConverter.ToNarrow("ャ"), "ｬ"); // U+30E3
            Assert.AreEqual(KanaConverter.ToNarrow("ヤ"), "ﾔ"); // U+30E4
            Assert.AreEqual(KanaConverter.ToNarrow("ュ"), "ｭ"); // U+30E5
            Assert.AreEqual(KanaConverter.ToNarrow("ユ"), "ﾕ"); // U+30E6
            Assert.AreEqual(KanaConverter.ToNarrow("ョ"), "ｮ"); // U+30E7
            Assert.AreEqual(KanaConverter.ToNarrow("ヨ"), "ﾖ"); // U+30E8
            Assert.AreEqual(KanaConverter.ToNarrow("ラ"), "ﾗ"); // U+30E9
            Assert.AreEqual(KanaConverter.ToNarrow("リ"), "ﾘ"); // U+30EA
            Assert.AreEqual(KanaConverter.ToNarrow("ル"), "ﾙ"); // U+30EB
            Assert.AreEqual(KanaConverter.ToNarrow("レ"), "ﾚ"); // U+30EC
            Assert.AreEqual(KanaConverter.ToNarrow("ロ"), "ﾛ"); // U+30ED
            Assert.AreEqual(KanaConverter.ToNarrow("ヮ"), "ヮ"); // U+30EE
            Assert.AreEqual(KanaConverter.ToNarrow("ワ"), "ﾜ"); // U+30EF
            Assert.AreEqual(KanaConverter.ToNarrow("ヲ"), "ｦ"); // U+30F2
            Assert.AreEqual(KanaConverter.ToNarrow("ン"), "ﾝ"); // U+30F3
            Assert.AreEqual(KanaConverter.ToNarrow("ヴ"), "ｳﾞ"); // U+30F4
            Assert.AreEqual(KanaConverter.ToNarrow("ヷ"), "ﾜﾞ"); // U+30F7
            Assert.AreEqual(KanaConverter.ToNarrow("ヺ"), "ｦﾞ"); // U+30FA
            Assert.AreEqual(KanaConverter.ToNarrow("・"), "･"); // U+30FB
            Assert.AreEqual(KanaConverter.ToNarrow("ー"), "ｰ"); // U+30FC
            Assert.AreEqual(KanaConverter.ToNarrow("！"), "!"); // U+FF01
            Assert.AreEqual(KanaConverter.ToNarrow("＂"), "\""); // U+FF02
            Assert.AreEqual(KanaConverter.ToNarrow("＃"), "#"); // U+FF03
            Assert.AreEqual(KanaConverter.ToNarrow("＄"), "$"); // U+FF04
            Assert.AreEqual(KanaConverter.ToNarrow("％"), "%"); // U+FF05
            Assert.AreEqual(KanaConverter.ToNarrow("＆"), "&"); // U+FF06
            Assert.AreEqual(KanaConverter.ToNarrow("＇"), "'"); // U+FF07
            Assert.AreEqual(KanaConverter.ToNarrow("（"), "("); // U+FF08
            Assert.AreEqual(KanaConverter.ToNarrow("）"), ")"); // U+FF09
            Assert.AreEqual(KanaConverter.ToNarrow("＊"), "*"); // U+FF0A
            Assert.AreEqual(KanaConverter.ToNarrow("＋"), "+"); // U+FF0B
            Assert.AreEqual(KanaConverter.ToNarrow("，"), ","); // U+FF0C
            Assert.AreEqual(KanaConverter.ToNarrow("－"), "-"); // U+FF0D
            Assert.AreEqual(KanaConverter.ToNarrow("．"), "."); // U+FF0E
            Assert.AreEqual(KanaConverter.ToNarrow("／"), "/"); // U+FF0F
            Assert.AreEqual(KanaConverter.ToNarrow("０"), "0"); // U+FF10
            Assert.AreEqual(KanaConverter.ToNarrow("１"), "1"); // U+FF11
            Assert.AreEqual(KanaConverter.ToNarrow("２"), "2"); // U+FF12
            Assert.AreEqual(KanaConverter.ToNarrow("３"), "3"); // U+FF13
            Assert.AreEqual(KanaConverter.ToNarrow("４"), "4"); // U+FF14
            Assert.AreEqual(KanaConverter.ToNarrow("５"), "5"); // U+FF15
            Assert.AreEqual(KanaConverter.ToNarrow("６"), "6"); // U+FF16
            Assert.AreEqual(KanaConverter.ToNarrow("７"), "7"); // U+FF17
            Assert.AreEqual(KanaConverter.ToNarrow("８"), "8"); // U+FF18
            Assert.AreEqual(KanaConverter.ToNarrow("９"), "9"); // U+FF19
            Assert.AreEqual(KanaConverter.ToNarrow("："), ":"); // U+FF1A
            Assert.AreEqual(KanaConverter.ToNarrow("；"), ";"); // U+FF1B
            Assert.AreEqual(KanaConverter.ToNarrow("＜"), "<"); // U+FF1C
            Assert.AreEqual(KanaConverter.ToNarrow("＝"), "="); // U+FF1D
            Assert.AreEqual(KanaConverter.ToNarrow("＞"), ">"); // U+FF1E
            Assert.AreEqual(KanaConverter.ToNarrow("？"), "?"); // U+FF1F
            Assert.AreEqual(KanaConverter.ToNarrow("＠"), "@"); // U+FF20
            Assert.AreEqual(KanaConverter.ToNarrow("Ａ"), "A"); // U+FF21
            Assert.AreEqual(KanaConverter.ToNarrow("Ｂ"), "B"); // U+FF22
            Assert.AreEqual(KanaConverter.ToNarrow("Ｃ"), "C"); // U+FF23
            Assert.AreEqual(KanaConverter.ToNarrow("Ｄ"), "D"); // U+FF24
            Assert.AreEqual(KanaConverter.ToNarrow("Ｅ"), "E"); // U+FF25
            Assert.AreEqual(KanaConverter.ToNarrow("Ｆ"), "F"); // U+FF26
            Assert.AreEqual(KanaConverter.ToNarrow("Ｇ"), "G"); // U+FF27
            Assert.AreEqual(KanaConverter.ToNarrow("Ｈ"), "H"); // U+FF28
            Assert.AreEqual(KanaConverter.ToNarrow("Ｉ"), "I"); // U+FF29
            Assert.AreEqual(KanaConverter.ToNarrow("Ｊ"), "J"); // U+FF2A
            Assert.AreEqual(KanaConverter.ToNarrow("Ｋ"), "K"); // U+FF2B
            Assert.AreEqual(KanaConverter.ToNarrow("Ｌ"), "L"); // U+FF2C
            Assert.AreEqual(KanaConverter.ToNarrow("Ｍ"), "M"); // U+FF2D
            Assert.AreEqual(KanaConverter.ToNarrow("Ｎ"), "N"); // U+FF2E
            Assert.AreEqual(KanaConverter.ToNarrow("Ｏ"), "O"); // U+FF2F
            Assert.AreEqual(KanaConverter.ToNarrow("Ｐ"), "P"); // U+FF30
            Assert.AreEqual(KanaConverter.ToNarrow("Ｑ"), "Q"); // U+FF31
            Assert.AreEqual(KanaConverter.ToNarrow("Ｒ"), "R"); // U+FF32
            Assert.AreEqual(KanaConverter.ToNarrow("Ｓ"), "S"); // U+FF33
            Assert.AreEqual(KanaConverter.ToNarrow("Ｔ"), "T"); // U+FF34
            Assert.AreEqual(KanaConverter.ToNarrow("Ｕ"), "U"); // U+FF35
            Assert.AreEqual(KanaConverter.ToNarrow("Ｖ"), "V"); // U+FF36
            Assert.AreEqual(KanaConverter.ToNarrow("Ｗ"), "W"); // U+FF37
            Assert.AreEqual(KanaConverter.ToNarrow("Ｘ"), "X"); // U+FF38
            Assert.AreEqual(KanaConverter.ToNarrow("Ｙ"), "Y"); // U+FF39
            Assert.AreEqual(KanaConverter.ToNarrow("Ｚ"), "Z"); // U+FF3A
            Assert.AreEqual(KanaConverter.ToNarrow("［"), "["); // U+FF3B
            Assert.AreEqual(KanaConverter.ToNarrow("＼"), "\\"); // U+FF3C
            Assert.AreEqual(KanaConverter.ToNarrow("］"), "]"); // U+FF3D
            Assert.AreEqual(KanaConverter.ToNarrow("＾"), "^"); // U+FF3E
            Assert.AreEqual(KanaConverter.ToNarrow("＿"), "_"); // U+FF3F
            Assert.AreEqual(KanaConverter.ToNarrow("｀"), "`"); // U+FF40
            Assert.AreEqual(KanaConverter.ToNarrow("ａ"), "a"); // U+FF41
            Assert.AreEqual(KanaConverter.ToNarrow("ｂ"), "b"); // U+FF42
            Assert.AreEqual(KanaConverter.ToNarrow("ｃ"), "c"); // U+FF43
            Assert.AreEqual(KanaConverter.ToNarrow("ｄ"), "d"); // U+FF44
            Assert.AreEqual(KanaConverter.ToNarrow("ｅ"), "e"); // U+FF45
            Assert.AreEqual(KanaConverter.ToNarrow("ｆ"), "f"); // U+FF46
            Assert.AreEqual(KanaConverter.ToNarrow("ｇ"), "g"); // U+FF47
            Assert.AreEqual(KanaConverter.ToNarrow("ｈ"), "h"); // U+FF48
            Assert.AreEqual(KanaConverter.ToNarrow("ｉ"), "i"); // U+FF49
            Assert.AreEqual(KanaConverter.ToNarrow("ｊ"), "j"); // U+FF4A
            Assert.AreEqual(KanaConverter.ToNarrow("ｋ"), "k"); // U+FF4B
            Assert.AreEqual(KanaConverter.ToNarrow("ｌ"), "l"); // U+FF4C
            Assert.AreEqual(KanaConverter.ToNarrow("ｍ"), "m"); // U+FF4D
            Assert.AreEqual(KanaConverter.ToNarrow("ｎ"), "n"); // U+FF4E
            Assert.AreEqual(KanaConverter.ToNarrow("ｏ"), "o"); // U+FF4F
            Assert.AreEqual(KanaConverter.ToNarrow("ｐ"), "p"); // U+FF50
            Assert.AreEqual(KanaConverter.ToNarrow("ｑ"), "q"); // U+FF51
            Assert.AreEqual(KanaConverter.ToNarrow("ｒ"), "r"); // U+FF52
            Assert.AreEqual(KanaConverter.ToNarrow("ｓ"), "s"); // U+FF53
            Assert.AreEqual(KanaConverter.ToNarrow("ｔ"), "t"); // U+FF54
            Assert.AreEqual(KanaConverter.ToNarrow("ｕ"), "u"); // U+FF55
            Assert.AreEqual(KanaConverter.ToNarrow("ｖ"), "v"); // U+FF56
            Assert.AreEqual(KanaConverter.ToNarrow("ｗ"), "w"); // U+FF57
            Assert.AreEqual(KanaConverter.ToNarrow("ｘ"), "x"); // U+FF58
            Assert.AreEqual(KanaConverter.ToNarrow("ｙ"), "y"); // U+FF59
            Assert.AreEqual(KanaConverter.ToNarrow("ｚ"), "z"); // U+FF5A
            Assert.AreEqual(KanaConverter.ToNarrow("｛"), "{"); // U+FF5B
            Assert.AreEqual(KanaConverter.ToNarrow("｜"), "|"); // U+FF5C
            Assert.AreEqual(KanaConverter.ToNarrow("｝"), "}"); // U+FF5D
            Assert.AreEqual(KanaConverter.ToNarrow("～"), "~"); // U+FF5E
            Assert.AreEqual(KanaConverter.ToNarrow("｟"), "⸨"); // U+FF5F
            Assert.AreEqual(KanaConverter.ToNarrow("｠"), "⸩"); // U+FF60
            Assert.AreEqual(KanaConverter.ToNarrow("￠"), "¢"); // U+FFE0
            Assert.AreEqual(KanaConverter.ToNarrow("￡"), "£"); // U+FFE1
            Assert.AreEqual(KanaConverter.ToNarrow("￥"), "\\"); // U+FFE5


        } //ConvertToNarrow

        [TestMethod]
        public void ConvertNotToNarrow()
        {

            //Note: Surroage region is U+D800 to U+DFFF
            for (int codePoint = 0; codePoint < 0xFFFF; codePoint++)
            {
                char c = (char)codePoint;

                if (c == '\u2018' || c == '\u2019' || c == '\u201C' || c == '\u201D'
                    || c >= '\u3000' && c <= '\u3002'
                    || c == '\u300C' || c == '\u300D'
                    || c >= '\u3099' && c <= '\u309C'
                    || c >= '\u30A1' && c <= '\u30EF'
                    || c >= '\u30F2' && c <= '\u30F4'
                    || c >= '\u30F7'
                    || c >= '\u30FA' && c <= '\u30FC'
                    || c >= '\uFF01' && c <= '\uFF5E'
                    || c == '\uFF5F' || c == '\uFF60' || c == '\uFFE0' || c == '\uFFE1' || c == '\uFFE5')
                {
                    continue;
                }

                string actual = KanaConverter.ToNarrow(c.ToString());
                Assert.AreEqual(c.ToString(), actual, $"{c}({codePoint:X})");
            }


        } //ConvertNotToNarrow

        [TestMethod]
        public void ConvertToWideWithDiacritical()
        {

            KanaConverter.ResetToInitialSettings();

            //Diacritical mark at Last
            Assert.AreEqual("ガ", KanaConverter.ToWide("ｶﾞ"),"A1000");
            Assert.AreEqual("ザ゛", KanaConverter.ToWide("ｻﾞﾞ"),"A2000");
            Assert.AreEqual("゛バ", KanaConverter.ToWide("ﾞﾊﾞ"),"A3000");
            Assert.AreEqual("゛゛", KanaConverter.ToWide("ﾞﾞ"),"A4000"); //Irregular usage in Japanese orthography.

            //Diacritical mark at middle of string
            Assert.AreEqual("ゲム", KanaConverter.ToWide("ｹﾞﾑ"), "B1000");
            Assert.AreEqual("ジ゛ル", KanaConverter.ToWide("ｼﾞﾞﾙ"), "B2000");
            Assert.AreEqual("゛ダア", KanaConverter.ToWide("ﾞﾀﾞｱ"), "B3000");
            Assert.AreEqual("゛゛フ", KanaConverter.ToWide("ﾞﾞﾌ"), "B4000");

            //Irregular diacritical mark at last
            Assert.AreEqual("ラ゛", KanaConverter.ToWide("ﾗﾞ"), "C1000");
            Assert.AreEqual("ニ゛゛", KanaConverter.ToWide("ﾆﾞﾞ"), "C2000");
            Assert.AreEqual("゛オ゛", KanaConverter.ToWide("ﾞｵﾞ"), "C3000");

            //Irregular diacritical mark at middle of string
            Assert.AreEqual("メ゛キ", KanaConverter.ToWide("ﾒﾞｷ"), "D1000");
            Assert.AreEqual("レ゛゛ス", KanaConverter.ToWide("ﾚﾞﾞｽ"), "D2000");
            Assert.AreEqual("゛イ゛チ", KanaConverter.ToWide("ﾞｲﾞﾁ"), "D3000");
            Assert.AreEqual("゛゛ヘ", KanaConverter.ToWide("ﾞﾞﾍ"), "D4000");

            //Another diacritial mark in Japanese
            Assert.AreEqual("ポ", KanaConverter.ToWide("ﾎﾟ"), "E1000");
            Assert.AreEqual("パル", KanaConverter.ToWide("ﾊﾟﾙ"), "E2000");
            Assert.AreEqual("エ゜", KanaConverter.ToWide("ｴﾟ"), "E3000");
            Assert.AreEqual("゜ク゜コ", KanaConverter.ToWide("ﾟｸﾟｺ"), "E4000");

            //
            Assert.AreEqual("゜カギク゜ケゴパビ゛プ゜ベホ", 
                KanaConverter.ToWide("ﾟｶｷﾞｸﾟｹｺﾞﾊﾟﾋﾞﾞﾌﾟﾟﾍﾞﾎ"), "F1000");

        }
    }
}
