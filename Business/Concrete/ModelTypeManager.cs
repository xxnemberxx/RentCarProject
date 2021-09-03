using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.Constants;
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
    public class ModelTypeManager : IModelTypeService
    {
        private IModelTypeDal _modelTypeDal;
        public ModelTypeManager(IModelTypeDal modelTypeDal)
        {
            _modelTypeDal = modelTypeDal;
        }

        [SecuredOperation("modeltype.add,admin")]
        //[TransactionScopeAspect]
        [CacheRemoveAspect("IModelTypeService.Get")]
        public async Task<IResult> AddAsync(ModelType modelType)
        {
            var result = BusinessRules.Run();
            if (!result.Success)
            {
                return result;
            }

            await _modelTypeDal.AddAsync(modelType);
            await _modelTypeDal.SaveChangesAsync();

            return new SuccessResult();
        }

        [SecuredOperation("modeltype.add,admin")]
        //[TransactionScopeAspect]
        [CacheRemoveAspect("IModelTypeService.Get")]
        public async Task<IResult> AddRangeAsync(IEnumerable<ModelType> modelTypes)
        {
            var result = BusinessRules.Run();
            if (!result.Success)
            {
                return result;
            }

            await _modelTypeDal.AddRangeAsync(modelTypes);
            await _modelTypeDal.SaveChangesAsync();

            return new SuccessResult();
        }

        [CacheAspect]
        public async Task<IDataResult<IEnumerable<ModelType>>> GetAllAsync()
        {
            var result = BusinessRules.Run();
            if (!result.Success)
            {
                return new ErrorDataResult<IEnumerable<ModelType>>(result.Message);
            }

            return new SuccessDataResult<IEnumerable<ModelType>>
                (await _modelTypeDal.GetAllAsync());
        }

        [CacheAspect]
        public async ValueTask<IDataResult<ModelType>> GetByIdAsync(byte typeId)
        {
            var result = BusinessRules.Run();
            if (!result.Success)
            {
                return new ErrorDataResult<ModelType>(result.Message);
            }

            return new SuccessDataResult<ModelType>
                (await _modelTypeDal.GetByIdAsync<byte>(typeId));
        }

        [SecuredOperation("modeltype.remove,admin")]
        [TransactionScopeAspect]
        [CacheRemoveAspect("IModelTypeService.Get")]
        public IResult Remove(ModelType modelType)
        {
            var result = BusinessRules.Run();
            if (!result.Success)
            {
                return result;
            }

            _modelTypeDal.Remove(modelType);
            _modelTypeDal.SaveChanges();

            return new SuccessResult();
        }

        [SecuredOperation("modeltype.remove,admin")]
        [TransactionScopeAspect]
        [CacheRemoveAspect("IModelTypeService.Get")]
        public IResult RemoveRange(IEnumerable<ModelType> modelTypes)
        {
            var result = BusinessRules.Run();
            if (!result.Success)
            {
                return result;
            }

            _modelTypeDal.RemoveRange(modelTypes);
            _modelTypeDal.SaveChanges();

            return new SuccessResult();
        }

        [SecuredOperation("modeltype.update,admin")]
        [TransactionScopeAspect]
        [CacheRemoveAspect("IModelTypeService.Get")]
        public IResult Update(ModelType modelType)
        {
            var result = BusinessRules.Run();
            if (!result.Success)
            {
                return result;
            }

            _modelTypeDal.Update(modelType);
            _modelTypeDal.SaveChanges();

            return new SuccessResult();
        }

        [SecuredOperation("modeltype.update,admin")]
        [TransactionScopeAspect]
        [CacheRemoveAspect("IModelTypeService.Get")]
        public IResult UpdateRange(IEnumerable<ModelType> modelTypes)
        {
            var result = BusinessRules.Run();
            if (!result.Success)
            {
                return result;
            }

            _modelTypeDal.RemoveRange(modelTypes);
            _modelTypeDal.SaveChanges();

            return new SuccessResult();
        }
    }
}
