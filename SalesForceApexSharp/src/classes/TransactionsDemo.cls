public with sharing class TransactionsDemo {
//    public static void Setup() {
//        Balance__c balanceOneSave = new Balance__c();
//        balanceOneSave.Name = 'JayOne';
//        balanceOneSave.Balance__c = 10;
//        balanceOneSave.Comment__c = 'Jay One';
//        upsert balanceOneSave;
//
//        balanceOneSave = new Balance__c();
//        balanceOneSave.Name = 'JayTwo';
//        balanceOneSave.Balance__c = 10;
//        balanceOneSave.Comment__c = 'Jay Two';
//        upsert balanceOneSave;
//    }
//
//    public static void AddRemoveCorrect() {
//
//        Balance__c balanceOne = [SELECT Name, Balance__c, Comment__c FROM Balance__c WHERE Name = 'JayOne'];
//        Balance__c balanceTwo = [SELECT Name, Balance__c, Comment__c FROM Balance__c WHERE Name = 'JayTwo'];
//
//        System.debug(balanceOne.Balance__c);
//        System.debug(balanceTwo.Balance__c);
//
//        balanceOne.Balance__c = balanceOne.Balance__c + 2;
//        balanceTwo.Balance__c = balanceTwo.Balance__c - 2;
//
//        // Comment__c is a requird field, it was created to simulate a DML Exception.
//        balanceOne.Comment__c = 'JayTwo Added 2 Bucks to JayOne';
//        balanceTwo.Comment__c = null;
//
//        Savepoint sp = System.Database.setSavepoint();
//        try {
//            update balanceOne;
//            update balanceTwo;
//       } catch (Exception e) {
//          System.debug(e.getMessage());
//          System.Database.rollback(sp);
//        }
//
//        balanceOne = [SELECT Name, Balance__c, Comment__c FROM Balance__c WHERE Name = 'JayOne'];
//        balanceTwo = [SELECT Name, Balance__c, Comment__c FROM Balance__c WHERE Name = 'JayTwo'];
//
//        System.debug(balanceOne.Balance__c);
//        System.debug(balanceTwo.Balance__c);
//    }
}