   M S B A M L   `   `   `  ����E  ASwissKnife, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:SwissKnife
SwissKnife  5   	       SwissKnife.InputRequest   5   	   \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:SwissKnife     5   	     � Title$   ��5   	    � AllowsTransparency$
 True��5	   	      	AquaStyle#��[  5
   	   $	��235��5   	   $	��330��5   	   $��Center=�5   	   $��Center=�5   	   
������  � 
ResizeMode$ NoResize=�5   	    � WindowStyle$
 None=�5   	   $��Normal"�5   	   $��16(�5   	   $��Normal$�5   	    � WindowStartupLocation$ CenterScreen=�5   	   ��5   	   ��   	TextStyle �� Source# [  �� Path$ 
FontFamily� � 	Resources 5          SwissKnife.CommonViewModel  commonViewModel   SwissKnife.BorderViewModel  borderViewModel��%:   &	       &	        5   
   6      5   
   6    5      .��5      � $��Center=�6   .+�5   
   F� 
���iii�$��1��5        BlackButtonContent#��[ 5       ��5!      B� 5"      .��5#      E�  E� IsClosed$
 True��6!   	 E� 
StartPoint$		 0,0&�5$   !   .��5%      �� 
 �� Point$
 0,152&�6&   �� 5&       �� Point$ 8,160&�6&    �� Size$	 8,8��5'   &   �� 5(      $
 292,160&�6&   �� 5)      $ 300,152&�6&   $	 8,8��5*   &   �� 5+      $
 300,0&�6&   5,      5-      5/      �� 51   
   $��Center=�6   $��Center=�52      $
��Auto��53      $��0,0,0,30q�54      .+�55      �� -   5         ��Name$ Message��55        t_inputnamerequest#���  56      
���iii�$��16(�58      $��0,0,0,5q�59      �� 5:      $��	5,10,5,10q�5;      $
��auto��5<       �� TextAlignment$ Center=�5=      ��5:      �� # [ $ InputRequestText�5=      �� 5>      -   5         ��Name$ Accept��5>        SettingsButton#��[ 5?        t_acceptrequest#���  5@      $��5q�5A      $	��100��5B      $��40��5C      ��5D      �� # [ $ CloseButton���5E      ��  �� RelativeSource ��  �� AncestorType" �5F      5G      5H      