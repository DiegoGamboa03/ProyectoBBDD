   M S B A M L   `   `   `  ����Q  MProyecto base de datos, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:Proyecto_base_de_datos.pagesProyecto_base_de_datos.pages  5   	   0    *Proyecto_base_de_datos.pages.TeacherWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   <local*clr-namespace:Proyecto_base_de_datos.pages     5   	     � Title$  TeacherWindow��5   	   $	��500��6   $	��950��6,    � 	Resources 5	          BooleanToVisibilityConverter  ItemContainerStyle �� 
TargetType �� Property �� Value �� 
TargetType �� Stretch �� 	Converter �� RelativeSource  TabControlStyle1	 �Name
 J� SnapsToDevicePixels-  'System.Windows.Input.KeyboardNavigation   TabNavigation � ColumnDefinitions �� Padding �� EndPoint �� 
StartPoint � Color � Offset ��Name K� IsItemsHost   TabIndex K� ZIndex ��Name ��Name��%�  &	        &	      7   &	 �    7  �� 5
   
   6'   �� 5   
   " ��6+   .�5      ��  � �� 5      �� 5      " ��6&   .R�5      � $
��15,5q�6   .+�5      F� $��10��6#   $��14��6.   $��0,2,0,0q�6:   $
��Left=�6K   $��Center=�6f   $
 Fill=�6�   ���	#FF000000X�����_h�=�$s/|yфJ�X[d�xTX[dѸ�h�=�xTx;фJ�x;�$s/�nѬ�_h�=y�6H  �� *
IsSelected+8    �� *TemplatedParent+�� 5      #��z��6/   $��	20,5,10,5q�6R    5   "   ���� 5   &   '��       " ��6,   .�5   *   ��  � ��$ 18(�6E   �� 5   *    � ��$ Light"�6G   5   '   5   #   5      5      5      5      5      �� 5   
   " ��6)   .�5      ��  �@��TabStripPlacement$
 Left=�62   �� 5        � ��8   63   �� 5!       � �� 5"      �� 5#      " ��6&   .R�5$      � $	 templateRoot��6   $
}�true��65   $

 true��6I   $ Local=�6d    5%      �� 5&   "   $
��Auto �63   �� 5'   "   $��1* �63   .+�5)      �� $��0��6%   $ 5q�65   ��5*   "   �� 5+   &   $	 0,0&�6:   $	 1,0&�6I   .��5,   *   � $ #0C907D��67   $ 0Q�6G   � 5-   *   $ #0D627A��67   $ 1Q�6G   5.   '   ._�50   "   ]� .+�51   &   �� $��Bottom=�6,   $��Center=�6D   $��20q�6a   $F��@pack://application:,,,/StackOverflowTabControl;component/twc.png��6m   $	��200��6�   �� 52   &   $ headerPanel��6/   
������ $��0��6]   $
 true��6m   $��2,2,2,0q�6�   $��0��6�   $ 1��6�   $ 1��6�   53   #   54      �� 55      $ contentPanel��6%   $��1��6;   $��5,0,0,0q�6K   ._�56   "   �� $ PART_SelectedContentHost��63   $��SelectedContent��6U   #��z��6u   #
 z
 6�   57      58      59      5;      5<      5=      .��5>      � .+�5?   
   �� -   5        #���  5?      .@�5@      �� $��Información Personal��6   $��44��64   $	��Top=�6@   $	��233��6X   $��0,4,0,0q�6d   .��5A       � -   5          �Name$ 	mainFrame��5A      5B      5C      �� 5D      $��Comité��6   $��Segou UI)�6&   $��
0,10,0,-10q�6<   .��5E       � -   5        $ Frame1��5E      $��0,0,0,4q�6(   $	��476��69   5F      �� 5G      $��Profesor Revisor��6   $��
0,10,0,-10q�60   .��5H       � -   5        $ Frame2��5H      $��0,0,-1,0q�6(   $	��533��6:   5I      5J      �� 5K      $��Consejo de escuela��6   $��44��62   $	��Top=�6>   $	��235��6V   $��0,10,0,0q�6b   .��5L       � -   5        $ Frame3��5L      5M      5N      �� 5O      $#��Evaluación trabajo de 
grado��6   $	��232��6@   $��	0,10,0,-5q�6L   .��5P       � -   5        $ Frame4��5P      5Q      5R      �� 5S      $��Crear especialidad��6   $��44��62   $��Bottom=�6>   $	��224��6Y   .��5T       � -   5        $ Frame5��5T      5U      5V      �� 5W      $��Crear Criterio��6   $��44��6.   $��Center=�6:   $	��219��6U   .��5X       � -   5        $ Frame6��5X      5Y      5Z      5[      �� 5\   
   $
��Left=�6   $	��104��6+   $��
51,370,0,0q�68   $	��Top=�6L   $	��146��6d   $i��c/pages/png-clipart-soni-design-printing-cat-furniture-sandwich-wood-eco-friendly-furniture-food.png��6p   $
��Fill=�6�   5]      5^      