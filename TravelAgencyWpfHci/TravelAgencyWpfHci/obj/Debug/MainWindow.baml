   M S B A M L   `   `   `  ????  TravelAgencyWpfHci#    TravelAgencyWpfHci.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   _ [MaterialDesignThemes.Wpf, Version=4.4.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	    
  agency  ? Title#  ?   5   	   $	??450??6*   $	??800??67    ? WindowStartupLocation$ CenterScreen=?6C    ? 
ResizeMode$ NoResize=?6h   .??5	      ? ??5
   
   ?? 5       ?? 
StartPoint$ 0.1,0&?6"    ?? EndPoint$ 0.9,1&?65   .??5      ?   
startColor ? Color# ?  6    ? Offset$ 1Q?6E   ? 5        endColor# ?  6   $ 0Q?6C   5      .+?5   
   ?? -   5        $	??390??5      $	??Top=?6    ?? CornerRadius$ 0 180 180 0??66     
background#???  6Q   $??0,0,5,0q?6?   ?? 5   
    ?? Orientation$ 
Horizontal=?6   .+?5      ?? $	??350??6   .+?5      ?? $??assets/slika2.jpg??6   $??0,60,0,0q?63   $	??300??6E   $	??285??6Q   $
??Fill=?6^   	 ?? StretchDirection$
	 Both=?6m   5      ?? 5      $	??350??6   .+?5      ?? $??20 40q?6   .+?5      ? .+?5      ?? -   5        
 ??Name$
 English??5   E     english ? ToolTip# ?  6!   $??180 -20 0 0q?6V   $??15??6l   $??15??6w   ??5      ?? 5   "    ?? 
TargetType" ??62   .R?5   &   ? .+?5   *   ?? $??assets/us.png??60   ?? 5   *   $??Center=?6;   $??Center=?6X   5   '   5   #   5!      5"      ? 5#      .+?5$      ?? -   5        $
 Serbia??5$   E     serbian# ?  6!   $??220 -20 0 0q?6U   $??15??6k   $??15??6v   ??5%      ?? 5&   "   " ??62   .R?5'   &   ? .+?5(   *   ?? $??assets/rs.png??60   ?? 5)   *   $??Center=?6;   $??Center=?6X   5*   '   5+   #   5-      5.      ? 5/      .+?50      ?? -   5        $
 
DarkButton??50   B     dark# ?  6!   $??0 -20 250 0q?6V   $??15??6l   $??15??6w   ??51      ?? 52   "   " ??62   .R?53   &   ? .+?54   *   A? ???#00000062   ?? 55   *   $??Center=?6;   $??Center=?6X   56   '   57   #   59      5:      ? 5;      .+?5<      ?? -   5        $

 Blue??5<   B     blue# ?  6!   $??0 -20 190 0q?6P   $??15??6f   $??15??6q   ??5=      ?? 5>   "   " ??62   .R?5?   &   ? .+?5@   *   A? ???#01039b62   ?? 5A   *   $??Center=?6;   $??Center=?6X   5B   '   5C   #   5E      5F      ? 5G      .+?5H      ?? -   5        $
 White??5H   C    	 light# ?  6!   $??0 -20 130 0q?6R   $??15??6h   $??15??6s   ??5I      ?? 5J   "   " ??62   .R?5K   &   ? .+?5L   *   A? ???#dedede62   ?? 5M   *   $??Center=?6;   $??Center=?6X   5N   '   5O   #   5Q      5R      ?? 5S       		 login#??? 	 6    $??20q?6?    
 	fontColor#??? 
 6K    ?? TextAlignment$ Center=?6t   $??38(?6?   $??Great Vibes)?6?   ?? 5T      $ 
Horizontal=?6!   $??10q?6:   .+?5U      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$
 User=?62   $??25??6>   $??25??6I    	 back1#???  6U   ?? 5V      -   5         ??Name$ txtUsername??5V   "   $
??10 0q?67     username)  #MaterialDesignThemes.Wpf.HintAssist   Hint# ?  6E   #??? 
 6?   $	??250??6?   #??? 
 6?    ?? 
CaretBrush ?	#FFD94448 ?? SelectionBrush ?	#FFD944486?   5W      ?? 5X      $ 
Horizontal=?6!   $??10q?6:   .+?5Y        $
 Lock=?62   $??25??6>   $??25??6I   #???  6U   G? 5Z      -   5         G?Name$ txtPassword??5Z   &   $
??10 0q?6;   $ ********??6I   #??? 
 6s   $	??250??6?   #??? 
 6?    G? 
CaretBrush ?	#FFD94448 G? SelectionBrush ?	#FFD944486?   5[      ?? 5\      $??10q?6!   $??Center=?6-   .+?5]      ?? -	   5        $
 btnLogin??5_   ?   $	??100??5]   !   $??40??6-     MaterialDesignRaisedButton#??[ 69   +  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 10??5^      $??2q?6H    
 border#???  6\     buttonBackground#???  5_      #??? 
 6J   # ? 	 6s   #??? 	 6?   5`      5a      5b      5c      5d      5e      