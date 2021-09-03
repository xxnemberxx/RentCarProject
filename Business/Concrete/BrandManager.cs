using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.Constants;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Exception;
using Core.Aspects.Autofac.Transaction;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        private IBrandDal _brandDal;
        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        [SecuredOperation("brand.add,admin")]
        //[TransactionScopeAspect]    
        public async Task<IResult> AddAsync(Brand brand)
        {
            var result = BusinessRules.Run();
            if (!result.Success)
            {
                return result;
            }

            await _brandDal.AddAsync(brand);
            await _brandDal.SaveChangesAsync();

            return new SuccessResult();
        }

        [SecuredOperation("brand.add,admin")]
        //[TransactionScopeAspect]
        public async Task<IResult> AddRangeAsync(IEnumerable<Brand> brands)
        {
            var result = BusinessRules.Run();
            if (!result.Success)
            {
                return result;
            }

            await _brandDal.AddRangeAsync(brands);
            await _brandDal.SaveChangesAsync();

            return new SuccessResult();
        }

        [CacheAspect]
        public async Task<IDataResult<IEnumerable<Brand>>> GetAllAsync()
        {
            var result = BusinessRules.Run();
            if (!result.Success)
            {
                return new ErrorDataResult<IEnumerable<Brand>>(result.Message);
            }

            return new SuccessDataResult<IEnumerable<Brand>>
                (await _brandDal.GetAllAsync());
        }

        [CacheAspect]
        public async ValueTask<IDataResult<Brand>> GetByIdAsync(short brandId)
        {
            var result = BusinessRules.Run();
            if (!result.Success)
            {
                return new ErrorDataResult<Brand>(result.Message);
            }

            return new SuccessDataResult<Brand>
                (await _brandDal.GetByIdAsync<short>(brandId));
        }

        [SecuredOperation("brand.remove,admin")]
        [TransactionScopeAspect]
        [CacheRemoveAspect("IBrandService.Get")]
        public IResult Remove(Brand brand)
        {
            var result = BusinessRules.Run();
            if (!result.Success)
            {
                return result;
            }

            _brandDal.Remove(brand);
            _brandDal.SaveChanges();

            return new SuccessResult();
        }
        [SecuredOperation("brand.remove,admin")]
        [TransactionScopeAspect]
        [CacheRemoveAspect("IBrandService.Get")]
        public IResult RemoveRange(IEnumerable<Brand> brands)
        {
            var result = BusinessRules.Run();
            if (!result.Success)
            {
                return result;
            }

            _brandDal.RemoveRange(brands);
            _brandDal.SaveChanges();

            return new SuccessResult();
        }

        [SecuredOperation("brand.update,admin")]
        [TransactionScopeAspect]
        public IResult Update(Brand brand)
        {
            var result = BusinessRules.Run();
            if (!result.Success)
            {
                return result;
            }

            _brandDal.Update(brand);
            _brandDal.SaveChanges();

            return new SuccessResult();
        }

        [SecuredOperation("brand.update,admin")]
        [TransactionScopeAspect]
        public IResult UpdateRange(IEnumerable<Brand> brands)
        {
            var result = BusinessRules.Run();
            if (!result.Success)
            {
                return result;
            }

            _brandDal.UpdateRange(brands);
            _brandDal.SaveChanges();

            return new SuccessResult();
        }
    }
}
