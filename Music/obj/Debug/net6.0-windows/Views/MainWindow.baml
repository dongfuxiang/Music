   M S B A M L   `   `   `  ����@  <Music, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:MusicMusic  5   	   ?$clr-namespace:Music.ViewModels.PagesMusic.ViewModels.Pages  5   	       Music.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   %localclr-namespace:Music     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2p$clr-namespace:Music.ViewModels.Pages     5   	     � Title$  音乐播放器��5   	   $
��1200��5	   	   $	��700��5
   	   $��Microsoft YaHei)�5   	   $��12(�5   	   $��
ExtraLight"�5   	    � 
ResizeMode$ NoResize=�5   	    � WindowStartupLocation$ CenterScreen=�5   	   '  !System.Windows.Shell.WindowChrome   WindowChrome 5        5   
      GlassFrameThickness$ 1q�6   .��5      � ��5   
   �� 5       �� 
StartPoint$	 0 0&�6"    �� EndPoint$	 0 1&�63   .��5      �  � Offset$ 0Q�6    � Color$ #F8FFFB��6*   � 5      $ 1Q�6   $ #FAFAFE��6*   5      	 � ColumnDefinitions	 5   
   �� 5       $	��180 �6   �� 5!      .+�5#   
   �� ���	#090000006   � 5%   
   
 � RowDefinitions
 5&      �� 5'      $��80 �6    �� 5(      .+�5*      �� $��Center=�6   $��Center=�5+       �� Orientation$ 
Horizontal=�5,      .+�5-      �� $��30��6   $��30��6$   ��5/      �� 50       �� ImageSource$ ../Assets/Images/m_1.png��6%    j� Stretch$ UniformToFill=�51   %    j� Viewport$ 0 0  1 1�52   %   54      �� 55      $��10,0,0,0q�6   $��Center=�56      $��Center=�57      $��13(�58      $
��Bold"�59      
��� ���$��音乐播放器��5;      5<      �� 5>      $��1��6   .+�5?      	� $��首页��6   $��15(�5@       d� 	IsChecked$
 TrueY�5A         MenuButtonStyle#��[  5B      
 � Tag$	 ��5C      	� 5D      $��精品歌单��6   $��15(�5E      #��[  5F      $	 ��5G      	� 5H      $��歌手推荐��6   $��15(�5I      #��[  5J      $	 ��5K      	� 5L      $��单曲排行��6   $��15(�5M      #��[  5N      $	 ��5O      �� 5P      $��音乐分类��6   $��15(�5Q        MenuLabelStyle#��[ 5R      $	 ��5S      A� 5T      $��	40,0,10,0q�6    A� Columns$ 3��61   .+�5U      	� $��流行��6"     ClassButtonStyle#��[ 6/   	� 5V      $��民谣��6"   #��[ 6/   	� 5W      $��电子��6"   #��[ 6/   	� 5X      $��舞曲��6"   #��[ 6/   	� 5Y      $��说唱��6"   #��[ 6/   	� 5Z      $��	轻音乐��6"   #��[ 60   	� 5[      $��爵士��6"   #��[ 6/   	� 5\      $��乡村��6"   #��[ 6/   	� 5]      $��更多��6"   #��[ 6/   5^      �� 5_      $��我的音乐��6   $��15(�5`      #��[ 5a      $	 ��5b      �� 5c      $��40,0,0,0q�6   ��61   �� *SList+��5d      �� 5e      .R�5f      	�   SheetButtonStyle#��[ 6E   ��6*   �� *Header+6E   5g      5i      5j      5k      � 5m   
   $��1��6   $��30,0,0,0q�6   
 5n      �� 5o      $��50 �6    �� 5p      .+�5r      �� $	��280��6   $��28��5s      $
��Left=�5t        SearchTextBoxStyle#��[ 5u      �� 5w      $��1��6   $��Hidden=�6(   .��5x      &    Music.ViewModels.Pages.FirstPage  5y      5{      �� 5|   
   5~      5      5�      