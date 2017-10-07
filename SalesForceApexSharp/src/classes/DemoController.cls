public with sharing class DemoController {

    public Contact GetContactByName(string contactName) {
        List<Contact> allContacts = [SELECT Id, Name FROM Contact];
        for (Contact con:allContacts) {
            if (con.Name == contactName) {
                return con;
            }
        }

        return null;
    }


    public void UpdateContact(Contact contactToUpdate) {

    }
}