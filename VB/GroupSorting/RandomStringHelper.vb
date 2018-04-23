Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks

Namespace DXSample
	Public Class RandomStringHelper
		Private Shared rnd As New Random()
		Private Shared letters As String = "abcdefghijklmnopqrstuvwxyz"

		Public Shared Function GetRandomString() As String
			Dim length As Integer = rnd.Next(6, 20)
			Dim retVal As String = ("" & letters.Chars(rnd.Next(25))).ToUpper()

			For i As Integer = 0 To length - 2
				retVal &= letters.Chars(rnd.Next(25))
			Next i

			Return retVal
		End Function
	End Class
End Namespace
