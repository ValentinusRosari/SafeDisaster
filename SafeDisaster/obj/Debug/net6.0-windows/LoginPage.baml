   M S B A M L   `   `   `  ����  SafeDisaster    SafeDisaster.LoginPage   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          � Title$  Login��5   	   $	��450��6   $	��400��6$    � 	Resources 5       �� 
TargetType �� Property �� Value �� Triggers P� Property P� Value   RoundedTextBoxStyle �� 
TargetType	 �� CornerRadius
 ��Name  RoundedPasswordBoxStyle��%�  '��       &	  2    &	 `    �� 5   
   " ��6   .�5      ��  � �� �#00A9FF6+   �� 5	       � ��
 �����6+   �� 5
       � ��$
 15,5q�6(   �� 5       � ��$ 0q�60    5      P� 5       �@J�IsMouseOver$
 True��61   . �5      ��  � �� �#45a04963   5      5      �� 5   
   " ��6,   .�5      ��  � ��$ 10q�6(   �� 5       � ��$	 0 5q�6'   �� 5       � �� �#3336+   �� 5       � �� �#eee6+   �� 5       � �� �#ccc6,   �� 5       � ��$ 2q�60   �� 5       � ��$ Stretch=�64   �� 5       � ��$ Center=�69   �� 5       � �� 5      �� 5      " ��6&   .R�5      �� #��z��6!   #��z��6K   #��z��6w   $	 15��6�   ._�5       �� $
 PART_ContentHost��66   $��0q�6+   66   5!      5"      5$      5%      �� 5'   
   " G�60   .�5(      ��  � ��$ 10q�6(   �� 5)       � ��$	 0 5q�6'   �� 5*       � �� �#3336+   �� 5+       � �� �#eee6+   �� 5,       � �� �#ccc6,   �� 5-       � ��$ 2q�60   �� 5.       � ��$ Stretch=�64   �� 5/       � ��$ Center=�69   �� 50       � �� 51      �� 52      " G�6&   .R�53      �� #��z��6!   #��z��6K   #��z��6w   $	 15��6�   ._�54      �� $
 PART_ContentHost��66   $��0q�6+   66   55      56      58      59      5:      .��5<      � $��0,4,0,0q�6   $	��450��6   $	��400��6)   $	��Top=�65   ��5=   
   �� 5>       �� ImageSource$ /Assets/disasterImage.jpg��6    �� Opacity$
 0.75Q�6A    � ColumnDefinitions 5A   
   �� 5B      $��* �6   �� 5C      $��2* �6   �� 5D      $��* �6    � RowDefinitions 5G   
   �� 5H      $��* �6   �� 5I      $
��Auto �6   .+�5L   
   �� $��1��6   $��0��6%   $��Center=�62   ���	#80FFFFFF.+�5M      �� $��15q�6   .+�5N      �� $��Sign In��6   $��Center=�6+   $��18(�6H   $
��Bold"�6V   
���   �$��0 0 0 10q�6{   $��./Fonts/#Poppins-Regular)�6�   �� 5O      $��0 0 0 0q�6   .+�5P      �� $��Username��6   $
��Left=�6/   $��Center=�6J   
���   �$��./Fonts/#Poppins-Regular)�6x   �� 5Q      -   5        $��txtUsernameOrEmail��5Q   K   #��[  6   6K   5R      �� 5S      $��0 0 0 10q�6   .+�5T      �� $��Password��6   $
��Left=�6/   $��Center=�6J   
���   �6e   G� 5U      -   5        $��txtPassword��5U   S   #��[ 6"   6S   5V      �� 5W      -   5        $��Sign In��5W      $��Center=�6F   $	��175��6c   $��0 1 0 0q�6o   �� 5X       �� Orientation$ Vertical=�6   $��Center=�64   $��0 5 0 0q�6Q   .+�5Y      �� $��Don't have an account?��6   $
��Left=�6=   $��Center=�6X   ���#7D7C7C$��10(�6�   �� 5Z      -   5        $��Sign Up��5Z      $	��175��6/   $��0 0 0 0q�6;   6L   5[      5\      5]      5^      5_      