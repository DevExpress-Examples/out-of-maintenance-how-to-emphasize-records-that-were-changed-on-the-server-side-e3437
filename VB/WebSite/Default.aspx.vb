Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls

Partial Public Class _Default
	Inherits System.Web.UI.Page

	Protected Sub grid_CustomJSProperties(ByVal sender As Object, ByVal e As DevExpress.Web.ASPxGridView.ASPxGridViewClientJSPropertiesEventArgs)
		Dim startIndex As Int32 = grid.PageIndex * grid.SettingsPager.PageSize
        Dim endIndex As Int32 = Math.Min(grid.VisibleRowCount, startIndex + grid.SettingsPager.PageSize)

        Dim rowIndexes(endIndex - startIndex - 1) As Object
        Dim locks(endIndex - startIndex - 1) As Object

        For i As Int32 = startIndex To endIndex - 1
            rowIndexes(i - startIndex) = i
            locks(i - startIndex) = grid.GetRowValues(i, "Lock")
        Next i

		e.Properties("cpRowIndexes") = rowIndexes
		e.Properties("cpLocks") = locks
	End Sub
End Class