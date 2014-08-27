using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Markup;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Globalization;

namespace Trust
{
    /// <summary>
    /// Interaction logic for Match.xaml
    /// </summary>
    public partial class Match : Page
    {
        private Bll.Alais alaisInvoices;
        private Bll.Alais alaisOrders;

        private List<Bll.MatchingResult> MatchResults;

        private SolidColorBrush highlightBrush = new SolidColorBrush(Colors.Orange);

        //Create a Delegate that matches 
        //the Signature of the ProgressBar's SetValue method
        private delegate void UpdateProgressBarDelegate(
                System.Windows.DependencyProperty dp, Object value);

        public Match()
        {

            InitializeComponent();

            //show anything that is not matched
            populateWithUnmatched();

            //now rename the columns
            this.alaisOrders = new Bll.Alais("purchase_orders");
            this.alaisInvoices = new Bll.Alais("invoices");

            //init. the local matchresults
            this.MatchResults = new List<Bll.MatchingResult>();

        }

        private void populateWithUnmatched()
        {

            Bll.Invoice inv = new Bll.Invoice();
            GetInvocies();

            //get the purchase order list and populate it
            Bll.PurchaseOrder po = new Bll.PurchaseOrder();
            //this.lblNoOfRows.Content = po.TotalUnmatchedCount().ToString();
            List<Bll.PurchaseOrder> orders = po.GetAllUmatched(null, null, null).ToList();
            GetPOs();
            this.extendedDataGrid2.IsReadOnly = true;
        }

        private void CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            int i = 10;
        }

        private void extendedDataGrid1_AutoGeneratingColumn(object sender, ExtendedGrid.Microsoft.Windows.Controls.DataGridAutoGeneratingColumnEventArgs e)
        {
            //check if the column is within the alais details
            if (this.alaisOrders.Fields.Count(c => c.FieldName == e.Column.Header.ToString().ToLower()) > 0)
            {
                //get the instance of the field and replace it
                Bll.AlaisField field = this.alaisOrders.Fields.First(c => c.FieldName == e.Column.Header.ToString().ToLower());
                e.Column.Header = field.AlaisName;
            }

            if (e.PropertyType == typeof(System.DateTime))
                (e.Column as ExtendedGrid.Microsoft.Windows.Controls.DataGridTextColumn).Binding.StringFormat = "dd/MM/yyyy";

            //if we are in edit mode make it editable
            e.Column.IsReadOnly = true;
        }

        private void extendedDataGrid2_AutoGeneratingColumn(object sender, ExtendedGrid.Microsoft.Windows.Controls.DataGridAutoGeneratingColumnEventArgs e)
        {
            //check if the column is within the alais details
            if (this.alaisInvoices.Fields.Count(c => c.FieldName == e.Column.Header.ToString().ToLower()) > 0)
            {
                //rget the instance of the field and replace it
                Bll.AlaisField field = this.alaisInvoices.Fields.First(c => c.FieldName == e.Column.Header.ToString().ToLower());
                e.Column.Header = field.AlaisName;
            }

            if (e.PropertyType == typeof(System.DateTime))
                (e.Column as ExtendedGrid.Microsoft.Windows.Controls.DataGridTextColumn).Binding.StringFormat = "dd/MM/yyyy";
            e.Column.IsReadOnly = true;
        }

        private void butRunMatch_Click(object sender, RoutedEventArgs e)
        {
            Bll.PurchaseOrder po = new Bll.PurchaseOrder();
            Bll.Invoice inv = new Bll.Invoice();
            //run the processor
            Bll.MatchProcessor matchProcessor = new Bll.MatchProcessor(po.GetAllUmatched(null, null, null).ToList(),
                inv.GetAllUnmatched(null, null, null).ToList());

            SortTables(matchProcessor.Run());
        }

