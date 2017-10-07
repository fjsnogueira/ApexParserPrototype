public with sharing class DataAccessLayerDemo {
    public static String GetEmailAddressOfAContact(string contactName) {
        Contact contact =  DataAccessLayer.GetContact(contactName);
        if(contact != null) {
            return contact.Email;
        } else {
            return null;
        }
    }
}