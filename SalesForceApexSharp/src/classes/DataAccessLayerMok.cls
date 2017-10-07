@isTest
public with sharing class DataAccessLayerMok implements DataAccessLayerI
{
    public Contact GetContactByName(String firstName, String lastName)
    {
        DataAccessLayer dal = (DataAccessLayer) MokProvider.createMokProvidor(DataAccessLayer.class);
        Contact contact = dal.GetContactByName(firstName, lastName);
        return contact;
    }

    public void UpdateContact(Contact contact)
    {
        DataAccessLayer dal = (DataAccessLayer) MokProvider.createMokProvidor(DataAccessLayer.class);
        dal.UpdateContact(contact);
    }
}