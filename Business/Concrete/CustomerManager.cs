using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        private ICustomerDal _customerDal;
        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public Task<IResult> AddAsync(Customer customer)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> AddRangeAsync(IEnumerable<Customer> customers)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<IEnumerable<Customer>>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public ValueTask<IDataResult<Customer>> GetByIdAsync(int customerId)
        {
            throw new NotImplementedException();
        }

        public IResult Remove(Customer customer)
        {
            throw new NotImplementedException();
        }

        public IResult RemoveRange(IEnumerable<Customer> customers)
        {
            throw new NotImplementedException();
        }

        public IResult Update(Customer customer)
        {
            throw new NotImplementedException();
        }

        public IResult UpdateRange(IEnumerable<Customer> customers)
        {
            throw new NotImplementedException();
        }
    }
}
