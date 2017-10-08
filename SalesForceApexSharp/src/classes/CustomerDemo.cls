public with sharing class CustomerDemo {
    public static void UpdateCustomerDemo(String email, String newPhoneNumber) {
        CustomerManagement.CustomerDto vipCustomer;
        CustomerManagement.CustomerDao customerDao = new CustomerManagement.CustomerDao();

        try {
            vipCustomer = customerDao.GetCustomerByEmail(email);
        } catch (CustomerManagement.CustomerRecordNotFoundException e) {
            // Logic to handle if no records are found
        }

        try {
            vipCustomer.Phone = newPhoneNumber;
            customerDao.UpdateCustomer(vipCustomer);
        } catch (CustomerManagement.CustomerRecordNotFoundException e) {
            // Logic to handle if no records are found
        } catch (CustomerManagement.CustomerRecordUpdateException e) {
            // Logic to handle if update fails
        }

        try {
            vipCustomer = customerDao.GetCustomerByEmail(email);
            System.debug(vipCustomer.Phone);
        } catch (CustomerManagement.CustomerRecordNotFoundException e) {
            // Logic to handle if no records are found
        }
    }
}