Option Strict On

Imports System

Module Program
    Sub Main(args As String())
#If NETCOREAPP Then
        System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance)
#End If

        'Dim p As New Performance
        'p.Test()

        Dim s As New Sample
        s.DoSample()


        'Dim generator As New StrConvGenerator
        'Dim pg As String

        'pg = generator.StrConvWideList
        'IO.File.WriteAllText("C:\temp\umawidelist.txt", pg)

        'pg = generator.StrConvNarrowList
        'IO.File.WriteAllText("C:\temp\umanarrowlist.txt", pg)

        'pg = generator.GenerateQuestionIf
        'IO.File.WriteAllText("C:\temp\pg1.cs", pg)

        'pg = generator.GenerateUniqueIf
        'IO.File.WriteAllText("C:\temp\umaunique.txt", pg)

        'pg = generator.StrConvHiraganaList
        'IO.File.WriteAllText("C:\temp\umahiraganalist.txt", pg)

        'pg = generator.StrConvKatakanaList
        'IO.File.WriteAllText("C:\temp\umakatakanalist.txt", pg)


    End Sub
End Module
