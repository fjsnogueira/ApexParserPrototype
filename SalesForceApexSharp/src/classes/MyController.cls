// Demo Test Class.
//::    ApexClassDeclarationSyntax
global without sharing class MyController {
//::    ApexFieldDeclarationSyntax
global DateTime DateTimeOne;
//::    ApexPropertyDeclarationSyntax
global DateTime DateTimeTwo { get; set; }
//::    ApexFieldDeclarationSyntax
global DateTime DateTimeFour = DateTime.now();
//::    ApexFieldDeclarationSyntax
global List<DateTime> DateTimeList = new List<DateTime>();
//::    ApexConstructorDeclarationSyntax
public MyController() {
//::    ApexExpressionStatementSyntax
RunTest();
//::    CloseBrace
}
//::    ApexMethodDeclarationSyntax
public void RunTest() {
//::    ApexExpressionStatementSyntax
SoqlTestFilter('Test' , 'CC978213');
//::    ApexExpressionStatementSyntax
JsonTest();
//::    ApexExpressionStatementSyntax
SoqlTest();
//::    ApexExpressionStatementSyntax
ForLoopTest();
//::    ApexExpressionStatementSyntax
ForEachTest();
//::    CloseBrace
}
//::    ApexMethodDeclarationSyntax
public String GetString() {
//::    ApexReturnStatementSyntax
return 'Jay';
//::    CloseBrace
}
//::    ApexMethodDeclarationSyntax
public void SoqlTestFilter(string name , string accountNumber) {
//::    Soql
List<Account> accountListTwo = [SELECT Id, Name FROM Account WHERE Name = :name AND AccountNumber = :accountNumber];
//::    ApexExpressionStatementSyntax
System.debug(accountListTwo [ 0 ].Name);
//NoApex.Serilog.LogInfo(accountListTwo[0].Name);
//::    Soql
Account oneAccount = [SELECT Id, Name FROM Account LIMIT 1];
//::    ApexExpressionStatementSyntax
System.debug(oneAccount.Name);
//::    Soql
String accountName = [SELECT Id, Name FROM Account LIMIT 1].Name;
//::    ApexExpressionStatementSyntax
System.debug(accountName);
//::    CloseBrace
}
//::    ApexMethodDeclarationSyntax
public void JsonTest() {
//::    Soql
List<Account> newDateTime = [SELECT Id, Name FROM Account LIMIT 2];
//::    ApexFieldDeclarationSyntax
String newDateTimeJson = JSON.serialize(newDateTime);
//::    ApexExpressionStatementSyntax
System.debug(newDateTimeJson);
//::    ApexFieldDeclarationSyntax
List<Account> newnewDateTime =(List<Account>) JSON.deserialize(newDateTimeJson , List<Account> .class);
//::    ApexExpressionStatementSyntax
System.debug(newnewDateTime.size());
//::    ApexExpressionStatementSyntax
newnewDateTime =(List<Account>) JSON.deserialize(newDateTimeJson , List<Account> .class);
//::    ApexExpressionStatementSyntax
System.debug(newnewDateTime.size());
//::    CloseBrace
}
//::    ApexMethodDeclarationSyntax
public void SoqlTest() {
//::    Soql
List<Account> accountList = [SELECT Id, Name FROM Account LIMIT 1];
//::    Dml
update accountList;
//::    Dml
delete accountList;
//::    Dml
undelete accountList;
//::    Dml
update accountList;
//::    CloseBrace
}
//::    ApexMethodDeclarationSyntax
public void ForLoopTest() {
//::    ApexForStatementSyntax
for(Integer i = 0; i < 10; i ++) {
//::    ApexExpressionStatementSyntax
System.debug('Original Value : ' + i);
//::    CloseBrace
}
//::    CloseBrace
}
//::    ApexMethodDeclarationSyntax
public void ForEachTest() {
//::    Soql
List<Account> accountList = [SELECT Id, Name FROM Account LIMIT 1];
//::    ApexForStatementSyntax
for(Account account : accountList) {
//::    ApexExpressionStatementSyntax
System.debug('original value : ' + account.Name);
//::    CloseBrace
}
//::    CloseBrace
}
//::    CloseBrace
}