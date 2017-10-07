@IsTest
private class MokDemoTest {
    static testMethod void getContactLastNameWITHMokTest() {

        Datetime startTime = Datetime.now();
        Integer startms = startTime.millisecond();

        MokDemoDAL dal = (MokDemoDAL)MokProvider.createMokProvidor(MokDemoDAL.class);

        MokDemo demoMok = new MokDemo();
        System.assertEquals('ContactWithMock', demoMok.getContactLastName(dal));

        Datetime endTime = Datetime.now();
        Integer endms = endTime.millisecond();

        System.debug('Total Time : ' + (endms - startms));
    }

    static testMethod void getContactLastNameNOMokTest() {

        Datetime startTime = Datetime.now();
        Integer startms = startTime.millisecond();

        Contact demoContact = new Contact();
        demoContact.LastName = 'ContactNoMock';
        insert demoContact;

        MokDemo demoMok = new MokDemo();

        MokDemoDAL dal = new MokDemoDal();
        System.assertEquals('ContactNoMock', demoMok.getContactLastName(dal));

        Datetime endTime = Datetime.now();
        Integer endms = endTime.millisecond();

        System.debug('Total Time : ' + (endms - startms));
    }
}