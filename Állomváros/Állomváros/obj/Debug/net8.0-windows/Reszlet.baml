   M S B A M L   `   `   `  ����G  CÁllomváros, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:ÁllomvárosÁllomváros  5   	       Állomváros.Reszlet   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:Állomváros     5   	     � Title$  
MainWindow��5   	   ���#181735$	��500��62   $	��900��6?    � WindowStyle$
 None=�6K    � 
ResizeMode$ NoResize=�6^    � 	Resources 5
         RoundedButtonStyle �� 
TargetType �� Property �� Value �� 
TargetType �� CornerRadius��%�  &	        �� 5   
   " ��6+   .�5      ��  � �� �#FE65846+   �� 5       � ��
 �����6+   �� 5       � ��$	 200��6&   �� 5       � ��$ 50��6'   �� 5       � ��$ 0q�6'   �� 5       � ��$ 1q�6(   �� 5       � �� 5      �� 5      " ��6&   .R�5      �� #��z��6!   $ 12��6K   ._�5      �� $��Center=�6/   $��Center=�6L   5      5      5      5      5      .��5      � 	 � RowDefinitions	 5   
   �� 5       $��25 �6   �� 5!      �� 5"      $��50 �6   
 � ColumnDefinitions
 5%   
   �� 5&      $��1* �6   �� 5'      $��1* �6   .+�5)   
   � -   5        ���#0f0f2d$��0��5)   $   $��2��61   .+�5+      �� $��Állomváros��5,      $��20(�5-      
�������$��Center=�5/      $��Center=�50      $��Fonts/#Dosis)�51      $��Medium"�52      53      �� 55   
   $��1��6   $��0��6"   .+�56      �� -   5         ��Name$ TitleTextLeft��56      $��18(�6/   $
��Bold"�6=   $��10q�6O   �� 57      -   5         ��Name$ ContentPanel��57      $��Center=�6/   $��Center=�6J   $��10q�6g   58      �� 5:   
   $��1��6   $��1��6"   .+�5;      �� -   5        $ TitleTextRight��5;      $��18(�60   $
��Bold"�6>   $��10q�6P   �� 5<      -   5        $ ContentPanel2��5<      $��Center=�60   $��Center=�6K   $��10q�6h   5=      �� 5?   
   $��2��6   $��2��6"   $��Center=�66   .+�5@      �� -   5        $��OK��5A      
�������$��28(�5C      
 � Tag$ szolgaltatas��5D      $��Medium"�5E      $��5q�5F      ��5H      �� 5I      " ��6   .�5J      ��  � ��$ Fonts/#Dosis)�6C   �� 5K       � �� �#FE658467   �� 5L       �@�Cursor$
 Hand��63    �� Triggers 5M      P� 5N       P� Property �@J�IsMouseOver P� Value$
 True��6=   . �5O   "   ��  � �� �#FF4C706?   5P      5R      ��5T      �� 5U      " ��6&   .R�5V      �� $	��280��6!   $��35��6-   $ 12��5W      #��z��5X      ._�5Y      �� $��Center=�6/   $��Center=�6J   5Z      5[      5]      5^      5_      5c      