//::    ApexClassDeclarationSyntax
public with sharing class PropertyAndField {
//::    ApexPropertyDeclarationSyntax
public DateTime DateTimeGetSet { get; set; }
//::    ApexPropertyDeclarationSyntax
public List<DateTime> DateTimeGetSetGeneric { get; set; }
//::    ApexPropertyDeclarationSyntax
public DateTime[] DateTimeGetSetArray { get; set; }
//::    ApexFieldDeclarationSyntax
public DateTime DateTimeEmpty;
//::    ApexFieldDeclarationSyntax
public DateTime DateTimeInitilized = DateTime.now();
//::    ApexFieldDeclarationSyntax
public List<DateTime> DateTimeList = new List<DateTime>();
//::    ApexFieldDeclarationSyntax
public DateTime[] DateTimeArrary = new DateTime[5];
//::    ApexFieldDeclarationSyntax
public String Name = 'jay';
//::    CloseBrace
    public final String nameFinal = 'jay';
    public static String NameStatic = 'jay';
    public static final String NameStaticFinal = 'jay';
}