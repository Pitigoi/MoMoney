   M S B A M L   `   `   `  ????B  >MoMoney, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:MoMoneyMoMoney  5   	       MoMoney.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:MoMoney     5   	     ? Title$  
MainWindow??5   	   $	??450??6   $	??800??6)    ? 	Resources 5	         categoryViewSource  categoryProductsViewSource ?? Source ?? Source??%]   &	        &	      7   ?? 5
   
   6   ?? 5   
    5      ?? *
Products+8   5      .??5      ?  ? RowDefinitions 5   
   ?? 5      $	??24* ?6   ?? 5      $??* ?6   ?? 5      $	??24* ?6   .+?5   
   ? $??10,10,10,10q?6   
???  ??$??3??65    ? ColumnDefinitions 5      ?? 5      $??* ?6#   ?? 5      $??* ?6#   .+?5      &   System.Windows.Controls.DataGrid  -   5          Name$ 	Lefttable??5      $??0??6*   $??0,0,5,0q?6:      AutoGenerateColumns .     Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn	   Header$	 Category??6)   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 5      ?? *name+  5      $
	 Date??6)   
 5      ?? *time+  5      $	 Amount??6)   
 5       ?? *amount+  5!      $	 Comment??6)   
 5"      ?? *note+5$        5%      -   5        $ 
Righttable??5%      $??1??6+   $??5,0,0,0q?6;    .   5&        5'      $
	 Date??6)   
 5(      ?? *time+  5)      $	 Amount??6)   
 5*      ?? *amount+  5+      $	 Comment??6)   
 5,      ?? *note+5.      5/      ? 50   
   ?? 51   
   -   5        $??Button??51      $
??Left=?6"   $??122,106,0,0q?6=   $	??Top=?6R   6j   52      53      