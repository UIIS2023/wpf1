   M S B A M L   `   `   `  ����C  ?WpfBanka, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:WpfBankaWpfBanka  5   	       WpfBanka.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:WpfBanka     5   	     � Title$  Banka��5   	   $	��350��6   $	��700��6$   .��5	      � .+�5
   
   &   System.Windows.Controls.DataGrid  -   5          Name$ dataGridCentralni��5
      $��Center=�6.   $
��auto��6K   $��Center=�6Y   $
��auto��6t      
IsReadOnly .    AlternatingRowBackground
 ���_�   CanUserAddRows .     SelectionMode$ Single=�5   O      SelectionUnit$ FullRow=�6f   �� 5   
   $��Center=�6   $��30��62   $	��Top=�6>   $
��auto��6V    �� Orientation$ 
Horizontal=�6c   .+�5      �� -   5         ��Name$ btnKlijenti��5      $��Klijenti��6*   $��30��6=   $��75��6I   6T   �� 5      -   5        $ btnKorisnici��5      $��	Korisnici��6+   $��30��6?   $��75��6K   6V   �� 5      -   5        $ 
btnKartice��5      $��Kartice��6)   $��30��6;   $��75��6G   6R   �� 5      -   5        $ 
btnKrediti��5      $��Krediti��6)   $��30��6;   $��75��6G   6R   �� 5      -   5        $ 	btnRacuni��5      $��Računi��6(   $��30��69   $��75��6E   6P   �� 5      -   5        $ btnRateKredita��5      $��Rate kredita��6-   $��30��6D   $��75��6P   6[   �� 5      -   5        $ btnTipoviKartica��5      $��Tipovi kartica��6/   $��30��6H   $��75��6T   6_   �� 5      -	   5        $ btnTipoviRacuna��5      $��Tipovi računa��6.   $��30��6F   $��75��6R   6]   �� 5      -
   5        $ btnTransakcije��5      $��Transakcije��6-   $��30��6C   $��75��6O   $	��Top=�6Z   6r   5      �� 5   
   $��Center=�6   $��30��62   $��Bottom=�6>   $
��auto��6Y   $ 
Horizontal=�6f   .+�5      �� -   5        $ btnDodaj��5      $��Dodaj��6'   $��30��67   $��75��6C   6N   �� 5      -   5        $ btnIzmijeni��5      $��Izmijeni��6*   $��30��6=   $��75��6I   6T   �� 5      -   5        $ 	btnObrisi��5      $��Obrisi��6(   $��30��69   $��75��6E   6P   5      5      5       