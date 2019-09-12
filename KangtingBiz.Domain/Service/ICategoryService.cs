﻿using KangtingBiz.Domain.Models;
using KangtingBiz.Domain.Repository;
using KangtingBiz.Domain.Service.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KangtingBiz.Domain.Service
{
    public interface ICategoryService: IService<Category, ICategoryRepository>
    {
        IEnumerable<Category> GetCategories(string name);
    }
}
