   M S B A M L   `   `   `  ����A  =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:ClientClient  5          Client.Login   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      &localclr-namespace:Client     5        N� Title$  Login��5	       � 	Resources 5
       �� Source�� 5   
   $ ../MainRes.xaml?�6   %    .��5      �  � RowDefinitions 5   
   �� 5      �� 5      $
��Auto �6   �� 5      ��5   
   �� 5       �� Color$ 	#FFB9D1EA��6   .+�5   
   �� $	��300��6   $��1��6    ���	#FF75A4D4 J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         
BlurRadius$ 20Q�6#      	Direction$	 -45Q�63      RenderingBias$ Quality=�6C   	   ShadowDepth$	 15Q�6[   
   Opacity$	
 0.6Q�6l   ._�5      �� ���	#FF75A4D4$��5q�60   .+�5      �� $��10��6   $��-5, -15, -5, 0q�6%    �� CornerRadius$ 100, 100, 0, 0��6=   ���	#FFFF72536\   �� 5      $��30(�6   $��Center=�6&   $
��Bold"�6C   ���	#FFFF2E00.��6m   Login6t   �� 5      $��3��6   $��10, 0, 10, 0q�6$   ���	#FFFF7253$ 2��6Q   �� 5      $��10, 10, 10, 0q�6   
���   �$��2q�5       $ 5��5!      ���	#FFE8D580._�5#      �� -   5        $��txtLogin��5#   )   $��1q�6   $��25(�69   ���	#FFE8D580$
��Bold"�6^   ���	#FF0500746p   5$      �� 5%      $��10, 10, 10, 0q�6   
���   �$��2q�5'      $ 5��5(      ���	#FFE8D580._�5*      G� -   5        $��txtPass��5*   -   $��1q�6"   $��25(�6<   ���	#FFE8D580$
��Bold"�6a   ���	#FF050074$��0q�6�   5+      � 5,      $��10q�6    � ColumnDefinitions 5-      �� 5.      �� 5/      .+�51      �� -   5         
  minBtn#��[  51      $��
0, 0, 5, 0q�6=   $
��Bold"�6f   $��25(�6x   $��10, 3, 10, 3q�6�   ���	#FFFF2E00
�������.��6�   GO6�   �� 52      -   5        #��[  52      $��1��6=   $��
5, 0, 0, 0q�6M   $��Bottom=�6b   $��Stretch=�6}   $
��Bold"�6�   $��25(�6�   ���	#FF0074FF
�������.��6�   
Register53   #   54      �� 56      $��10��6   $��-5, 0, -5, -5q�6%   $ 
5, 5, 0, 0��6<   ���	#FFFF72536W   57      58      59      5:      