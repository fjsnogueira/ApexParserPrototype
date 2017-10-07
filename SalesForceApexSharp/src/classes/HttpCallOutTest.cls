@isTest
public with sharing class HttpCallOutTest {

    // Cant Unit Test outbound HTTP Calls
    static testMethod void httpPostNoMockTest() {
    //    HttpCallOut.PostWithNoFuture('{"msg":"hello world5"}');
    }

    // Cant Unit Test outbound HTTP Calls even if its a @futre method
    static testMethod void httpPostWithFuture() {
    //    HttpCallOut.PostWithFuture('{"msg":"hello world5"}');
    }

    // We Need to Mock
    static testMethod void httpPostWithMockTest() {
        HttpCallOutMok mok = new HttpCallOutMok();
        Test.setMock(HttpCalloutMock.class, mok);
        HttpCallOut.PostWithNoFuture('{"msg":"hello world5"}');
    }



    // We Need to Mock
    static testMethod void httpPostTest() {
        HttpCallOut.CreateObject();

        HttpCallOutMok mok = new HttpCallOutMok();
        Test.setMock(HttpCalloutMock.class, mok);

        HttpCallOut.Post();
    }
}