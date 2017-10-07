public with sharing class MokDemoDAL {
    public Contact getFirstContact() {
        List<Contact> contacts = [SELECT Id,LastName FROM Contact LIMIT 1];
        return contacts[0];
    }
}