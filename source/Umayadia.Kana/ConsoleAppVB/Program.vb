Option Strict On

Imports System

Module Program
    Sub Main(args As String())
        Console.WriteLine($"Visual Basic on {Environment.OSVersion}")

        Dim s As New Sample
        s.DoSample()


        'Dim generator As New StrConvGenerator
        'Dim pg As String

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
