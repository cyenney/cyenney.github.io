using webapi.Models.Customer;

namespace webapi.DAL
{
    public class CustomerRepository
    {
        public List<Customer> _customers = new()
        {
            new Customer{Id = Guid.Parse("16132c8e-4a88-46d9-9610-0be91fb2fbc0"), Email = "test", Password = "test", Name = "contoso", PhoneNumber = "8152758696"},
            new Customer{Id = Guid.NewGuid(), Email="123", Password = "abc" ,Name ="fake", PhoneNumber = "123456789"}
        };
        public Customer GetCustomer(LoginCustomer customer)
        {
            var foundCustomer = _customers.FirstOrDefault(x => x.Email == customer.Email && x.Password == customer.Password);
            return foundCustomer;
        }
    }
}
