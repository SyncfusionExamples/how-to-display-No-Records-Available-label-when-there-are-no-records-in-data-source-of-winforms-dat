# How to display "No Records Available" label when there are no records in the DataSource of WinForms DataGrid (SfDataGrid)?

## About the sample

This example illustrates how to display "No Records Available" label when there are no records in the DataSource of WinForms DataGrid (SfDataGrid).

[WinForms DataGrid](https://www.syncfusion.com/winforms-ui-controls/datagrid) (SfDataGrid) doesn’t have direct support to show any label when no records are available in the underlying data source. However, you can manually add a label to the SfDataGrid.TableControl and handle its visibility based on the number of records. This needs to be checked on initial loading and in the events that occurs while changing the DataSource and while deleting the existing row.

```C#

Label noRecordsLabel = new Label();

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

```

![Display No Records label when all the rows](NoRecords.gif)


## Requirements to run the demo

Visual Studio 2015 and above versions.