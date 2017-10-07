public interface DataAccessLayerI
{
    
    Contact GetContactByName(String firstName, String lastName);
    void UpdateContact(Contact contact);
}