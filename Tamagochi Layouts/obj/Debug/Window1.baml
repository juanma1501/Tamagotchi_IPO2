   M S B A M L   `   `   `  ����L  HTamagochi Layouts, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Tamagochi_LayoutsTamagochi_Layouts  5   	       Tamagochi_Layouts.Window1   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:Tamagochi_Layouts     5   	   -   5          �Name$  
Bienvenido��5   	    � Title$ 
Bienvenido��5   	   $��266.14��6   $��468.849��6,    � 
ResizeMode$ NoResize=�6<    � Topmost .  � WindowStartupLocation$ CenterScreen=�6a    � WindowStyle$
 None=�6�    � ShowInTaskbar .   � 	Resources 5	         
Bienvenida �� TargetProperty	 �� 
TargetName9  3System.Windows.Media.Animation.EasingDoubleKeyFrame
 O� KeyTime O� Value R� KeyTime  System.Windows.Visibility   Visible R� Value   EasingFunction0  *System.Windows.Media.Animation.QuarticEase7  1System.Windows.Media.Animation.EasingFunctionBase   
EasingMode��%�  &	        �� 5
   
   .��5      U� $ (UIElement.Opacity)�6,   $	 image��6\   .\�5        $
 0��6'   $ 1Q�63     5      $
 0:0:1.4��6'   $
 0.75Q�69     5      $
 0:0:5��6'   $	 0.5Q�67   5      U� 5      $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleX)�6,   $	 image��6�   .\�5        $
 0��6'   $ 1Q�63     5      $
 0:0:1.4��6'   $ 6.557Q�69   5      U� 5      $U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�6,   $	 image��6�   .\�5        $
 0��6'   $ 0Q�63     5      $
 0:0:1.4��6'   $ 8.447Q�69   5      U� 5      $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleY)�6,   $	 image��6�   .\�5        $
 0:0:1.4��6'   $ 3.127Q�69     5      $
 0:0:5��6'   $
 4.87Q�67   5      U� 5      $U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.Y)�6,   $	 image��6�   .\�5        $
 0:0:1.4��6'   $ 8.801Q�69     5      $
 0:0:5��6'   $ -1.056Q�67   5      T� 5       $ (UIElement.Visibility)�6,   $	 label��6_   ..�5!      i� $ 0��6)   # Z 65   i� 5"      $ 0:0:5��6)   # Z 69   5#      T� 5$      $ (UIElement.Visibility)�6,   $	 label1��6_   ..�5%      i� $ 0��6)   # Z 65   i� 5&      $ 0:0:5��6)   # Z 69   5'      T� 5(      $ (UIElement.Visibility)�6,   $	 txtBoxNombre��6_   ..�5)      i� $ 0��6)   # Z 65   i� 5*      $ 0:0:5��6)   # Z 69   5+      T� 5,      $ (UIElement.Visibility)�6,   $	 button��6_   ..�5-      i� $ 0��6)   # Z 65   i� 5.      $ 0:0:5��6)   # Z 69   5/      U� 50      $ (UIElement.Opacity)�6,   $	 label��6\   .\�51        $
 0��6'   $ 0Q�63    52        53      $ EaseOut=�6&   55        56      $
 0:0:1��6'   $
 0.25Q�67    57        58      $ EaseOut=�6&   5:        5;      $
 0:0:5��6'   $ 1Q�67    5<        5=      $ EaseOut=�6&   5?      5@      U� 5A      $ (UIElement.Opacity)�6,   $	 label1��6\   .\�5B        $
 0��6'   $ 0Q�63     5C      $
 0:0:1��6'   $
 0.25Q�67     5D      $
 0:0:5��6'   $ 1Q�67   5E      U� 5F      $ (UIElement.Opacity)�6,   $	 txtBoxNombre��6\   .\�5G        $
 0��6'   $ 0Q�63     5H      $
 0:0:1��6'   $
 0.25Q�67     5I      $
 0:0:5��6'   $ 1Q�67   5J      U� 5K      $ (UIElement.Opacity)�6,   $	 button��6\   .\�5L        $
 0��6'   $ 0Q�63     5M      $
 0:0:1��6'   $
 0.25Q�67     5N      $
 0:0:5��6'   $ 1Q�67   5O      U� 5P      $ (UIElement.Opacity)�6,   $	 capiCentrado��6\   .\�5Q        $
 0��6'   $ 0Q�63     5R      $
 0:0:5��6'   $ 1Q�67   5S      5T      5U      .��5V      � -   5         �Name$ ventanaBienvenida��5V      ��5W   
   �� 5X       �� EndPoint$ 0.5,1&�6"    � MappingMode$ RelativeToBoundingBox=�63    �� 
StartPoint$ 0.5,0&�6W   .��5Y      �  � Color$ Black��6   � 5Z      $ White��6    � Offset$ 0.993Q�6-   � 5[      $ 	#FF16ADB6��6   5\       � ColumnDefinitions 5^   
   �� 5_      $	��51* �6   �� 5`      $
��361* �6   �� 5a      $
��153* �6   .+�5d   
   �� -   5         ��Name$ image��5d      $
��Left=�6   $��28.999��6:   $��146.388,112.795,0,0q�6J   $	��Top=�6g   $��70.698��6   $��
marvel.png��6�    J� Opacity$	 0.5Q�6�   $��1��6�    J� RenderTransformOrigin$ 0.5,0.5&�6�   $
��Fill=�6�   z�5e      V� 5f      .~�5g      �� �� 5h      �� 5i      T� 5j      5k      5m      �� 5o   
   -   5         ��Name$ label��5o      $��IPO 2 - TAMAGOCHI��6   $��1��6;   $
��Left=�6K   $��47.521,10,0,0q�6f   $	��Top=�6}   $��Avengero)�6�   $��22(�6�   $��2��6�   $	��336��6�   ���	#FFD60E0E6�   �� 5p   
   -   5        $ label1��5p      $��NOMBRE DE TU CAPITAN
��6    $
��Left=�6D   $��28.594,194,0,0q�6_   $	��Top=�6w   $��33��6�   $��16(�6�   ���	#FFF41010$��Avengero)�6�   ���	#FFE24444$��262.216��6  $��2��6  ��6�   Z� 6  �� 5q   
   -   5         ��Name$ txtBoxNombre��5q      $��1��6(   $
��Left=�68   $��33��6S   $��10,223.14,0,0q�6_    �� TextWrapping$
 Wrap=�6v   $	��Top=�6�   $	��190��6�   $��Avengero)�6�   $��16(�6�   ���	#FFFF02026�   �� 5r   
   -   5         ��Name$ button��5r      $��EMPEZAR��6!   $��2��63   $
��Left=�6C   $��10,221.14,0,0q�6^   $	��Top=�6u   $��98��6�   $��35��6�   $��14(�6�   $��Avengero)�6�   ���	#FFEB1515 � Cursor$
 Hand��6�     �� 	IsDefault  . ���	#FFFA2906���	#FF00FAFF6+  �� 5s   
   -   5        $ gifCapi��5s      $
��Left=�6!   $��266.14��6<   $	��Top=�6L   $��468.849��6d   $��3��6t   $
��Fill=�6�   $y�Hidden=�6�   �� 5t   
   -	   5        $ capiCentrado��5t      $��1��6&   $
��Left=�66   $��113.766��6Q   $��129.976,55.1,0,0q�6b   $	��Top=�6|   $��118.513��6�   5u      5v      