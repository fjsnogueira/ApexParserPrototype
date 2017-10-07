@isTest
global with sharing class EveryThing
{
    // ApexPropertyDeclarationSyntax
    public DateTime DateTimeGetSet { get; set; }
    public List<DateTime> DateTimeGetSetGeneric { get; set; }
    public DateTime[] DateTimeGetSetArray { get; set; }
    // ApexFieldDeclarationSyntax
    public string Name = 'Jay';
    public final string nameFinal = 'Jay';
    public static string NameStatic = 'Jay';
    public static final string NameStaticFinal;
    public static final string NameStaticFinalAssignd = 'Jay';
    public DateTime DateTimeEmpty;
    public DateTime DateTimeInitilized = DateTime.Now();
    public List<DateTime> DateTimeList = new List<DateTime>();
    public DateTime[] DateTimeArrary = new DateTime[5];
    public List<Account> accountListTwo;
    public EveryThing()
    {
        testMethodOne();
        soqlOne();
        soqlTwo();
        soqlThree();
    }
    public EveryThing(string demoString)
    {
        // ApexLocalDeclarationStatementSyntax
        string nameInternal = 'Jay';
        System.debug(nameInternal + demoString);
    }
    // ApexMethodDeclarationSyntax
    @isTest
    public static void testMethodOne()
    {
        // ApexLocalDeclarationStatementSyntax
        String nameInternal = 'Jay';
        System.debug('Jay');
    }
    public string soqlOne()
    {
        string id = '0013600000Vm91zAAB';
        string name = 'TEST';
        List<Account> accountListOne = [SELECT Id, Name FROM Account WHERE Name = :name AND Id = :id];
        // ApexReturnStatementSyntax
        return 'Jay';
    }
    public void soqlTwo()
    {
        string id = '0013600000Vm91zAAB';
        string name = 'TEST';
        accountListTwo = [SELECT Id, Name FROM Account WHERE Name = :name AND Id = :id];
        System.debug(accountListTwo.size());
        List<Account> accountListThree;
        accountListThree = [SELECT Id, Name FROM Account WHERE Name = :name AND Id = :id];
        System.debug(accountListThree.size());
    }

    public void soqlThree()
    {
        string id = '0013600000Vm91zAAB';
        string name = 'TEST';
        Account accountListThree = [SELECT Id, Name FROM Account WHERE Name = :name AND Id = :id LIMIT 1];
    }
}