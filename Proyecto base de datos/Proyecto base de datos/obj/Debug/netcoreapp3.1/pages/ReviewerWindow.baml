   M S B A M L   `   `   `  ����Q  MProyecto base de datos, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:Proyecto_base_de_datos.pagesProyecto_base_de_datos.pages  5   	   1    +Proyecto_base_de_datos.pages.ReviewerWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   <local*clr-namespace:Proyecto_base_de_datos.pages     5   	     � Title$  ReviewerWindow��5   	   $	��550��6    $	��950��6-   .��5	      � .+�5
   
   �� $��Center=�6   $	��186��61   $��0,47,0,0q�6>   ���	#FF0C907D$	��Top=�6c   $	��836��6{   �� 5   
   $��Tema propuesto:��6   $
��Left=�6*   $��	74,68,0,0q�6E   $	��Top=�6X   $	��136��6p   $��16(�6|   $
��Left=�6�    J� RenderTransformOrigin$ 
0.45,0.338&�6�   $��Segoe UI Semibold)�6�   �� 5   
   $��	Tesista::��6   $
��Left=�6$   $��
74,136,0,0q�6?   $	��Top=�6S   $��63��6k   $��Segoe UI Semibold)�6v   $��16(�6�   �� 5   
   $��	Cédula:
��6   $
��Left=�6'   $��302,138,0,0q�6B   $	��Top=�6W   $��70��6o   $��27��6z   $��16(�6�   $��Segoe UI Semibold)�6�   $ 0.486,0.557&�6�   �� 5   
   $��Email:��6   $
��Left=�6!   $��553,138,0,0q�6<   $	��Top=�6Q   $��58��6i   $��16(�6t   $��Segoe UI Semibold)�6�   �� 5   
   $��Datos de los tesistas:��6   $
��Left=�61   $��
74,101,0,0q�6L   $	��Top=�6`   $	��201��6x   $��16(�6�   $��Segoe UI Semibold)�6�   �� 5   
   -   5         ��Name$ StudentName��5      $
��Left=�6)   $��142,141,0,0q�6D   $
��Wrap=�6Y   $��	TextBlock��6m   $	��Top=�6~   $	��145��6�   $��16(�6�   $��37��6�   �� 5   
   -   5        $ 	idStudent��5      $
��Left=�6'   $��377,145,0,0q�6B   $
��Wrap=�6W   $��	TextBlock��6k   $	��Top=�6|   $	��150��6�   $��16(�6�   $��33��6�   �� 5   
   -   5        $ StudentEmail��5      $
��Left=�6*   $��616,141,0,0q�6E   $
��Wrap=�6Z   $��	TextBlock��6n   $	��Top=�6   $	��246��6�   $��16(�6�   $��37��6�   �� 5   
   -   5        $ TitleTDG��5      $
��Left=�6&   $��
215,70,0,0q�6A   $
��Wrap=�6U   $	��Top=�6i   $	��611��6�   $��29��6�   $��16(�6�   �� 5   
   -   5         ��Name$ observationsTextBox��5      $
��Left=�6/   $��584,268,0,0q�6J    �� TextWrapping$
 Wrap=�6_   $	��Top=�6s   $	��310��6�   $	��176��6�   ���	#FF0C907D$��18(�6�   �� 5   
   $��Observaciones��6   $
��Left=�6(   $��584,238,0,0q�6C   $	��Top=�6X   $	��137��6p   $��30��6|   $��17(�6�   $��Segoe UI Semibold)�6�   �� 5   
   -   5        $��Enviar revisión��5      $
��Left=�6+   $��657,453,0,0q�6F   $	��Top=�6[   $��39��6s   $	��180��6   $��16(�6�   $��Segoe UI Semibold)�6�   ���	#FFF2F4B2���	#FF0C907D6�   �� 5   
   -   5         ��Name$ criteriaEvaluationListBox��5      $
��Left=�65   $	��176��6P   $��
51,275,0,0q�6]   $	��Top=�6q   $	��408��6�   ���	#FF0C907D$��20(�6�   �� 5   
   $%��Evaluación de Profesor Revisor��6   $��Center=�69   $��50��6V   $��0,-3,0,0q�6b   $	��Top=�6t   $	��500��6�   $��Segoe UI Semibold)�6�   $��30(�6�   $��Normal"�6�   ���	#FF0C907D6�   �� 5   
   $
��Left=�6   $��24��6/   $��
51,248,0,0q�6;   $
��Wrap=�6O   $	��Top=�6c   $	��183��6{   $��17(�6�   $��Segoe UI Semibold)�6�   �� 6�   $�Criterios de evaluaci��6�   �� 6�    � Language$ es-ve�6�   $�ó��6�   �� 6�   $�n:��6�   6	  �� 5   
   -   5        $ adviseLabel��5      $
��Left=�6)   $��
57,462,0,0q�6D   $
��Wrap=�6X   $7��1(*) Doble Click sobre un criterio para evaluarlo ��6l   $	��Top=�6�   $	��350��6�   $��16(�6�   �� 5   
   $��	Tesista::��6   $
��Left=�6$   $��
74,178,0,0q�6?   $	��Top=�6S   $��63��6k   $��Segoe UI Semibold)�6v   $��16(�6�   �� 5   
   $��
Cédula:
��6   $
��Left=�6,   $��302,180,0,0q�6G   $	��Top=�6\   $��70��6t   $��27��6   $��16(�6�   $��Segoe UI Semibold)�6�   $ 0.486,0.557&�6�   �� 5   
   $��Email:��6   $
��Left=�6!   $��553,180,0,0q�6<   $	��Top=�6Q   $��58��6i   $��16(�6t   $��Segoe UI Semibold)�6�   �� 5   
   -	   5        $ StudentName2��5      $
��Left=�6*   $��142,183,0,0q�6E   $
��Wrap=�6Z   $��	TextBlock��6n   $	��Top=�6   $	��145��6�   $��16(�6�   $��37��6�   �� 5   
   -
   5        $ 
idStudent2��5      $
��Left=�6(   $��377,187,0,0q�6C   $
��Wrap=�6X   $��	TextBlock��6l   $	��Top=�6}   $	��150��6�   $��16(�6�   $��33��6�   �� 5    
   -   5        $ StudentEmail2��5       $
��Left=�6+   $��616,183,0,0q�6F   $
��Wrap=�6[   $��	TextBlock��6o   $	��Top=�6�   $	��246��6�   $��16(�6�   $��37��6�   5"      5#      