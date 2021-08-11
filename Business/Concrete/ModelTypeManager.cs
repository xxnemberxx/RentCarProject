using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class ModelTypeManager : IModelTypeService
    {
        private IModelTypeDal _modelTypeDal;
        public ModelTypeManager(IModelTypeDal modelTypeDal)
        {
            _modelTypeDal = modelTypeDal;
        }

        public IResult Add(ModelType modelType)
        {
            _modelTypeDal.Add(modelType);
            return new SuccessResult(Message.Added);
        }

        public IResult Delete(ModelType modelType)
        {
            _modelTypeDal.Delete(modelType);
            return new SuccessResult(Message.Deleted);
        }

        public IDataResult<List<ModelType>> GetAll()
        {
            return new SuccessDataResult<List<ModelType>>(_modelTypeDal.GetAll(), Message.SelectedList);
        }

        public IResult Update(ModelType modelType)
        {
            _modelTypeDal.Update(modelType);
            return new SuccessResult(Message.Updated);
        }
    }
}
