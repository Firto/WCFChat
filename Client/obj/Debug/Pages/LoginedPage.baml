   M S B A M L   `   `   `  ����A  =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Client.PagesClient.Pages  5      1clr-namespace:Client.ControlsClient.Controls  5          Client.Pages.LoginedPage   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:Client.Pages     5      2controlsclr-namespace:Client.Controls     5      -   5          N� Title$  LoginedPage��5
       N� 
Background �	#FFB9D1EA � 	Resources 5       �� Source�� 5   
   $ ../MainRes.xaml?�6   %    .��5      �  � RowDefinitions 5   
   �� 5      $��40 �6   �� 5       � ColumnDefinitions 5   
   �� 5      $	��250 �6   �� 5      �� 5      -   5         �Name$
 clmn��5   )   $��0 �6   6)   .+�5   
   �� -   5        $��writeMsg��5   .   $��1��6   $��1��6!   5      �� 5   
   -   5        $��CreateGroup��5   I   ���	#FF6EA5DE$��1��6(   $y�Hidden=�65   5       �� 5"   
   -   5        $��GroupsItems��5"   ^   $
��Auto=�6   ���	#FF6EA5DE$��1��6Q    J� Effect 5#      3  -System.Windows.Media.Effects.DropShadowEffect  5$         
BlurRadius$ 30Q�6#   	   	Direction$	 0Q�63   
   RenderingBias$
 Quality=�6A      ShadowDepth$ 15Q�6Y      Opacity$	 0.6Q�6j   .��5&      �� -   5        $��ss��5&      5,      5-      � 5.   
   $��3��6   .+�5/      �� ���	#FF234F7C �� Orientation$ 
Horizontal=�60   .+�50      �� $��10, 0, 0, 0q�6   $��Center=�6.   ���	#FF6EA5DE �� CornerRadius$ 10��6a      
groupStyle#��[  6s   ._�51      �� -   5         
 minBtn#��[ 51   2   .��52      �� 
�������$��14(�63   $��
7, 1, 7, 1q�6A   $��Center=�6V   .��6y   Create Group6�   53      54      56      �� 58      $��0, 0, 10, 0q�6   $��Center=�6*   $��Right=�6E   ���	#FFDE6E6E$ 10��6x     	exitStyle#��[ 6�   ._�59      �� -   5        #��[ 59   .   .��5:      �� 
�������$��14(�6/   $��
7, 1, 7, 1q�6=   $��Center=�6R   .��6t   Exit6z   5;      5<      5=      �� 5A   
   $
��Auto=�6   ���	#FF6EA5DE$��1��6Q   $��2��6^    5B        5C      $ 30Q�6#   $	 0Q�63   $
 Quality=�6A   $ 15Q�6Y   $	 0.6Q�6j   .��5E      �� -	   5        $��users��5E      5F      5G      5H      5I      