using ConsoleApp.Entities;
using ConsoleApp_CODE_FIRST.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_CODE_FIRST.Services
{
    internal class CustomerService
    {
        private readonly CustomerRepository _customerRepository;
        private readonly RoleService _roleService;
        private readonly AddressService _addressService;

        public CustomerService(CustomerRepository customerRepository, RoleService roleService, AddressService addressService)
        {
            _customerRepository = customerRepository;
            _roleService = roleService;
            _addressService = addressService;
        }

        public CustomerEntity CreateCustomer(string firstName,  string lastName, string email, string roleName, string streetName, string postalCode, string city) 
        {
            var roleEntity = _roleService.CreateRole(roleName);
            var addressEntity = _addressService.CreateAddress(streetName, postalCode, city);

            var customerEntity = new CustomerEntity
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                RoleId = roleEntity.Id,
                AddressId = addressEntity.Id,
            };
            customerEntity = _customerRepository.Create(customerEntity);
            return customerEntity;
        }


        public CustomerEntity GetCustomerByEmail(string email)
        {
            var customerEntity = _customerRepository.Get(x => x.Email == email);
            return customerEntity;
        }

        public CustomerEntity GetCustomerById(int id)
        {
            var customerEntity = _customerRepository.Get(x => x.Id == id);
            return customerEntity;
        }

        public IEnumerable<CustomerEntity> GetCustomers()
        {
            var customers = _customerRepository.GetAll();
            return customers;
        }

        public CustomerEntity UpdateCustomer(CustomerEntity customerEntity)
        {
            var updatedCustomerEntity = _customerRepository.Update(x => x.Id == customerEntity.Id, customerEntity);
            return updatedCustomerEntity;
        }

        public bool DeleteCustomer(int id)
        {
            _customerRepository.Delete(x => x.Id == id);
            return true;
        }
    }
}
