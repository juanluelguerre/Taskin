// -------------------------------------------------------------------
// <copyright Author="Juan Luis Guerrero Minero" www="elGuerre.com">
//     Copyright (c) elGuerre.com. All rights reserved.
// </copyright>
// -------------------------------------------------------------------
using ElGuerre.Taskin.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ElGuerre.Taskin.Api.Services
{
    public interface IBaseService<TModel, Tkey> where TModel : class, IModel<Tkey>
    {            
        Task<TModel> GetAsync(Tkey id);
        Task<IEnumerable<TModel>> GetAsync();
        Task<TModel> AddAsync(TModel model);
        Task<TModel> UpdateAsync(TModel model);
        Task DeleteAsync(TModel model);
        Task<bool> ExistsAsync(Tkey id);
    }
}