@isTest
public class ClassUnitTest
{
    @TestSetup
    public static void Setup()
    {
        System.Debug('One Time Setup Got Called');
    }
    @isTest static public void Assert()
    {
        System.Assert(true, 'Assert True');
    }
    @isTest static public void AssertEquals()
    {
        System.AssertEquals(5, 5, 'Assert Equal');
    }
    @isTest static public void AssertNotEquals()
    {
        System.AssertEquals(5, 0, 'Assert Not Equal');
    }

    static testMethod public void AssertNew()
    {
        System.Assert(true, 'Assert True');
    }
    static testMethod public void AssertEqualsNew()
    {
        System.AssertEquals(5, 5, 'Assert Equal');
    }
    static testMethod public void AssertNotEqualsNew()
    {
        System.AssertEquals(5, 0, 'Assert Not Equal');
    }
}