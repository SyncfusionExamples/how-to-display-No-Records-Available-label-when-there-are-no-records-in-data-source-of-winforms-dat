using SfDataGrid_Demo;
using Syncfusion.WinForms.Controls;
using Syncfusion.WinForms.DataGrid;
using System;
using System.Collections;
using System.Linq;
using System.Windows.Forms;
using Syncfusion.WinForms.DataGrid.Enums;
using System.Drawing;
using Syncfusion.WinForms.DataGrid.Renderers;
using Syncfusion.WinForms.GridCommon.ScrollAxis;
using Syncfusion.Data.Extensions;

namespace SfDataGrid_Demo
{
    /// <summary>
    /// Summary description for Form1.
    /// </summary>
    public partial class Form1 : Form
    {
        #region Constructor

        Label noRecordsLabel = new Label();
        /// <summary>
        /// Initializes the new instance for the Form.
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            sfDataGrid1.DataSource = new OrderInfoRepository().GetListOrdersDetails(5);


            noRecordsLabel.Visible = false;
            noRecordsLabel.Text = "No records available";
            noRecordsLabel.TextAlign = ContentAlignment.MiddleCenter;
            noRecordsLabel.Width = 300;
            noRecordsLabel.Location = new Point(this.sfDataGrid1.TableControl.Width/3, this.sfDataGrid1.TableControl.Height/3);

            this.sfDataGrid1.TableControl.Controls.Add(noRecordsLabel);

            this.Load += OnForm_Load;
            this.sfDataGrid1.DataSourceChanged += OnSfDataGrid_DataSourceChanged;
            this.sfDataGrid1.View.Records.CollectionChanged += OnRecords_CollectionChanged;
            this.sfDataGrid1.RecordDeleted += OnSfDataGrid_RecordDeleted;
        }

        private void OnSfDataGrid_RecordDeleted(object sender, Syncfusion.WinForms.DataGrid.Events.RecordDeletedEventArgs e)
        {
            SetNoRecordsLabelVisibility();
        }

        private void OnRecords_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            SetNoRecordsLabelVisibility();
        }

        private void OnForm_Load(object sender, EventArgs e)
        {
            SetNoRecordsLabelVisibility();
        }

        private void OnSfDataGrid_DataSourceChanged(object sender, Syncfusion.WinForms.DataGrid.Events.DataSourceChangedEventArgs e)
        {
            SetNoRecordsLabelVisibility();
        }


        private void SetNoRecordsLabelVisibility()
        {
            if (this.sfDataGrid1.GroupColumnDescriptions.Count > 0)
                noRecordsLabel.Visible = this.sfDataGrid1.View.TopLevelGroup != null && this.sfDataGrid1.View.TopLevelGroup.Groups.Count == 0;
            else
                noRecordsLabel.Visible = this.sfDataGrid1.View.Records.Count == 0;
        }

        #endregion
    }
}
