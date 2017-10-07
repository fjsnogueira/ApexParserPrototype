public with sharing class MokDemo {
    public String getContactLastName(MokDemoDAL dal) {

        Contact contact = dal.getFirstContact();

        System.debug('Doing some work');

        return contact.LastName;
    }
}