public with sharing class ForLoop
{
    public Integer dataOfBirth
    {
        get;
        set;
    }

    private Integer dataOfBirthNew;

    public with sharing class InnerForLoop
    {
    }

    public void ForLoopTest()
    {
        for (Integer i = 0; i < 10; i++)
        {
            System.debug (i + 1);
        }
    }

    public static Contact GetContact(String name)
    {
        List<Contact> contacts = [SELECT Name, Email From Contact Where Name = :name];
        if (contacts.size () > 0)
        {
            return contacts[0];
        }
        else
        {
            return null;
        }
    }
}