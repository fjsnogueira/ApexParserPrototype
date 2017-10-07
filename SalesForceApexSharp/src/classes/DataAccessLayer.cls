public with sharing class DataAccessLayer implements DataAccessLayerI
{
    public Contact GetContactByName(String firstName, String lastName)
    {
        Contact contact;
        try
        {
            contact = [SELECT Name, Email From Contact Where FirstName = :firstName AND LastName = :lastName];
        }
        catch (QueryException e)
        {
            System.debug(e.getMessage());
        }

        return contact;
    }

    
    public void UpdateContact(Contact contact)
    {
        try
        {
            update contact;
        }
        catch (DmlException e)
        {
            contact.addError(e.getMessage());
        }
    }
}