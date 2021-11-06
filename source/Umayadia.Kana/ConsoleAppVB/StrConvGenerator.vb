Option Strict On

Imports Umayadia.Kana

Public Class StrConvGenerator

    <CodeAnalysis.SuppressMessage("Interoperability", "CA1416")>
    Public Function StrConvWideList() As String
#If NETCOREAPP Then
        System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance)
#End If

        Dim diffString As New List(Of String)

        For codePoint As Integer = 0 To &HFFFF

            Dim c As String

            If codePoint >= &HD800 AndAlso codePoint <= &HDFFF Then

                'サロゲート領域を飛ばす。
                Continue For

            ElseIf codePoint <= &HFFFF Then
                'サロゲート領域(&HD800 ～ &HDFFF)を単独で Char型にするために ChrW を使います。
                c = ChrW(codePoint).ToString
            Else
                'この領域は ChrWはエラーになるので、 ConvertFromUtf32 を使用します。
                c = Char.ConvertFromUtf32(codePoint).ToString
            End If

            Dim strConvResult = StrConv(c, VbStrConv.Wide)
            If strConvResult = "？" Then

                Continue For
            End If

            If strConvResult <> c Then
                Dim bytes = System.Text.Encoding.UTF32.GetBytes(strConvResult)
                Dim resultCP = BitConverter.ToInt32(bytes)
                diffString.Add($"'Original 0x{codePoint:X} {c} Widen 0x{resultCP:X} {strConvResult}")
            End If
        Next

        Dim result As String = String.Join(vbCrLf, diffString)


        Return result

    End Function

    <CodeAnalysis.SuppressMessage("Interoperability", "CA1416")>
    Public Function StrConvNarrowList() As String
#If NETCOREAPP Then
        System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance)
