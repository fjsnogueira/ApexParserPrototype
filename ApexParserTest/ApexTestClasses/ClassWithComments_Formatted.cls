public with sharing class ClassTwo
{
     // constructor
     public ClassTwo()
     {
          System.debug('Test');
     }

     // another constructor
     // with a lot of misplaced comments
     public ClassTwo(String vin)
     {
     }

     /*
     * This  is a comment line one
     * This is a comment // line two
     */
     public void Hello()
     {
          System.debug('Hello');
     }
}