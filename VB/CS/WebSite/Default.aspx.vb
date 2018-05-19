Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports DevExpress.Web.ASPxGridView

Partial Public Class _Default
	Inherits System.Web.UI.Page

	Protected Sub ASPxGridView1_DataBound(ByVal sender As Object, ByVal e As EventArgs)
		Dim grid As ASPxGridView = CType(sender, ASPxGridView)
		SaveJsProperties(grid)
	End Sub
	Protected Sub ASPxGridView1_CustomCallback(ByVal sender As Object, ByVal e As ASPxGridViewCustomCallbackEventArgs)
		Dim grid As ASPxGridView = CType(sender, ASPxGridView)
		Select Case e.Parameters
			Case "Next"
				grid.PageIndex += 1
			Case "Prev"
				grid.PageIndex -= 1
		End Select
		SaveJsProperties(grid)
	End Sub
	Private Sub SaveJsProperties(ByVal grid As ASPxGridView)
		grid.JSProperties("cpPageCount") = grid.PageCount
		grid.JSProperties("cpPageIndex") = grid.PageIndex
	End Sub
End Class
