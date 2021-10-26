# Kana.NET
Japanese Kana utility for .NET. Convert Hiragana and Katakana.
Kana.NET depends on only .NET. Kana.NET doesn't invoke windows funtion.
So it works on Linux too.

平仮名とカタカナを変換します。文字コードの計算処理だけで変換を実現しているためOSの機能に依存しません。
そのため、非日本語環境のWindowsやLinux上でも動作します。

You can get "どらえもん大好き" from this code.
```
string hiragana = Umayadia.Kana.KanaConverter.ToHiragana("ドラえもん大好き");
```

You can get "ドラエモン大好キ" from this code.
```
string katakana = Umayadia.Kana.KanaConverter.ToKatakana("ドラえもん大好き");
```

# Custom mapper

MapToHiraganaプロパティを使用すると、カスタムなひらがな変換を定義できます。
MapToKatakanaプロパティを使用すると同様にカスタムなカタカナ変換を定義できます。

これらは静的なプロパティなので１度定義すればその後のすべての変換に適用されます。
カスタムな変換を無効にするには null を設定します。

sample
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


