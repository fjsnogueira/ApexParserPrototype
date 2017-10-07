@isTest public class UnitTest
{
 public void Setup()
{
System.Debug('One Time Setup Got Called');
}
@isTest public void Assert()
{
System.Assert(true, 'Assert True');
}
@isTest public void AssertEquals()
{
System.AssertEquals(5, 5, 'Assert Equal');
}
@isTest public void AssertNotEquals()
{
System.AssertEquals(5, 0, 'Assert Not Equal');
}
}
