Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web

Public Class BusinessObject
	Private SessionKey As String = "Some key"

	Public Function GetDataSource() As List(Of DataItem)
		If HttpContext.Current.Session(SessionKey) Is Nothing Then
			Dim items As List(Of DataItem) = New List(Of DataItem)()

			items.Add(New DataItem(0, "Value"))
			items.Add(New DataItem(1, "Random value"))
			items.Add(New DataItem(2, "Some value"))
			items.Add(New DataItem(3, "Just a value"))
			items.Add(New DataItem(4, "Unknown value"))
			items.Add(New DataItem(5, "Public value"))
			items.Add(New DataItem(6, "Secret value"))

			HttpContext.Current.Session(SessionKey) = items
		End If

		Return CType(HttpContext.Current.Session(SessionKey), List(Of DataItem))
	End Function

	Public Sub UpdateDataItem(ByVal Id As Int32, ByVal SomeValue As String)
		Dim items As List(Of DataItem) = GetDataSource()

		Dim item As DataItem = items.Find(Function(i) i.Id = Id)
		item.UpdateItem(SomeValue)
	End Sub
End Class