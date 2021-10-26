// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
Console.WriteLine(Environment.OSVersion.ToString());

string hiragana = Umayadia.Kana.KanaConverter.ToHiragana("ドラえもん大好き");
Console.WriteLine(hiragana);

string katakana = Umayadia.Kana.KanaConverter.ToKatakana("ドラえもん大好き");
Console.WriteLine(katakana);

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