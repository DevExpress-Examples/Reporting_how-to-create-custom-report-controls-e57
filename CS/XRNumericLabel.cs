using System;
using System.Drawing;
using System.ComponentModel;
using System.Windows.Forms;
using DevExpress.XtraReports;
using DevExpress.XtraReports.UI;
using DevExpress.XtraReports.Localization;
//...

namespace CustomControls {
    [DefaultBindableProperty("Number"), ToolboxBitmap(typeof(XRNumericLabel))]
    public class XRNumericLabel : XRLabel {
        private int number;

        [SRCategory(ReportStringId.CatData), DefaultValue(0), Bindable(true)]
        public virtual int Number {
            get { return number; }
            set { number = value; }
        }

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never), Bindable(false)]
        public override string Text {
            get { return number.ToString(); }
            set {
                int i;

                if (int.TryParse(value, out i)) {
                       number = i;
                }
                else {
                    MessageBox.Show("This text can't be converted to a number!");
                }
            }
        }
    }
}
