@isTest
public with sharing class DataAccessLayerTest
{
    @isTest
    public static void UpdateContactEmailAddress() {
        Datetime startTime = Datetime.now();
        Integer startms = startTime.millisecond();

        DataAccessDemo dl = new DataAccessDemo();
        String replyvalue = dl.UpdateContactEmailAddress('Tim','Barr', 'abc@abcOne.com');
        System.debug(replyvalue);

        Datetime endTime = Datetime.now();
        Integer endms = endTime.millisecond();

        System.debug('Total Time : ' + (endms - startms));
    }
}