   M S B A M L   `   `   `  ����  NETRecorder    NETRecorder.App   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5        �� 	Resources  5       �� 
TargetType �� Property �� Value �� 
TargetType'  !System.Windows.VisualStateManager   VisualStateGroups%  System.Windows.VisualStateGroup   Name   Transitions%  System.Windows.VisualTransition   GeneratedDuration	   States   System.Windows.VisualState
   Name   
Storyboard �� TargetProperty �� 
TargetName8  2System.Windows.Media.Animation.EasingColorKeyFrame �� KeyTime �� Value ��Name �� Triggers P� Property P� Value��%�  '��       '�� �    �� 5   
   " ��6   .�5      ��  �@�OverridesDefaultStyle . 66   �� 5       �@�FocusVisualStyle 61   Z� �� 5	       � �� 5
      �� 5      " ��6&   .R�5      �� $��ButtonBorder��6!   $��0q�65   
���   � 5        5   "   $ CommonStates��63    5   &     5   *   $ 0:0:0.2D�6;   .	 5   &     $
 Normal��62     5   &   $
 	MouseOver��62   . 5   *   �� .��5   .   �� $0 *(Panel.Background).(SolidColorBrush.Color)�6K   $ ButtonBorder��5   K   .g�5   2     $ 0��6F   $ 	#FFABCB7A��5   F   5   /   5   +   5   '     5   &   $
 Pressed��62   . 5   *   �� .��5   .   �� $0 *(Panel.Background).(SolidColorBrush.Color)�6K   $ ButtonBorder��5   K   .g�5    2     $ 0��6F   $ White��5!   F   5"   /   5#   +   5$   '     5%   &   $
 Disabled��62   5&   #   5(      5)      5+      5,      �� 5-   
   " ��6   .�5.      ��  �@�OverridesDefaultStyle . 66   �� 5/       � ��$ 0,5,0,5q�6'   �� 50       � ��$ Malgun Gothic)�6+   �� 51       � ��$ 18(�6)   �� 52       � ��$ 0q�60   �� 53       � ��$ Center=�6;   �� 54       �@�FocusVisualStyle 61   Z� �� 55       � �� 56      �� 57      " ��6&   .R�58      �� $��TextBoxBorder��6!   $��0,0,0,1q�66   ���	#FF9BBB5A 59        5:   "   $ CommonStates��63    5;   &     5<   *   $ 0:0:0.2D�6;   .	 5>   &     $
 Normal��62     5?   &   $
 Focused��62   . 5@   *   �� .��5A   .   �� $2 ,(Border.BorderBrush).(SolidColorBrush.Color)�6K   $ TextBoxBorder��5B   K   .g�5C   2     $ 0��6F   $ Black��5D   F   5E   /   5F   +   5G   '     5H   &   $
 	MouseOver��62   . 5I   *   �� .��5J   .   �� $2 ,(Border.BorderBrush).(SolidColorBrush.Color)�6K   $ TextBoxBorder��5K   K   .g�5L   2     $ 0��6F   $ Black��5M   F   5N   /   5O   +   5P   '     5Q   &   $
 ReadOnly��62     5R   &   $
 Disabled��62   5S   #   ._�5U      �� $ PART_ContentHost��66   $��0q�6+   66   5V      5W      5Y       5Z      P� 5[       �@J�	IsFocused . . �5\      ��  � ��
 �����64   5]      5_      5`      5a      