   M S B A M L   `   `   `  ����A  =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Client.ControlsClient.Controls  5           Client.Controls.GroupWrite   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      2gif"http://wpfanimatedgif.codeplex.com     5      /localclr-namespace:Client.Controls     5      -   5          � 	Resources  5       �� Source�� 5   
   $ ../MainRes.xaml?�6   %    .��5      �  � ColumnDefinitions 5   
   �� 5      �� 5      -   5         �Name$ ComminShtorka��5   ;   $
��0.4* �6   $	��300��6,   6;   .+�5   
   �� ���	#FF234F7C$��1��6(   ._�5      � -   5        $��mainMain��5      .+�5      �� -   5        $��	mainItems��5      5      5      5      �� 5   
   -   5        $��
MsgScrolls��5   :   $
��Auto=�6   .��5      �� -   5        $��msges��5      .+�5       �� $��60��6   6'   5!      5"      �� 5$   
   -   5        $��plashkaLoading��5$      $��0��6'   $	��300��62   $��Center=�6A    �� CornerRadius$ 0, 0, 100, 100��6^   $	��Top=�6|   ��5%      �� 5'       �� EndPoint$ 0.5,1&�6&    � MappingMode$ RelativeToBoundingBox=�67    �� 
StartPoint$ 0.5,0&�6[    �� RelativeTransform 5(      V� 5)      .~�5*      �� 	 �� CenterY$		 0.5Q�6-   
 �� CenterX$	
 0.5Q�6;   �� 5+       �� CenterY$	 0.5Q�6,    �� CenterX$	 0.5Q�6:   �� 5,       �� Angle$ -71.03Q�6.    �� CenterY$	 0.5Q�6=    �� CenterX$	 0.5Q�6K   T� 5-      5.      .��50      � -   5        GradientStop1�� � Color$ 	#FF363131��50   :    � Offset$ 0Q�6L   � 51      -	   5        GradientStop2��$ 	#FF049151��51   :   $ 0Q�6L   � 52      -
   5        GradientStop3��$ 	#FF363131��52   :   $ 0Q�6L   53       � Triggers 55      :� 56       :� RoutedEvent$ Loaded��6    [�57      �� 58      .��59      �� -   5         g�Name$
 anim��59   )   .��5:   "   W�  �� 
TargetName$ GradientStop1��5;   !    �� TargetProperty$ Offset�5<   !    W� From$ 0X�5=   !   	 W� To$ 0.615X�6*    g� Duration$ 0:0:1.5D�65    g� AutoReverse .  W� EasingFunction 5?   &   0  *System.Windows.Media.Animation.QuinticEase  5@   *   7  1System.Windows.Media.Animation.EasingFunctionBase   
EasingMode$ 	EaseInOut=�66   5B   #   W� 5C   "   $ GradientStop2��5D   !   $ Offset�5E   !   $ 0X�5F   !   $ 0.809X�6*   $ 0:0:1.5D�65    .  5H   &     5I   *   $ 	EaseInOut=�66   5K   #   W� 5L   "   $ GradientStop3��5M   !   $ Offset�5N   !   $ 0X�5O   !   $ 1X�6*   $ 0:0:1.5D�61    .  5Q   &     5R   *   $ 	EaseInOut=�66   5T   #   5b      5c      5e      ._�5g      �� $
��Bold"�6   $��20(�6&   
�������$��Center=�6G   .��6e   
Loading...6q   5h      � 5k   
   $��2��6   $��0, 0, 0, 10q�6   $��Bottom=�61    5l      �� 5m      $
��0.2* �6#   �� 5n      �� 5o      $
��0.2* �6#   .+�5s      �� $��0q�6   $��1��6)   ���	#FF234F7C$ 5��6P   ._�5w      � $��5q�6    5x      �� 5y      �� 5z      $
��Auto �6+   .+�5|      ��  �� Padding$ 5q�6   
�������$ 5��6<   ._�5}      �� -   5        $	��msg��5}   [   $��20(�6"   ���	#00000000$��0q�6G   6{   5~      �� 5      $��1��6   $��10, 0, 0, 0q�6.   ���	#FF6EA5DE$ 10��6\      
groupStyle#��[  6n   ._�5�      �� -   5         
 minBtn#��[ 5�   1   .��5�      �� 
�������$��20(�67   $��
7, 1, 7, 1q�6E   $��Center=�6Z   .��6}   Send6�   5�      5�      5�      5�      5�      5�      5�      