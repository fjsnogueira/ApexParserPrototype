global with sharing class MethodOne
{
    MethodOne()
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
}