Imports System.Drawing
Imports System.ComponentModel
Imports DevExpress.XtraPrinting
Imports DevExpress.XtraReports
Imports DevExpress.XtraReports.UI
' ...

Namespace CustomControls
    ' The DefaultBindableProperty attribute is intended to make the Position 
    ' property bindable when an item is dropped from the Field List.
    <ToolboxItem(True), _
    DefaultBindableProperty("Position")> _
    Public Class ProgressBar
        Inherits XRControl

        ' The current position value.
        Private pos As Single = 0

        ' The maximum value for the progress bar position.
        Private maxVal As Single = 100

        Public Sub New()
            Me.ForeColor = SystemColors.Highlight
        End Sub

        ' Define the MaxValue property.
        <DefaultValue(100)> _
        Public Property MaxValue() As Single
            Get
                Return Me.maxVal
            End Get
            Set(ByVal value As Single)
                If value <= 0 Then
                    Return
                End If
                Me.maxVal = value
            End Set
        End Property

        ' Define the Position property. 
        <DefaultValue(0), Bindable(True)> _
        Public Property Position() As Single
            Get
                Return Me.pos
            End Get
            Set(ByVal value As Single)
                If value < 0 Or value > maxVal Then
         Return
                End If
                Me.pos = value
            End Set
        End Property

        ' Override the XRControl.CreateBrick method.
        Protected Overrides Function CreateBrick(ByVal childrenBricks As VisualBrick()) As VisualBrick
            ' Use this code to make the progress bar control 
            ' to be always represented as a Panel brick.
            Return New PanelBrick(Me)
        End Function

        ' Override the XRControl.PutStateToBrick method.
        Protected Overrides Sub PutStateToBrick(ByVal brick As VisualBrick, ByVal ps As PrintingSystem)
            ' Call the PutStateToBrick method of the base class.
            MyBase.PutStateToBrick(brick, ps)

            ' Get the Panel brick which represents the current progress bar control.
            Dim panel As PanelBrick = CType(brick, PanelBrick)

            ' Create a new VisualBrick to be inserted into the panel brick.
            Dim myProgressBar As VisualBrick = New VisualBrick(Me)

            ' Hide borders.
            myProgressBar.Sides = BorderSide.None

            ' Set the foreground color to fill the completed area of a progress bar.
            myProgressBar.BackColor = panel.Style.ForeColor

            ' Calculate the rectangle to be filled by the foreground color.
            myProgressBar.Rect = New RectangleF(0, 0, panel.Rect.Width * (Position / MaxValue), _
                panel.Rect.Height)

            ' Add the VisualBrick to the panel.
            panel.Bricks.Add(myProgressBar)
        End Sub
    End Class
End Namespace
