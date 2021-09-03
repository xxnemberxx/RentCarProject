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
    public class ModelManager : IModelService
    {
        private IModelDal _modelDal;
        public ModelManager(IModelDal modelDal)
        {
            _modelDal = modelDal;
        }
        [SecuredOperation("model.add,admin")]
        //[TransactionScopeAspect]
        [CacheRemoveAspect("IModelService.Get")]
        public async Task<IResult> AddAsync(Model model)
        {
            var result = BusinessRules.Run();
            if (!result.Success)
            {
                return result;
            }

            await _modelDal.AddAsync(model);
            await _modelDal.SaveChangesAsync();

            return new SuccessResult();
        }

        [SecuredOperation("model.add,admin")]
        [TransactionScopeAspect]
        [CacheRemoveAspect("IModelService.Get")]
        public async Task<IResult> AddRangeAsync(IEnumerable<Model> models)
        {
            var result = BusinessRules.Run();
            if (!result.Success)
            {
                return result;
            }

            await _modelDal.AddRangeAsync(models);
            await _modelDal.SaveChangesAsync();

            return new SuccessResult();
        }
    
        [CacheAspect]
        public async Task<IDataResult<IEnumerable<Model>>> GetAllAsync()
        {
            var result = BusinessRules.Run();
            if (!result.Success)
            {
                return new ErrorDataResult<IEnumerable<Model>>(result.Message);
            }

            return new SuccessDataResult<IEnumerable<Model>>
                (await _modelDal.GetAllAsync());
        }

        [CacheAspect]
        public async ValueTask<IDataResult<Model>> GetByIdAsync(short modelId)
        {
            var result = BusinessRules.Run();
            if (!result.Success)
            {
                return new ErrorDataResult<Model>(result.Message);
            }

            return new SuccessDataResult<Model>
                (await _modelDal.GetByIdAsync<short>(modelId));

        }

        [SecuredOperation("model.remove,admin")]
        [TransactionScopeAspect]
        [CacheRemoveAspect("IModelService.Get")]
        public IResult Remove(Model model)
        {
            var result = BusinessRules.Run();
            if (!result.Success)
            {
                return result;
            }

            _modelDal.Remove(model);
            _modelDal.SaveChanges();

            return new SuccessResult();
        }

        [SecuredOperation("model.remove,admin")]
        [TransactionScopeAspect]
        [CacheRemoveAspect("IModelService.Get")]
        public IResult RemoveRange(IEnumerable<Model> models)
        {
            var result = BusinessRules.Run();
            if (!result.Success)
            {
                return result;
            }

            _modelDal.RemoveRange(models);
            _modelDal.SaveChanges();

            return new SuccessResult();
        }

        [SecuredOperation("model.update,admin")]
        [TransactionScopeAspect]
        [CacheRemoveAspect("IModelService.Get")]
        public IResult Update(Model model)
        {
            var result = BusinessRules.Run();
            if (!result.Success)
            {
                return result;
            }

            _modelDal.Update(model);
            _modelDal.SaveChanges();

            return new SuccessResult();
        }

        [SecuredOperation("model.update,admin")]
        [TransactionScopeAspect]
        [CacheRemoveAspect("IModelService.Get")]
        public IResult UpdateRange(IEnumerable<Model> models)
        {
            var result = BusinessRules.Run();
            if (!result.Success)
            {
                return result;
            }

            _modelDal.UpdateRange(models);
            _modelDal.SaveChanges();

            return new SuccessResult();
        }
    }
}
