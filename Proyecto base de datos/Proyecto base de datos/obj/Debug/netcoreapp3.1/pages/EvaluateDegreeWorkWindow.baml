   M S B A M L   `   `   `  ����Q  MProyecto base de datos, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:Proyecto_base_de_datos.PagesProyecto_base_de_datos.Pages  5   	   ;    5Proyecto_base_de_datos.Pages.EvaluateDegreeWorkWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   <local*clr-namespace:Proyecto_base_de_datos.Pages     5   	     � Title$  EvaluateDegreeWorkWindow��5   	   $	��500��6*   $	��950��67   .��5	      � .+�5
   
   �� $
��Left=�6   $	��116��6/   $��	38,66,0,0q�6<   ���	#FF0C907D$	��Top=�6b   $	��867��6z   �� 5   
   $��Tema propuesto:��6   $
��Left=�6*   $��	48,66,0,0q�6E   $	��Top=�6X   $	��136��6p   $��16(�6|   $
��Left=�6�    J� RenderTransformOrigin$ 
0.45,0.338&�6�   $��Segoe UI Semibold)�6�   �� 5   
   $��Tesista:��6   $
��Left=�6#   $��
53,137,0,0q�6>   $	��Top=�6R   $��64��6j   $��Segoe UI Semibold)�6u   $��16(�6�   �� 5   
   $��Cedula:
��6   $��Center=�6'   $��	0,137,0,0q�6D   $	��Top=�6W   $��64��6o   $��32��6z   $��16(�6�   $��Segoe UI Semibold)�6�   �� 5   
   $��Datos del tesista:��6   $
��Left=�6-   $��	48,97,0,0q�6H   $	��Top=�6[   $	��136��6s   $��16(�6   $��Segoe UI Semibold)�6�   �� 5   
   -   5         ��Name$ StudentName��5      $
��Left=�6)   $��122,140,0,0q�6D   $
��Wrap=�6Y   $��	TextBlock��6m   $	��Top=�6~   $	��193��6�   $��16(�6�   $��26��6�   �� 5   
   -   5        $ 	idStudent��5      $
��Left=�6'   $��512,142,0,0q�6B   $
��Wrap=�6W   $��	TextBlock��6k   $	��Top=�6|   $	��202��6�   $��16(�6�   $��31��6�    �� TextAlignment$
 Left=�6�   �� 5   
   -   5        $ TitleTDG��5      $
��Left=�6&   $��
189,73,0,0q�6A   $
��Wrap=�6U   $	��Top=�6i   $	��696��6�   $��29��6�   $��14(�6�   �� 5   
   -   5        $��Enviar revisión��5      $
��Left=�6+   $��630,396,0,0q�6F   $	��Top=�6[   $��51��6s   $	��216��6   $��16(�6�   $��Segoe UI Semibold)�6�   ���	#FFF2F4B2���	#FF0C907D6�   �� 5   
   -   5         ��Name$ criteriaEvaluationListBox��5      $
��Left=�65   $	��176��6P   $��
38,229,0,0q�6]   $	��Top=�6q   $	��408��6�   ���	#FF0C907D$��20(�6�   6  �� 5   
   $$��Evaluacion de trabajo de grado��6   $
��Left=�69   $��50��6T   $��
244,16,0,0q�6`   $	��Top=�6t   $	��446��6�   $��Segoe UI Semibold)�6�   $��30(�6�   $��Normal"�6�   ���	#FF0C907D$ 0.5,0.5&�6�   z�5      V� 5      .~�5      �� �� 5      �� 5       �� Angle$ 0.028Q�6&   T� 5      5      5      �� 5   
   $
��Left=�6   $��24��6/   $��
38,200,0,0q�6;   $��Criterios de evaluacion:��6O   $
��Wrap=�6o   $	��Top=�6�   $	��184��6�   $��17(�6�   $��Segoe UI Semibold)�6�   �� 5   
   -   5        $ adviseLabel��5      $
��Left=�6)   $��
53,436,0,0q�6D   $
��Wrap=�6X   $7��1(*) Doble Click sobre un criterio para evaluarlo ��6l   $	��Top=�6�   $	��350��6�   $��16(�6�   5!      5"      