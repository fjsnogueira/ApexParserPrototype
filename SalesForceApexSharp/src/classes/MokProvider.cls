@IsTest
public class MokProvider implements System.StubProvider {
    public static Object createMokProvidor(Type typeToMock) {
        return Test.createStub(typeToMock, new MokProvider());
    }

    public Object handleMethodCall(Object stubbedObject, String stubbedMethodName,
            Type returnType, List<Type> listOfParamTypes, List<String> listOfParamNames,
            List<Object> listOfArgs) {

        System.debug('Object Name : ' + stubbedObject);
        System.debug('Method Name : ' + stubbedMethodName);
        System.debug('Return Type : ' + returnType.getName());

        if (stubbedMethodName == 'GetContactByName') {
            Contact demoContact = new Contact();
            demoContact.LastName = 'ContactWithMock';
            return demoContact;
        } else {
            return null;
        }
    }
}