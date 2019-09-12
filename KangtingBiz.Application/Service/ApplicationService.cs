using KangtingBiz.Domain.BizValidation;
using KangtingBiz.Domain.Models.Base;
using KangtingBiz.Domain.Repository;
using KangtingBiz.Domain.Service;
using KangtingBiz.Domain.Service.Base;
using KangtingBiz.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KangtingBiz.Application.Service
{
    public class ApplicationService<T, TRepository, TService> :IApplicationService<T>
        where T: EntityBase<int>
        where TRepository : IRepository<T>
        where TService: IService<T, TRepository>
    {
        protected IUnitOfWork _uow;
        protected Validation _validation;
        protected TService _service;
        //private ICategoryService categoryService;
        //private IUnitOfWork uow;

        public ApplicationService(TService service,IUnitOfWork uow)
        {
            _service = service;
            _uow = uow;
            _uow.RegisterRepository((IUnitOfWorkRepository)_service.DomainRepository);
            _validation = new Validation();
        }

        public Validation Create(T entity)
        {
            _validation = _service.Add(entity);
            UowCommit();
            return _validation;
        }

        public T Details(int id)
        {
            var entity = _service.Get(id);
            return entity;
        }

        public IEnumerable<T> ListAll()
        {
            var entities = _service.GetAll();
            return entities; 
        }

        public Validation Remove(int id)
        {
            _validation = _service.Delete(id);
            UowCommit();
            return _validation;
        }

        public Validation Update(T entity)
        {
            _validation = _service.Update(entity);
            UowCommit();
            return _validation;
        }

        protected void UowCommit() {
            if (!(_validation.GetRules().Count() > 0))
                _uow.Commit();
        }
    }
}
