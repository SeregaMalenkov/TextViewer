   M S B A M L   `   `   `  ����E  ATextViewer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:TextViewer.ModelsTextViewer.Models  5      9!clr-namespace:TextViewer.ControlsTextViewer.Controls  5      "    TextViewer.Controls.Launcher   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      2modelsclr-namespace:TextViewer.Models     5      3local!clr-namespace:TextViewer.Controls     5        � 	Resources  5       �� DataType,   &TextViewer.Models.ViewerIndicatorModel)   #TextViewer.Controls.ViewerIndicator��%d   (��       5      *, +)�� 6
   "  6   .R�5	        $��10q�6$   $	��Top=�60   5
      5      .��5      �  � RowDefinitions 5   
   �� 5      �� 5      $
��Auto �6   .+�5   
   �� -   5         ��Name$ PART_MainPanel��5      ��5      �� 5      .R�5      �  � Orientation$ 
Horizontal=�6    5      5      �� 5   
   -   5        $��1��5      $	��100��6   $��25��6*   $��Select file��66   $��Bottom=�6L   $��Right=�6g      BaseButtonTemplate#��[  5      ��5      �� 5       �� 
TargetType" ��6    �� Triggers 5      P� 5        P� Property �@J�IsMouseOver P� Value . . �5!      �� 	 �� Property	 � ��
 �� Value

 �����6;   5"      5$      5&      5'      5(      