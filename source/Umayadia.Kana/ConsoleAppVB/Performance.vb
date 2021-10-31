Option Strict On

Public Class Performance

    <CodeAnalysis.SuppressMessage("Interoperability", "CA1416")>
    Public Sub Test()


        Debug.WriteLine("■ドラえもん大好きだネ × 1")
        Test("ドラえもん大好きだネ")

        Debug.WriteLine("■ドラえもん大好きだネ × 1000")
        Test(StrDup(1000, "ドラえもん大好きだネ"))

        Debug.WriteLine("■ABCDEFGhijkmnl × 1000")
        Test(StrDup(1000, "ABCDEFGhijkmnl"))

        Debug.WriteLine("■子曰、吾十有五而... × 200")
        Test(StrDup(200, "子曰、吾十有五而志於學。三十而立。四十而不惑。五十而知天命。六十而耳順。七十而從心所欲不踰矩"))


    End Sub

    <CodeAnalysis.SuppressMessage("Interoperability", "CA1416")>
    Public Sub Test(source As String)

#If NETCOREAPP Then
        System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance)
#End If

        Const iterationCount As Integer = 10000

        Dim watch As Stopwatch

        '▼Strings.StrConv
        watch = Stopwatch.StartNew

        For i As Integer = 0 To iterationCount
            Dim result = Strings.StrConv(source, VbStrConv.Hiragana)
        Next

        watch.Stop()

        Debug.WriteLine($"Strings.StrConv: {watch.ElapsedMilliseconds} ms")

        '▼KanaKonverter.ToHiragana
        watch = Stopwatch.StartNew

        For i As Integer = 0 To iterationCount
            Dim result = Umayadia.Kana.KanaConverter.ToHiragana(source)
        Next

        watch.Stop()

        Debug.WriteLine($"KanaKonverter.ToHiragana: {watch.ElapsedMilliseconds} ms")

        ''▼KanaKonverter.ToHiraganaV1
        'watch = Stopwatch.StartNew

        'For i As Integer = 0 To iterationCount
        '    Dim result = Umayadia.Kana.KanaConverter.ToHiraganaV1(source)
        'Next

        'watch.Stop()

        'Debug.WriteLine($"KanaKonverter.ToHiraganaV1: {watch.ElapsedMilliseconds} ms")

        ''▼KanaKonverter.ToHiraganaV2
        'watch = Stopwatch.StartNew

        'For i As Integer = 0 To iterationCount
        '    Dim result = Umayadia.Kana.KanaConverter.ToHiraganaV2(source)
        'Next

        'watch.Stop()

        'Debug.WriteLine($"KanaKonverter.ToHiraganaV2: {watch.ElapsedMilliseconds} ms")

        ''▼KanaKonverter.ToHiraganaV3
        'watch = Stopwatch.StartNew

        'For i As Integer = 0 To iterationCount
        '    Dim result = Umayadia.Kana.KanaConverter.ToHiraganaV3(source)
        'Next

        'watch.Stop()

        'Debug.WriteLine($"KanaKonverter.ToHiraganaV3: {watch.ElapsedMilliseconds} ms")


        '▼KanaKonverter.StrConv
        watch = Stopwatch.StartNew

        For i As Integer = 0 To iterationCount
            Dim result = Umayadia.Kana.KanaConverter.StrConv(source, VbStrConv.Hiragana)
        Next

        watch.Stop()

        Debug.WriteLine($"KanaKonverter.StrConv: {watch.ElapsedMilliseconds} ms")

    End Sub


End Class
