   M S B A M L   `   `   `  ����	  Trust    Trust.Import   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35` \RibbonControlsLibrary, Version=4.0.0.11019, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5        N� Title$  Import��5      .��5
      �  � RowDefinitions 5   
   �� 5      $	��85* �6   �� 5      $	��40* �6   �� 5      $
��475* �6    � ColumnDefinitions 5   
   �� 5      $
��129* �6   �� 5      $
��399* �6   �� 5      $	��98* �6   �� 5      $
��610* �6   .+�5   
   �� -   5        $��FileNameTextBox��5   J   $��26��6   $
��Left=�6   $��4,4,0,0q�69   $	��Top=�6a   $	��393��6y   $��1��6�   $��1��6�   �� 5   
   -   5        $��button1��5   "   $��Browse��6   $��4,4,6,10q�6G   $��2��6Y   $��1��6i   �� 5   
   -   5        $��
textBlock1��5   N   $��23��6   $
��Left=�6    $��	33,58,0,0q�6;   $��Use import routine:��6`   $	��Top=�6{   �� 5   
   -   5        $��cbImportRoutine��5   L   $��23��6   $
��Left=�6   $��4,58,0,0q�6:   $	��Top=�6c   $	��120��6{   $��1��6�   �� 5   
   -   5        $��
textBlock2��5   N   $��23��6   $
��Left=�6    $��	27,13,0,0q�6;   $��File Name to Import:��6`   $	��Top=�6|   $��1��6�   �� 5   
   -   5        $��	butImport��5   F   $��Import��6   $��151,1,160,448q�6"   $��20��69   $��1��6W   $��2��6g   6t   �� 5   
   -   5        $��chkHasHeader��5   �   $"��The import file has a header��6   $��1��6:   $��17��6J   $
��Left=�6V   $��
135,64,0,0q�6q   $	��Top=�6�   � 5   
   -   5        $��progressBar1��5   l   $��1��6   $��2��6&   $��26��63   $
��Left=�6?   $��4,29,0,0q�6Z   $	��Top=�6�   $	��397��6�   $��2��6�   �� 5   
   -	   5        $��txtImported��5   Z   $��2��6   $��23��6!   $
��Left=�6-   $��6,61,0,0q�6H   $�� ��6m   $	��Top=�6u   $��1��6�   &   System.Windows.Controls.DataGrid  5   
   -
   5        $��	dataGrid1��5   u      AutoGenerateColumns . $��2��6.   $	��285��6;   $
��Left=�6H   $��0,89,0,0q�6c   $	��Top=�6�   $	��399��6�   $��1��6�   5       5!      