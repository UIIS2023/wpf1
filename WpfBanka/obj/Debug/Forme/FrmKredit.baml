   M S B A M L   `   `   `  ����C  ?WpfBanka, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:WpfBanka.FormeWpfBanka.Forme  5   	       WpfBanka.Forme.FrmKredit   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:WpfBanka.Forme     5   	     � Title$  Dodaj/Izmijeni kredit��5   	   $	��250��6'   $	��350��64   .��5	      � .+�5
   
   �� $��Iznos kredita:��6   $
��Left=�6)   $��	20,20,0,0q�6D   $	��Top=�6W   �� 5   
   -   5         ��Name$ 	cbKlijent��5      $
��Left=�6&   $��
180,80,0,0q�6A   $	��Top=�6U   $	��120��6m    �� DisplayMemberPath$ Klijent��6y    �� SelectedValuePath$ 	KlijentID��6�   �� 5   
   $��Klijent:��6   $
��Left=�6#   $��	20,80,0,0q�6>   $	��Top=�6Q   �� 5   
   -   5         ��Name$ txtIznosKredita��5      $
��Left=�6+   $��23��6F   $��
180,20,0,0q�6R    �� TextWrapping$
 Wrap=�6f   $�� ��6z   $	��Top=�6�   $	��120��6�   �� 5   
   -   5         ��Name$ 
btnSacuvaj��5      $��Sačuvaj��6%   $
��Left=�67   $��
40,130,0,0q�6R   $	��Top=�6f   $��75��6~   6�   �� 5   
   -   5        $ 	btnOtkazi��5      $��Otkaži��6$   $
��Left=�65   $��200,130,0,0q�6P   $	��Top=�6e   $��75��6}   6�   �� 5   
   $��Datum podizanja kredita:��6   $
��Left=�63   $��	20,50,0,0q�6N   $	��Top=�6a   (  "System.Windows.Controls.DatePicker  5   
   -   5          Name$ dtDatumKredita��5      $
��Left=�6-   $��
180,50,0,0q�6H   $	��Top=�6\   5      5      