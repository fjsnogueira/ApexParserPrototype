/*
 *  A simple class to demon how Unit Testing works in Salesforce
 *  Business requirment: 
 *  	If the creditscore is 600 or less return 10
 *  	If its more return 7
 * 
 */
public with sharing class UnitTestDemo {
    public static Integer getIntrestRate(Integer creditScore) {
        if(creditScore <= 600)
            return 10;
        else
            return 7;
    }
}