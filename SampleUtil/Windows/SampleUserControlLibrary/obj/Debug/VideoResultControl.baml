   M S B A M L   `   `   `  ����S  OSampleUserControlLibrary, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:SampleUserControlLibrarySampleUserControlLibrary  5      1    +SampleUserControlLibrary.VideoResultControl   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      8local&clr-namespace:SampleUserControlLibrary     5        � 	Resources  5	      8   2SampleUserControlLibrary.BoolToVisibilityConverter   BoolToVisibilityConverter>   8SampleUserControlLibrary.InvertBoolToVisibilityConverter # InvertBoolToVisibilityConverter��%:   &	        &	        5
   
   6N     5   
   6Z   5      .��5      �  � DataContext 6   ��  �� RelativeSource ��  �� AncestorType$ UserControlL�.+�5   
   �  � RowDefinitions 5   
   �� 5      $
��Auto �6   6,   �� 5      $��* �6   6)   �� 5      $
��Auto �6   6,    � ColumnDefinitions 5   
   �� 5      $��* �6   6+   �� 5      $��* �6   6+   .+�5   
   �� $��0��6   $��0��6$   	Original:6<   �� 5   
   $��1��6   $��0��6$   	Result:6:   � 5   
   -   5         �Name$ originalVideoHolder��5   K   
���   �$��0��6"   $��1��62   $��5q�6@   .+�5      r� -   5         r�Name$ originalVideo��5   �   $��Stretch=�6   $��Stretch=�69    r� LoadedBehavior$ Manual=�6U   	 r� UnloadedBehavior$	 Manual=�6m   
 r� Source
 6�   ��  �� Path$ 	SourceUri�6�   �� 5      -   5         ��Name$ rectangleAreas��5      $��Stretch=�6-   $��Stretch=�6L   5      � 5   
   
���   �$��1��6#   $��1��63   $��5q�6@   .+�5       r� -   5        $ resultVideo��5    �   $��Stretch=�6   $��Stretch=�69   $ Manual=�6U   $	 Manual=�6m    r� IsMuted . 
 6�   �� $ 	ResultUri�y�6�   �� $ IsVideoResult� �� 	Converter# [  �� 5!       �� 
IsReadOnly . " �� VerticalScrollBarVisibility$ Visible=�6(    �� TextWrapping$
 Wrap=�6N   y�6b   �� $ IsTextResult�# [  ��6�   �� $ 
ResultText�6�   �� 5"      ��6   �� *ResultControl+y�6?   �� $ IsCustomResult�# [  5#      �� 5%   
   $��2��6   $��2��6#    �� Orientation$ 
Horizontal=�67   $��Center=�6P   .+�5&      �� -   5        $��30��5&      $��20��6    $��5q�6,   .��6S   F� $��10��6X   $��10��6c   "������     р� ��� �@T� @KL 	
���   �6�   6�   �� 5'      -   5        $��30��5'      $��20��6    $��5q�6,   .��6S   F� $��10��6X   $��10��6c   +������ �� р�  z � z  z � z �� 	
���   �6�   6�   5(      5+      � 5,   
   
������� J� Opacity$	 0.9Q�6"   $��Stretch=�60   $��Stretch=�6N   y�6k   �� $ 	IsWorking�# [  .+�5-      � $	��100q�6   $��10��6'   $	��300��63    � IsIndeterminate . 6[   5.      5/      50      