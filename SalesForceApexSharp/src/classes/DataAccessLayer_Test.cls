@isTest
public with sharing class DataAccessLayer_Test
{
    static testMethod void test_GetContactByName_UseCase1()
    {
        DataAccessLayer obj01 = new DataAccessLayer();
        obj01.GetContactByName('test data', 'test data');
    }

    static testMethod void test_GetContactByName_UseCase2()
    {
        DataAccessLayer obj01 = new DataAccessLayer();

        obj01.GetContactByName('test data', 'test data');
    }
    static testMethod void test_UpdateContact_UseCase1()
    {
        DataAccessLayer obj01 = new DataAccessLayer();
        obj01.UpdateContact(new Contact());
    }
}