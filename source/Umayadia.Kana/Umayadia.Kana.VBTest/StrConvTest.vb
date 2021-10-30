Option Strict On

Imports Microsoft.VisualStudio.TestTools.UnitTesting
'Imports Umayadia.Kana

Namespace Umayadia.Kana.VBTest
    <TestClass>
    Public Class StrConvTest

        <TestMethod>
        <CodeAnalysis.SuppressMessage("Interoperability", "CA1416")>
        Public Sub StrConvToHiragana()


#If NETCOREAPP Then
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance)
#End If

            For codePoint As Integer = 0 To &H3FFFF

                Dim c As String

                If codePoint >= &HD800 AndAlso codePoint <= &HDFFF Then
                    'サロゲート領域(&HD800 ～ &HDFFF)を単独で Char型にするために ChrW を使います。
                    c = ChrW(codePoint).ToString
                Else
                    c = Char.ConvertFromUtf32(codePoint).ToString
                End If

                Dim strConvResult = StrConv(c, VbStrConv.Hiragana)
                Dim kanaConvResult = KanaConverter.StrConv(c, umaStrConv.Hiragana)
                Assert.AreEqual(strConvResult, kanaConvResult, $"CodePoint 0x{codePoint:X}")
            Next

        End Sub

        <TestMethod>
        <CodeAnalysis.SuppressMessage("Interoperability", "CA1416")>
        Public Sub StrConvToKatakana()

#If NETCOREAPP Then
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance)
#End If

            For codePoint As Integer = 0 To &H3FFFF

                Dim c As String

                If codePoint >= &HD800 AndAlso codePoint <= &HDFFF Then
                    'サロゲート領域(&HD800 ～ &HDFFF)を単独で Char型にするために ChrW を使います。
                    c = ChrW(codePoint).ToString
                Else
                    c = Char.ConvertFromUtf32(codePoint).ToString
                End If

                Dim strConvResult = StrConv(c, VbStrConv.Katakana)
                Dim kanaConvResult = KanaConverter.StrConv(c, umaStrConv.Katakana)
                Assert.AreEqual(strConvResult, kanaConvResult, $"CodePoint 0x{codePoint:X}")
            Next

        End Sub


        <TestMethod>
        Public Sub StrConvUnique()
            Assert.AreEqual("あ??お", KanaConverter.StrConv("あゕゖお", umaStrConv.Hiragana), "A1000")
            Assert.AreEqual("ア??オ", KanaConverter.StrConv("あゕゖお", umaStrConv.Katakana), "A1100")
        End Sub

        <TestMethod>
        Public Sub NullConversion()
            Assert.AreEqual("", KanaConverter.StrConv(Nothing, umaStrConv.Hiragana), "A1000")
            Assert.AreEqual("", KanaConverter.StrConv(Nothing, umaStrConv.Katakana), "A2000")

            Assert.AreEqual("", KanaConverter.StrConv("", umaStrConv.Hiragana), "B1000")
            Assert.AreEqual("", KanaConverter.StrConv("", umaStrConv.Katakana), "B2000")
        End Sub

        <TestMethod>
        Public Sub StrConvIntegerVersion()
            Assert.AreEqual(
                "有櫛動物（Ctenophora）は、くらげ様の動物の分類群。くしくらげ類とも。",
                 KanaConverter.StrConv("有櫛動物（Ctenophora）は、クラゲ様の動物の分類群。クシクラゲ類とも。", vbHiragana),
                 "A1000")

            Assert.AreEqual(
                "オビクラゲハソノエレガントナ美シサカラ『ヴィーナスノ飾リ帯』トモ呼バレル。",
                KanaConverter.StrConv("オビクラゲはそのエレガントな美しさから『ヴィーナスの飾り帯』とも呼ばれる。", vbKatakana),
                "A1100")

            Assert.AreEqual(
                "したーるという言葉は、さんすくりっと語saptatantri veena（七弦のヴぃーな）から派生した。",
                 KanaConverter.StrConv("シタールという言葉は、サンスクリット語saptatantri veena（七弦のヴィーナ）から派生した。", VbStrConv.Hiragana),
                 "A1200")

            Assert.AreEqual(
                "シタールトイウ言葉ハ、サンスクリット語saptatantri veena（七弦ノヴィーナ）カラ派生シタ。",
                 KanaConverter.StrConv("シタールという言葉は、サンスクリット語saptatantri veena（七弦のヴィーナ）から派生した。", VbStrConv.Katakana),
                 "A1300")

            Assert.ThrowsException(Of ArgumentException)(Sub()
                                                             KanaConverter.StrConv("これはエラーのはず", 9999)
                                                         End Sub)
        End Sub


    End Class
End Namespace

