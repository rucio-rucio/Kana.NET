using Microsoft.VisualStudio.TestTools.UnitTesting;
using Umayadia.Kana;

namespace Umayadia.Kana.Test;

[TestClass]
public class VariousSentence
{
    [TestMethod]
    public void OnyankoClub()
    {

        string value = "おニャン子クラブ（おニャンこクラブ）は、"
                      + "1985年にフジテレビのテレビ番組『夕やけニャンニャン』から誕生した女性アイドルグループ。";

        Assert.AreEqual(
            "おにゃん子くらぶ（おにゃんこくらぶ）は、"
            + "1985年にふじてれびのてれび番組『夕やけにゃんにゃん』から誕生した女性あいどるぐるーぷ。",
            KanaConverter.ToHiragana(value), "A1000");

        Assert.AreEqual(
            "オニャン子クラブ（オニャンコクラブ）ハ、"
            + "1985年ニフジテレビノテレビ番組『夕ヤケニャンニャン』カラ誕生シタ女性アイドルグループ。",
        KanaConverter.ToKatakana(value), "A2000");

        Assert.AreEqual(
            "おニャン子クラブ（おニャンこクラブ）は、"
            + "１９８５年にフジテレビのテレビ番組『夕やけニャンニャン』から誕生した女性アイドルグループ。",
        KanaConverter.ToWide(value), "A3000");

        Assert.AreEqual(
            "おﾆｬﾝ子ｸﾗﾌﾞ(おﾆｬﾝこｸﾗﾌﾞ)は､"
            + "1985年にﾌｼﾞﾃﾚﾋﾞのﾃﾚﾋﾞ番組『夕やけﾆｬﾝﾆｬﾝ』から誕生した女性ｱｲﾄﾞﾙｸﾞﾙｰﾌﾟ｡",
        KanaConverter.ToNarrow(value), "A4000");


    }

    [TestMethod]
    public void MaartenSchmidt()
    {
        string value = "マーテン・シュミットは、これが水素のスペクトル線が 16% も赤方偏移したものであることを発見した。";

        Assert.AreEqual(
            "まーてん・しゅみっとは、これが水素のすぺくとる線が 16% も赤方偏移したものであることを発見した。",
            KanaConverter.ToHiragana(value), "A1000");

        Assert.AreEqual(
            "マーテン・シュミットハ、コレガ水素ノスペクトル線ガ 16% モ赤方偏移シタモノデアルコトヲ発見シタ。",
            KanaConverter.ToKatakana(value), "A2000");

        Assert.AreEqual(
            "マーテン・シュミットは、これが水素のスペクトル線が　１６％　も赤方偏移したものであることを発見した。",
            KanaConverter.ToWide(value), "A3000");

        Assert.AreEqual(
            "ﾏｰﾃﾝ･ｼｭﾐｯﾄは､これが水素のｽﾍﾟｸﾄﾙ線が 16% も赤方偏移したものであることを発見した｡",
            KanaConverter.ToNarrow(value), "A4000");

    }

    [TestMethod]
    public void Amenimomakezu()
    {
        string value = "雨ニモマケズ\r\n"
            + "風ニモマケズ\r\n"
            + "雪ニモ夏ノ暑サニモマケヌ\n\r"
            + "丈夫ナカラダヲモチ\n\r"
            + "慾ハナク\n\r"
            + "決シテ瞋ラズ\n\r"
            +"イツモシヅカニワラッテヰル";

        Assert.AreEqual(
            "雨にもまけず\r\n"
            + "風にもまけず\r\n"
            + "雪にも夏の暑さにもまけぬ\n\r"
            + "丈夫なからだをもち\n\r"
            + "慾はなく\n\r"
            + "決して瞋らず\n\r"
            + "いつもしづかにわらってゐる",
            KanaConverter.ToHiragana(value), "A1000");

        Assert.AreEqual(
            "雨ニモマケズ\r\n"
            + "風ニモマケズ\r\n"
            + "雪ニモ夏ノ暑サニモマケヌ\n\r"
            + "丈夫ナカラダヲモチ\n\r"
            + "慾ハナク\n\r"
            + "決シテ瞋ラズ\n\r"
            + "イツモシヅカニワラッテヰル",
            KanaConverter.ToKatakana(value), "A2000");

        Assert.AreEqual(
            "雨ニモマケズ\r\n"
            + "風ニモマケズ\r\n"
            + "雪ニモ夏ノ暑サニモマケヌ\n\r"
            + "丈夫ナカラダヲモチ\n\r"
            + "慾ハナク\n\r"
            + "決シテ瞋ラズ\n\r"
            + "イツモシヅカニワラッテヰル",
            KanaConverter.ToWide(value), "A3000");

        Assert.AreEqual(
            "雨ﾆﾓﾏｹｽﾞ\r\n"
            + "風ﾆﾓﾏｹｽﾞ\r\n"
            + "雪ﾆﾓ夏ﾉ暑ｻﾆﾓﾏｹﾇ\n\r"
            + "丈夫ﾅｶﾗﾀﾞｦﾓﾁ\n\r"
            + "慾ﾊﾅｸ\n\r"
            + "決ｼﾃ瞋ﾗｽﾞ\n\r"
            + "ｲﾂﾓｼﾂﾞｶﾆﾜﾗｯﾃヰﾙ",
            KanaConverter.ToNarrow(value), "A4000");
    }

