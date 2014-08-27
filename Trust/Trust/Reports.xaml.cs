using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ExtendedGrid.Classes;

namespace Trust
{
    /// <summary>
    /// Interaction logic for Reports.xaml
    /// </summary>
    public partial class Reports : Page
    {
        private Bll.Alais alaisInvoices;
        private Bll.Alais alaisOrders;

        public Reports()
        {
            InitializeComponent();

            //now rename the columns
            this.alaisOrders = new Bll.Alais("purchase_orders");
            this.alaisInvoices = new Bll.Alais("invoices");
        }



        private void butBrowse_Click(object sender, RoutedEventArgs e)
        {
            // Create OpenFileDialog
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            dlg.DefaultExt = ".xlsx"; // Default file extension
            dlg.Filter = "Excel documents (.xlsx)|*.xlsx"; // Filter files by extension7

            // Display OpenFileDialog by calling ShowDialog method
            Nullable<bool> result = dlg.ShowDialog();
            string filename = "";

            // Get the selected file name and display in a TextBox
            if (result == true)
            {
                // Open document
                try
                {
                    filename = dlg.FileName;
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error");
                }
            }

            if (filename != "")
            {
                if (!filename.ToLower().Contains(".xls"))
                {
                    filename += ".xlsx"; 
                }
                this.extendedDataGrid1.ExportToExcel("Trust Export", filename, true);
            }   
        }

        private void extendedDataGrid1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (this.radPO.IsChecked.Value)
            {
                if (this.radUnmatched.IsChecked.Value)
                {
                    //get the purchase order list and populate it
                    Bll.PurchaseOrder po = new Bll.PurchaseOrder();
                    List<Bll.PurchaseOrder> orders = po.GetAllUmatched(null, null, null).ToList();
                    this.extendedDataGrid1.ItemsSource = orders;
                    this.extendedDataGrid1.AutoGeneratingColumn += extendedDataGrid1_AutoGeneratingColumn;
                }
                else if (this.radUnmatched_inc_credit.IsChecked.Value)
                {
                    //get the purchase order list and populate it
                    Bll.PurchaseOrder po = new Bll.PurchaseOrder();
                    List<Bll.PurchaseOrder> orders = po.GetAllUmatchedIncludingHidden(null, null, null).ToList();
                    this.extendedDataGrid1.ItemsSource = orders;
                    this.extendedDataGrid1.AutoGeneratingColumn += extendedDataGrid1_AutoGeneratingColumn;
                } 
                else
                {
                    Bll.PurchaseOrder po = new Bll.PurchaseOrder();
                    List<Bll.PurchaseOrder> orders = po.GetAllMatched(null, null, null).ToList();
                    this.extendedDataGrid1.ItemsSource = orders;
                    this.extendedDataGrid1.AutoGeneratingColumn += extendedDataGrid1_AutoGeneratingColumn;
                }
                Bll.Helpers.ColumnOrder.OrderColumns(typeof(Bll.PurchaseOrder),this.extendedDataGrid1);
            }
            else if (this.radInv.IsChecked.Value)
            {
                if (this.radUnmatched.IsChecked.Value)
                {
                    //get the purchase order list and populate it
                    Bll.Invoice i = new Bll.Invoice();
                    List<Bll.Invoice> invoices = i.GetAllUnmatched(null, null, null).ToList();
                    this.extendedDataGrid1.ItemsSource = invoices;
                    this.extendedDataGrid1.AutoGeneratingColumn += extendedDataGrid1_AutoGeneratingColumn;
                }               
                else if (this.radUnmatched_inc_credit.IsChecked.Value)
                {
                    //get the purchase order list and populate it
                    Bll.Invoice i = new Bll.Invoice();
                    List<Bll.Invoice> invoices = i.GetAllUnmatchedIncludingCredits(null, null, null).ToList();
                    this.extendedDataGrid1.ItemsSource = invoices;
                    this.extendedDataGrid1.AutoGeneratingColumn += extendedDataGrid1_AutoGeneratingColumn;
                }
                else
                {
                    //get this purchase order list and populate it
                    Bll.Invoice i = new Bll.Invoice();
                    List<Bll.Invoice> invoices = i.GetAllMatched(null, null, null).ToList();
                    this.extendedDataGrid1.ItemsSource = invoices;
                    this.extendedDataGrid1.AutoGeneratingColumn += extendedDataGrid1_AutoGeneratingColumn;
                }
                Bll.Helpers.ColumnOrder.OrderColumns(typeof(Bll.Invoice), this.extendedDataGrid1);
            }
        }

        private void extendedDataGrid1_AutoGeneratingColumn(object sender, ExtendedGrid.Microsoft.Windows.Controls.DataGridAutoGeneratingColumnEventArgs e)
        {
            //check if the column is within the alais details
            if (this.alaisOrders.Fields.Count(c => c.FieldName == e.Column.Header.ToString().ToLower()) > 0)
            {
                //rget the instance of the field and replace it
                Bll.AlaisField field = this.alaisOrders.Fields.First(c => c.FieldName == e.Column.Header.ToString().ToLower());
                e.Column.Header = field.AlaisName;
            }

            if (e.PropertyType == typeof(System.DateTime))
                (e.Column as ExtendedGrid.Microsoft.Windows.Controls.DataGridTextColumn).Binding.StringFormat = "dd/MM/yyyy";
            //if we are in edit mode make it editable

            e.Column.IsReadOnly = true;
        }

    }
}
