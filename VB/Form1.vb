Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing.Design
Imports System.Windows.Forms
Imports DevExpress.XtraReports.UserDesigner
' ...

Namespace WindowsFormsApplication1
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
			' Create an End-User Designer form.
			Dim designForm As New XRDesignForm()

			' Handle the DesignPanelLoaded event.
			AddHandler designForm.DesignMdiController.DesignPanelLoaded, AddressOf DesignMdiController_DesignPanelLoaded

			' Load a report into the Designer.
			designForm.OpenReport(New XtraReport1())

			' Show the End-User Designer form, modally.
			designForm.ShowDialog()

		End Sub

		Private Sub DesignMdiController_DesignPanelLoaded(ByVal sender As Object, ByVal e As DesignerLoadedEventArgs)
			' Get the Toolbox service from the Designer host.
			Dim ts As IToolboxService = CType(e.DesignerHost.GetService(GetType(IToolboxService)), IToolboxService)

			' Add a new category to the Toolbox,
			' and place a custom control into it.
			Dim item As New ToolboxItem(GetType(ProgressBar))
			ts.AddToolboxItem(item, "New Category")
			'((XRToolboxService)ts).AddToolBoxImage(typeof(ProgressBar), Image.FromFile("ProgressBar.bmp"));

		End Sub
	End Class
End Namespace