    [TestMethod]
    public void Laplace()
    {
        //NOTICE                                              ↓this Sacpe is THIN SPACE (U+2009)
        string value = "c > 0 として、関数 F(s) から元の関数 f (t) を計算することを逆ラプラス変換 (inverse Laplace transform) と呼ぶ";

        //THIN SPACE
        //https://en.wikipedia.org/wiki/Thin_space
        //https://unicode.org/charts/PDF/U2000.pdf
        //Kana.NET doesn't convert thin space.

        Assert.AreEqual(
            "c > 0 として、関数 F(s) から元の関数 f (t) を計算することを逆らぷらす変換 (inverse Laplace transform) と呼ぶ",
            KanaConverter.ToHiragana(value), "A1000");

        Assert.AreEqual(
            "c > 0 トシテ、関数 F(s) カラ元ノ関数 f (t) ヲ計算スルコトヲ逆ラプラス変換 (inverse Laplace transform) ト呼ブ",
            KanaConverter.ToKatakana(value), "A2000");

        //Keep thin space.
        Assert.AreEqual(
            "ｃ　＞　０　として、関数　Ｆ（ｓ）　から元の関数　ｆ （ｔ）　を計算することを逆ラプラス変換　（ｉｎｖｅｒｓｅ　Ｌａｐｌａｃｅ　ｔｒａｎｓｆｏｒｍ）　と呼ぶ",
           //ｃ　＞　０　として、関数　Ｆ（ｓ）　から元の関数　ｆ （ｔ）　を計算することを逆ラプラス変換　（ｉｎｖｅｒｓｅ　Ｌａｐｌａｃｅ　ｔｒａｎｓｆｏｒｍ）　と呼ぶ
            KanaConverter.ToWide(value), "A3000");

        Assert.AreEqual(
            "c > 0 として､関数 F(s) から元の関数 f (t) を計算することを逆ﾗﾌﾟﾗｽ変換 (inverse Laplace transform) と呼ぶ",
            KanaConverter.ToNarrow(value), "A4000");

    }


    [TestMethod]
    public void ExCriminalLawNo68()
    {
        string value = "法律ニ依リ刑ヲ減軽ス可キ一個又ハ数個ノ原由アルトキハ左ノ例ニ依ル";

        Assert.AreEqual(
            "法律に依り刑を減軽す可き一個又は数個の原由あるときは左の例に依る",
            KanaConverter.ToHiragana(value), "A1000");

        Assert.AreEqual(
            "法律ニ依リ刑ヲ減軽ス可キ一個又ハ数個ノ原由アルトキハ左ノ例ニ依ル",
            KanaConverter.ToKatakana(value), "A2000");

        Assert.AreEqual(
            "法律ニ依リ刑ヲ減軽ス可キ一個又ハ数個ノ原由アルトキハ左ノ例ニ依ル",
            KanaConverter.ToWide(value), "A3000");

        Assert.AreEqual(
            "法律ﾆ依ﾘ刑ｦ減軽ｽ可ｷ一個又ﾊ数個ﾉ原由ｱﾙﾄｷﾊ左ﾉ例ﾆ依ﾙ",
            KanaConverter.ToNarrow(value), "A4000");

    }

