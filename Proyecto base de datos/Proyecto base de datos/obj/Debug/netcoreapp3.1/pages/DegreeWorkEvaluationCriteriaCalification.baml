   M S B A M L   `   `   `  ����Q  MProyecto base de datos, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:Proyecto_base_de_datos.PagesProyecto_base_de_datos.Pages  5   	   K    EProyecto_base_de_datos.Pages.DegreeWorkEvaluationCriteriaCalification   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   <local*clr-namespace:Proyecto_base_de_datos.Pages     5   	     � Title$.  (DegreeWorkEvaluationCriteriaCalification��5   	   $	��450��6:   $	��800��6G   .��5	      �  � RowDefinitions 5
   
   �� 5      $
��107* �6   �� 5      $
��110* �6   .+�5   
   �� -   5         ��Name$ ApprobationButton��5      $��Evaluar��6,   $
��Left=�6>   $��48��6Y   $��517,116,0,0q�6e   $	��Top=�6z   $	��198��6�   ���	#FF0C907D$��Segoe UI Semibold)�6�   $��24(�6�   ���	#FFF2F4B2$��1��6  �� 5   
   $
��Left=�6   $��32��6/   $��
86,132,0,0q�6;   $��Titulo:��6O   $
��Wrap=�6^   $	��Top=�6r   $��80��6�   $��20(�6�   $��Segoe UI Semibold)�6�   �� 5   
   $
��Left=�6   $��32��6/   $��
86,192,0,0q�6;   $��
Modalidad:��6O   $
��Wrap=�6a   $	��Top=�6u   $	��120��6�   $��Segoe UI Semibold)�6�   $��20(�6�   $��2��6�   �� 5   
   $
��Left=�6   $��42��6/   $��392,192,0,0q�6;   $��Numero correlativo:��6P   $
��Wrap=�6k   $	��Top=�6   $	��186��6�   $��Segoe UI Semibold)�6�   $��20(�6�   $��2��6�   �� 5   
   -   5         ��Name$ titleTextBlock��5      $
��Left=�6,   $��33��6G   $��172,132,0,0q�6S   $��A��6h   $
��Wrap=�6q   $	��Top=�6�   $	��152��6�   $��20(�6�   $��Segoe UI Semilight)�6�   $��Normal"�6�   $��Italic$�6�    J� RenderTransformOrigin$ 0.5,0.5&�6�   z�5      V� 5      .~�5      �� �� 5      �� 5       �� Angle$ -0.422Q�6&   T� 5      5      5      �� 5   
   -   5        $ modalityTextBlock��5      $
��Left=�6/   $��32��6J   $��211,192,0,0q�6V   $��	TextBlock��6k   $
��Wrap=�6|   $	��Top=�6�   $	��106��6�   $��20(�6�   $��Segoe UI Semilight)�6�   $��2��6�   �� 5   
   -   5        $  correlativeNumberTextBlock��5      $
��Left=�68   $��40��6S   $��583,195,0,0q�6_   $��B��6t   $
��Wrap=�6}   $	��Top=�6�   $	��118��6�   $��20(�6�   $��2��6�   �� 5   
   $
��Left=�6   $��32��6/   $��	81,63,0,0q�6;   $(��"Titulo del criterio de evaluacion:��6N   $
��Wrap=�6x   $	��Top=�6�   $	��296��6�   $��20(�6�   $��Segoe UI Semibold)�6�   �� 5   
   -   5        $&  evaluationCriteriaTitleTextBlock��5      $
��Left=�6>   $��28��6Y   $��
386,64,0,0q�6e   $��A��6y   $
��Wrap=�6�   $	��Top=�6�   $	��152��6�   $��20(�6�   $��Segoe UI Semilight)�6�   $��Normal"�6�   $��Italic$�6�   $ 0.5,0.5&�6  z�5       V� 5!      .~�5"      �� �� 5#      �� 5$      $ 0.731Q�6&   T� 5%      5&      5(      �� 5)   
   -   5         ��Name$ numberupdownTextBox��5)      $
��Left=�6/   $��49��6J   $��144,110,0,0q�6V    �� TextWrapping$
 Wrap=�6k   $	��Top=�6   $��80��6�   ���	#FF0C907D$��1��6�   �� 5*   
   -   5        $ upButton��5*      $	��▲��6#   $
��Left=�6/   $��23��6J   $��233,110,0,0q�6V   $	��Top=�6k   $��43��6�   $��1��6�   �� 5+   
   -   5        $ 
downButton��5+      $	��▼��6%   $
��Left=�61   $��233,139,0,0q�6L   $	��Top=�6a   $��43��6y   $��19��6�   $��1��6�   �� 5,   
   $
��Left=�6   $��32��6/   $��
81,116,0,0q�6;   $��Nota:��6O   $
��Wrap=�6\   $	��Top=�6p   $��80��6�   $��20(�6�   $��Segoe UI Semibold)�6�   $��1��6�   �� 5-   
   -	   5        $ maxNoteTextBlock��5-      $
��Left=�6.   $��32��6I   $��322,116,0,0q�6U   $
��Wrap=�6j   $	��Top=�6~   $��80��6�   $��20(�6�   $��Segoe UI Semibold)�6�   $��1��6�   �� 5.   
   $
��Left=�6   $��32��6/   $��297,118,0,0q�6;   $��/��6P   $
��Wrap=�6Y   $	��Top=�6m   $��20��6�   $��20(�6�   $��Segoe UI Semibold)�6�   $��1��6�   5/      50      