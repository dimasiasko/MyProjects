   M S B A M L   `   `   `  ����E  AWeatherApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:WeatherApp
WeatherApp  5   	   O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5   	       WeatherApp.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:WeatherApp     5   	   b ^MaterialDesignThemes.Wpf, Version=3.2.0.1979, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   0sys&clr-namespace:System;assembly=mscorlib  5   	   -   5        $	��600��5
   	   $	��420��6     � WindowStartupLocation$  CenterScreen=�6"    � WindowStyle$
 None=�6G    � 
ResizeMode$ NoResize=�5   	    � AllowsTransparency . ��69   Z� .��5      � ��6   Z� .+�5   
   #  MaterialDesignThemes.Wpf.Card  -   5        $��10q�5         UniformCornerRadius$ 20Q�6*   ��6C   Z� .��5      �� ��5      �� 5       �� 
StartPoint$	 0,0&�6*    �� EndPoint$	 0,1&�6;   .��5      �  � Color$ #0C3B2E��6'    � Offset$
 0.55Q�67   � 5      $ #6D9773��6'   $ 1Q�67   5      .+�5      � $��70��6   .+�5      �� $
��20,0q�6   $
��Left=�6+      myButton#��[  6F   .��5      �� .+�5      '  !MaterialDesignThemes.Wpf.PackIcon  $��20��66   $��20��6A   	   Kind$	 Refresh=�6M   6^   5      5      �� 5      $��Center=�6   $��Center=�6:   .+�5      �� -   5        
 ��Name$
 
txtDateNow��5   �    �� Left$
 -100��6$   ���#FFBA00$��5q�6�   ���#B46617 �� Padding$ 5q�5   :   $��19(�6G    ! MaterialDesignButtonTextBlock#��[ 6U   ��5   7   �� 
 �� Now �� Source# Z  � Triggers 5      :� 5   "    :� RoutedEvent$ TextBlock.Loaded��6/   [�5    &   �� 5!   *   .��5"   .   �� .��5#   2   W�  �� TargetProperty$ (Canvas.Left)�6B    W� From$
 -100X�6l   	 W� To$	 -75X�6x    g� Duration$ 0:0:2D�5$   B    g� RepeatBehavior$ Forever��6S    g� AutoReverse . 6l   5%   /   5&   +   5(   #   5*      5+      �� 5,      -   5        $
��20,0q�5,      $��Right=�6+   #��[  6b   .��5-      �� .+�5.        $��20��66   $��20��6A   $	 CloseBox=�6M   6_   5/      50      51      � 53       � RowDefinitions 54      �� 55      $
��Auto �6(   �� 56      $
��Auto �6(   .+�58      �� $��0 40 0 0q�6   $��Icons/sun with clouds.png��6.   $	��250��6Q   $	��250��6]   �� 59      -   5        $��txtCurrentTemperature��59       $��5q�6=   $��1��6H   $��Center=�6U   $��55(�6r   ���#FFBA00$��SemiBold"�5:       $��
./#Kameron)�66   6P   5;      5>      5?      5@      5A      