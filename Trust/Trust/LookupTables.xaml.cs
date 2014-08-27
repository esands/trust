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
    /// Interaction logic for LookupTables.xaml
    /// </summary>
    public partial class LookupTables : Page
    {
        public LookupTables()
        {
            InitializeComponent();
            
            //get all of the depots names including any that are not named. 
            this.extendedDataGrid1.ItemsSource = Bll.LookupTable.GetAllIncludingBlanks();

            //set up the combo box for haulier
            this.ddlHaluier.ItemsSource = Bll.Haulier.GetAll();

            //set up the combobox depot
            this.ddlDepot.ItemsSource = Bll.Depot.GetAll();

        }

        private void butBrowse_Copy_Click(object sender, RoutedEventArgs e)
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
        

        private void extendedDataGrid1_AutoGeneratingColumn(object sender, ExtendedGrid.Microsoft.Windows.Controls.DataGridAutoGeneratingColumnEventArgs e)
        {
           if (e.Column.Header.ToString() != "HaulierDepotName" && e.Column.Header.ToString() != "HaulierID")
           {
               e.Column.IsReadOnly = true;
           }    
        }

        private void butBrowse_Copy2_Click(object sender, RoutedEventArgs e)
        {
            this.extendedDataGrid1.ItemsSource = Bll.LookupTable.GetAllIncludingBlanks();
        }

        private void butBrowse_Copy1_Click(object sender, RoutedEventArgs e)
        {
            Bll.LookupTable lt = new Bll.LookupTable();
            List<Bll.LookupTable> lstLT = Bll.LookupTable.GetAllIncludingBlanks();

            try
            {

                foreach (var v in this.extendedDataGrid1.Items.SourceCollection)
                {
                    //Get the instance of the field the field alaises as required.  

                    if (v.GetType() == typeof(Bll.LookupTable))
                    {
                        Bll.LookupTable item = (Bll.LookupTable)v;


                        //if this is a new item
                        if (item.ID == 0 && item.HaulierDepotName != "")
                        {
                            //insert the new items into the database
                            item.Insert(item.HaulierDepotName, item.HaulierID, item.YeoValleyDepotID);
                        }
                        else if (item.ID != 0)
                        {
                            Bll.LookupTable t = lstLT.First(l => l.ID == item.ID);
                            if (t.HaulierDepotName != item.HaulierDepotName)
                            {
                                //the details have changed so update the record
                                t.Update(item.ID, item.HaulierDepotName, item.HaulierID, item.YeoValleyDepotID);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "One or more of your changes were not saved", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            this.extendedDataGrid1.ItemsSource = Bll.LookupTable.GetAllIncludingBlanks();
        }

        private void ddlDepot_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void butBrowse_Copy3_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //get the relevant details from the page
                Bll.LookupTable item = new Bll.LookupTable();
                Bll.Depot d = (Bll.Depot)this.ddlDepot.SelectedItem;
                Bll.Haulier h = (Bll.Haulier)this.ddlHaluier.SelectedItem;

                //insert the new items into the database
                item.Insert(this.txtHaulierName.Text, h.ID, d.Code);
            }
            catch
            {
                MessageBox.Show("Unable to add data", "Their is an error in the values you are trying to add, please check and try again", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            //get all of the depots names including any that are not named. 
            this.extendedDataGrid1.ItemsSource = Bll.LookupTable.GetAllIncludingBlanks();
        }
    }
}
