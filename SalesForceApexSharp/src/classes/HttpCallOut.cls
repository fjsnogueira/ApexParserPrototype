public with sharing class HttpCallOut {

    public static void CreateObject() {
        LargeObject__c largeObject = new LargeObject__c();
        insert largeObject;
        System.debug(largeObject.Id);
    }

    public static void Post() {
        if(Test.isRunningTest()) {
            PostWithFuture('{"msg":"hello world5"}');
        } else {
            PostWithNoFuture('{"msg":"hello world5"}');
        }
    }

    public static void PostWithNoFuture(string msg) {
        HttpRequest req = new HttpRequest();

        req.setEndpoint('http://putsreq.com/mwx6F9p9NFAky0JwIOid');
        req.setMethod('POST');
        req.setHeader('Accept', 'application/json');
        req.setHeader('Content-Type', 'application/json');
        req.setBody('{"msg":"hello world5"}');

        Http http = new Http();
        HTTPResponse resp = new HttpResponse();
        resp = http.send(req);

        Log__c logInfo = new Log__c();
        logInfo.Name = resp.getBody();
        insert logInfo;
    }

    @future(callout=true)
    public static void PostWithFuture(string msg) {
        HttpRequest req = new HttpRequest();

        req.setEndpoint('http://putsreq.com/mwx6F9p9NFAky0JwIOid');
        req.setMethod('POST');
        req.setHeader('Accept', 'application/json');
        req.setHeader('Content-Type', 'application/json');
        req.setBody(msg);

        Http http = new Http();
        HTTPResponse resp = new HttpResponse();
        resp = http.send(req);

        Log__c logInfo = new Log__c();
        logInfo.Name = resp.getBody();
        insert logInfo;
    }
}