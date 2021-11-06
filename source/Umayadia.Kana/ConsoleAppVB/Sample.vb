Imports Umayadia.Kana.KanaConverter

Public Class Sample

    Public Sub DoSample()

        Dim hiragana As String = Umayadia.Kana.KanaConverter.ToHiragana("ドラえもん大好き")
        Dim katakana As String = Umayadia.Kana.KanaConverter.ToKatakana("ドラえもん大好き")
        Dim zenkaku As String = Umayadia.Kana.KanaConverter.ToWide("ｱｲｳｴｵ")
        Dim hankaku As String = Umayadia.Kana.KanaConverter.ToNarrow("アイウエオ")

        Console.WriteLine($"{hiragana} {katakana} {zenkaku} {hankaku}")

        ''▼Sample1 Katakana to Hiragana
        ''次のように１行記述するだけ カタカナ を ひらがな に変換できます。
        ''You can convert Katakana to Hiragana, writing just only one following line.
        'Dim hiragana As String = Umayadia.Kana.KanaConverter.ToHiragana("ドラえもん大好き")
        'Console.WriteLine(hiragana) 'どらえもん大好き

        ''▼Sample2 Hiragana to Katakana
        ''次のように１行記述するだけ ひらがな を カタカナ に変換できます。
        ''You can convert Hiragana to Katakana, writing just only one following line.
        'Dim katakana As String = Umayadia.Kana.KanaConverter.ToKatakana("ドラえもん大好き")
        'Console.WriteLine(katakana) 'ドラエモン大好キ

        '▼Sample3 Custome mapping to Hiragana
        '文字ごとに独自の変換を定義することもできます。
        'You can define custome conversion each character as following.
        Umayadia.Kana.KanaConverter.MapToHiragana =
            Sub(builder As System.Text.StringBuilder, letter As String, suggestion As String, source As String)
                Select Case letter
                    Case "ド"
                        builder.Append("★")
                    Case "ラ"
                        builder.Append("ららら～")
                    Case Else
                        builder.Append(suggestion)
                End Select
            End Sub

        Dim result1 As String = Umayadia.Kana.KanaConverter.ToHiragana("ドラえもん大好き")
        Console.WriteLine(result1) '★ららら～えもん大好き

        '▼Sample4 Custome mapping to Katakana
        '文字ごとに独自の変換を定義することもできます。
        'You can define custome conversion each character as following.
        Umayadia.Kana.KanaConverter.MapToKatakana =
            Sub(builder As System.Text.StringBuilder, letter As String, suggestion As String, source As String)
                Select Case letter
                    Case "え"
                        builder.Append("e")
                    Case "も"
                        builder.Append("MO")
                    Case Else
                        builder.Append(suggestion)
                End Select
            End Sub

        Dim result2 As String = Umayadia.Kana.KanaConverter.ToKatakana("ドラえもん大好き")
        Console.WriteLine(result2) 'ドラeMOン大好キ


        '▼Sample5
        Umayadia.Kana.KanaConverter.MapToHiragana =
            Sub(builder As System.Text.StringBuilder, letter As String, suggestion As String, source As String)
                Select Case letter
                    Case "ヷ"
                        builder.Append("わ゙")
                    Case "ヸ"
                        builder.Append("ゐ゙")
                    Case "ヹ"
                        builder.Append("ゑ゙")
                    Case "ヺ"
                        builder.Append("を゙")
                    Case Else
                        builder.Append(suggestion)
                End Select
            End Sub

        Dim result5 As String = Umayadia.Kana.KanaConverter.ToHiragana("ワヷヰヸヱヹヲヺ")
        Console.WriteLine(result5) 'わわ゙ゐゐ゙ゑゑ゙をを゙

        '▼Sample6
        'StrConv
        Dim result6 As String = Umayadia.Kana.KanaConverter.StrConv("ドラえもんは𩸽が大好き", vbHiragana)
        Console.WriteLine(result6) 'どらえもんは??が大好き

        '▼Sample7
        'StrConv
        Dim result7 As String = Umayadia.Kana.KanaConverter.StrConv("ドラえもんは𩸽が大好き", vbKatakana)
        Console.WriteLine(result7) 'ドラエモンハ??ガ大好キ

        '▼Sample8
        Dim sjis = Umayadia.Kana.KanaUtil.ShiftJIS
        Dim bytes = sjis.GetBytes("楽しい.NET")
        Console.WriteLine($"楽しい.NET is {bytes.Length} bytes.") '10



    End Sub

End Class
