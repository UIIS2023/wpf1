   M S B A M L   `   `   `  ����C  ?WpfBanka, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:WpfBanka.FormeWpfBanka.Forme  5   	       WpfBanka.Forme.FrmRacun   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:WpfBanka.Forme     5   	     � Title$  Dodaj/Izmijeni racun��5   	   $	��300��6&   $	��300��63   .��5
      � .+�5   
   �� $��Broj racuna:��6   $
��Left=�6'   $��	20,20,0,0q�6B   $	��Top=�6U   �� 5   
   -   5         ��Name$ txtBrojRacuna��5      $
��Left=�6)   $��23��6D   $��
140,20,0,0q�6P    �� TextWrapping$
 Wrap=�6d   $�� ��6x   $	��Top=�6�   $	��120��6�   �� 5   
   $��Kamatna stopa:��6   $
��Left=�6)   $��	20,50,0,0q�6D   $	��Top=�6W   �� 5   
   -   5        $ txtKamatnaStopa��5      $
��Left=�6+   $��23��6F   $��
140,50,0,0q�6R   $
 Wrap=�6f   $�� ��6z   $	��Top=�6�   $	��120��6�   �� 5   
   $��Klijent:��6   $
��Left=�6#   $��	20,80,0,0q�6>   $	��Top=�6Q   �� 5   
   -   5         ��Name$ 	cbKlijent��5      $
��Left=�6&   $��
140,80,0,0q�6A   $	��Top=�6U   $	��120��6m    �� DisplayMemberPath$ Klijent��6y    �� SelectedValuePath$ 	KlijentID��6�   �� 5   
   $��	Korisnik:��6   $
��Left=�6$   $��
20,110,0,0q�6?   $	��Top=�6S   �� 5   
   -   5        $ 
cbKorisnik��5      $
��Left=�6'   $��140,110,0,0q�6B   $	��Top=�6W   $	��120��6o   $ Korisnik��6{   $ 
KorisnikID��6�   �� 5   
   $��Tip racuna:��6   $
��Left=�6&   $��
20,140,0,0q�6A   $	��Top=�6U   �� 5   
   -   5        $ cbTipRacuna��5      $
��Left=�6(   $��140,140,0,0q�6C   $	��Top=�6X   $	��120��6p   $	 tip��6|   $ TipRacunaID��6�   �� 5   
   -   5         ��Name$ Sacuvaj��5      $��Sačuvaj��6"   $
��Left=�64   $��
40,220,0,0q�6O   $	��Top=�6c   $��75��6{   6�   �� 5   
   -   5        $ Otkazi��5      $��Otkaži��6!   $
��Left=�62   $��170,220,0,0q�6M   $	��Top=�6b   $��75��6z   6�   5      5      