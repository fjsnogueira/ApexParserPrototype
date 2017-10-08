@RestResource(urlMapping='/demo/*/')
global with sharing class MethodDemo extends ClassAbstract
{

    MethodDemo()
    {
    }

    void StringVoid()
    {
    }

    public void StringPublic()
    {
    }

    string GetString()
    {
        return 'Hello World';
    }

    public string GetStringPublic()
    {
        return 'Hello World';
    }

    private string GetStringprivate()
    {
        return 'Hello World';
    }

    global string GetStringglobal()
    {
        return 'Hello World';
    }

    List<string> GetGenericList()
    {
        return new List<string>();
    }

    Map<string, string> GetGenericMap()
    {
        return new Map<string, string>();
    }

    void arrayMethodTwoPrivate(List<string> stringArray)
    {
    }

    global static Map<string, string> arrayMethodOne(Map<string, string> stringArray, List<string> stringArrayList)
    {
        return null;
    }

    global static void arrayMethodTwo(List<string> stringArray)
    {
    }

    public Map<string, string> methodReturnMap(Map<string, string> mapList)
    {
        return null;
    }

    @HttpGet
    @HttpDelete
    global static void getAndDelete()
    {
    }

    @HttpPost
    global static void post(string name, string accountNumber)
    {
        System.debug('Method Post');
    }

    global static void genericMethod(List<string> stringList, Map<string, string> stringMap)
    {
        System.debug('Method Three');
    }

    // From extending class
    public override void methodThree()
    {
        System.debug('Method Three');
    }

    public List<string> methodReturnList()
    {
        return null;
    }

    public Map<string, string> methodReturnMap()
    {
        return null;
    }

    public void MethodOne()
    {
        string returnValue = GetSomeThing('Hello World');
    }
    public string GetSomeThing(string valueToReturn)
    {
        return valueToReturn;
    }
}