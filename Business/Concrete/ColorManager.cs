using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Transaction;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        private IColorDal _colorDal;
        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        [SecuredOperation("color.add,admin")]
        //[TransactionScopeAspect]
        [CacheRemoveAspect("IColorService.Get")]
        public async Task<IResult> AddAsync(Color color)
        {
            var result = BusinessRules.Run();
            if (!result.Success)
            {
                return result;
            }

            await _colorDal.AddAsync(color);
            await _colorDal.SaveChangesAsync();

            return new SuccessResult();
        }

        [SecuredOperation("color.add,admin")]
        //[TransactionScopeAspect]
        [CacheRemoveAspect("IColorService.Get")]
        public async Task<IResult> AddRangeAsync(IEnumerable<Color> colors)
        {
            var result = BusinessRules.Run();
            if (!result.Success)
            {
                return result;
            }

            await _colorDal.AddRangeAsync(colors);
            await _colorDal.SaveChangesAsync();

            return new SuccessResult();
        }

        [CacheAspect]
        public async Task<IDataResult<IEnumerable<Color>>> GetAllAsync()
        {
            var result = BusinessRules.Run();
            if (!result.Success)
            {
                return new ErrorDataResult<IEnumerable<Color>>(result.Message);
            }

            return new SuccessDataResult<IEnumerable<Color>>(await _colorDal.GetAllAsync());        
        }

        [CacheAspect]
        public async ValueTask<IDataResult<Color>> GetByIdAsync(byte colorId)
        {
            var result = BusinessRules.Run();
            if (!result.Success)
            {
                return new ErrorDataResult<Color>(result.Message);
            }

            return new SuccessDataResult<Color>
                (await _colorDal.GetByIdAsync<byte>(colorId));
        }

        [SecuredOperation("color.remove,admin")]
        [TransactionScopeAspect]
        [CacheRemoveAspect("IColorService.Get")]
        public IResult Remove(Color color)
        {
            var result = BusinessRules.Run();
            if (!result.Success)
            {
                return result;
            }

            _colorDal.Remove(color);
            _colorDal.SaveChanges();

            return new SuccessResult();
        }
        [SecuredOperation("color.remove,admin")]
        [TransactionScopeAspect]
        [CacheRemoveAspect("IColorService.Get")]
        public IResult RemoveRange(IEnumerable<Color> colors)
        {
            var result = BusinessRules.Run();
            if (!result.Success)
            {
                return result;
            }

            _colorDal.RemoveRange(colors);
            _colorDal.SaveChanges();

            return new SuccessResult();
        }
        [SecuredOperation("color.update,admin")]
        [TransactionScopeAspect]
        [CacheRemoveAspect("IColorService.Get")]
        public IResult Update(Color color)
        {
            var result = BusinessRules.Run();
            if (!result.Success)
            {
                return result;
            }

            _colorDal.Update(color);
            _colorDal.SaveChanges();

            return new SuccessResult();
        }
        [SecuredOperation("color.update,admin")]
        [TransactionScopeAspect]
        [CacheRemoveAspect("IColorService.Get")]
        public IResult UpdateRange(IEnumerable<Color> colors)
        {
            var result = BusinessRules.Run();
            if (!result.Success)
            {
                return result;
            }

            _colorDal.UpdateRange(colors);
            _colorDal.SaveChanges();

            return new SuccessResult();
        }
    }
}
