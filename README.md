# Kana.NET
Japanese Kana utility for .NET. Convert Hiragana and Katakana.
Kana.NET depends on only .NET. Kana.NET doesn't invoke windows funtion.
So it works on Linux too.
See also 
https://www.umayadia.com/Note/Note063Kana.NET.htm 

平仮名とカタカナを変換します。文字コードの計算処理だけで変換を実現しているためOSの機能に依存しません。
そのため、非日本語環境のWindowsやLinux上でも動作します。
詳細はこちらの記事をご覧ください。
https://www.umayadia.com/Note/Note063Kana.NET.htm


You can get "どらえもん大好き" from this code.
C#
```
string hiragana = Umayadia.Kana.KanaConverter.ToHiragana("ドラえもん大好き");
```

VB
```
Dim hiragana As String = Umayadia.Kana.KanaConverter.ToHiragana("ドラえもん大好き")
```

You can get "ドラエモン大好キ" from this code.
C#
```
string katakana = Umayadia.Kana.KanaConverter.ToKatakana("ドラえもん大好き");
```

VB
```
Dim katakana As String = Umayadia.Kana.KanaConverter.ToKatakana("ドラえもん大好き")
```

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
