   M S B A M L   `   `   `  ����G  CExtendedGrid, Version=2.0.0.6, Culture=neutral, PublicKeyToken=nulliDclr-namespace:ExtendedGrid.ExtendedGridControl;assembly=ExtendedGrid ExtendedGrid.ExtendedGridControl  5   2   	 Trust   Trust.Match   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35` \RibbonControlsLibrary, Version=4.0.0.11019, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      SmyDclr-namespace:ExtendedGrid.ExtendedGridControl;assembly=ExtendedGrid     5   2   -   5          N�Name$  myRoot��5       N� Title$ Match��5   	   $
��1000��6   $
��1383��6%   .��5      � $
��1320��6   $
��1345��6   .+�5	   
   �� -   5        $��label1��5	   m   $9��3Number of purchase order lines not current matched:��6   $��28��6N   $��	22,10,0,0q�6Z   $	��Top=�6{   $
��Left=�6�   $	��297��6�   �� 5
   
   -   5        $��
lblPOCount��5
   [   $��Label��6   $��28��6    $
��Left=�6,   $��
324,10,0,0q�6G   $	��Top=�6m   $��97��6�   7   1ExtendedGrid.ExtendedGridControl.ExtendedDataGrid  5   
   -   5        $��extendedDataGrid1��5   V     HideColumnChooser .     CanUserReorderRows . 6   0ExtendedGrid.Microsoft.Windows.Controls.DataGrid   CanUserReorderColumns .    
IsReadOnly . $	��441��6      AutoGenerateColumns . $
��Left=�6(  $��	22,43,0,0q�6C  $	��Top=�6o  $	��617��6�  �� 5   
   -   5        $��label2��5   �   $1��+Number of invoicelines not current matched:��6   $��28��6F   $
��Left=�6R   $��
754,10,0,0q�6m   $	��Top=�6�   $	��294��6�   �� 5   
   -   5        $��lblNoOfRows��5   \   $��Label��6   $��28��6    $
��Left=�6,   $��1009,10,0,0q�6G   $	��Top=�6o   $��97��6�   �� 5   
   -   5        $��lblRun��5   e   $��Run match now:��6   $��28��6)   $
��Left=�65   $��573,505,0,0q�6P   $	��Top=�6s   $��97��6�   �� 5   
   -   5        $��butRunMatch��5   \   $	��Run��6   $��23��6   $��Right=�6+   $��0,505,600,0q�6G   $	��Top=�6o   $��75��6�   6�     5   
   -	   5          Name$ extendedDataGrid2��5   �   .   .  .  . $	��441��6.   . $
��Left=�6V  $��
754,43,0,0q�6q  $	��Top=�6�  $	��550��6�  �� 5   
   -
   5        $��lblMatchResults��5      $�� ��6   $
��Left=�62   $��350,530,0,0q�6M   $	��Top=�6b    J� RenderTransformOrigin$ 
0.7,-0.615&�6z   �� 5   
   -   5        	 ��Name$	 butSave��5   q   $
��Save��6   $y�Hidden=�6    $��23��64   $��Right=�6@   $��0,530,344,0q�6\   $	��Top=�6�   $��75��6�   6�   � 5   
   -   5        $��progressBar��5   *   $y�Hidden=�6   $
��Left=�6=   $��30��6X   $��542,556,0,0q�6d   $	��Top=�6y   $	��319��6�   �� 5   
   -   5        $��butSaveChanges��5   �   $
��Edit��6   $��23��6    $��Right=�6,   $��0,500,1237,0q�6H   $	��Top=�6_   $��86��6w   $ 2.853,4.478&�6�   �� 5   
   -   5        $	 	butCancel��5   �   $��Cancel��6   $��23��6"   $��Right=�6.   $��0,490,1135,0q�6J   $	��Top=�6a   $��86��6y   $y�Hidden=�6�   $ 2.853,4.478&�6�   �� 5   
   -   5        $	 butAddCredit��5   �   $��Add Credit or Acceptance��6   $��23��64   $��Right=�6@   $��
0,490,41,0q�6\   $	��Top=�6p   $	��145��6�   $ 2.853,4.478&�6�   �� 5   
   -   5        $��
chkCredits��5   @   $(��"Include Credits and Forced Accepts��6   $
��Left=�6R   $��1071,16,0,0q�6m   $	��Top=�6�   6�   �� 5   
   -   5        $	 butHide��5   �   $��
Hide Order��6   $��23��6&   $��Right=�62   $��0,500,1135,0q�6N   $	��Top=�6e   $��86��6}   $ 2.853,4.478&�6�   �� 5   
   -   5        
 ��Name$
 	chkHidden��5   ,   $��Include Hidden��6   $
��Left=�6?   $��
383,16,0,0q�6Z   $	��Top=�6n   6�   �� 5   
   $����Please note, messages and notes added to purchase order changes are not shown on this page, please see the reports or match manager��6   $
��Left=�6�   $��
22,479,0,0q�6�   $	��Top=�6�   $	��743��6�   5      5      