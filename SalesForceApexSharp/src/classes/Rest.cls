@RestResource(urlMapping='/api/v1/restdemo')
global class Rest {

    global static void Put() {

        RestRequest req = RestContext.request;
        RestResponse res = RestContext.response;

        Rest.DtoRestUpdateUserNameRequest dto = (Rest.DtoRestUpdateUserNameRequest) JSON.deserialize(req.requestBody.toString(), Rest.DtoRestUpdateUserNameRequest.class);
        try {
            UpdateContact(dto);
            res.responseBody = Blob.valueOf(JSON.serialize('OK'));
            res.statusCode = 200;

        } catch (Rest.UpdateContactException e) {
            res.statusCode = 400;
            res.responseBody = Blob.valueOf(JSON.serialize(e.getMessage()));
        }
        RestContext.response = res;
    }

    private static void UpdateContact(DtoRestUpdateUserNameRequest dto) {

        //DtoRestUpdateUserNameResponse response = new DtoRestUpdateUserNameResponse();

        List<Contact> contactList = [SELECT Id, Name, Email, Phone FROM Contact WHERE Name = :dto.name];
        if (!contactList.isEmpty()) {

            for (Contact con : contactList) {
                con.Email = dto.emailAddress;
            }
            update contactList;
        } else {
            throw new Rest.UpdateContactException();
        }
    }

    class DtoRestUpdateUserNameRequest {
        public string name { get; set; }
        public string emailAddress { get; set; }
        public string mobilePhoneNumber { get; set; }
    }

    class UpdateContactException extends Exception {
    }

}