        private void SortTables(List<Bll.MatchingResult> results)
        {
            //save the match results to the local item.
            this.MatchResults = results;

            //this is where the sorted results will go
            List<Bll.Invoice> sortedInvoices = new List<Bll.Invoice>();

            //the orginal
            List<Bll.Invoice> invoices = (List<Bll.Invoice>)this.extendedDataGrid2.Items.SourceCollection;

            //Reorder
            foreach (Bll.MatchingResult result in results)
            {
                //find the invoice that matches this
                Bll.Invoice inv = invoices.First(i => i.ID == result.InvoiceID);
                //invoices are added 
                sortedInvoices.Add(inv);
            }
            //now set the grid to the matched invoices
            this.extendedDataGrid2.ItemsSource = sortedInvoices;

            //now match the purchase orders
            //this is where the sorted results will go
            List<Bll.PurchaseOrder> sortedPurchaseOrders = new List<Bll.PurchaseOrder>();

            //the orginal
            List<Bll.PurchaseOrder> purchaseOrders = (List<Bll.PurchaseOrder>)this.extendedDataGrid1.Items.SourceCollection;

            //Reorder
            foreach (Bll.MatchingResult result in results)
            {
                //find the invoice that matches this
                Bll.PurchaseOrder po = purchaseOrders.First(p => p.ID == result.PurchaseOrderID);
                sortedPurchaseOrders.Add(po);
            }

            //now set the grid to the matched invoices
            this.extendedDataGrid1.ItemsSource = sortedPurchaseOrders;

            //let the user know what has happened
            this.lblMatchResults.Content = sortedInvoices.Count.ToString() + @" matches were found - above is the filtered results of this match - results have been ordered to match";
            this.lblMatchResults.Visibility = System.Windows.Visibility.Visible;

            //update the headers at the top
            this.lblNoOfRows.Content = sortedInvoices.Count.ToString();
            this.lblPOCount.Content = sortedInvoices.Count.ToString();

            //if we have matched then save it
            if (sortedInvoices.Count > 0)
            {
                this.butSave.Visibility = System.Windows.Visibility.Visible;
                this.progressBar.Visibility = System.Windows.Visibility.Visible;
            }
        }

        /// <summary>
        /// Not in use
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void extendedDataGrid1_GotFocus(object sender, RoutedEventArgs e)
        {
            if (this.MatchResults != null && this.MatchResults.Count != 0)
            {
                //in here we need to use the latest results to highlight matches 
                //change colour to the local variable brush colour
                Bll.PurchaseOrder poID = (Bll.PurchaseOrder)this.extendedDataGrid1.CurrentItem;

                ExtendedGrid.Microsoft.Windows.Controls.DataGridRow dgr = (ExtendedGrid.Microsoft.Windows.Controls.DataGridRow)this.extendedDataGrid1.ItemContainerGenerator.ContainerFromItem(this.extendedDataGrid1.CurrentItem);
                dgr.Background = this.highlightBrush;

                List<Bll.Invoice> invoices = (List<Bll.Invoice>)this.extendedDataGrid2.Items.SourceCollection;
                Bll.Invoice inv = invoices.Where(p => p.ID == this.MatchResults.Where(mr => mr.PurchaseOrderID == poID.ID).First().InvoiceID).First();

                this.extendedDataGrid2.CurrentItem = inv;
                dgr = (ExtendedGrid.Microsoft.Windows.Controls.DataGridRow)this.extendedDataGrid2.ItemContainerGenerator.ContainerFromItem(this.extendedDataGrid2.Items.CurrentItem);
                dgr.Background = this.highlightBrush;
            }
        }

        private void butSave_Click(object sender, RoutedEventArgs e)
        {
            //save the matched records
            //set the progress bar details
            this.progressBar.Minimum = 0;
            this.progressBar.Maximum = this.MatchResults.Count;

            //Create a new instance of our ProgressBar Delegate that points
            // to the ProgressBar's SetValue method.
            UpdateProgressBarDelegate updatePbDelegate = new UpdateProgressBarDelegate(progressBar.SetValue);

            //loop through each
            this.progressBar.Value = 0;
            int i = 0;

            foreach (Bll.MatchingResult m in this.MatchResults)
            {
                m.Save();
                Dispatcher.Invoke(updatePbDelegate, System.Windows.Threading.DispatcherPriority.Background,
                    new object[] { ProgressBar.ValueProperty, Convert.ToDouble(i) });
                i++;
            }


            //now hide all of the matching result commands and display the unmatched results
            this.progressBar.Visibility = System.Windows.Visibility.Hidden;
            this.progressBar.Value = 0;
            this.lblMatchResults.Visibility = System.Windows.Visibility.Hidden;
            this.butSave.Visibility = System.Windows.Visibility.Hidden;

            //show what is now not matched
            populateWithUnmatched();
        }

        private void extendedDataGrid2_BeginningEdit(object sender, ExtendedGrid.Microsoft.Windows.Controls.DataGridBeginningEditEventArgs e)
        {


        }

