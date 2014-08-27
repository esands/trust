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
using System.Data.OleDb;

namespace Trust
{
    /// <summary>
    /// Interaction logic for options.xaml
    /// </summary>
    public partial class Options : Page
    {
        public Options()
        {
            InitializeComponent();
            this.lblConnectionString.Text = Properties.Settings.Default.ConnectionString;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            MSDASC.DataLinks mydlg = new MSDASC.DataLinks();
            OleDbConnection OleCon = new OleDbConnection();
            ADODB._Connection ADOcon;

            //Cast the generic object that PromptNew returns to an ADODB._Connection.
            ADOcon = (ADODB._Connection)mydlg.PromptNew();

            OleCon.ConnectionString = ADOcon.ConnectionString;
            OleCon.Open();

            //test the connection - if ok save it to the setting file
            if (OleCon.State.ToString() == "Open")
            {
                MessageBox.Show("Connection OK");
                Properties.Settings.Default.ConnectionString = OleCon.ConnectionString.ToString();
                Properties.Settings.Default.Save();
                string connection = (string)Properties.Settings.Default.ConnectionString;
                OleCon.Close();
            }
            else
            {
                MessageBox.Show("Connection Failed");
            }
        }
    }
}
