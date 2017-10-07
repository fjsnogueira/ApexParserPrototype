/**
 * Created by jay on 5/9/2017.
 */

public with sharing class MasterDetailDemo {
    public MasterDetailDemo() {
        Parent__c parent = new Parent__c();
        parent.Name = 'Parent1';
        insert parent;

        FirstChild__c firstChild = new FirstChild__c();
        firstChild.Name = 'FirstChild12345';
        firstChild.Parent__c = parent.id;

        insert firstChild;

        List<FirstChild__c> firstChildren = [SELECT Name, Parent__c, Parent__r.Id, Parent__r.Name From FirstChild__c WHERE Name = 'FirstChild12345'];
    }
}