// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

string hiragana = Umayadia.Kana.KanaConverter.ToHiragana("ドラえもん大好き");
Console.WriteLine(hiragana);

string katakana = Umayadia.Kana.KanaConverter.ToKatakana("ドラえもん大好き");
Console.WriteLine(katakana);
