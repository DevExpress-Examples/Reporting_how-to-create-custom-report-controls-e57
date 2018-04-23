Imports System
Imports System.Drawing
Imports System.ComponentModel
Imports System.Windows.Forms
Imports DevExpress.XtraReports
Imports DevExpress.XtraReports.UI
Imports DevExpress.XtraReports.Localization
'...

Namespace CustomControls
    <DefaultBindableProperty("Number"), ToolboxBitmap(GetType(XRNumericLabel))> _
    Public Class XRNumericLabel
        Inherits XRLabel
        Private number_Renamed As Integer

        <SRCategory(ReportStringId.CatData), DefaultValue(0), Bindable(True)> _
        Public Overridable Property Number() As Integer
            Get
                Return number_Renamed
            End Get
            Set(ByVal value As Integer)
                number_Renamed = Value
            End Set
        End Property

        <Browsable(False), EditorBrowsable(EditorBrowsableState.Never), Bindable(False)> _
        Public Overrides Property Text() As String
            Get
                Return number_Renamed.ToString()
            End Get
            Set(ByVal value As String)
                Dim i As Integer

                If Integer.TryParse(Value, i) Then
                    number_Renamed = i
                Else
                    MessageBox.Show("This text can't be converted to a number!")
                End If
            End Set
        End Property
    End Class
End Namespace
