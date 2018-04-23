using System.Drawing;
using System.ComponentModel;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports;
using DevExpress.XtraReports.UI;
// ...

namespace CustomControls {
    // The DefaultBindableProperty attribute is intended to make the Position 
    // property bindable when an item is dropped from the Field List.
    [
    ToolboxItem(true),
    DefaultBindableProperty("Position")
    ]
    public class ProgressBar : XRControl {

        // The current position value.
        private float pos = 0;

        // The maximum value for the progress bar position.
        private float maxVal = 100;

        public ProgressBar() {
            this.ForeColor = SystemColors.Highlight;
        }

        // Define the MaxValue property.
        [DefaultValue(100)]
        public float MaxValue {
            get { return this.maxVal; }
            set {
                if (value <= 0) return;
                this.maxVal = value;
            }
        }

        // Define the Position property. 
        [DefaultValue(0), Bindable(true)]
        public float Position {
            get { return this.pos; }
            set {
                if(value < 0 || value > maxVal)
                    return;
                this.pos = value;
            }
        }

        // Override the XRControl.CreateBrick method.
        protected override VisualBrick CreateBrick(VisualBrick[] childrenBricks) {
            // Use this code to make the progress bar control 
            // always represented as a Panel brick.
            return new PanelBrick(this);
        }

        // Override the XRControl.PutStateToBrick method.
        protected override void PutStateToBrick(VisualBrick brick, PrintingSystemBase ps) {
            // Call the PutStateToBrick method of the base class.
            base.PutStateToBrick(brick, ps);

            // Get the Panel brick which represents the current progress bar control.
            PanelBrick panel = (PanelBrick)brick;

            // Create a new VisualBrick to be inserted into the panel brick.
            VisualBrick progressBar = new VisualBrick(this);

            // Hide borders.
            progressBar.Sides = BorderSide.None;

            // Set the foreground color to fill the completed area of a progress bar.
            progressBar.BackColor = panel.Style.ForeColor;

            // Calculate the rectangle to be filled by the foreground color.
            progressBar.Rect = new RectangleF(0, 0, panel.Rect.Width * (Position / MaxValue),
                panel.Rect.Height);

            // Add the VisualBrick to the panel.
            panel.Bricks.Add(progressBar);
        }
    }
}