        private void butSaveChanges_Click(object sender, RoutedEventArgs e)
        {
            //just get an orginl set of data back and compare against the new ones. 
            if (this.butSaveChanges.Content.ToString() == "Edit")
            {

                this.butSaveChanges.Content = "Save";
                this.butHide.IsEnabled = false;
                this.butSaveChanges.IsEnabled = true;
                this.butCancel.Visibility = System.Windows.Visibility.Visible;
                this.butRunMatch.IsEnabled = false;
                //this.extendedDataGrid2.HideColumnChooser = false;


                //get the alais details to use for the matching
                Bll.Alais alais = new Bll.Alais("purchase_orders");

                string totalpallets = alais.Fields.First(f => f.FieldName == "total_actual_pallets").AlaisName;
                if (totalpallets == "" || totalpallets == null)
                {
                    totalpallets = "total_actual_pallets";
                }

                string DepotDate = alais.Fields.First(f => f.FieldName == "depot_date").AlaisName;
                if (DepotDate == "" || DepotDate == null)
                {
                    DepotDate = "depot_date";
                }

                string id = alais.Fields.First(f => f.FieldName == "id").AlaisName;
                if (id == "" || id == null)
                {
                    id = "id";
                }

                //hide all but the editable or interesting columns
                foreach (ExtendedGrid.Microsoft.Windows.Controls.DataGridColumn c in this.extendedDataGrid1.Columns)
                {
                    if (c.Header.ToString().ToLower() != totalpallets.ToLower() && c.Header.ToString().ToLower() != DepotDate.ToLower() &&
                        c.Header.ToString().ToLower() != "Depot_Name".ToLower() && c.Header.ToString().ToLower() != id.ToLower() 
                        && c.Header.ToString().ToLower() != "Notes".ToLower())
                    {
                        c.Visibility = System.Windows.Visibility.Hidden;
                    }

                    //make the correct columns editable
                    if (c.Header.ToString().ToLower() == totalpallets.ToLower() || c.Header.ToString().ToLower() == DepotDate.ToLower() 
                        || c.Header.ToString().ToLower() == "notes")
                    {
                        c.IsReadOnly = false;
                    }
                }
            }
            else
            {
                Bll.PurchaseOrder po = new Bll.PurchaseOrder();
                this.lblPOCount.Content = po.TotalUnmatchedCount().ToString();

                //for each of the results if it has changed update it
                //check the data is correct
                //get the purchase order list and populate it
                List<Bll.PurchaseOrder> orders = po.GetAllUmatchedIncludingHidden(null, null, null).ToList();

                //loop through these 
                foreach (var v in this.extendedDataGrid1.Items.SourceCollection)
                {
                    //check it is a purchase order line
                    if (v.GetType() == typeof(Bll.PurchaseOrder))
                    {
                        Bll.PurchaseOrder order = (Bll.PurchaseOrder)v;
                        //Bll.PurchaseOrder order = (Bll.PurchaseOrder)os;
                        //when the order matches go for it
                        Bll.PurchaseOrder ord = orders.Where(o => o.ID == order.ID).First();
                        if (ord != null)
                        {
                            if (order.Total_Actual_Pallets != ord.Total_Actual_Pallets || order.Depot_Date != ord.Depot_Date)
                            {
                                //update it as there ordre changes
                                Bll.PurchaseOrder.UpdatePurchaseOrder((int)order.ID, (DateTime)order.Depot_Date, (DateTime)ord.Depot_Date, 
                                    (int)order.Total_Actual_Pallets, (int)ord.Total_Actual_Pallets, order.Notes);
                            }
                        }
                    }
                }

                GetPOs();
                this.extendedDataGrid2.IsReadOnly = true;
                this.butSaveChanges.Content = "Edit";
                this.butRunMatch.IsEnabled = true;
                this.butCancel.Visibility = System.Windows.Visibility.Hidden;
                this.butHide.IsEnabled = true;
            }

        }


        private void butCancel_Click(object sender, RoutedEventArgs e)
        {
            Bll.PurchaseOrder po = new Bll.PurchaseOrder();
            GetPOs();
            this.extendedDataGrid2.IsReadOnly = true;
            this.butSaveChanges.Content = "Edit";
            this.butRunMatch.IsEnabled = true;
        }

