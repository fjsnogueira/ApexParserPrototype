public with sharing class ClassTwo {
    public ClassTwo() { // constructor
        System.debug('Test');
    }

    public ClassTwo(String vin) { // another constructor
    }

    /*
     * This  is a comment line one
     * This is a comment // line two
     */
    public void Hello() { System.debug('Hello'); }
}