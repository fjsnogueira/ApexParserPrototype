public with sharing class CustomerManagement
{
    public class CustomerDto
    {
        public String Email
        {
            get ;
            set ;
        }
        public String FristName
        {
            get ;
            set ;
        }
        public String LastName
        {
            get ;
            set ;
        }
        public String Phone
        {
            get ;
            set ;
        }
    }
    public class CustomerRecordUpdateException extends Exception
    {
    }
    public class CustomerRecordNotFoundException extends Exception
    {
    }
    public class CustomerDao
    {
        public CustomerManagement.CustomerDto GetCustomerByEmail(String email)
        {
            try
            {
                Contact contactRecord = [SELECT FirstName, LastName, Email, Account.Phone FROM Contact Where Email = :email LIMIT 1] ;
                CustomerManagement.CustomerDto dto = new CustomerManagement.CustomerDto() ;
                dto.FristName = contactRecord.FirstName ;
                dto.LastName = contactRecord.LastName ;
                dto.Phone = contactRecord.Account.Phone ;
                dto.Email = contactRecord.Email ;
                return dto ;
            }
            catch (QueryException e)
            {
                throw new CustomerManagement.CustomerRecordNotFoundException(e) ;
            }
        }
        public void UpdateCustomer(CustomerManagement.CustomerDto dto)
        {
            try
            {
                Contact contactRecord = [SELECT FirstName, LastName, Email, Account.Id FROM Contact Where Email = :dto.Email LIMIT 1] ;
                contactRecord.FirstName = dto.FristName ;
                contactRecord.LastName = dto.LastName ;
                Account accountRecord = [SELECT Account.Phone FROM Account WHERE Id = :contactRecord.AccountId] ;
                accountRecord.Phone = dto.Phone ;
                update accountRecord ;
                update contactRecord ;
            }
            catch (QueryException e)
            {
                throw new CustomerManagement.CustomerRecordNotFoundException(e) ;
            }
            catch (DMLException e)
            {
                throw new CustomerManagement.CustomerRecordUpdateException(e) ;
            }
        }
    }
}