        private void butAddCredit_Click(object sender, RoutedEventArgs e)
        {
            //get the alais details to use for the matching
            Bll.Alais alais = new Bll.Alais("invoices");
            //hide all but the editable or interesting columns

            if (this.butAddCredit.Content.ToString() == "Add Credit or Acceptance")
            {
                this.butAddCredit.Content = "Save"; 

                string creditneeded = alais.Fields.First(f => f.FieldName.ToLower() == "credit_needed").AlaisName;
                if (creditneeded == "" || creditneeded == null)
                {
                    creditneeded = "credit_needed";
                }

                string creditrecieved = alais.Fields.First(f => f.FieldName.ToLower() == "credit_recieved").AlaisName;
                if (creditrecieved == "" || creditrecieved == null)
                {
                    creditrecieved = "credit_recieved";
                }

                string notes = alais.Fields.First(f => f.FieldName.ToLower() == "credit_notes").AlaisName;
                if (notes == "" || notes == null)
                {
                    notes = "credit_notes";
                }

                string forceAccept = alais.Fields.First(f => f.FieldName.ToLower() == "forceaccept").AlaisName;
                if (forceAccept == "" || forceAccept == null)
                {
                    forceAccept = "forceaccept";
                }

                foreach (ExtendedGrid.Microsoft.Windows.Controls.DataGridColumn c in this.extendedDataGrid2.Columns)
                {
                    if (c.Header.ToString().ToLower() == creditneeded.ToLower() || c.Header.ToString().ToLower() == creditrecieved.ToLower() ||
                            c.Header.ToString().ToLower() == notes.ToLower() || c.Header.ToString().ToLower() == forceAccept.ToLower())
                    {
                        c.IsReadOnly = false;
                    }
                }
            }
            else
            {
                this.butAddCredit.Content = "Add Credit or Acceptance";
                Bll.Invoice i = new Bll.Invoice();
                List<Bll.Invoice> invoice = i.GetAllUnmatchedIncludingCredits(null, null, null);

                foreach (var v in this.extendedDataGrid2.Items.SourceCollection)
                {

                    //check it is a purchase order line
                    if (v.GetType() == typeof(Bll.Invoice))
                    {
                        Bll.Invoice inv = (Bll.Invoice)v;
                        //Bll.PurchaseOrder order = (Bll.PurchaseOrder)os;
                        //when the order matches go for it
                        Bll.Invoice invoi = invoice.Where(o => o.ID == inv.ID).First();
                        if (inv != null)
                        {
                            if (inv.Credit_Needed != invoi.Credit_Needed || inv.Credit_Notes != invoi.Credit_Notes ||
                                inv.Credit_Recieved != invoi.Credit_Recieved != inv.ForceAccept != invoi.ForceAccept)
                            {
                                //update it as there ordre changes
                                Bll.Invoice.UpdateCreditDetails(inv.ID, inv.Credit_Needed, inv.Credit_Recieved, inv.Credit_Notes, inv.ForceAccept);
                            }
                        }
                    }
                }
                //update the invoice results
                GetInvocies();
             }
        }

        private void GetInvocies()
        {
            Bll.Invoice i = new Bll.Invoice();
            if (this.chkCredits.IsChecked.Value)
            {
                List<Bll.Invoice> lst = i.GetAllUnmatchedIncludingCredits(null, null, null).ToList();
                this.extendedDataGrid2.ItemsSource = lst;
                this.lblNoOfRows.Content = lst.Count;
            }
            else
            {
                List<Bll.Invoice> lst = i.GetAllUnmatched(null, null, null).ToList();
                this.extendedDataGrid2.ItemsSource = lst;
                this.lblNoOfRows.Content = lst.Count;
            }
        }

        private void chkCredits_Checked(object sender, RoutedEventArgs e)
        {
            GetInvocies();
        }

        private void ExtendedDataGrid1_AutoGeneratedColumns(object sender, EventArgs e)
        {
            Bll.Helpers.ColumnOrder.OrderColumns(typeof(Bll.Invoice), this.extendedDataGrid2);
        }

        private void extendedDataGrid1_AutoGeneratedColumns_1(object sender, EventArgs e)
        {
            Bll.Helpers.ColumnOrder.OrderColumns(typeof(Bll.PurchaseOrder), this.extendedDataGrid1);
        }

