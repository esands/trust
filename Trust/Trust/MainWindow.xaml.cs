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
using System.Windows.Shapes;
using Microsoft.Windows.Controls.Ribbon;
using Microsoft.Windows.Controls;

namespace Trust
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : RibbonWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            this.auxPanel.Text = "Please select from these commonly used features";
            
            // Insert code required on object creation below this point.
            
        }

        private void RibbonButton_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void Ribbon_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ConfigSettings_Click(object sender, RoutedEventArgs e)
        {
            Page p = new Options();
            this.ContentFrame.Content = p;
        }

        private void FieldName_Click(object sender, RoutedEventArgs e)
        {
            Page p = new TableAlais();
            this.ContentFrame.Content = p;
        }

        private void ImportRoutine_Click(object sender, RoutedEventArgs e)
        {
            Page p = new ImportRountineManager();
            this.ContentFrame.Content = p;
        }

        private void ImportRoutineFile_Click(object sender, RoutedEventArgs e)
        {
            Page p = new Import();
            this.ContentFrame.Content = p;
        }

        private void Match_NewMatch_Click(object sender, RoutedEventArgs e)
        {
            Page p = new Match();
            this.ContentFrame.Content = p; 
        }

        private void RibbonButton_Click(object sender, RoutedEventArgs e)
        {
            Page p = new Reports();
            this.ContentFrame.Content = p; 
        }

        private void RibbonButton_Click_1(object sender, RoutedEventArgs e)
        {
            Page p = new Amendments();
            this.ContentFrame.Content = p;
        }

        private void RibbonButton_Click_2(object sender, RoutedEventArgs e)
        {
            Page p = new LookupTables();
            this.ContentFrame.Content = p;

        }

        private void RibbonButton_Click_3(object sender, RoutedEventArgs e)
        {
            Page p = new ColumnOrder();
            this.ContentFrame.Content = p;
        }

        private void RibbonButton_Click_4(object sender, RoutedEventArgs e)
        {
            Page p = new MatchingManager();
            this.ContentFrame.Content = p;
        }
    }
}
