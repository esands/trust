   M S B A M L   `   `   `  ����	  Trust!    Trust.ImportRountineManager   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35` \RibbonControlsLibrary, Version=4.0.0.11019, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          N� Title$  ImportRountineManager��5   	   $
��1000��6'   $
��1298��65   .��5      � $
��1000��6   $
��1236��6   .+�5   
   �� -   5        $��tabControl1��5   P   $	��827��6   $
��Left=�6"   $��	21,21,0,0q�6=   $	��Top=�6c   $
��1203��6{   .@�5      �� -   5        $��tabItem1��5   0   $��Current Mappings��6   .��5      � $
��1196��6   .+�5	      &   System.Windows.Controls.DataGrid  -   5        $��	dgHeaders��5	   �   $	��181��6      
IsReadOnly .    CanUserAddRows .  $
��Left=�6R   $��6,51,0,0q�6n   $	��Top=�6�   $	��762��6�      AutoGenerateColumns .     Columns 5
      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6-   1  +System.Windows.Controls.DataGridBoundColumn   Binding 69   ��  �� Path$ Id� �� Mode$ OneTime=�6f     5      $
 Type��6-   	   Width5  /System.Windows.Controls.DataGridLengthConverter$		 100 6;    6G   �� $
 Type�$ OneTime=�6u     5      $ Tab Name��6-    6?   �� $ TabName�6b     5      $ Deliminator��6-    6B   �� $ deliminator�6i     5      $ Import To Table��6-   $		 150 6F    6S   �� $ ImportToTable�6|     5      $ Rountine Name��6-   $		 150 6D    6P   �� $
 Name�6p     5      $ Import Reader��6-   $		 135 6D    6Q   �� $ 	ClassName�6v   4  .System.Windows.Controls.DataGridTemplateColumn  5      $ Delete��61   
   CellTemplate
 5   "   �� 5   &   .R�5   &   ��  ��Name$ 	btnDelete��6>   -   5        $��Delete��5   -   5   ;   5   #   5      5        5      -   5        $��
dgMappings��5   �    .   .  $	��408��6R   $
��Left=�6_   $��
811,95,0,0q�6z   $	��Top=�6�   $	��327��6�    5        5      $ Field��62   $		 230 6A      
IsReadOnly .  6_   �� $ Alais�$ OneTime=�6�     5       $ 	Column No��61    6D   �� $ Column�6f   5"      �� 5#      -   5        $��label9��5#   �   $4��.Current import routines - double click to edit��6   $��28��6U   $
��Left=�6a   $��6,30,0,0q�6|   $	��Top=�6�   �� 5$      -   5        $��label10��5$   �   $,��&Field Mappings For Selected Rountine. ��6   $��28��6M   $
��Left=�6Y   $��
811,30,0,0q�6t   $	��Top=�6�   �� 5%      -	   5        $��butSaveMapping��5%   i   $
��Save��6   $��23��6,   $
��Left=�68   $��1063,508,0,0q�6S   $	��Top=�6   $��75��6�   6�   �� 5&      -
   5        $��label11��5&   �   $!��Set to 0 if not applicable.��6   $��Italic$�6B   $��28��6a   $
��Left=�6m   $��1016,30,0,0q�6�   $	��Top=�6�   �� 5'      -   5        $��label12��5'   �   $����Any value pairs must be in sequential columns - for example Hauler Type and Haulier Description must be next to each other with the code first.��6   $��46��6�   $
��Left=�6�   $��
811,51,0,0q�6�   $	��Top=�6  5(      5)      �� 5*      -   5        $��	tabItem12��5*   3   $��Create New Mappings��6   .��5+      �  � ColumnDefinitions 5,      �� 5-      $	��28* �6+   �� 5.      $��55 �6+   �� 5/      $
��691* �6+   .+�51      �� -   5        $��label1��51   n   $��Name of Routine��6   $��23��66   $
��Left=�6B   $��6,6,0,0q�6]   $	��Top=�6|   $	��100��6�   $��3��6�   �� 52      -   5         ��Name$ txtName��52      $��29,8,813,767q�6/   $��2��6E   �� 53      -   5        $��cbInputFormat��53      $��29,35,813,738q�64   $��2��6K   .@�54      �� -   5        $��excel��54   '   .��64   Excel6;   55      �� 56      -   5        $��label2��56   i   $��	File Type��6   $��23��60   $
��Left=�6<   $��6,35,0,0q�6W   $	��Top=�6w   $	��100��6�   $��3��6�   �� 57      -   5        $��label3��57   l   $��Deliminator ��6   $��23��63   $
��Left=�6?   $��6,64,0,0q�6Z   $	��Top=�6z   $	��100��6�   $��3��6�   �� 58      -   5        $��txtDeliminator��58   5   $��29,66,930,709q�6   $��2��6K   �� 59      -   5        $��label4��59   w   $��Only complete for csv��6   $��23��6<   $
��Left=�6H   $��
169,66,0,0q�6c   $	��Top=�6�   $	��172��6�   $��2��6�   �� 5:      -   5        $��cbTable��5:   6   $��29,95,813,678q�6   $��2��6E   .@�5;      �� -   5        $��purchase_orders��5;   '   .��6>   Purchase Orders6O   �� 5<      -   5        $��invoices��5<   '   .��67   
Invoices6A   �� 5=      -   5        $��lookup_table��5=   '   .��6;   Lookup Table6I   5>      �� 5?      -   5        $��label5��5?   m   $��Document Type��6   $��23��64   $
��Left=�6@   $��6,95,0,0q�6[   $	��Top=�6{   $	��100��6�   $��3��6�   �� 5@      -   5        $��label6��5@   i   $��Tab Name��6   $��23��6/   $
��Left=�6;   $��	6,122,0,0q�6V   $	��Top=�6w   $	��100��6�   $��3��6�   �� 5A      -   5        $��
txtTabName��5A   6   $��29,124,813,651q�6   $��2��6H   �� 5B      -   5        $��label7��5B   �   $2��,Only for excel - the tab name the data is in��6   $��23��6S   $
��Left=�6_   $��285,122,0,0q�6z   $	��Top=�6�   $	��224��6�   $��2��6�   �� 5C      -   5        $��butAdd��5C   g   $	��Add��6   $��23��6+   $
��Left=�67   $��204,192,0,0q�6R   $	��Top=�6u   $��75��6�   $��2��6�   �� 5D      -   5        $��cbImportClass��5D   7   $��28,150,813,623q�6   $��2��6L   .@�5E      �� -   5        $��PurchaseOrderExcelImport��5E   '   .��6G   Excel Purchase Orders6^   �� 5F      -    5        $��LangdonsInvoice��5F   '   .��6>   Langdons Invoices6Q   �� 5G      -!   5        $��LangdonsLookup��5G   '   .��6=   Langdons Lookup Table6T   5H      �� 5I      -"   5        $��label8��5I   �   $��Import Reader��6   $��3��64   $��23��6H   $
��Left=�6T   $��	6,150,0,0q�6o   $	��Top=�6�   $	��100��6�   5J      5K      5L      5M      5N      