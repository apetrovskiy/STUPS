##Get-UIAWindow -Title 'Windows PowerShell';
##		#ScrollPattern
##		#WindowPattern
##		#TransformPattern
#
##Get-UIATitleBar -AutomationId 'TitleBar' -Title 'Maskinvara och ljud';
##		# no supported pattterns
#
#Get-UIAWindow -Title 'Maskinvara och ljud' | `
#	Get-UIAProgressBar | `
#	Get-UIAToolBar -AutomationId '1001' -Title 'Adress: Kontrollpanelen\Maskinvara och ljud';
#		# no supported pattterns
#
##Get-UIAWindow -Title 'Maskinvara och ljud' | `
##	Get-UIAPane -AutomationId 'CategoryPanel' -Title 'CPCategoryPanel' | `
##	Get-UIAHyperlink -AutomationId 'name' -Title 'Spela upp automatiskt';
##		#InvokePattern
##		#ValuePattern
#
#Get-UIAWindow -Title 'Maskinvara och ljud' | `
#	Get-UIAPane -AutomationId 'CategoryPanel' -Title 'CPCategoryPanel' | `
#	Get-UIAHyperlink -AutomationId 'tasklink' -Title 'Ändra standardinställningarna för medier eller enheter';
#		#InvokePattern
#		#ValuePattern
#
#Get-UIAWindow -Title 'Maskinvara och ljud' | `
#	Get-UIAPane;
#		# no supported pattterns

Get-UIAWindow -Title 'Maskinvara och ljud' | `
	Get-UIAPane -AutomationId 'CategoryPanel' -Title 'CPCategoryPanel' | `
	Get-UIAHyperlink -AutomationId 'tasklink' -Title 'Lägg till en skrivare';
		#InvokePattern
		#ValuePattern

Get-UIATitleBar -AutomationId 'TitleBar' -Title 'Lägg till skrivare' | `
	Invoke-UIAHyperlinkClick;
		# no supported pattterns

Get-UIAWindow -Title 'Lägg till skrivare' | `
	Get-UIAText -AutomationId 'wizardtitle' -Title 'Lägg till skrivare';
		#ValuePattern

Get-UIAWindow -Title 'Lägg till skrivare';
		#WindowPattern
		#TransformPattern

Get-UIAWindow -Title 'Lägg till skrivare' | `
	Get-UIAText -AutomationId 'headertitle' -Title 'Vilken typ av skrivare vill du installera?';
		#ValuePattern

Get-UIAWindow -Title 'Lägg till skrivare' | `
	Get-UIAPane -AutomationId 'dialogroot' -Title 'Vilken typ av skrivare vill du installera?' | `
	Get-UIAPane -AutomationId '3510' -Title 'Lägg till en lokal skrivare';
		# no supported pattterns

Get-UIAWindow -Title 'Lägg till skrivare' | `
	Get-UIAPane -AutomationId 'dialogroot' -Title 'Vilken typ av skrivare vill du installera?' | `
	Get-UIAPane -AutomationId '3511' -Title 'Lägg till en nätverksskrivare, trådlös skrivare eller Bluetooth-skrivare';
		# no supported pattterns

Get-UIAWindow -Title 'Lägg till skrivare' | `
	Get-UIAPane -AutomationId 'dialogroot' -Title 'Vilken typ av skrivare vill du installera?' | `
	Get-UIAPane -AutomationId '3510' -Title 'Lägg till en lokal skrivare';
		# no supported pattterns

Get-UIAWindow -Title 'Lägg till skrivare' | `
	Get-UIAPane -AutomationId 'dialogroot' -Title 'Välj en skrivarport' | `
	Get-UIARadioButton -AutomationId '4559' -Title 'Använd en befintlig port:';
		#SelectionItemPattern

Get-UIAWindow -Title 'Lägg till skrivare' | `
	Get-UIAPane -AutomationId 'dialogroot' -Title 'Välj en skrivarport' | `
	Get-UIAText -AutomationId '4677' -Title 'En skrivarport är en typ av anslutning som gör att information kan skickas mellan datorn och skrivaren.';
		# no supported pattterns

Get-UIAWindow -Title 'Lägg till skrivare' | `
	Get-UIAText -AutomationId 'headertitle' -Title 'Välj en skrivarport';
		#ValuePattern

Get-UIAWindow -Title 'Lägg till skrivare' | `
	Get-UIAText -AutomationId 'wizardtitle' -Title 'Lägg till skrivare';
		#ValuePattern

Get-UIAWindow -Title 'Lägg till skrivare';
		#WindowPattern
		#TransformPattern

Get-UIAWindow -Title 'Lägg till skrivare' | `
	Get-UIAPane -AutomationId 'dialogroot' -Title 'Välj en skrivarport' | `
	Get-UIARadioButton -AutomationId '4559' -Title 'Använd en befintlig port:';
		#SelectionItemPattern

Get-UIAWindow -Title 'Lägg till skrivare' | `
	Get-UIAPane -AutomationId 'dialogroot' -Title 'Välj en skrivarport' | `
	Get-UIARadioButton -AutomationId '4558' -Title 'Skapa en ny port:';
		#SelectionItemPattern

Get-UIAWindow -Title 'Lägg till skrivare' | `
	Get-UIAPane -AutomationId '{74B47F6B-BD7A-44C7-9176-1435E9151F94}' -Title 'Välj en port';
		# no supported pattterns

