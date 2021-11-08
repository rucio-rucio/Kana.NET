# Kana.NET
Japanese Kana utility for .NET. Convert Hiragana and Katakana, Half width(Hankaku) and Full width(Zenkaku).
Kana.NET depends on only .NET. Kana.NET doesn't invoke windows funtion.
So it works on Linux too.

See also 

https://www.umayadia.com/Note/Note063Kana.NET.htm 

ひらがな と カタカナ の変換、全角と半角の変換を行います。文字コードの計算処理だけで変換を実現しているためOSの機能に依存しません。
そのため、非日本語環境のWindowsやLinux上でも動作します。

詳細はこちらの記事をご覧ください。

https://www.umayadia.com/Note/Note063Kana.NET.htm


C#
```
string hiragana = Umayadia.Kana.KanaConverter.ToHiragana("ドラえもん大好き");
string katakana = Umayadia.Kana.KanaConverter.ToKatakana("ドラえもん大好き");
string zenkaku = Umayadia.Kana.KanaConverter.ToWide("ｱｲｳｴｵ");
string hankaku = Umayadia.Kana.KanaConverter.ToNarrow("アイウエオ");

Console.WriteLine($"{hiragana} {katakana} {zenkaku} {hankaku}");
```

VB
```
Dim hiragana As String = Umayadia.Kana.KanaConverter.ToHiragana("ドラえもん大好き")
Dim katakana As String = Umayadia.Kana.KanaConverter.ToKatakana("ドラえもん大好き")
Dim zenkaku As String = Umayadia.Kana.KanaConverter.ToWide("ｱｲｳｴｵ")
Dim hankaku As String = Umayadia.Kana.KanaConverter.ToNarrow("アイウエオ")

Console.WriteLine($"{hiragana} {katakana} {zenkaku} {hankaku}")
```

# Full width and Half width (全角と半角)

全角と半角の変換はどの文字とどの文字を対応させるのかの選択が難しく、Kana.NET では日本語で便利に使用できるように調整しました。
たとえば、半角のバックスラッシュ(U+005C)は全角の円マークに対応して、相互に全角・半角変換します。
本来、半角の円マークは U+00A5 で定義されており、U+005C とは別物なのですが、日本語の全角変換においてはこの変換の方が便利と判断したからです。

半角ハングルや、ダイアクリティカルマーク付きのラテン文字(À, Á, Â, Ã, Ä, Å など)など、日本語でまず使用されない文字の全角・半角変換は行いません。

変換する全文字の一覧は、[全角半角のテスト](https://github.com/rucio-rucio/Kana.NET/blob/main/source/Umayadia.Kana/Umayadia.Kana.Test/KanaConverterWideNarrowTest.cs) を見るとわかります。

# Custom mapper

MapToHiraganaプロパティを使用すると、カスタムなひらがな変換を定義できます。
MapToKatakanaプロパティを使用すると同様にカスタムなカタカナ変換を定義できます。

これらは静的なプロパティなので１度定義すればその後のすべての変換に適用されます。
カスタムな変換を無効にするには null を設定します。

C# sample
```
//Define custom map to Hiragana
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
```

sample
```
//Define custom map to Hiragana
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
```

カスタム変換用の関数は１文字ごとに呼ばれます。引数の意味は次の通りです。

### builder

変換結果のバッファーです。ここに変換後の文字を追加してください。
ここに何も追加しないと、その文字は無視されます。

### letter

この文字に対する変換を定義してください。言い換えるとこれは変換前の文字です。

### suggestion

Kana.NET が提案する変換後の文字です。カスタムな変換が不要な場合、この文字をそのまま builder に追加してください。

### source

変換を行おうとしている文字列全体です。

# StrConv compatibility

Microsoft.VisualBasic.Strings.StrConv (and StrConv of VB6, VBA) is obsolete. But some programs needs alternative method.
So Kana.NET have StrConv compatible method named, same as, StrConv.

In following sample you will see that '𩸽' become '??'. This is the StrConv way.

Microsoft.VisualBasic.Strings.StrConv (それにVB6やVBAのStrConv)は時代遅れですが、互換性が必要なプログラムもあるでしょう。
Kana.NETではStrConvと互換性のある同じ名前の StrConv というメソッドを用意しています。

下記のサンプルでは '𩸽' が ?? に変換されます。StrConvと同じ仕様です。

VB Sample
```
'▼Sample6
'StrConv
Dim result6 As String = Umayadia.Kana.KanaConverter.StrConv("ドラえもんは𩸽が大好き", vbHiragana)
Console.WriteLine(result6) 'どらえもんは??が大好き

'▼Sample7
'StrConv
Dim result7 As String = Umayadia.Kana.KanaConverter.StrConv("ドラえもんは𩸽が大好き", vbKatakana)
Console.WriteLine(result7) 'ドラエモンハ??ガ大好キ
```

C# Sample
```
//▼Sample6
//StrConv
string result6 = Umayadia.Kana.KanaConverter.StrConv("ドラえもんは𩸽が大好き", Umayadia.Kana.umaStrConv.Hiragana);
Console.WriteLine(result6); //どらえもんは??が大好き

//▼Sample7
//StrConv
string result7 = Umayadia.Kana.KanaConverter.StrConv("ドラえもんは𩸽が大好き", Umayadia.Kana.umaStrConv.Katakana);
Console.WriteLine(result7); //ドラエモンハ??ガ大好キ
```

# Extra

Umayadia.Kana.KanaUtil.ShiftJIS returns Shift_JIS encoding object. This is a little shortcut to get the encoding object.
So you can write program as follow.

C#
```
var sjis = Umayadia.Kana.KanaUtil.ShiftJIS;
var bytes = sjis.GetBytes("楽しい.NET");
Console.WriteLine($"楽しい.NET is {bytes.Length} bytes."); //10
```

VB
```
Dim sjis = Umayadia.Kana.KanaUtil.ShiftJIS
Dim bytes = sjis.GetBytes("楽しい.NET")
Console.WriteLine($"楽しい.NET is {bytes.Length} bytes.") '10
```

