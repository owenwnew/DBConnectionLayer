   M S B A M L   `   `   `  ����T  PDBConnectionLayerFrontEnd, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullW0clr-namespace:DBConnectionLayerFrontEnd.Resource"DBConnectionLayerFrontEnd.Resource  5      Y1clr-namespace:DBConnectionLayerFrontEnd.ViewModel#DBConnectionLayerFrontEnd.ViewModel  5      O,clr-namespace:DBConnectionLayerFrontEnd.ViewDBConnectionLayerFrontEnd.View  5      Q-clr-namespace:DBConnectionLayerFrontEnd.ModelDBConnectionLayerFrontEnd.Model  5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089   Button_Background  �� EndPoint �� 
StartPoint � Color � Offset �� DataType>    8DBConnectionLayerFrontEnd.ViewModel.CustomerMgtViewModel4   .DBConnectionLayerFrontEnd.View.CustomerMgtView;   5DBConnectionLayerFrontEnd.ViewModel.OrderMgtViewModel1   +DBConnectionLayerFrontEnd.View.OrderMgtViewB   <DBConnectionLayerFrontEnd.ViewModel.InvoiceItemListViewModel8   2DBConnectionLayerFrontEnd.View.InvoiceItemListView  toolBarTemplate  MyFocusVisual � FocusVisualStyle � Cursor �� Path  InvoiceItemListGridTemplate �� Orientation&   System.Windows.Controls.DataGrid	 J� 	AllowDrop
   AlternatingRowBackground �� AlternationCount   RowDetailsVisibilityMode   EnableRowVirtualization   AutoGenerateColumns   CanUserAddRows   CanUserDeleteRows   Columns0  *System.Windows.Controls.DataGridTextColumn,  &System.Windows.Controls.DataGridColumn   Header   Width5	  /System.Windows.Controls.DataGridLengthConverter1
  +System.Windows.Controls.DataGridBoundColumn 
  Binding  ClosableTabItemTemplate  OrdersWorkspacesTemplate � RowDefinitions$ �� IsSynchronizedWithCurrentItem  WorkspacesTemplate �� UpdateSourceTrigger�� 5      D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    :x,http://schemas.microsoft.com/winfx/2006/xaml     5      :local0clr-namespace:DBConnectionLayerFrontEnd.Resource  5      8vm1clr-namespace:DBConnectionLayerFrontEnd.ViewModel  5      3vw,clr-namespace:DBConnectionLayerFrontEnd.View  5      4md-clr-namespace:DBConnectionLayerFrontEnd.Model  5      %�  &	        (��     5      *,  +)(�� ?    5      *, +)(�� q    5      *, +)&	 �    7   &	 �    &	      &	 �    7  &	 �	    7  �� 5      $  0.5,1&�64   $ 0.5,0&�6E   .��5   
   � $ DeepSkyBlue��6   $ 0.963Q�6+   � 5   
   $ 	AliceBlue��6   $ 0.177Q�6)   � 5   
   $ 	AliceBlue��6   $
 0.41Q�6)   � 5   
   $ 	#FF8DE0FF��6   $ 0.771Q�6)   5      �� 5      "   6   .R�5   
     5      �� 5      "  6   .R�5   
     5      �� 5      "  6   .R�5    
     5!      �� 5#      .R�5$   
   c� $��1q�6*   
���������6   �� ��5%      �� 5&      $  0.5,1&�6&   $ 0.5,0&�67   .��5'      � $ 
WhiteSmoke��6#   $ 1Q�66   � 5(      $ White��6#   $ 0.409Q�61   5)      ��5+      �� 5-      .R�5/      �� $��1,0,0,0q�6   $��Center=�51      8��  
���   �
����� �$��30��55      # �  56      $
 Hand��57      ��5/   .   �� $ Command�.��5:      �� $��5,0,5,0q�6$   $��Black"�6Y   ��65   �� $ DisplayName�6Y   5F      5G      5I      5K      �� 5O      .R�5P   
   �� $ Vertical=�6   .+�5Q        	 . 

 �����$ 2��6L   $ VisibleWhenSelected=�6a    .  .  $��Stretch=�6�   $��2,2,2,0q�6   
������� .  . ��6�   ��  5R        5S      $ Invoiced Item��6O   $ SizeToHeader	 6f    6)   �� $ invoicedItem�6f     5T      $ Quantity��6K   $ SizeToHeader	 6]    6)   �� $ quantity�6]     5U      $ 
Unit Price��6L   $ SizeToHeader	 6`    6)   �� $ 	unitPrice�6`     5V      $ Total Price��6M   $
 Auto	 6b    6)   �� $ 
totalPrice�6b     5W      $ Item Catagory��6O   $ SizeToHeader	 6f    6)   �� $ itemCatagory�6f     5X      $ Payment Option��6P   $ SizeToHeader	 6h    6)   �� $ paymentOption�6h   5]      5^      5_      �� 5b      .R�5c   
   ]� $
��Auto��6   .+�5d      �� $��X��5f   	   $
 Hand��5g   	   $��Right=�5h   	   |�.  $��Courier)�5j   	   $��9(�5k   	   $
��Bold"�5l   	   $��5,1,5,0q�5m   	   $��0q�5n   	   $��Bottom=�5o   	   $��16��5p   	   $��16��6   ��5e   	   �� $ CloseCommand�5p      �� 5r      $��Center=�5t   	   ��5s   	   �� $ DisplayName�5t   	   5w      5y      �� 5{      .R�5|   
   �  5}      �� 5~      $��* �6    �� 5      $
��Auto �6    .+�5�      �� $��0��6   $
 TrueY�5�      8��  $��4q�5�      ��5�      �� 5�      5�      5�      �� 5�      .R�5�   
   �  5�      �� 5�      $��* �6    �� 5�      $
��Auto �6    .+�5�      �� $��0��6   $
 TrueY�5�      8��  $��4q�5�      ��5�      �� 5�      �� 5�      $��1��6   .@�5�      �� $��24��6   ��6$   �� $ CurrentStatus�$ PropertyChanged=�5�      5�      5�      5�      