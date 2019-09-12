using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KangtingBiz.Domain.BizValidation;
using KangtingBiz.Domain.Models.Base;
using KangtingBiz.Domain.Repository;

namespace KangtingBiz.Domain.Service.Base
{
    public abstract class DomainService<T,TRepository> : IService<T, TRepository>
        where T:EntityBase<int>   
        where TRepository:IRepository<T>
    {
        protected TRepository _repository; 
        public DomainService(TRepository repository )
        {
            _repository = repository; 
        }       
        
        public TRepository DomainRepository
        {
            get { return _repository; }
        }

        public Validation Add(T entity)
        {
            var validation = entity.Validate();
            if (!(validation.GetRules().Count() > 0))
                _repository.Add(entity);
            return validation;
        }

        public Validation Delete(int id)
        {
            var entity = _repository.FindByID(id);
            var validation = ValidateExistingEntity(entity);
            if (!(validation.GetRules().Count() > 0))
                _repository.Delete(entity);
            return validation;
        }

        public T Get(int id)
        {
            T entity = _repository.FindByID(id);
            return entity ;
        }

        public IEnumerable<T> GetAll()
        {
            var list = _repository.FindAll();
            return list; 
        }

        public Validation Update(T entity)
        {
            var validation = entity.Validate();
            if (!(validation.GetRules().Count() > 0))
                _repository.Update(entity);
            return validation;
        }

        protected Validation ValidateExistingEntity(T entity)
        {
            Validation validation = new Validation();

            if (entity == null)
            {
                validation.AddRule(new ValidationRule(""));
            }
            return validation;
        }
    }
}