#End If

        Dim diffString As New List(Of String)

        For codePoint As Integer = 0 To &HFFFF

            Dim c As String

            If codePoint >= &HD800 AndAlso codePoint <= &HDFFF Then

                'サロゲート領域を飛ばす。
                Continue For

            ElseIf codePoint <= &HFFFF Then
                'サロゲート領域(&HD800 ～ &HDFFF)を単独で Char型にするために ChrW を使います。
                c = ChrW(codePoint).ToString
            Else
                'この領域は ChrWはエラーになるので、 ConvertFromUtf32 を使用します。
                c = Char.ConvertFromUtf32(codePoint).ToString
            End If

            Dim strConvResult = StrConv(c, VbStrConv.Narrow)
            If strConvResult = "?" Then
                Continue For
            End If

            If strConvResult <> c Then
                Dim bytes = System.Text.Encoding.UTF32.GetBytes(strConvResult)
                Dim resultCP = BitConverter.ToInt32(bytes)
                diffString.Add($"""{c}"" => ""{strConvResult}"", // U+{codePoint:X4} to U+{resultCP:X4}")
            End If
        Next

        Dim result As String = String.Join(vbCrLf, diffString)


        Return result

    End Function

    ''' <summary>
    ''' generate character sequence from StrConv(&&H0000, VbStrConv.Katakana) to StrConv(&&HFFFF, VbStrConv.Katakana)
    ''' As C# string literal.
    ''' </summary>
    ''' <returns></returns>
    <CodeAnalysis.SuppressMessage("Interoperability", "CA1416")>
    Public Function StrConvKatakanaList() As String
#If NETCOREAPP Then
        System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance)
#End If
        Dim builder As New System.Text.StringBuilder(&HFFFF)
        Dim count As Integer
        builder.Append("""")

        For codePoint As Integer = 0 To &HFFFF
            count += 1

            Dim c As String

            If codePoint <= &HFFFF Then
                'サロゲート領域(&HD800 ～ &HDFFF)を単独で Char型にするために ChrW を使います。
                c = ChrW(codePoint).ToString
            Else
                'この領域は ChrWはエラーになるので、 ConvertFromUtf32 を使用します。
                c = Char.ConvertFromUtf32(codePoint).ToString
            End If

            Dim strConvResult = StrConv(c, VbStrConv.Katakana)

            '念のため文字数を確認します。
            If strConvResult.Length > 2 Then
                Throw New InvalidOperationException($"As unexpected, length too long. at code point {codePoint:X}")
            End If

            If strConvResult = """" Then
                strConvResult = "\"""
            End If

            builder.Append(strConvResult)

            If count = 64 Then
                builder.Append($""" // 0x{codePoint - 63:X}" & vbCrLf)
                builder.Append("+ """)
                count = 0
            End If

        Next

        Return builder.ToString
    End Function
    ''' <summary>
    ''' generate character sequence from StrConv(&H0000, VbStrConv.Hiragana) to StrConv(&HFFFF, VbStrConv.Hiragana)
    ''' As C# string literal.
    ''' </summary>
    ''' <returns></returns>
    <CodeAnalysis.SuppressMessage("Interoperability", "CA1416")>
    Public Function StrConvHiraganaList() As String
#If NETCOREAPP Then
        System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance)
#End If
        Dim builder As New System.Text.StringBuilder(&HFFFF)
        Dim count As Integer
        builder.Append("""")

        For codePoint As Integer = 0 To &HFFFF
            count += 1

            Dim c As String

            If codePoint <= &HFFFF Then
                'サロゲート領域(&HD800 ～ &HDFFF)を単独で Char型にするために ChrW を使います。
                c = ChrW(codePoint).ToString
            Else
                'この領域は ChrWはエラーになるので、 ConvertFromUtf32 を使用します。
                c = Char.ConvertFromUtf32(codePoint).ToString
            End If

            Dim strConvResult = StrConv(c, VbStrConv.Hiragana)

            '念のため文字数を確認します。
            If strConvResult.Length > 2 Then
                Throw New InvalidOperationException($"As unexpected, length too long. at code point {codePoint:X}")
            End If

            If strConvResult = """" Then
                strConvResult = "\"""
            End If

            builder.Append(strConvResult)

            If count = 64 Then
                builder.Append($""" // 0x{codePoint - 63:X}" & vbCrLf)
                builder.Append("+ """)
                count = 0
            End If

        Next

        Return builder.ToString
    End Function

    ''' <summary>
    ''' StrConv(value, VbStrConv.Hiragana)の結果が、"?"になる value を
    ''' コードポイントで条件分岐する C# のプログラムを生成します。
    ''' 生成されるプログラムは条件分岐のみであり、単体で実行できるものではありません。
    ''' </summary>
    ''' <param name="fileName"></param>
    <CodeAnalysis.SuppressMessage("Interoperability", "CA1416")>
    Public Function GenerateQuestionIf() As String

#If NETCOREAPP Then
        System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance)
#End If

        Dim qStart As Integer
        Dim qLast As Integer = -1
        Dim pg As String = ""

        '&H10000～&H10FFFFの範囲では、StrConv はすべて ? を返します。
        'そこで、&HFFFF までをしらべれば十分です。
        For codePoint As Integer = 0 To &HFFFF


            Dim c As String

            If codePoint <= &HFFFF Then
                'サロゲート領域(&HD800 ～ &HDFFF)を単独で Char型にするために ChrW を使います。
                c = ChrW(codePoint).ToString
            Else
                'この領域は ChrWはエラーになるので、 ConvertFromUtf32 を使用します。
                c = Char.ConvertFromUtf32(codePoint).ToString
            End If

            Dim strConvResult = StrConv(c, VbStrConv.Hiragana)

            If strConvResult = "?" Then
                If qLast = -1 Then
                    qStart = codePoint
                    qLast = codePoint
                ElseIf codePoint = qLast + 1 Then
                    qLast = codePoint
                Else
                    If qStart = qLast Then
                        pg &= "}" & $" else if (codePoint == 0x{qStart:X}) " & "{" & vbCrLf
                        pg &= vbTab & "suggestion = ""?"";" & vbCrLf
                    Else
                        pg &= "}" & $" else if (codePoint >= 0x{qStart:X} && codePoint <= 0x{qLast:X}( " & "{" & vbCrLf
                        pg &= vbTab & "suggestion = ""?"";" & vbCrLf
                    End If
                    qStart = codePoint
                    qLast = codePoint
                End If
            End If

        Next

        If qStart = qLast Then
            pg &= "}" & $" else if (codePoint == 0x{qStart:X}) " & "{" & vbCrLf
            pg &= vbTab & "suggestion = ""?"";" & vbCrLf
        Else
            pg &= "}" & $" else if (codePoint >= 0x{qStart:X} && codePoint <= 0x{qLast:X}( " & "{" & vbCrLf
            pg &= vbTab & "suggestion = ""?"";" & vbCrLf
        End If

        pg = pg.Substring(7) & vbCrLf & "}"

        Return pg

    End Function

    ''' <summary>
    ''' StrConv(value, VbStrConv.Hiragana)と Umayadia.Kana.KanaConverter.ToHiragana で
    ''' 結果が異なるものの一覧
    ''' ただし、StrConvの結果が ? になるものは結果から除きます。
    ''' </summary>
    ''' <returns></returns>
    <CodeAnalysis.SuppressMessage("Interoperability", "CA1416")>
    Public Function GenerateUniqueIf() As String

#If NETCOREAPP Then
        System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance)
#End If

        Dim diffString As New List(Of String)

        For codePoint As Integer = 0 To &H6FFF

            Dim c As String = Char.ConvertFromUtf32(codePoint).ToString

            Dim strConvResult = StrConv(c, VbStrConv.Hiragana)
            If strConvResult = "?" Then
                Continue For
            End If

            Dim kanaConvResult = KanaConverter.ToHiragana(c)

            If strConvResult <> kanaConvResult Then
                diffString.Add($"'&H{codePoint:X} StrConv={strConvResult} KanaConv={kanaConvResult}")
            End If
        Next

        Dim result As String = String.Join(vbCrLf, diffString)


        Return result

    End Function
End Class