        private void butSaveChanges_Copy_Click(object sender, RoutedEventArgs e)
        {
            //just get an orginl set of data back and compare against the new ones. 
            if (this.butHide.Content.ToString() == "Hide Order")
            {

                this.butHide.Content = "Save";
                this.butSaveChanges.IsEnabled = false;
                this.butRunMatch.IsEnabled = false;
                //this.extendedDataGrid2.HideColumnChooser = false;


                //get the alais details to use for the matching
                Bll.Alais alais = new Bll.Alais("purchase_orders");

                string totalpallets = alais.Fields.First(f => f.FieldName == "total_actual_pallets").AlaisName;
                if (totalpallets == "" || totalpallets == null)
                {
                    totalpallets = "total_actual_pallets";
                }

                string DepotDate = alais.Fields.First(f => f.FieldName == "depot_date").AlaisName;
                if (DepotDate == "" || DepotDate == null)
                {
                    DepotDate = "depot_date";
                }

                string id = alais.Fields.First(f => f.FieldName == "id").AlaisName;
                if (id == "" || id == null)
                {
                    id = "id";
                }

                //hide all but the editable or interesting columns
                foreach (ExtendedGrid.Microsoft.Windows.Controls.DataGridColumn c in this.extendedDataGrid1.Columns)
                {
                    if (c.Header.ToString().ToLower() != totalpallets.ToLower() && c.Header.ToString().ToLower() != DepotDate.ToLower() &&
                        c.Header.ToString().ToLower() != "depot_name".ToLower() && c.Header.ToString().ToLower() != id.ToLower()
                        && c.Header.ToString().ToLower() != "notes".ToLower() && c.Header.ToString().ToLower() != "hide".ToLower()
                        && c.Header.ToString().ToLower() != "reasonforhide".ToLower())
                    {
                        c.Visibility = System.Windows.Visibility.Hidden;
                    }

                    //make the correct columns editable
                    if (c.Header.ToString().ToLower() != totalpallets.ToLower() && c.Header.ToString().ToLower() != DepotDate.ToLower()
                        && c.Header.ToString().ToLower() != "notes")
                    {
                        c.IsReadOnly = false;
                    }
                }
            }
            else
            {
                Bll.PurchaseOrder po = new Bll.PurchaseOrder();
                this.lblPOCount.Content = po.TotalUnmatchedCount().ToString();

                //for each of the results if it has changed update it
                //check the data is correct
                //get the purchase order list and populate it
                List<Bll.PurchaseOrder> orders = po.GetAllUmatched(null, null, null).ToList();
                this.butSaveChanges.IsEnabled = false;
                //loop through these 
                foreach (var v in this.extendedDataGrid1.Items.SourceCollection)
                {
                    //check it is a purchase order line
                    if (v.GetType() == typeof(Bll.PurchaseOrder))
                    {
                        Bll.PurchaseOrder order = (Bll.PurchaseOrder)v;
                        //Bll.PurchaseOrder order = (Bll.PurchaseOrder)os;
                        //when the order matches go for it
                        Bll.PurchaseOrder ord = orders.Where(o => o.ID == order.ID).First();
                        if (ord != null)
                        {
                            if (order.Hide != ord.Hide || order.ReasonForHide != ord.ReasonForHide)
                            {
                                //update it as there ordre changes
                                Bll.PurchaseOrder.ChangeHideStatus((int)order.ID, order.Hide,order.ReasonForHide);
                            }
                        }
                    }
                }

                GetPOs();
                this.extendedDataGrid2.IsReadOnly = true;
                this.butHide.Content = "Hide Order";
                this.butRunMatch.IsEnabled = true;
                this.butSaveChanges.IsEnabled = true;
                this.butCancel.Visibility = System.Windows.Visibility.Hidden;
            }
        }

        private void chkHidden_Checked(object sender, RoutedEventArgs e)
        {
            GetPOs();
        }

        private void GetPOs()
        {
            Bll.PurchaseOrder i = new Bll.PurchaseOrder();
            if (this.chkHidden.IsChecked.Value)
            {
                List<Bll.PurchaseOrder> lst = i.GetAllUmatchedIncludingHidden(null, null, null).ToList();
                this.extendedDataGrid1.ItemsSource = lst;
                this.lblPOCount.Content = lst .Count;
            }
            else
            {
                List<Bll.PurchaseOrder> lst = i.GetAllUmatched(null, null, null).ToList();
                this.extendedDataGrid1.ItemsSource = lst;
                this.lblPOCount.Content = lst.Count;

            }
        }

    }
}
