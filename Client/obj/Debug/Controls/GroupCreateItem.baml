   M S B A M L   `   `   `  ����A  =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Client.ControlsClient.Controls  5      %    Client.Controls.GroupCreateItem   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      /localclr-namespace:Client.Controls     5      $��Stretch=�5      $��5q�5	        � 	Resources  5
       �� Source�� 5   
   $ ../MainRes.xaml?�6   %    .��5      �� ���	#FFB3D3F3 �� CornerRadius$ 10��6$    J� Effect 5   
   3  -System.Windows.Media.Effects.DropShadowEffect  5         
BlurRadius$ 20Q�6      	Direction$	 -45Q�6/      RenderingBias$ Quality=�6?      ShadowDepth$ 3Q�6W      Opacity$	 0.6Q�6g   ._�5   
   � 	 � RowDefinitions	 5      �� 5      $
��Auto �6    �� 5      �� 5      $
��Auto �6    .+�5      �� $ 10��6   
�������$��10q�6>   ._�5      �� -   5        $��	groupName��5      $��5q�6+   $��15(�66   6G   5      �� 5      $��1��6   $
��Auto=�6(   .��5      �� $ 5��6   ���	#FF7AB8F5$	�� 10q�6A   ._�5      �� -   5        $��users��5   !   5      5       5!      � 5#      $��2��6   
 � ColumnDefinitions
 5$      �� 5%      �� 5&      .+�5(      �� $��5q�6   ���	#FF47A4E4$ 10��6;      confirmStyle#���   6M   ._�5)      �� -   5         
 minBtn#��[ 5)   .   .��5*      �� $
��Bold"�6    $��0, -5, 0, -5q�62   
�������.��6]   O6`   5+      5,      �� 5-      $��1��6   $��5q�6)   ���	#FFDE6E6E$ 10��6K     	exitStyle#���  6]   ._�5.      �� -   5        #��[ 5.   2   .��5/      �� $
��Bold"�6    $��0, -5, 0, -5q�62   
�������.��6]   X6`   50      51      52      54      55      56      