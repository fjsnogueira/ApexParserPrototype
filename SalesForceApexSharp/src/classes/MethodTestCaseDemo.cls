@isTest
public with sharing class MethodTestCaseDemo
        {
    @isTest public static void TestMethodOne()
    {
        System.debug('TestMethodOne');
    }

    public testMethod static void TestMethodTwo()
    {
        System.debug('TestMethodTwo');
    }


    @isTest static void TestMethodThree()
    {
        System.debug('TestMethodThree');
    }

    static testMethod void TestMethodFour()
    {
        System.debug('TestMethodFour');
    }
}