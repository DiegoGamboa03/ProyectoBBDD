   M S B A M L   `   `   `  ����Q  MProyecto base de datos, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:Proyecto_base_de_datos.PagesProyecto_base_de_datos.Pages  5   	   4    .Proyecto_base_de_datos.Pages.CouncilAprobation   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   <local*clr-namespace:Proyecto_base_de_datos.Pages     5   	     � Title$  CouncilAprobation��5   	   $	��450��6#   $	��800��60   .��5	      � .+�5
   
   �� $
��Left=�6   $��31��6/   $��	52,79,0,0q�6;   $��Titulo:��6N   $
��Wrap=�6]   $	��Top=�6q   $��80��6�   $��20(�6�   $��Segoe UI Semibold)�6�   �� 5   
   $
��Left=�6   $��31��6/   $��
400,79,0,0q�6;   $��
Modalidad:��6O   $
��Wrap=�6a   $	��Top=�6u   $	��120��6�   $��Segoe UI Semibold)�6�   $��20(�6�   �� 5   
   $
��Left=�6   $��41��6/   $��
52,135,0,0q�6;   $��Numero correlativo:��6O   $
��Wrap=�6j   $	��Top=�6~   $	��198��6�   $��Segoe UI Semibold)�6�   $��20(�6�   �� 5   
   -   5         ��Name$ titleTextBlock��5      $
��Left=�6,   $��28��6G   $��
124,77,0,0q�6S   $��A��6g   $
��Wrap=�6p   $	��Top=�6�   $	��152��6�   $��20(�6�   $��Segoe UI Semilight)�6�   $��Normal"�6�   $��Italic$�6�    J� RenderTransformOrigin$ 0.5,0.5&�6�   z�5      V� 5      .~�5      �� �� 5      �� 5       �� Angle$ -0.95Q�6&   T� 5      5      5      �� 5   
   -   5        $ modalityTextBlock��5      $
��Left=�6/   $��31��6J   $��
520,79,0,0q�6V   $��	TextBlock��6j   $
��Wrap=�6{   $	��Top=�6�   $	��106��6�   $��20(�6�   $��Segoe UI Semilight)�6�   �� 5   
   -   5        $  correlativeNumberTextBlock��5      $
��Left=�68   $��41��6S   $��254,135,0,0q�6_   $��B��6t   $
��Wrap=�6}   $	��Top=�6�   $��68��6�   $��20(�6�   �� 5   
   -   5         ��Name$ approveButton��5      $��Aprobar��6(   $
��Left=�6:   $��58��6U   $��494,340,0,0q�6a   $	��Top=�6v   $	��165��6�   $��Segoe UI Black)�6�   $��16(�6�   ���	#FF0C907D���	#FFF2F4B26�   �� 5   
   -   5        $ DisapproveButton_��5      $��
Desaprobar��6,   $
��Left=�6A   $��138,342,0,0q�6\   $	��Top=�6q   $��56��6�   $	��165��6�   $��Segoe UI Black)�6�   $��16(�6�   ���	#FF0C907D���	#FFF2F4B26  �� 5   
   -   5         ��Name$ 	tutorList��5      $
��Left=�6&   $��31��6A   $��578,135,0,0q�6M   $	��Top=�6b   $	��172��6z   $��Segoe UI Semilight)�6�   $��20(�6�   �� 5   
   $��Evaluacion de Consejo��6   $
��Left=�60   $��50��6K   $��
251,10,0,0q�6W   $	��Top=�6k   $	��357��6�   $��Segoe UI Semibold)�6�   $��30(�6�   $��Normal"�6�   �� 5   
   $��Profesores Tutores��6   $
��Left=�6-   $��42��6H   $��400,129,0,0q�6T   $	��Top=�6i   $	��200��6�   $��Segoe UI Semibold)�6�   $��20(�6�   �� 5   
   -   5        $ firstJuryComboBox��5      $
��Left=�6.   $��32��6I   $��202,195,0,0q�6U   $	��Top=�6j   $	��172��6�   $��Segoe UI Semilight)�6�   $��20(�6�   �� 5   
   $��Primer Jurado��6   $
��Left=�6(   $��42��6C   $��
51,190,0,0q�6O   $	��Top=�6c   $	��200��6{   $��Segoe UI Semibold)�6�   $��20(�6�   �� 5    
   -   5        $ firstsubstituteComboBox��5       $
��Left=�64   $��32��6O   $��578,195,0,0q�6[   $	��Top=�6p   $	��172��6�   $��Segoe UI Semilight)�6�   $��20(�6�   �� 5!   
   $��Primer Suplente��6   $
��Left=�6*   $��42��6E   $��400,190,0,0q�6Q   $	��Top=�6f   $	��200��6~   $��Segoe UI Semibold)�6�   $��20(�6�   �� 5"   
   -	   5        $ secondJuryComboBox��5"      $
��Left=�6/   $��32��6J   $��220,276,0,0q�6V   $	��Top=�6k   $	��172��6�   $��Segoe UI Semilight)�6�   $��20(�6�   �� 5#   
   $��Segundo  Jurado��6   $
��Left=�6*   $��42��6E   $��
52,271,0,0q�6Q   $	��Top=�6e   $	��200��6}   $��Segoe UI Semibold)�6�   $��20(�6�   �� 5$   
   -
   5        $ secondSubstituteComboBox��5$      $
��Left=�65   $��32��6P   $��578,276,0,0q�6\   $	��Top=�6q   $	��172��6�   $��Segoe UI Semilight)�6�   $��20(�6�   �� 5%   
   $��Segundo Suplente��6   $
��Left=�6+   $��42��6F   $��400,271,0,0q�6R   $	��Top=�6g   $	��200��6   $��Segoe UI Semibold)�6�   $��20(�6�   5'      5(      