   M S B A M L   `   `   `  ����E  AFlowerShop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:FlowerShop
FlowerShop  5           FlowerShop.CreateOrderPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      *localclr-namespace:FlowerShop     5        N� Title$  CreateOrderPage��5	      .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   �� $��0��6   .+�5      �� $!��Выберите товар��6   
�������6.   �� 5      -   5         ��Name$ ProductComboBox��5      5      �� 5   
   $��1��6   .+�5      �� $��Количество��6   
�������6*   �� 5      -   5         ��Name$ QuantityTextBox��5      6/   5      �� 5   
   $��2��6   .+�5      �� $!��Адрес доставки��6   
�������6.   �� 5      -   5        $ AddressTextBox��5      5      �� 5    
   $��3��6   .+�5!      �� $'��!Фотография товара��6   
�������61   �� 5"      -   5         ��Name$ ProductImage��5"      $	��100��6*   $	��100��66   $��UniformToFill=�6C   5#      �� 5$   
   $��4��6   .+�5%      �� -   5         ��Name$ TotalPriceTextBlock��5%      $��Сумма: 0��65   
�������6E   5&      �� 5'   
   $��5��6   .+�5(      �� -   5         ��Name$ ConfirmButton��5(      $��Подтвердить��6,   6B   �� 5)      -   5        $��
Выход��5)      $��Center=�6@   $��0,10,0,0q�6[   5*      5+      5,      