# Kana.NET
Japanese Kana utility for .NET. Convert Hiragana and Katakana.
Kana.NET depends on only .NET. Kana.NET doesn't invoke windows funtion.

平仮名とカタカナを変換します。文字コードの計算処理だけで変換を実現しているためOSの機能に依存しません。
そのため、非日本語環境のWindowsやLinux上でも動作すると思いますが実際に実行して試したわけではありません。

You can get "どらえもん大好き" from this code.
```
string hiragana = Umayadia.Kana.KanaConverter.ToHiragana("ドラえもん大好き");
```

You can get "ドラエモン大好キ" from this code.
```
string katakana = Umayadia.Kana.KanaConverter.ToKatakana("ドラえもん大好き");
```

# None-Japanese Windows

It will work. But I don't test yet.

# Linux

It will work. But I don't test yet.
