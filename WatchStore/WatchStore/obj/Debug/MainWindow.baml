   M S B A M L   `   `   `  ����E  AWatchStore, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:WatchStore
WatchStore  5   	       WatchStore.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   b ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   $localclr-namespace:WatchStore  5   	      MaterialDesignBody#���   5	   	   $��Regular"�5
   	   $��13(�5   	   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignPaper#���  5   	     MaterialDesignFont#���  5   	    � Title$ 
MainWindow��5   	   $	��450��6   $	��800��6)    � 	Resources 5       �� 
TargetType " MaterialDesignCaptionTextBlock �� BasedOn �� Property �� Value % !MaterialDesignFloatingHintTextBox��%�   '��       7  '�� M     7  �� 5   
   " ��6   8   .�5      ��  � ��$ 14(�6)   5      �� 5   
   " ��6   8   .�5      ��  � ��$ 14(�6)   5      5      .��5      �  � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $
��0.8* �6   	 � RowDefinitions	 5   
   �� 5      $��* �6   �� 5       $
��0.2* �6   .+�5#   
   �� $��0��6     MaterialDesignCardsListBox#��[ 5$   9   ��5#   "   �� *	Watches+
 �� SelectedItem
 5$      �� *SelectedWatch+��5%      �� 5&      .R�5'      ��  �� Orientation$ 
Horizontal=�6!   .+�5(      �� $��5q�6%   .+�5)      �� $��18(�6(   ��66   ��  �� Path$ Title��� 5*      ��6(   �� $ Company��� 5+      ��6(   �� $ Price�5,      �� 5-      $��65��6=   $��65��6H   ��6    �� $
 Icon�6V   5.      50      52      �� 54   
   $��1��6   $ 
Horizontal=�6"   .+�55      �� ��6   �� *
AddCommand+.��64   +67   �� 56      ��6   �� *RemoveCommand+��57      �� *SelectedWatch+.��6@   -6C   58      �� 5:   
   $��1��6    � DataContext 6%   �� *SelectedWatch+.+�5;      �� $'��!Выбранный элемент��6   �� 5<      $��Модель��6   �� 5=      ��6   �� *Title+ �� UpdateSourceTrigger$ PropertyChanged=��� 5>      $ ��Производитель��6   �� 5?      ��6   �� *	Company+$ PropertyChanged=��� 5@      $��Цена��6   �� 5A      ��6   �� *Price+$ PropertyChanged=�5B      5C      5D      