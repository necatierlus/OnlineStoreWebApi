﻿using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using OnlineStore.Business.Contracts;
using OnlineStore.Core.Common.Contracts.RequestMessages;
using OnlineStore.Core.Common.Contracts.ResponseMessages;

namespace OnlineStore.ServiceHost.API.Controllers
{
    public class CategoryController : ApiController
    {
        private readonly ICategoryEngine _categoryEngine;

        public CategoryController(ICategoryEngine categoryEngine)
        {
            _categoryEngine = categoryEngine;
        }

        public Task<CategoryResponse> Get(int id)
        {
            return _categoryEngine.GetAsync(id);
        }

        public Task<CategoryResponse> Post([FromBody] CategoryCreateRequest categoryCreateRequest)
        {
            return _categoryEngine.CreateAsync(categoryCreateRequest);
        }

        public Task<CategoryResponse> Put([FromBody] CategoryUpdateRequest categoryUpdateRequest)
        {
            return _categoryEngine.UpdateAsync(categoryUpdateRequest);
        }

        public Task Delete(int id)
        {
            return _categoryEngine.DeleteAsync(id);
        }

        public Task<List<CategoryResponse>> Get(int skip, int take)
        {
            return _categoryEngine.GetAllAsync(skip, take);
        }
    }
}