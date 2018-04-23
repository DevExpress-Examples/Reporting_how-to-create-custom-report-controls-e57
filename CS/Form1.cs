using System;
using System.Drawing.Design;
using System.Windows.Forms;
using DevExpress.XtraReports.UserDesigner;
// ...

namespace WindowsFormsApplication1 {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            // Create an End-User Designer form.
            XRDesignForm designForm = new XRDesignForm();

            // Handle the DesignPanelLoaded event.
            designForm.DesignMdiController.DesignPanelLoaded += DesignMdiController_DesignPanelLoaded;

            // Load a report into the Designer.
            designForm.OpenReport(new XtraReport1());

            // Show the End-User Designer form, modally.
            designForm.ShowDialog();

        }

        void DesignMdiController_DesignPanelLoaded(object sender, DesignerLoadedEventArgs e) {
            // Get the Toolbox service from the Designer host.
            IToolboxService ts =
                (IToolboxService)e.DesignerHost.GetService(typeof(IToolboxService));

            // Add a new category to the Toolbox,
            // and place a custom control into it.
            ToolboxItem item = new ToolboxItem(typeof(ProgressBar));
            ts.AddToolboxItem(item, "New Category");
            //((XRToolboxService)ts).AddToolBoxImage(typeof(ProgressBar), Image.FromFile("ProgressBar.bmp"));

        }
    }
}
