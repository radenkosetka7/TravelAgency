   M S B A M L   `   `   `  ????M  ITravelAgencyWpfHci, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:TravelAgencyWpfHci.viewTravelAgencyWpfHci.view  5   	   .    (TravelAgencyWpfHci.view.KupacRezervacija   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   7local%clr-namespace:TravelAgencyWpfHci.view     5   	   _ [MaterialDesignThemes.Wpf, Version=4.4.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  6=      customerreservation  ? Title#  ?   5   	   $	??450??67   $	??800??6D    ? WindowStartupLocation$ CenterScreen=?6P    ? 
ResizeMode$ NoResize=?6u   .??5	      ? .+?5
   
   ? $??3??6   $??2??6#   ??5      ?? 5       ?? 
StartPoint$ 0.1,0&?6&    ?? EndPoint$ 0.9,1&?69   .??5      ?   
startColor ? Color# ?  6#    ? Offset$ 1Q?6H   ? 5        endColor# ?  6#   $ 0Q?6F   5      .+?5      ?? -   5         ??Name$ border??5      $	??390??6%   $	??Top=?62    ?? CornerRadius$ 0 180 180 0??6J     
background#???  6e   5      5      ?? 5   
   $??2??6   $??	20,0,0,45q?6'   .??5      ?? 	 ?? Orientation$	 Vertical=?6   $??12 12 12 12q?60   .+?5      ?? -   5        
 ??Name$
 heading??5      $??25(?6-   $
??Bold"?6;     	fontColor#???  6M     reservation#???  6v   $??Center=?6?   ?? 5      -   5        $
 txtKorisnickoIme??5   *   $??18(?6   $
??Bold"?6D     arrangementname#???  6V   $??	0 50 0 10q?6   #???  6?   6?   ?? 5      -   5         ??Name$ NazivBox??5      $??120 -35 60 20q?6,   $??28??6C   $	??255??6O   $??15(?6[   #???  6i   #???  6?   ?? 5      -   5        $
 txtKorisnickoPrezime??5   *   $??18(?6   $
??Bold"?6H     jmbg#???  6Z   $??0 0 0 10q?6x   #???  6?   ?? 5      -   5        $ JMBGBox??5      $??120 -35 60 20q?6+   $??15(?6B   #???  6P   #???  6z   $??28??6?   $	??255??6?   ?? 5      -   5        $
 txtBlockDatumRodjenja??5   *   $??18(?6   $
??Bold"?6I     reservationdate#???  6[   $??0 0 0 10q?6?   #???  6?   (  "System.Windows.Controls.DatePicker  5      -   5          Name$ DatumBox??5      $??120 -35 60 20q?6/   $??15(?6F   #???  6T   #???  6~   $??25??6?   $	??255??6?   ?? 5      -	   5        $
 txtKorisnickiMail??5   *   $??18(?6   $
??Bold"?6E    	 quantity#??? 	 6W   $??0 0 0 10q?6y   #???  6?   6?   ?? 5      -
   5        $ KolicinaBox??5      $??120 -35 60 20q?6/   $??15(?6F   #???  6T   #???  6~   $??28??6?   $	??255??6?   ?? 5      -   5         ??Name$ 
SaveButton??5   }    
 makereservation ? ToolTip# ? 
 6   $??Center=?6E   $??Center=?6b   $??40??6?   $??50??6?   .??5       ? $	??150??6   .+?5!      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ ContentSave=?62   $??16??6E   ?? 5"      -   5        $

 Save??5"   $   $??Center=?62    
 logout#???  6O   5#      5$      5%      5&      5'      5(      