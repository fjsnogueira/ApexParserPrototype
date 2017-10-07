public class HttpCallOutException extends Exception {
    public integer statusCode;
    public HttpCallOutException(integer httpStatusCode) {
        statusCode = httpStatusCode;
    }
}