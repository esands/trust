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
using System.Reflection;
using Trust.Bll;

namespace Trust
{
    /// <summary>
    /// Interaction logic for Import.xaml
    /// </summary>
    public partial class Import : Page
    {
        //Create a Delegate that matches 
        //the Signature of the ProgressBar's SetValue method
        private delegate void UpdateProgressBarDelegate(
                System.Windows.DependencyProperty dp, Object value);

        public Import()
        {
            InitializeComponent();
            this.cbImportRoutine.Items.Clear();

            foreach (Bll.ImportHeader routine in Bll.ImportRoutine.GetAllImportRoutineDetails())
            {
                ComboBoxItem item = new ComboBoxItem();
                item.Content = routine.Name;
                this.cbImportRoutine.Items.Add(item);
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            // Create OpenFileDialog
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();

            // Display OpenFileDialog by calling ShowDialog method
            Nullable<bool> result = dlg.ShowDialog();
            this.progressBar1.Value = 0;
            // Get the selected file name and display in a TextBox
            if (result == true)
            {
                // Open document
                string filename = dlg.FileName;
                FileNameTextBox.Text = filename;
            }
        }

        private void butImport_Click(object sender, RoutedEventArgs e)
        {
            //get the header info of the selected value

            if (this.cbImportRoutine.Text == "" || this.FileNameTextBox.Text == "")
            {
                MessageBox.Show("You must select an import routine", "Import Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                Bll.ImportHeader header = Bll.ImportRoutine.GetAllImportRoutineDetails().Where(h => h.Name.ToString() == this.cbImportRoutine.Text).First();
                //MessageBox.Show("You must select an import routine", "Import Error", MessageBoxButton.OK, MessageBoxImage.Error);
                //Bll.Import.PurchaseOrderExcelImport c = new Bll.Import.PurchaseOrderExcelImport(header.Id, this.FileNameTextBox.Text, (bool)this.chkHasHeader.IsChecked);
                //string s = c.GetType().ToString();

                //import routine.
                Type type = Type.GetType(header.ClassName, true);

                //create the argments for the object  
                Object[] args = { header.Id, this.FileNameTextBox.Text, this.chkHasHeader.IsChecked };

                //create the instance of the importer class
                Bll.Import.IImportProcess importer = (Bll.Import.IImportProcess)Activator.CreateInstance(type, args);

                //open the file
                importer.OpenFile();

                //set the progress bar details
                this.progressBar1.Minimum = 0;
                this.progressBar1.Maximum = importer.TotalRows;

                //Create a new instance of our ProgressBar Delegate that points
                // to the ProgressBar's SetValue method.
                UpdateProgressBarDelegate updatePbDelegate = new UpdateProgressBarDelegate(progressBar1.SetValue);


                try
                {

                    //loop through each
                    this.progressBar1.Value = 0;
                    do
                    {

                        importer.ImportLine();
                        //update the progress bar
                        /*Update the Value of the ProgressBar:
                        1) Pass the "updatePbDelegate" delegate
                           that points to the ProgressBar1.SetValue method
                        2) Set the DispatcherPriority to "Background"
                        3) Pass an Object() Array containing the property
                           to update (ProgressBar.ValueProperty) and the new value */
                        Dispatcher.Invoke(updatePbDelegate, System.Windows.Threading.DispatcherPriority.Background,
                            new object[] { ProgressBar.ValueProperty, Convert.ToDouble(importer.ProcessingRow) });

                    } while (!importer.EOF);

                }
                catch (Exception ex)
                {
                    //show user the error message for debugging purposes.
                    MessageBox.Show(ex.Message, "An error has occured while importing", MessageBoxButton.OK, MessageBoxImage.Error);
                    this.progressBar1.Value = 0;
                }

                //ensure all the progress bar gets to the end
                // Dispatcher.Invoke(updatePbDelegate, System.Windows.Threading.DispatcherPriority.Background,
                //     new object[] { ProgressBar.ValueProperty, importer.TotalRows });

                //print the details of what has happened.  
                if (importer.dalImporter.ArrayErrors.Count != 0)
                {
                    txtImported.Text = "Import complete. " + "There were " + importer.dalImporter.ArrayErrors.Count.ToString() + " Lines not imported - see below for details ";
                }
                else
                {
                    txtImported.Text = "Import complete, no rows skipped";
                }

                this.dataGrid1.ItemsSource = null;
                this.dataGrid1.ItemsSource = importer.dalImporter.ArrayErrors;

                //finally close the file
                importer.CloseFile();
            }
        }

        private void progressBar1_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            
        }

        private void dataGrid1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
