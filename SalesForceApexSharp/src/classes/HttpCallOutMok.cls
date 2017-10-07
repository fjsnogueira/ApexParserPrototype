global with sharing class HttpCallOutMok implements HttpCalloutMock {
    global integer statusCode = 200;

    global HTTPResponse respond(HTTPRequest req) {
        HttpResponse res = new HttpResponse();
        res.setHeader('Content-Type', 'application/json');
        res.setBody('{"msg":"Hi"}');
        res.setStatusCode(200);
        return res;
    }
}