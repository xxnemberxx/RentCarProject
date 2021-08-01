using Business.Abstract;
using Business.Constants;
using Core.Utilities;
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
        public IDataResult<List<ModelType>> GetAll()
        {
            return new SuccessDataResult<List<ModelType>>(_modelTypeDal.GetAll(), Message.SelectedList);
        }
    }
}
