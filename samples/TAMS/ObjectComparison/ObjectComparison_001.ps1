Set-StrictMode -Version Latest;
cls;

ipmo C:\Projects\PS\STUPS\TAMS\TAMS\bin\Release35\TAMS.dll;

$Assem = ( 
    "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
    ) 

$Source = @" 
public class Person
{
    public Person(string name) 
    { 
        Name = name;
        Children = new System.Collections.ObjectModel.Collection<Person>();
    }
    public string Name { get; set; }
    public System.Collections.ObjectModel.Collection<Person> Children { get; private set;  }
}
"@ 

Add-Type -ReferencedAssemblies $Assem -TypeDefinition $Source -Language CSharp

$p1 = New-Object Person("John");
$p1.Children.Add((New-Object Person("Peter")));
$p1.Children.Add((New-Object Person("Mary")));
$p2 = New-Object Person("John");
$p2.Children.Add((New-Object Person("Peter")));

Compare-Object -ReferenceObject $p1 -DifferenceObject $p2;
Compare-TamsObject -ReferenceObject $p1 -DifferenceObject $p2;

$p3 = New-Object Person("John");
$p3.Children.Add((New-Object Person("Peter")));
$p3.Children.Add((New-Object Person("Mary")));

$p4 = New-Object Person("John");
$p4.Children.Add((New-Object Person("Mary")));

Compare-TamsObject -ReferenceObject $p1 -DifferenceObject $p2, $p3, $p4;