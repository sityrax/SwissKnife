   M S B A M L   `   `   `  ����E  ASwissKnife, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:SwissKnife
SwissKnife  5      \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089    SwissKnife.BorderViewModel   borderViewModel  StyleHeadButton  �� 
TargetType&   SwissKnife.CustomButtonExtention �� 	Resources  Key �� Property �� Value �� 
TargetType ��Name �� CornerRadius  
HeaderBack � Triggers :� RoutedEvent	 �� 
TargetName
 �� TargetProperty  LightedButton	 �� To g� Duration  HeaderBackColor F�Name  GradLine J� IsHitTestVisible   GeometryData �� Triggers P� Property P� Value �� 
TargetName  BlackButtonContent  	AquaStyle3  -System.Windows.Media.Effects.DropShadowEffect   
BlurRadius   ShadowDepth   Opacity � ColumnDefinitions J� Opacity � RowDefinitions �� Orientation  Name 	 t_minimizewindow � ToolTip �� Source �� Path � FillRule  �� 
StartPoint! �� EndPoint 
 t_foregroundwindow" �� RelativeSource# �� Mode$ @� Center% @� RadiusX& @� RadiusY  t_closewindow' � Title( ��Name�� 5      F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     :x,http://schemas.microsoft.com/winfx/2006/xaml     5      "localclr-namespace:SwissKnife  5      %%  &	        &	      7  7  7  7  7  7  &	     7  7  7  7   7  7   7  7      5      6   �� 5	      "   5
       5   
   ����5      LightedButton #3F3F41��63   5      �5   
   �� 5       � �� 5      �� 5      "  6&   .R�5      � .+�5      �� $ 
ShapeStyle��6%   $ 5��5   %   
������ $��0q�5   %   8��   5   "   :� 5   &   $ 
MouseEnter��63   .[�5   *   �� .��5   .   �� .��5   2   �� $	 
ShapeStyle��6A   $'
 !Background.GradientStops[0].Color�5   A   8  $ 0:0:0.2D�5   A   �� 5    2   $	 
ShapeStyle��6A   $'
 !Background.GradientStops[1].Color�5!   A   8  $ 0:0:0.2D�5#   A   5$   /   5%   +   5&   '   :� 5'   &   $ 
MouseLeave��63   .[�5(   *   �� .��5)   .   �� .��5*   2   �� $	 
ShapeStyle��6A   $'
 !Background.GradientStops[0].Color�5+   A   8  $ 0:0:0.2D�5-   A   �� 5.   2   $	 
ShapeStyle��6A   $'
 !Background.GradientStops[1].Color�5/   A   8  $ 0:0:0.2D�51   A   52   /   53   +   54   '   56      F� 57      $ FuncIcon��6#   #���  59   #   $��Center=�5:   #   $��Center=�5;   #   $ False��5<   #   #��z 5=   #   ��58   #   Z� 5>      5?       5@      P� 5A       � ��$
 True��5B   &   . �5C   "   �� $ FuncIcon��6)   8   � ��5E   )   5F      5H      5J      5L      �� 5S      "  �6   �5U   
   �� 5V       � ��# � ��5W      �� 5X       � ��# � ��5Y      �� 5Z       �@J�Effect 5[        5\      $ 15Q�6'   $ 0Q�5]   '   $	 0.4Q�5^   '   5`      �� 5a       � �� 5b      �� 5c      " �6&   .R�5e      �  5f      �� 5g   "   $��15 �63   �� 5h   "   $��* �63   �� 5i   "   $��15 �63   .+�5l      � $��1��6#   .+�5n   "   �� $ 5��6)   $ 1Q�5o   )   #��z��5p   )   #��z��5q   )   $
��Auto��5r   )   ._�5u   &   � $
��Auto��6+    5v   *   �� 5w   .   $
��Auto �6<   �� 5x   .   �� 5y   .   $
��Auto �6<   .+�5~   *   �� $��0��61   $��40��5   1   $ 10��5�   1   8��  ._�5�   .   �� $��0��65   $��30��5�   1   $��0,10,0,0q�5�   1   8�� 5�   1   5�   +   �� 5�   *   $ 
Horizontal=�65   $��Right=�5�   5   .+�5�   .     $ MinimizeWindow��6J   8�� # � 	 5�   J   $��30��5�   J   $��30��5�   J   $��Right=�5�   J   $��Center=�5�   J   $��0,0,5,0q�5�   J   ��5�   J   �� 8  $ MinimizeButton� 5�   2   � 5�   6   $ Nonzero=�6D   .��5�   :   �� $	  0,0&�6G   $
! 10,0&�5�   G   5�   7   5�   /     5�   .   $ FixOver��6J   8�� # � 
 5�   J   $��30��5�   J   $��30��5�   J   $��Right=�5�   J   $��Center=�5�   J   $��0,0,5,0q�5�   J   ��5�   J   �� 8  $ FixOver���5�   J   �� " �� $# TemplatedParent=� 5�   2   � 5�   6   .��5�   :   @� $	$ 6,6&�6J   $% 6Q�5�   J   $& 6Q�5�   J   5�   7   5�   /     5�   .   $ CloseWindow��6J   8�� # �  5�   J   $��30��5�   J   $��30��5�   J   $��Right=�5�   J   $��Center=�5�   J   $��0,0,5,0q�5�   J   ��5�   J   �� 8  $ CloseButton���5�   J   �� " �� *TemplatedParent+ 5�   2   � 5�   6   $ Nonzero=�6D   .��5�   :   �� $	  0,0&�6G   $! 10,10&�5�   G   �� 5�   :   $
  0,10&�6G   $
! 10,0&�5�   G   5�   7   5�   /   5�   +   �� 5�   *   $ 
Horizontal=�65   .+�5�   .   �� $.��(pack://application:,,,/Images/icon64.ico��64   $��20��5�   4   $��20��5�   4   $��10,0,0,0q�5�   4   $ 1Q�5�   4   5�   /   �� 5�   .   #��z' 68   $��Normal"�5�   8   $��20(�5�   8   
�������$��Center=�5�   8   $
��Left=�5�   8   $��5,0,0,0q�5�   8   $ False��5�   8   5�   +   �� 5�   *   $��1��61   ._�5�   .   �� .u�5�   2   �� $( content��6C   5�   /   5�   +   5�   '   5�   #   5�      5�      5�      5�      5�      5�      