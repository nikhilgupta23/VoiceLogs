   M S B A M L   `   `   `  ����S  OSampleUserControlLibrary, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:SampleUserControlLibrarySampleUserControlLibrary  5      2    ,SampleUserControlLibrary.SubscriptionKeyPage   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      8local&clr-namespace:SampleUserControlLibrary     5        N� Title$  SubscriptionKeyPage��5	       � 	Resources 5         
LinkButton �� 
TargetType �� Property �� Value �� 
TargetType �� Triggers P� Property P� Value��%F  &	        �� 5   
   " ��6#   .�5      ��  � �� 5      �� 5      " ��6&   .R�5      �� $��	Underline{�6$   �� 5      5      5      5      �� 5       � ��
 ��  �6+    5      P� 5       �@J�IsMouseOver . . �5      ��  � ��
 �  ��63   5      5      5      .��5      � .+�5   
   �� 	 �� Orientation$	 Vertical=�6   .+�5       �� $��
5, 0, 5, 0q�6   NLTo use the service, you need to ensure that you have right subscription key.6{   �� 5!      $��
5, 0, 5, 0q�6   ZXPlease note that each service (Face, Emotion, Speech, etc) has its own subscription key.6�   �� 5"      $��
5, 0, 5, 0q�6   pnIf you do not have key yet, please use the link to get a key first, then paste the key into the textbox below.6�   �� 5#      -   5        $��1��5#      $��3��6"   $
��Left=�6M   #��[  6h   $��
5, 0, 0, 0q�6�   $��Get Key��6�   �� 5$      $	 
Horizontal=�6   $
��Left=�62   $	��Top=�6M   .+�5%      �� $��Center=�6   .��63   Subscription Key:6F   �� 5&      $��Stretch=�6   $	��300��66   $��2q�6B   $��0,5,0,5q�6�   ��6N   �� 
 �� Path$
 SubscriptionKey� �� Mode$ TwoWay=�6�   �� 5'      -   5        $��
5, 0, 0, 0q�5'   /   $��
5, 0, 5, 0q�6C   $��Center=�6X   .��6t   
Save Key6~   �� 5(      -   5        $��
5, 0, 0, 0q�5(   1   $��
5, 0, 5, 0q�6E   $��Center=�6Z   .��6v   
Delete Key6�   5)      5*      5+      5,      