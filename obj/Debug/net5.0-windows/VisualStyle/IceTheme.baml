   M S B A M L   `   `   `  ����\  XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089   GradLine  �� 
StartPoint �� EndPoint �� Opacity � Offset � Color  TabItemCustom �� 
TargetType �� Property �� Value ��Name  BlackButtonContent	 �� RelativeSource
 �� Path �� Triggers P� Property P� Value �� 
TargetName �� Value �� Binding �� ElementName  CommonButtonCustom �� 
TargetType ��Name �� CornerRadius  GradLineHighlight � Triggers :� RoutedEvent g� RepeatBehavior g� AutoReverse �� TargetProperty �� 
TargetName g� Duration	 �� To g� 	BeginTime J� IsHitTestVisible �� Triggers	  W� To�� 5      F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      :x,http://schemas.microsoft.com/winfx/2006/xaml      5      %�  &	        &	 �     7  &	     7  7  7  7   �� 5      $	  0,0&�5      $	 1,1&�5      $
 0.85Q�5      .��5	   
   � $ 0Q�6   $
 aqua��5
      � 5   
   $	 1.5Q�6   $
 aqua��5      5      �� 5      " ��5      .�5   
   ��  � �� 5      �� 5      .R�5      � .+�5      �� 
������ 
������ 5   !   �� 5      $ 
textInside��6$   8��  $��4,0,4,0q�5   $   ��5   $   �� 	 �� *TemplatedParent+$
 Header�5   $   5       5      P� 5       �@��
IsSelected$
 True��5    "   . �5!      �� $ 
textInside��6%    � ��
 ��� �5#   %   5$      �� 5%      $
 true��5&   &    5%   &   �� $ 
textInside��$
 IsMouseOver�.a�5'      �� $ 
textInside��6%    � ��
 �����5)   %   5*      5,      5.      5/      �� 53      " ��54      .�55   
   ��  � ��$ 16(�56      �� 57   
    � ��8   58      �� 59   
    � �� 5:      �� 5;      " ��6"   .R�5<      � .+�5=      �� $ 
ShapeStyle��6!   $ 2��5>   !   8�� $��2q�5@   !   8��  5B      :� 5C   "   $ 
MouseEnter��6/   .[�5D   &   �� .��5E   *   �� $ Forever��65   $
 True��5F   5   .��5G   .   �� $( "BorderBrush.GradientStops[0].Color�6=   $ 
ShapeStyle��5H   =   $ 0:0:0.25D�5I   =    
WhiteSmoke5J   =   �� 5K   .   $( "BorderBrush.GradientStops[1].Color�6=   $ 
ShapeStyle��5L   =    0:0:0.255M   =   $ 0:0:0.25D�5N   =   	 White5O   =   �� 5P   .   $( "BorderBrush.GradientStops[0].Color�6=   $ 
ShapeStyle��5Q   =    0:0:0.255R   =   $ 0:0:0.25D�5S   =    aqua5T   =   �� 5U   .   $( "BorderBrush.GradientStops[1].Color�6=   $ 
ShapeStyle��5V   =    0:0:0.55W   =   $ 0:0:0.75D�5X   =    aqua5Y   =   5Z   +   5[   '   5\   #   :� 5]   "   $ 
MouseLeave��6/   .[�5^   &   �� .��5_   *   �� .��5`   .   �� $( "BorderBrush.GradientStops[0].Color�6=   $ 
ShapeStyle��5a   =   $ 0:0:0.25D�5b   =    aqua5c   =   �� 5d   .   $( "BorderBrush.GradientStops[1].Color�6=   $ 
ShapeStyle��5e   =   $ 0:0:0.25D�5f   =    
Aquamarine5g   =   5h   +   5i   '   5j   #   5l      �� 5m      #��z��6+   $ False��5n   +   $��Center=�5o   +   $��Center=�5p   +   5q       5s      P� 5t       �@J�IsMouseOver$
 True��5u   "   . �5v      �� $ 
ShapeStyle��6%   8   � ��5x   %   5y      5|      5~       5�   
   P� 5�       � ��$
 True��5�      . �5�      ��  � ��
 �����5�      5�      :� 5�      $ 
MouseEnter��6   [�5�      �� 5�      .��5�      �� $ Forever��6%   $
 True��5�   %   .��5�      W� $ Foreground.Opacity�6.   $ 0:0:1D�5�   .     05�   .   5�      5�      5�      :� 5�      $ 
MouseLeave��6   .[�5�      �� .��5�      �� .��5�      W� $ Foreground.Opacity�6*   $ 0:0:1D�5�   *     15�   *   5�      5�      5�      5�      5�      