    [TestMethod]
    public void Address1()
    {
        string value = "シガケンカクウマチヨコヨンゲンチョウシャトールオウ５１２ゴウシツ";

        Assert.AreEqual(
            "しがけんかくうまちよこよんげんちょうしゃとーるおう５１２ごうしつ",
            KanaConverter.ToHiragana(value), "A1000");

        Assert.AreEqual(
            "シガケンカクウマチヨコヨンゲンチョウシャトールオウ５１２ゴウシツ",
            KanaConverter.ToKatakana(value), "A2000");

        Assert.AreEqual(
            "シガケンカクウマチヨコヨンゲンチョウシャトールオウ５１２ゴウシツ",
            KanaConverter.ToWide(value), "A3000");

        Assert.AreEqual(
            "ｼｶﾞｹﾝｶｸｳﾏﾁﾖｺﾖﾝｹﾞﾝﾁｮｳｼｬﾄｰﾙｵｳ512ｺﾞｳｼﾂ",
            KanaConverter.ToNarrow(value), "A4000");
    }

    [TestMethod]
    public void Address2()
    {
        string value = "ﾎｯｶｲﾄﾞｳﾎﾎﾞｼｬｯﾌﾟﾏﾁｵｵﾊﾗｻﾝｷﾞｮｳｶｲｶﾝ2ｺﾞｳﾄｳ114";

        Assert.AreEqual(
            "ﾎｯｶｲﾄﾞｳﾎﾎﾞｼｬｯﾌﾟﾏﾁｵｵﾊﾗｻﾝｷﾞｮｳｶｲｶﾝ2ｺﾞｳﾄｳ114",
            KanaConverter.ToHiragana(value), "A1000");

        Assert.AreEqual(
            "ﾎｯｶｲﾄﾞｳﾎﾎﾞｼｬｯﾌﾟﾏﾁｵｵﾊﾗｻﾝｷﾞｮｳｶｲｶﾝ2ｺﾞｳﾄｳ114",
            KanaConverter.ToKatakana(value), "A2000");

        Assert.AreEqual(
            "ホッカイドウホボシャップマチオオハラサンギョウカイカン２ゴウトウ１１４",
            KanaConverter.ToWide(value), "A3000");

        Assert.AreEqual(
            "ﾎｯｶｲﾄﾞｳﾎﾎﾞｼｬｯﾌﾟﾏﾁｵｵﾊﾗｻﾝｷﾞｮｳｶｲｶﾝ2ｺﾞｳﾄｳ114",
            KanaConverter.ToNarrow(value), "A4000");

    }

    [TestMethod]
    public void Address3()
    {
        string value = "鳥取県シラウオグン2-43ｼｮｳﾌﾞｿｳ７８９号";

        Assert.AreEqual(
            "鳥取県しらうおぐん2-43ｼｮｳﾌﾞｿｳ７８９号",
            KanaConverter.ToHiragana(value), "A1000");

        Assert.AreEqual(
            "鳥取県シラウオグン2-43ｼｮｳﾌﾞｿｳ７８９号",
            KanaConverter.ToKatakana(value), "A2000");

        Assert.AreEqual(
            "鳥取県シラウオグン２－４３ショウブソウ７８９号",
            KanaConverter.ToWide(value), "A3000");

        Assert.AreEqual(
            "鳥取県ｼﾗｳｵｸﾞﾝ2-43ｼｮｳﾌﾞｿｳ789号",
            KanaConverter.ToNarrow(value), "A4000");
    }

    [TestMethod]
    public void Tel1()
    {
        string value = "０８０－１２３４－５６７８";

        Assert.AreEqual(
            "０８０－１２３４－５６７８",
            KanaConverter.ToHiragana(value), "A1000");

        Assert.AreEqual(
            "０８０－１２３４－５６７８",
            KanaConverter.ToKatakana(value), "A2000");

        Assert.AreEqual(
            "０８０－１２３４－５６７８",
            KanaConverter.ToWide(value), "A3000");

        Assert.AreEqual(
            "080-1234-5678",
            KanaConverter.ToNarrow(value), "A4000");
    }

