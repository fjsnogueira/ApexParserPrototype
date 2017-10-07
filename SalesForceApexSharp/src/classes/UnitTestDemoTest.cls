// Should get 10 if credit score is less that 600
@isTest public with sharing class UnitTestDemoTest
{
    public DateTime DateTimeGetSet { get; set; }
    // ApexPropertyDeclarationSyntax
    public List<DateTime> DateTimeGetSetGeneric { get; set; }
    // ApexPropertyDeclarationSyntax
    public DateTime[] DateTimeGetSetArray { get; set; }
    // ApexFieldDeclarationSyntax
    public DateTime DateTimeEmpty;
    // ApexFieldDeclarationSyntax
    public DateTime DateTimeInitilized = DateTime.now();
    // ApexFieldDeclarationSyntax
    public List<DateTime> DateTimeList = new List<DateTime>();
    // ApexFieldDeclarationSyntax
    public DateTime[] DateTimeArrary = new DateTime[5];
    // ApexFieldDeclarationSyntax
    public String Name = 'jay';
    public final String nameFinal = 'jay';
    public static String NameStatic = 'jay';
    public static final String NameStaticFinal;

    // Should get 10 if credit score is less that 600
    @isTest public static void getIntrestRateOne()
    {
        // Should get 10 if credit score is less that 600
        Integer intrestRate = UnitTestDemo.getIntrestRate (599);
        System.assertEquals (10, intrestRate);
        // Should get 10 if credit score is equal to 600
        intrestRate = UnitTestDemo.getIntrestRate (600);
        System.assertEquals (10, intrestRate);
        // Should get 7 if credit score is more that 600
        intrestRate = UnitTestDemo.getIntrestRate (601);
        System.assertEquals (10, intrestRate);
    }
    // Should get 10 if credit score is less that 600
    @isTest public static void getIntrestRateTwo()
    {
        // Should get 10 if credit score is less that 600
        for (Integer i = 0; i < 10; i++)
        {
            System.debug (i + 1);
        }

        List<Contact> contacts = [SELECT Name, Email From Contact Where Name = :NameStatic];

        if (contacts.size () > 0)
        {

        }
        else
        {

        }
    }
}