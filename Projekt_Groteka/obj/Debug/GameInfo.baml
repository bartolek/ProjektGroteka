   M S B A M L   `   `   `  ����J  FProjekt_Groteka, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Projekt_GrotekaProjekt_Groteka  5   	       Projekt_Groteka.GameInfo   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   /localclr-namespace:Projekt_Groteka     5   	     � Title$  GameInfo��5   	   $	��650��6   $	��800��6'    � 
ResizeMode$ NoResize=�63   .��5	      � .+�5
   
   ]� .+�5      o� $	��Top=�6   .@�5      m� $��_Menu��6   .@�5      m� -   5        $��_Edytuj��5      61   �� 5      m� 5      -   5        $��_Wyjdź��5      6/   5      5      5      �� 5   
   -   5        $��
LeftScreen��5      $��5,20,5,0q�6"   $	��260��64   $	��200��6C   $	��Top=�6S   $
��Left=�6k   6�   �� 5   
   -   5        $��CenterScreen��5      $��5,20,5,0q�6'   $	��260��6:   $	��200��6I   $	��Top=�6Y   $��Center=�6q   6�   �� 5   
   -   5        $��RightScreen��5      $��5,20,5,0q�6&   $	��260��69   $	��200��6H   $	��Top=�6X   $��Right=�6p   6�   �� 5   
   -   5        $��GameDesc��5   &   $��0,30,0,0q�6   $��WrapWithOverflow=�67   $��Center=�6W   $��Center=�6r   $	��600��6�   
[TEMPLATE]5      �� 5   
   $��	10,0,0,30q�6   $��Bottom=�6'   $
��Left=�6B   Najbliższy turnej6p   �� 5   
   -   5        $��TournamentDate��5   ]   $��	10,0,0,10q�6   $��Bottom=�6'   $
��Left=�6B   
2015-07-136�   �� 5   
   -   5        $��Comments��5   +   $��0,0,0,10q�6;   $	��500��6M   $	��100��6Y   $��Bottom=�6f   ��6   ��  �� View 5      �� 5      .P�5      ��  �� Width$	 450��6!   $��	Komentarz��6-    �� DisplayMemberBinding 6@   ��  �� Path$ 	komentarz�6r   �� 5      $ 40��6!   $��Ocena��6,    6;   �� $ ocena�6i   5       5"      �� 5#   
   -	   5        $��
10,0,20,10q�5#   %   $��20��69   $	��100��6E   $��Bottom=�6Q   $��right=�6l   .��6�   Dodaj Komentarz6�   5$      5%      