   M S B A M L   `   `   `  ����C  ?BookShop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:BookShopBookShop  5          BookShop.Writers   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      (localclr-namespace:BookShop     5        N� Title$  Writers��5	      .��5
      �  "  SecondaryHueMidForegroundBrush#���   6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ 	dgWriters��5      $
��Left=�6&   $	��363��6A   $��	13,87,0,0q�6N   $	��Top=�6a   $	��977��6y      
IsReadOnly$
 True��6�     MaterialDesignBodyLight#���  6�     MaterialDesignBackground#���  6$  #���  6\     AutoGenerateColumns$ False��6�     HeadersVisibility$ Column=�6�   � DataContext 6�   ��  �� Source$ Writeres�� � 	Resources 5      =  7System.Windows.Controls.Primitives.DataGridColumnHeader �� BasedOn	 �� 
TargetType
 �� Property �� Value��%c   '        7 �� 5      8   "	  6Q   .�5      �� 
 � �� �	#FF354C5D63   5      5         Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Id��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$	 162 6H   1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   �� *Id+6H     5      $ Nombre��6%   $	 162 6N    65   �� *Name+6N     5      $
 Sexo��6%   $	 162 6Q    63   �� *	GenderStr+6Q     5      $ Nacionalidad��6%   $	 162 6[    6;   �� *Nacionality+6[     5      $ Libros��6%   $	 162 6O    65   �� *Books+6O   4  .System.Windows.Controls.DataGridTemplateColumn  5      $	 160 6*      CellTemplate 5      �� 5      .R�5      �� -   5        .��5   :   
Eliminar6D   5      5      5      �� 5    
   -   5         ��Name$ 
btnGuardar��5       $��Guardar��6%   $
��Left=�67   $��
777,38,0,0q�6R   $	��Top=�6f   6~   �� 5!   
   $��Nombre��6   $
��Left=�6!   $��9,33,0,0q�6<   $	��Top=�6N   #���  6f   �� 5"   
   -   5         ��Name$ txtName��5"      $
��Left=�6#   $��	81,35,0,0q�6>   $�� ��6Q    �� TextWrapping$
 Wrap=�6Y   $	��Top=�6m   $	��120��6�   
���   �6�   �� 5#   
   -   5         ��Name$ 	lblGender��5#      $
��Sexo��6#   $
��Left=�62   $��
228,33,0,0q�6M   $	��Top=�6a   #���  6y   �� 5$   
   $
��Pais��6   $
��Left=�6   $��
389,33,0,0q�6:   $	��Top=�6N   #���  6f   �� 5%   
   $��Ciudad��6   $
��Left=�6!   $��
565,33,0,0q�6<   $	��Top=�6P   #���  6h   �� 5&   
   -   5        $��Gender��5&   f   $
��Left=�6   $��
269,35,0,0q�6.   $	��Top=�6B   $	��120��6Z   
���   �.@�5'      ��  �� 
IsSelected$
 True��6   $��	Masculino��6-   �� 5(      $��Femenino��6   5)      �� 5*   
   -   5        $��Country��5*   g   $
��Left=�6   $��
424,35,0,0q�6.   $	��Top=�6B   $	��120��6Z   
���   �6�   �� 5+   
   -   5        $
��City��5+   f   $
��Left=�6   $��
626,35,0,0q�6.   $	��Top=�6B   $	��120��6Z   
���   �6r   �� 5,   
   -	   5        $ 
btnLimpiar��5,      $��Limpiar��6%   $
��Left=�67   $��
891,38,0,0q�6R   $	��Top=�6f   6~   5.      5/      