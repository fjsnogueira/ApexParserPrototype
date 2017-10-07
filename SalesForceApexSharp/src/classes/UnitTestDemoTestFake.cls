@ isTest
public class UnitTestDemoTestFake {
    static testMethod void getIntrestRate() {
        // Should get 10 if credit score is less that 600
        Integer intrestRate = UnitTestDemo.getIntrestRate(599);

        // Should get 10 if credit score is equal to 600
        intrestRate = UnitTestDemo.getIntrestRate(600);
        
        // Should get 7 if credit score is more that 600
        intrestRate = UnitTestDemo.getIntrestRate(601);
    }  
}