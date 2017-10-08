@isTest
public with sharing class MethodTwo
{
    @isTest public static void TestMethodOne()
    {
        System.debug('TestMethodOne');
    }

    @isTest static void TestMethodThree()
    {
        System.debug('TestMethodThree');
    }

    // Does Not Work
    static testMethod void TestMethodFour()
    {
        System.debug('TestMethodFour');
    }

    public testMethod static void TestMethodTwo()
    {
        System.debug('TestMethodTwo');
    }
}