Get-UIAWindow -Title 'Lägg till skrivare' | `
	Get-UIAPane -AutomationId 'dialogroot' -Title 'Välj en skrivarport' | `
	Get-UIAComboBox -AutomationId '3100' -Title 'En skrivarport är en typ av anslutning som gör att information kan skickas mellan datorn och skrivaren.';
		#SelectionPattern
		#ExpandCollapsePattern

Get-UIAWindow -Title 'Lägg till skrivare' | `
	Get-UIAPane -AutomationId '{74B47F6B-BD7A-44C7-9176-1435E9151F94}' -Title 'Välj en port';
		# no supported pattterns

Get-UIAWindow -Title 'Lägg till skrivare';
		#WindowPattern
		#TransformPattern

Get-UIAWindow -Title 'Lägg till skrivare' | `
	Get-UIAButton -AutomationId 'nextbutton' -Title 'Nästa';
		#InvokePattern

Get-UIAWindow -Title 'Lägg till skrivare' | `
	Get-UIAText -AutomationId 'wizardtitle' -Title 'Lägg till skrivare';
		#ValuePattern

Get-UIAWindow -Title 'Lägg till skrivare';
		#WindowPattern
		#TransformPattern

Get-UIAWindow -Title 'Lägg till skrivare' | `
	Get-UIAText -AutomationId 'headertitle' -Title 'Installera skrivardrivrutinen';
		#ValuePattern

Get-UIAWindow -Title 'Lägg till skrivare' | `
	Get-UIAPane -AutomationId 'dialogroot' -Title 'Installera skrivardrivrutinen' | `
	Get-UIAText -AutomationId '1570' -Title 'Välj din skrivare i listan. Klicka på Windows Update om du vill visa fler modeller.

Om du vill installera drivrutinen från en installations-CD klickar du på Disk finns.';
		# no supported pattterns

Get-UIAWindow -Title 'Lägg till skrivare' | `
	Get-UIAPane -AutomationId '{37B25614-112F-430A-87BC-88082E14E4B0}';
		# no supported pattterns

Get-UIAWindow -Title 'Lägg till skrivare' | `
	Get-UIADataGrid -AutomationId '1580' | `
	Get-UIAHeaderItem -AutomationId 'HeaderItem 0' -Title 'Tillverkare';
		#InvokePattern

Get-UIAWindow -Title 'Lägg till skrivare' | `
	Get-UIADataGrid -AutomationId '1580' | `
	Get-UIAText -Title 'Canon';
		#GridItemPattern
		#TableItemPattern

Get-UIAWindow -Title 'Lägg till skrivare' | `
	Get-UIADataGrid -AutomationId '1580' | `
	Get-UIAText -Title 'Epson';
		#GridItemPattern
		#TableItemPattern

Get-UIAWindow -Title 'Lägg till skrivare' | `
	Get-UIADataGrid -AutomationId '1581' | `
	Get-UIAText -Title 'Epson AL-C1900';
		#GridItemPattern
		#TableItemPattern

Get-UIAWindow -Title 'Lägg till skrivare' | `
	Get-UIADataGrid -AutomationId '1581' | `
	Get-UIAText -Title 'Epson AL-C1100';
		#GridItemPattern
		#TableItemPattern

Get-UIAWindow -Title 'Lägg till skrivare' | `
	Get-UIADataGrid -AutomationId '1581' | `
	Get-UIAText -Title 'Epson AL-C2600';
		#GridItemPattern
		#TableItemPattern

Get-UIAWindow -Title 'Lägg till skrivare' | `
	Get-UIAPane -AutomationId 'dialogroot' -Title 'Installera skrivardrivrutinen' | `
	Get-UIAButton -AutomationId '1566' -Title 'Windows Update';
		#InvokePattern

Get-UIAWindow -Title 'Lägg till skrivare';
		#WindowPattern
		#TransformPattern

Get-UIAWindow -Title 'Lägg till skrivare' | `
	Get-UIAButton -AutomationId 'nextbutton' -Title 'Nästa';
		#InvokePattern

