   M S B A M L   `   `   `  ����E  Atestik1212, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:testik1212
testik1212  5   	       testik1212.WorkSpace   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:testik1212     5   	     � Title$E  ?Администрирование: Рабочий доступ��5   	   $	��550��63   $	��950��6@   .��5	      � 
������� � ColumnDefinitions 5
   
   �� 5      $	��166 �6   �� 5      $��* �6   .+�5   
   � -   5         �Name$ Control_Panel��5      $��5,5,5,5q�6&   
�������.+�5      � .+�5      �� 
�������$
��Left=�66   $	��160��6Q   $	��260��6]   .+�5      �� -   5        $��Bahnschrift Light)�5      $��20(�6<   $��Регистрация��6J   $��
10,20,10,0q�6`   $��40��6t   $��Stretch=�6�   $��Bottom=�6�   ���	#FFBDB8FF
���   ����	#FFC1C1C1 � Cursor$ ScrollSE��6�   6  �� 5      -   5        $��Bahnschrift Light)�5      $��18(�6<   $"��Госпитализация��6J   $��
10,20,10,0q�6c   $��40��6w   $��Stretch=�6�   $��Bottom=�6�   ���	#FFFFEBF8���	#FFC1C1C1$ ScrollSE��6�   6�   �� 5      -   5        $��Bahnschrift Light)�5      $��21(�6<   $��Работа с QR��6J   $��
10,20,10,0q�6`   $��40��6t   $��Stretch=�6�   $��Bottom=�6�   ���	#FFFDB0E2���	#FFC1C1C1$ ScrollSE��6�   6�   5      5      5      � 5   
   -   5        $ 
Work_Space��5      $��1��6#   
�������$��
0,10,10,10q�6F   .+�5      �� -   5         ��Name$ 
RegPatient��5      ��. $��	0,10,0,82q�6G   .��5      � .+�5      �� $��Имя:��6    $	��194��6,   $��30��68   $
��Left=�6D   $��	50,20,0,0q�6_   $��Bahnschrift Light)�6r   $��25(�6�   $	��Top=�6�   �� 5      -   5         ��Name$
 name��5      $	��400��6,   $��30��68    �� TextWrapping$
 Wrap=�6D   $
��Left=�6X   $	��Top=�6s   $��
290,20,0,0q�6�   $��Bahnschrift Light)�6�   $��25(�6�   �� 5      $��Фамилия:��6    $	��194��60   $��30��6<   $
��Left=�6H   $	��Top=�6c   $��	50,60,0,0q�6{   $��Bahnschrift Light)�6�   $��25(�6�   �� 5       -   5        $ subname��5       $	��400��6/   $��30��6;   $
 Wrap=�6G   $
��Left=�6[   $	��Top=�6v   $��
290,60,0,0q�6�   $��Bahnschrift Light)�6�   $��25(�6�   �� 5"      $��Отчество:��6    $	��194��61   $��30��6=   $
��Left=�6I   $	��Top=�6d   $��
50,100,0,0q�6|   $��Bahnschrift Light)�6�   $��25(�6�   �� 5#      -	   5        $ 	thirdname��5#      $	��400��61   $��30��6=   $
 Wrap=�6I   $
��Left=�6]   $	��Top=�6x   $��290,100,0,0q�6�   $��Bahnschrift Light)�6�   $��25(�6�   �� 5%      $��Пол:��6    $	��194��6,   $��30��68   $
��Left=�6D   $	��Top=�6_   $��
50,140,0,0q�6w   $��Bahnschrift Light)�6�   $��25(�6�   �� 5&      -
   5         ��Name$ gender��5&      $	��400��6/   $��30��6;   $
��Left=�6G   $	��Top=�6b   $��290,140,0,0q�6z   $��Bahnschrift Light)�6�   $��25(�6�   �� 5(      $��Адрес:��6    $	��194��6.   $��30��6:   $
��Left=�6F   $	��Top=�6a   $��
50,180,0,0q�6y   $��Bahnschrift Light)�6�   $��25(�6�   �� 5)      -   5        $ address��5)      $	��400��6/   $��30��6;   $
 Wrap=�6G   $
��Left=�6[   $	��Top=�6v   $��290,180,0,0q�6�   $��Bahnschrift Light)�6�   $��25(�6�   �� 5+      $"��Номер телефона:��6    $	��194��67   $��30��6C   $
��Left=�6O   $	��Top=�6j   $��
50,220,0,0q�6�   $��Bahnschrift Light)�6�   $��25(�6�   �� 5,      -   5        $ phone��5,      $	��400��6-   $��30��69   $
 Wrap=�6E   $
��Left=�6Y   $	��Top=�6t   $��290,220,0,0q�6�   $��Bahnschrift Light)�6�   $��25(�6�   �� 5.      $��e-mail:��6    $	��194��6/   $��30��6;   $
��Left=�6G   $	��Top=�6b   $��
50,260,0,0q�6z   $��Bahnschrift Light)�6�   $��25(�6�   �� 5/      -   5        $ email��5/      $	��400��6-   $��30��69   $
 Wrap=�6E   $
��Left=�6Y   $	��Top=�6t   $��290,260,0,0q�6�   $��Bahnschrift Light)�6�   $��25(�6�   �� 51      $��№ мед. карты:��6    $	��194��65   $��30��6A   $
��Left=�6M   $	��Top=�6h   $��
50,300,0,0q�6�   $��Bahnschrift Light)�6�   $��25(�6�   �� 52      -   5        $ med_card��52      $	��400��60   $��30��6<   $
 Wrap=�6H   $
��Left=�6\   $	��Top=�6w   $��290,300,0,0q�6�   $��Bahnschrift Light)�6�   $��25(�6�   �� 54      $3��-Дата создания мед. карты:��6    $	��325��6A   $��30��6M   $
��Left=�6Y   $	��Top=�6t   $��
50,340,0,0q�6�   $��Bahnschrift Light)�6�   $��25(�6�   �� 55      -   5        $ create_data_med_card��55      $	��312��6<   $��30��6H   $
 Wrap=�6T   $
��Left=�6h   $	��Top=�6�   $��378,340,0,0q�6�   $��Bahnschrift Light)�6�   $��25(�6�   �� 57      $,��&Дата посл. обращения:��6    $	��325��6=   $��30��6I   $
��Left=�6U   $	��Top=�6p   $��
50,380,0,0q�6�   $��Bahnschrift Light)�6�   $��25(�6�   �� 58      -   5        $ last_request_data��58      $	��361��69   $��30��6E   $
 Wrap=�6Q   $
��Left=�6e   $	��Top=�6�   $��329,380,0,0q�6�   $��Bahnschrift Light)�6�   $��25(�6�   �� 5:      $,��&Дата след. обращения:��6    $	��325��6=   $��30��6I   $
��Left=�6U   $	��Top=�6p   $��
50,420,0,0q�6�   $��Bahnschrift Light)�6�   $��25(�6�   �� 5;      -   5        $ next_request_data��5;      $	��361��69   $��30��6E   $
 Wrap=�6Q   $
��Left=�6e   $	��Top=�6�   $��329,420,0,0q�6�   $��Bahnschrift Light)�6�   $��25(�6�   �� 5=      -   5         ��Name$ Registration_Patient��5=      $7��1Зарегистрировать пациента��6T   $	��400��6x   $��55��6�   $��Bottom=�6�   $
��Left=�6�   $��
290,0,0,20q�6�   $��Center=�6�   $��Center=�6�   $��Bahnschrift Light)�6   $��25(�6?  ���	#FFE2F3DA	 J� Effect	 5>      3  -System.Windows.Media.Effects.DropShadowEffect  5?      5A      5B      5C      � 5D      -   5        $ Gospitalization��5D      .+�5E      �� -   5        $��Bahnschrift Light)�5E      $��18(�68   $!��Поиск пациента��6F   $��
550,25,0,0q�6_   $��40��6s   $��Center=�6   $	��Top=�6�   ���	#FFE8FFE0���	#FFC1C1C16�   �� 5F      -   5        $ searcher_patient��5F      $	��374��64   $��30��6@   $
 Wrap=�6L   $��Center=�6`   $	��Top=�6}   $��0,30,0,0q�6�   $��Bahnschrift Light)�6�   $��25(�6�   6�   &   System.Windows.Controls.DataGrid  5H      -   5        $��result_searcher��5H      
   AutoGenerateColumns
 . $��5,90,5,5q�6M   $��Futura Bk BT)�6_   $��16(�6y      Columns 5I      5K      5L      � 5M      -   5        $ QR_zone��5M      .+�5N      � 
�������.+�5O      �� -   5         ��Name$ 	QR_result��5O      $	��200��6/   $��30��6;   $��287,23,287,461q�6G   $��Center=�6_   $��Center=�6�   �� 5P      -   5         ��Name$ QR_image��5P      $	��200��6.   $	��200��6:   $��287,72,287,242q�6G   �� 5Q      -   5        $ 	QR_encode��5Q      $	��200��61   $��30��6=   $��287,290,287,194q�6I   $
 Wrap=�6b   $��Center=�6v   $��Center=�6�   �� 5R      -   5        $ QR_start_encode��5R      $��Закодировать��66   $	��200��6M   $��30��6Y   $��287,338,287,146q�6e   6~   �� 5S      -   5        $ QR_start_save��5S      $��Сохранить��64   $	��200��6H   $��30��6T   $��287,385,287,99q�6`   6x   �� 5T      -   5        $ QR_start_decode��5T      $��Распознать��66   $	��200��6K   $��30��6W   $��287,433,287,51q�6c   6{   5V      5W      5X      5Y      5Z      