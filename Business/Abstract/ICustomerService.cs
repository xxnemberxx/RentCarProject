using Core.Utilities.Results;
using Entities.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICustomerService
    {
        Task<IResult> AddAsync(Customer customer);
        Task<IResult> AddRangeAsync(IEnumerable<Customer> customers);
        IResult Update(Customer customer);
        IResult UpdateRange(IEnumerable<Customer> customers);
        IResult Remove(Customer customer);
        IResult RemoveRange(IEnumerable<Customer> customers);
        ValueTask<IDataResult<Customer>> GetByIdAsync(int customerId);
        Task<IDataResult<IEnumerable<Customer>>> GetAllAsync();
    }
}
