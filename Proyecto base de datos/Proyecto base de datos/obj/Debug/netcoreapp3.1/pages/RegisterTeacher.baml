   M S B A M L   `   `   `  ����Q  MProyecto base de datos, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:Proyecto_base_de_datos.pagesProyecto_base_de_datos.pages  5   	   2    ,Proyecto_base_de_datos.pages.RegisterTeacher   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   <local*clr-namespace:Proyecto_base_de_datos.pages     5   	     � Title$  RegisterTeacher��5   	   $	��450��6!   $	��800��6.   .��5	      �  � RowDefinitions 5
   
   �� 5      $	��55* �6   �� 5      $
��162* �6   .+�5   
   �� -   5         ��Name$ 	idTextBox��5      $
��Left=�6%   $��
162,33,0,0q�6@    �� TextWrapping$
 Wrap=�6T   $	��Top=�6h   $	��150��6�   $��30��6�   �� 5   
   -   5        $ nameTextBox��5      $
��Left=�6'   $��
162,84,0,0q�6B   $
 Wrap=�6V   $	��Top=�6j   $	��150��6�   $��30��6�   $��2��6�   �� 5   
   -   5        $ directionTextBox��5      $
��Left=�6,   $��
162,27,0,0q�6G   $
 Wrap=�6[   $	��Top=�6o   $	��150��6�   $��30��6�   $��1��6�   �� 5   
   -   5        $ phoneNumberTextBox��5      $
��Left=�6.   $��
162,77,0,0q�6I   $
 Wrap=�6]   $	��Top=�6q   $	��150��6�   $��30��6�   $��1��6�   �� 5   
   -   5        $ institutionTextBox��5      $
��Left=�6.   $��162,131,0,0q�6I   $
 Wrap=�6^   $	��Top=�6r   $	��150��6�   $��30��6�   $��1��6�   �� 5   
   -   5         ��Name$ TeacherTypeListComboBox��5      $
��Left=�64   $��162,236,0,0q�6O   $	��Top=�6d   $	��150��6|   $��30��6�   $��1��6�   �� 5   
   -   5         ��Name$ RegisterButton��5      $��Registrarse como Profesor��6)   $
��Left=�6M   $��344,251,0,38q�6h   $	��150��6�   ���	#FFF2F4B2$��Segoe UI Semibold)�6�   ���	#FF0C907D$��1��6�   �� 5   
   -   5        $ passwordTextBox��5      $
��Left=�6+   $��162,181,0,0q�6F   $
 Wrap=�6[   $	��Top=�6o   $	��150��6�   $��30��6�   $��1��6�   �� 5   
   $
��Left=�6   $��	10,33,0,0q�6/   $
��Wrap=�6B   $��Cedula��6V   $	��Top=�6d   $��30��6|   $	��136��6�   $��14(�6�    �� TextAlignment$ Right=�6�   �� 5   
   $
��Left=�6   $��	10,86,0,0q�6/   $
��Wrap=�6B   $	��Top=�6V   $��30��6n   $	��136��6z   $��Nombre��6�   $ Right=�6�   $��2��6�   �� 5   
   $
��Left=�6   $��	10,29,0,0q�6/   $
��Wrap=�6B   $	��Top=�6V   $��30��6n   $	��136��6z   $ Right=�6�   $��1��6�   �� 6�    � Language$ es-ve�6�   $�	Direccion��6�   6�   �� 5   
   $
��Left=�6   $��	10,77,0,0q�6/   $
��Wrap=�6B   $	��Top=�6V   $��30��6n   $	��136��6z   $ Right=�6�   $��1��6�   �� 6�   $ es-ve�6�   $�Telefono��6�   6�   �� 5   
   -	   5         ��Name$ institutionLabel��5      $
��Left=�6.   $��
10,131,0,0q�6I   $
��Wrap=�6]   $	��Top=�6q   $��30��6�   $	��136��6�   $ Right=�6�   $��1��6�   �� 6�   $ es-ve�6�   $�Institución��6�   6�   �� 5   
   $
��Left=�6   $��
10,183,0,0q�6/   $
��Wrap=�6C   $	��Top=�6W   $��30��6o   $	��136��6{   $ Right=�6�   $��1��6�   �� 6�   $ es-ve�6�   $�Contraseña��6�   6�   �� 5   
   $
��Left=�6   $��
10,236,0,0q�6/   $
��Wrap=�6C   $��Tipo de Profesor��6W   $	��Top=�6o   $��30��6�   $	��136��6�   $ Right=�6�   $��1��6�   �� 5   
   $
��Left=�6   $	��443��6/   $��
518,-9,0,0q�6<   
���   �$	��Top=�6_   $	��287��6w   ���	#FF0C907D$��2��6�   �� 5   
   $��Registrar 
Profesor��6   $
��Left=�67   $	��119��6R   $��
571,24,0,0q�6_   $	��Top=�6s   $	��181��6�   $��Segoe UI Black)�6�   $��36(�6�   ���	#FFF2F4B2$
��Bold"�6�   $��2��6�   �� 5   
   $
��Left=�6   $	��207��6+   $��558,168,0,0q�68   $	��Top=�6M   $	��207��6e   $����D:\Diego\Programacion\6to semestre\Proyecto BBDD\ProyectoBBDD\Proyecto base de datos\Proyecto base de datos\Resources\png-clipart-soni-design-printing-cat-furniture-sandwich-wood-eco-friendly-furniture-food.png��6q   $��1��6M  5!      5"      