   M S B A M L   `   `   `  ����G  CExtendedGrid, Version=2.0.0.6, Culture=neutral, PublicKeyToken=nulliDclr-namespace:ExtendedGrid.ExtendedGridControl;assembly=ExtendedGrid ExtendedGrid.ExtendedGridControl  5   2   	 Trust   Trust.Amendments   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35` \RibbonControlsLibrary, Version=4.0.0.11019, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      SmyDclr-namespace:ExtendedGrid.ExtendedGridControl;assembly=ExtendedGrid     5   2     N� Title$  
Amendments��6   $��Center=�6   $	��640��6�   .��5      �� $
��Auto=�6   $
��auto=�69   $��Stretch=�6]   $��Stretch=�6�   $��0,0,0,44q�6�   .��5	   
   � $
��auto��6   $
��auto��6    � ColumnDefinitions 5
      �� 5      $	��20* �6#   �� 5      $��1137* �6#   .+�5      7   1ExtendedGrid.ExtendedGridControl.ExtendedDataGrid  -   5          Name$ extendedDataGrid1��5        HideColumnChooser .     CanUserReorderRows . 6   0ExtendedGrid.Microsoft.Windows.Controls.DataGrid   CanUserReorderColumns .    
IsReadOnly . $	��440��6�      AutoGenerateColumns . $
��Left=�6�   $��	2,106,0,0q�6  $	��Top=�65  $
��1120��6M  $��1��6Z  �� 5      -   5         ��Name$ butBrowse_Copy��5   /   $��Export To Excel��6   $
��Left=�6G   $��1000,551,0,0q�6b   $	��Top=�6x   $	��126��6�   $��24��6�   $��1��6�   �� 5      -   5        $��Get Data��5      $��1��6(   $
��Left=�68   $��
379,43,0,0q�6S   $	��Top=�6g   $��75��6   6�   (  "System.Windows.Controls.DatePicker  5      -   5        $��dpStartDate��5   4   $
��Left=�6   $��	93,42,0,0q�6G   $	��Top=�6Z   $��1��6r     5      -   5        $��	dpEndDate��5   4   $
��Left=�6   $��
263,41,0,0q�6E   $	��Top=�6Y   $��1��6q   	 J� RenderTransformOrigin$	 2.107,0.366&�6�   �� 5      $��Start Date:��6   $��1��6*   $
��Left=�6:   $��	22,40,0,0q�6U   $	��Top=�6h   �� 5      $V��PSelect a date range to display all purchase order adjustments during that period��6   $��1��6o   $
��Left=�6   $��22,0,0,0q�6�   $	��Top=�6�   �� 5      $��End Date��6   $��1��6'   $
��Left=�67   $��
200,42,0,0q�6R   $	��Top=�6f   �� 5      -   5        $ butBrowse_Copy1��5   /   $��Export To Excel��6   $
��Left=�6H   $��1000,551,0,0q�6c   $	��Top=�6y   $	��126��6�   $��24��6�   $��1��6�   5      5      5      