Get-UIAWindow -Title 'Lägg till skrivare' | `
	Get-UIAPane -AutomationId '{93FA9C27-9FEF-4136-B50F-F5445B06D07A}' -Title 'Skrivarnamn';
		# no supported pattterns

Get-UIAWindow -Title 'Lägg till skrivare';
		#WindowPattern
		#TransformPattern

Get-UIAWindow -Title 'Lägg till skrivare' | `
	Get-UIAText -AutomationId 'headertitle' -Title 'Skriv ett skrivarnamn';
		#ValuePattern

Get-UIAWindow -Title 'Lägg till skrivare' | `
	Get-UIAText -AutomationId '3002' -Title 'Skrivarnamn:' | `
	Invoke-UIAButtonClick;
		# no supported pattterns

Get-UIAWindow -Title 'Lägg till skrivare' | `
	Get-UIAPane -AutomationId '{93FA9C27-9FEF-4136-B50F-F5445B06D07A}' -Title 'Skrivarnamn';
		# no supported pattterns

Get-UIAWindow -Title 'Lägg till skrivare' | `
	Get-UIAPane -AutomationId 'dialogroot' -Title 'Skriv ett skrivarnamn' | `
	Get-UIAEdit -AutomationId '1046' -Title 'Skrivarnamn:';
		#ValuePattern
		#TextPattern

Get-UIAWindow -Title 'Lägg till skrivare' | `
	Get-UIAPane -AutomationId 'dialogroot' -Title 'Skriv ett skrivarnamn' | `
	Get-UIAText -AutomationId '9015' -Title 'Den här skrivaren kommer att installeras med drivrutinen Epson AL-C1100.';
		# no supported pattterns

Get-UIAWindow -Title 'Lägg till skrivare' | `
	Get-UIAPane -AutomationId '{93FA9C27-9FEF-4136-B50F-F5445B06D07A}' -Title 'Skrivarnamn';
		# no supported pattterns

Get-UIAWindow -Title 'Lägg till skrivare';
		#WindowPattern
		#TransformPattern

Get-UIAWindow -Title 'Lägg till skrivare' | `
	Get-UIAButton -AutomationId 'nextbutton' -Title 'Nästa';
		#InvokePattern

Get-UIAWindow -Title 'Lägg till skrivare' | `
	Get-UIAText -AutomationId 'headertitle' -Title 'Skrivardelning';
		#ValuePattern

Get-UIAWindow -Title 'Lägg till skrivare' | `
	Get-UIAText -AutomationId 'wizardtitle' -Title 'Lägg till skrivare';
		#ValuePattern

Get-UIAWindow -Title 'Lägg till skrivare';
		#WindowPattern
		#TransformPattern

Get-UIAWindow -Title 'Lägg till skrivare' | `
	Get-UIAPane -AutomationId 'dialogroot' -Title 'Skrivardelning' | `
	Get-UIARadioButton -AutomationId '3228' -Title 'Dela den här skrivaren så att andra användare i nätverket kan hitta och använda den';
		#SelectionItemPattern

Get-UIAWindow -Title 'Lägg till skrivare' | `
	Get-UIAPane -AutomationId '{3D5DF2FC-68A1-4FCF-ACB0-ACD844BFF499}' -Title 'Skrivardelning';
		# no supported pattterns

Get-UIAButton -AutomationId 'nextbutton' -Title 'Nästa';
		#InvokePattern

Get-UIAWindow -Title 'Lägg till skrivare' | `
	Get-UIAButton -AutomationId 'finishbutton' -Title 'Slutför';
		#InvokePattern

Get-UIAWindow -Title 'Lägg till skrivare' | `
	Get-UIAPane -AutomationId '{953DEBE2-AD80-488B-8C60-3A56CADA37FD}' -Title 'Installationen slutförd';
		# no supported pattterns

Get-UIAWindow -Title 'Lägg till skrivare';
		#WindowPattern
		#TransformPattern

Get-UIAWindow -Title 'Lägg till skrivare' | `
	Get-UIAText -AutomationId 'headertitle' -Title 'Epson AL-C1100 har lagts till' | `
	Invoke-UIAButtonClick;
		#ValuePattern

Get-UIAWindow -Title 'Lägg till skrivare';
		#WindowPattern
		#TransformPattern

Get-UIAWindow -Title 'Maskinvara och ljud' | `
	Get-UIAPane;
		# no supported pattterns

Get-UIATitleBar -AutomationId 'TitleBar' -Title 'Maskinvara och ljud';
		# no supported pattterns

Get-UIAWindow -Title 'Windows PowerShell';
		#ScrollPattern
		#WindowPattern
		#TransformPattern

Get-UIATitleBar -AutomationId 'TitleBar' -Title 'Maskinvara och ljud';
		# no supported pattterns

Get-UIAWindow -Title 'Maskinvara och ljud' | `
	Get-UIAPane -AutomationId 'CategoryPanel' -Title 'CPCategoryPanel' | `
	Get-UIAHyperlink -AutomationId 'name' -Title 'Spela upp automatiskt';
		#InvokePattern
		#ValuePattern

