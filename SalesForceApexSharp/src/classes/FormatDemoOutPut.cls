/*
* This  is a comment line one
* This is a comment // line two
*/
public with sharing class FormatDemoOutPut
{
    public Integer dataOfBirth { get; set; }
    public void ForLoopTest() {
        for (Integer i = 0; i < 10; i++) {
            // This is a middle line comment
            List<Contact> contacts = [ SELECT Name, Email From Contact Where Name = 'Jay'];
        }
    }
}