   M S B A M L   `   `   `  ����G  CExtendedGrid, Version=2.0.0.6, Culture=neutral, PublicKeyToken=nulliDclr-namespace:ExtendedGrid.ExtendedGridControl;assembly=ExtendedGrid ExtendedGrid.ExtendedGridControl  5   4   	 Trust   Trust.LookupTables   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35` \RibbonControlsLibrary, Version=4.0.0.11019, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      SmyDclr-namespace:ExtendedGrid.ExtendedGridControl;assembly=ExtendedGrid     5   4     N� Title$  LookupTables��6   $��Center=�6   $	��765��6�   $��946.083��6�   .��5      �� $
��Auto=�6   $
��auto=�69   $��Stretch=�6]   $��Stretch=�6�   $��0,0,0,44q�6�   .��5	   
   � $	��698��6   $
��auto��6    � ColumnDefinitions 5
      �� 5      $	��20* �6#   �� 5      $��1137* �6#   .+�5      7   1ExtendedGrid.ExtendedGridControl.ExtendedDataGrid  -   5          Name$ extendedDataGrid1��5   �      HideColumnChooser .     CanUserReorderRows . 6   0ExtendedGrid.Microsoft.Windows.Controls.DataGrid   CanUserReorderColumns .    
IsReadOnly . $	��413��6�      AutoGenerateColumns . $��	55,39,0,0q�6�   $	��Top=�6  $��1��62  $
��Left=�6B  $	��779��6^  �� 5      -   5         ��Name$ butBrowse_Copy��5   /   $��Export To Excel��6   $
��Left=�6G   $��446,457,0,0q�6b   $	��Top=�6w   $	��126��6�   $��24��6�   $��1��6�   �� 5      -   5        $ butBrowse_Copy1��5   ,   $��Save Changes��6   $
��Left=�6E   $��577,457,0,0q�6`   $	��Top=�6u   $	��126��6�   $��24��6�   $��1��6�   6�   �� 5      -   5        $ butBrowse_Copy2��5   &   $��Cancel��6   $
��Left=�6?   $��708,457,0,0q�6Z   $	��Top=�6o   $	��126��6�   $��24��6�   $��1��6�   6�   �� 5      $����Use this grid to update the details for Yeo Vally Depot name v Haulier Depot namee lookups.  Please not you must specify a haulier id (e.g. Langdons = 1).��6   $��1��6�   $
��Left=�6�   $��	35,13,0,0q�6�   $	��Top=�6�   	 J� RenderTransformOrigin$	 -5.711,-0.114&�6  �� 5      -   5        $��txtHaulierName��5   &   $��1��6   $
��Left=�6<   $��23��6W   $��712,502,0,0q�6c   
 �� TextWrapping$

 Wrap=�6x   $�� ��6�   $	��Top=�6�   $	��178��6�   �� 5      -   5        $��
ddlHaluier��5   y   $��1��6    �� DisplayMemberPath$ Description��6'   $
��Left=�6H   $��141,503,0,0q�6c   $	��Top=�6�   $	��146��6�   �� 5      -   5        $��ddlDepot��5   W   $��1��6   $
��Left=�6'   $��433,503,0,0q�6B   $	��Top=�6g   $	��150��6   6�   �� 5      $��1��6   $
��Left=�6(   $��
55,483,0,0q�6C   $
��Wrap=�6W   $Q��KTo create a new or duplicate depot v haulier lookup, please link them below��6k   $	��Top=�6�   �� 5      $��Haulier Name��6   $��1��6+   $
��Left=�6;   $��
55,499,0,0q�6V   $	��Top=�6j   �� 5      $��Yeo Valley Depot Name��6   $��1��64   $
��Left=�6D   $��292,499,0,0q�6_   $	��Top=�6t   �� 5      $��Hauliers Depot Name��6   $��1��62   $
��Left=�6B   $��588,499,0,0q�6]   $	��Top=�6r   �� 5      -   5        $ butBrowse_Copy3��5   $   $
��Save��6   $
��Left=�6=   $��764,526,0,0q�6X   $	��Top=�6m   $	��126��6�   $��24��6�   $��1��6�   5      5      5      