Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web

Public Class DataItem
	Public Sub New(ByVal id As Int32, ByVal someValue As String)
		Me.id_Renamed = id
		Me.someValue_Renamed = someValue
		Me._lock = 0
	End Sub

	Private id_Renamed As Int32
	Public ReadOnly Property Id() As Int32
		Get
			Return id_Renamed
		End Get
	End Property

	Private someValue_Renamed As String
	Public Property SomeValue() As String
		Get
			Return someValue_Renamed
		End Get
		Set(ByVal value As String)
			UpdateItem(value)
		End Set
	End Property

	Private _lock As Int32
	Public ReadOnly Property Lock() As Int32
		Get
			Return _lock
		End Get
	End Property

	Public Sub UpdateItem(ByVal value As String)
		Me.someValue_Renamed = value
		Me._lock += 1
	End Sub
End Class