    [TestMethod]
    public void PaymentReminder()
    {
        string value = "前略、従前からご請求しております請求書第A-1234号の売掛金123,456円の件、"
            + "令和7年5月14日の期日が過ぎましても、いまだ入金の確認が取れておりません。";


        Assert.AreEqual(
            "前略、従前からご請求しております請求書第A-1234号の売掛金123,456円の件、"
            + "令和7年5月14日の期日が過ぎましても、いまだ入金の確認が取れておりません。",
            KanaConverter.ToHiragana(value), "A1000");

        Assert.AreEqual(
            "前略、従前カラゴ請求シテオリマス請求書第A-1234号ノ売掛金123,456円ノ件、"
            + "令和7年5月14日ノ期日ガ過ギマシテモ、イマダ入金ノ確認ガ取レテオリマセン。",
            KanaConverter.ToKatakana(value), "A2000");

        Assert.AreEqual(
            "前略、従前からご請求しております請求書第Ａ－１２３４号の売掛金１２３，４５６円の件、"
            + "令和７年５月１４日の期日が過ぎましても、いまだ入金の確認が取れておりません。",
            KanaConverter.ToWide(value), "A3000");

        Assert.AreEqual(
            "前略､従前からご請求しております請求書第A-1234号の売掛金123,456円の件､"
            + "令和7年5月14日の期日が過ぎましても､いまだ入金の確認が取れておりません｡",
            KanaConverter.ToNarrow(value), "A4000");
    }

    [TestMethod]
    public void SuzukiSeiya()
    {
        string value = "鈴木誠也…メジャーいくかもなのでめっちゃレアですよ。。 活躍すごいですし😏";

        Assert.AreEqual(
            "鈴木誠也…めじゃーいくかもなのでめっちゃれあですよ。。 活躍すごいですし😏",
            KanaConverter.ToHiragana(value), "A1000");

        Assert.AreEqual(
            "鈴木誠也…メジャーイクカモナノデメッチャレアデスヨ。。 活躍スゴイデスシ😏",
            KanaConverter.ToKatakana(value), "A2000");

        Assert.AreEqual(
            "鈴木誠也…メジャーいくかもなのでめっちゃレアですよ。。　活躍すごいですし😏",
            KanaConverter.ToWide(value), "A3000");

        Assert.AreEqual(
            "鈴木誠也…ﾒｼﾞｬｰいくかもなのでめっちゃﾚｱですよ｡｡ 活躍すごいですし😏",
            KanaConverter.ToNarrow(value), "A4000");


    }

    [TestMethod]
    public void CostumePlayer()
    {
        string value = "ﾚｲﾔｰ、コスした瞬間コミュ力あがるの凄い…";

        Assert.AreEqual(
            "ﾚｲﾔｰ、こすした瞬間こみゅ力あがるの凄い…",
            KanaConverter.ToHiragana(value), "A1000");

        Assert.AreEqual(
            "ﾚｲﾔｰ、コスシタ瞬間コミュ力アガルノ凄イ…",
            KanaConverter.ToKatakana(value), "A2000");

        Assert.AreEqual(
            "レイヤー、コスした瞬間コミュ力あがるの凄い…",
            KanaConverter.ToWide(value), "A3000");

        Assert.AreEqual(
            "ﾚｲﾔｰ､ｺｽした瞬間ｺﾐｭ力あがるの凄い…",
            KanaConverter.ToNarrow(value), "A4000");

    }

    [TestMethod]
    public void PointBack()
    {
        //NOTEICE                 ↓This space is TAB
        string value = "ポイント：	1,928ポイント（10％還元）（￥1,928相当）";

        Assert.AreEqual(
            "ぽいんと：	1,928ぽいんと（10％還元）（￥1,928相当）",
            KanaConverter.ToHiragana(value), "A1000");

        Assert.AreEqual(
            "ポイント：	1,928ポイント（10％還元）（￥1,928相当）",
            KanaConverter.ToKatakana(value), "A2000");

        char[] values = value.ToCharArray();

        Assert.AreEqual(
            "ポイント：	１，９２８ポイント（１０％還元）（￥１，９２８相当）",
            KanaConverter.ToWide(value), "A3000");

        Assert.AreEqual(
            @"ﾎﾟｲﾝﾄ:	1,928ﾎﾟｲﾝﾄ(10%還元)(\1,928相当)",
            KanaConverter.ToNarrow(value), "A4000");

    }
    
} // class VariousSentence
