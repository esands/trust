   M S B A M L   `   `   `  ����G  CExtendedGrid, Version=2.0.0.6, Culture=neutral, PublicKeyToken=nulliDclr-namespace:ExtendedGrid.ExtendedGridControl;assembly=ExtendedGrid ExtendedGrid.ExtendedGridControl  5   /   	 Trust   Trust.Reports   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35` \RibbonControlsLibrary, Version=4.0.0.11019, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      SmyDclr-namespace:ExtendedGrid.ExtendedGridControl;assembly=ExtendedGrid     5   /     N� Title$  Reports��6   $��Center=�6   $	��640��6   .��5      �� $
��Auto=�6   $
��auto=�69   $��Stretch=�6]   $��Stretch=�6�   $��0,0,0,44q�6�   .��5	   
   � $
��auto��6   $
��auto��6    � ColumnDefinitions 5
      �� 5      $	��20* �6#   �� 5      $��1137* �6#   .+�5      7   1ExtendedGrid.ExtendedGridControl.ExtendedDataGrid  -   5          Name$ extendedDataGrid1��5   �      HideColumnChooser .     CanUserReorderRows . 6   0ExtendedGrid.Microsoft.Windows.Controls.DataGrid   CanUserReorderColumns .    
IsReadOnly . $	��440��6�      AutoGenerateColumns . $
��Left=�6�   $��	2,106,0,0q�6�   $	��Top=�6�   $
��1120��6  $��1��6  6,  �� 5      -   5         ��Name$ butBrowse_Copy��5   /   $��Export To Excel��6   $
��Left=�6G   $��1000,551,0,0q�6b   $	��Top=�6x   $	��126��6�   $��24��6�   $��1��6�   �� 5      $��Show me:��6   $
��Left=�6'   $��
2.5,23,0,0q�6B   $	��Top=�6V   $��1��6n   	� 5      -   5        $��radPO��5      	 d� 	IsChecked$
	 TrueY�6'   $��Purchase Orders��69   
 	� 	GroupName$

 type��6S   $
��Left=�6d   $��68.5,29,0,0q�6   $	��Top=�6�    J� RenderTransformOrigin$ 0.085,0.367&�6�   $��1��6�   	� 5      -   5        $��radInv��5      $��Invoices��6(   $

 type��6;   $
��Left=�6L   $��
192,29,0,0q�6g   $	��Top=�6{   $��1��6�   �� 5      $��	That are:��6   $
��Left=�6(   $��2,48,0,0q�6C   $	��Top=�6U   $��1��6m   	� 5      -   5        $��radUnmatched��5      $
	 TrueY�6.   $��	Unmatched��6?   $
 matched��6S   $
��Left=�6g   $��	68,54,0,0q�6�   $	��Top=�6�   $ 0.085,0.367&�6�   $��1��6�   	� 5      -   5        $��
radMatched��5      $��Matched��6,   $
 matched��6>   $
��Left=�6R   $��
380,54,0,0q�6m   $	��Top=�6�   $��1��6�   $ 
0.904,0.38&�6�   �� 5      -   5        $��Get Data��5      $��1��6(   $
��Left=�68   $��
183,74,0,0q�6S   $	��Top=�6g   $��75��6   6�   	� 5      -   5         	�Name$ radUnmatched_inc_credit��5      $"��Unmatched inc credits/hidden��6<   $
 matched��6c   $
��Left=�6w   $��
192,54,0,0q�6�   $	��Top=�6�   $ 0.085,0.367&�6�   $��1��6�   5      5      5      