ipmo C:\Projects\PS\STUPS\Data\Data\bin\Release35\Data.dll
New-DtXmlComparer | `
	Add-DtXmlDataEntry -XPath "//aaa" -Value "Aaaa" | `
	Add-DtXmlDataEntry -XPath "//BB" -Value "sadfasdf" | `
	Add-DtXmlDataEntry -XPath "//ccc" -Value "hhh" | `
	Add-DtXmlDataEntry -XPath "//dd" -Value "sdfljawes;riuapesworiu;alskdjf";

$comparer = `
	New-DtXmlComparer | `
	Add-DtXmlDataEntry -XPath "//aaa" -Value "Aaaa" | `
	Add-DtXmlDataEntry -XPath "//BB" -Value "sadfasdf" | `
	Add-DtXmlDataEntry -XPath "//ccc" -Value "hhh" | `
	Add-DtXmlDataEntry -XPath "//dd" -Value "sdfljawes;riuapesworiu;alskdjf";