   M S B A M L   `   `   `  ����Q  MProyecto base de datos, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:Proyecto_base_de_datos.PagesProyecto_base_de_datos.Pages  5   	   ;    5Proyecto_base_de_datos.Pages.ReviewerAprobationWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   <local*clr-namespace:Proyecto_base_de_datos.Pages     5   	     � Title$  ReviewerAprobationWindow��5   	   $	��450��6*   $	��800��67   .��5	      � .+�5
   
   �� -   5         ��Name$ ApprobationButton��5
      $��Aprobar��6,   $
��Left=�6>   $��48��6Y   $��464,272,0,0q�6e   $	��Top=�6z   $	��198��6�   ���	#FF0C907D���	#FFF2F4B2$��24(�6�   �� 5   
   -   5        $ disapprovalButton��5      $��Reprobar��6,   $
��Left=�6?   $��48��6Z   $��
81,272,0,0q�6f   $	��Top=�6z   $	��228��6�   ���	#FF0C907D$��24(�6�   ���	#FFF2F4B26�   �� 5   
   $
��Left=�6   $��32��6/   $��
86,132,0,0q�6;   $��Titulo:��6O   $
��Wrap=�6^   $	��Top=�6r   $��80��6�   $��20(�6�   $��Segoe UI Semibold)�6�   �� 5   
   $
��Left=�6   $��32��6/   $��227,132,0,0q�6;   $��
Modalidad:��6P   $
��Wrap=�6b   $	��Top=�6v   $	��120��6�   $��Segoe UI Semibold)�6�   $��20(�6�   �� 5   
   $
��Left=�6   $��42��6/   $��458,132,0,0q�6;   $��Numero correlativo:��6P   $
��Wrap=�6k   $	��Top=�6   $	��198��6�   $��Segoe UI Semibold)�6�   $��20(�6�   �� 5   
   -   5         ��Name$ titleTextBlock��5      $
��Left=�6,   $��28��6G   $��159,130,0,0q�6S   $��A��6h   $
��Wrap=�6q   $	��Top=�6�   $	��152��6�   $��20(�6�   $��Segoe UI Semilight)�6�   $��Normal"�6�   $��Italic$�6�    J� RenderTransformOrigin$ 0.5,0.5&�6�   z�5      V� 5      .~�5      �� �� 5      �� 5       �� Angle$ -0.95Q�6&   T� 5      5      5      �� 5   
   -   5        $ modalityTextBlock��5      $��Center=�6/   $��32��6L   $��	0,132,0,0q�6X   $��	TextBlock��6k   $
��Wrap=�6|   $	��Top=�6�   $	��106��6�   $��20(�6�   $��Segoe UI Semilight)�6�   �� 5   
   -   5        $  correlativeNumberTextBlock��5      $
��Left=�68   $��41��6S   $��656,131,0,0q�6_   $��B��6t   $
��Wrap=�6}   $	��Top=�6�   $	��118��6�   $��20(�6�   �� 5   
   $
��Left=�6   $��32��6/   $��	81,63,0,0q�6;   $(��"Titulo del criterio de evaluacion:��6N   $
��Wrap=�6x   $	��Top=�6�   $	��314��6�   $��20(�6�   $��Segoe UI Semibold)�6�   �� 5   
   -   5        $&  evaluationCriteriaTitleTextBlock��5      $
��Left=�6>   $��28��6Y   $��
386,64,0,0q�6e   $��A��6y   $
��Wrap=�6�   $	��Top=�6�   $	��152��6�   $��20(�6�   $��Segoe UI Semilight)�6�   $��Normal"�6�   $��Italic$�6�   $ 0.5,0.5&�6  z�5      V� 5      .~�5      �� �� 5       �� 5!      $ -0.95Q�6&   T� 5"      5#      5%      5'      5(      