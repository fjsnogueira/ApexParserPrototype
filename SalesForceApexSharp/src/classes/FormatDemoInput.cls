/*
* This  is a comment line one
* This is a comment // line two
*/
public with sharing class FormatDemoInput
{
    public Integer
        dataOfBirth
            { get; set; }
    public void ForLoopTest() {
        for (Integer i = 0; i < 10; i++) {
            List<Contact> contacts =
            [
                    SELECT Name, Email // This is a middle line comment
                    From Contact
                    Where Name = 'Jay'
            ];
        }
    }
}