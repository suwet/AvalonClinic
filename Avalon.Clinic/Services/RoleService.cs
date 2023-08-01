using System;
using System.Linq;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;
using ReactiveUI;
using Dapper;
using Avalon.Clinic.Services;
using Avalon.Clinic.Dals;
using Avalon.Clinic.ViewModels.RoleVM;
using Avalon.Clinic.Models;

namespace Avalon.Models
{
	public  class RoleService : BaseService
	{
        private RoleDal _RoleDal = new RoleDal();

        public override void ConfigMapForService()
        {
            // access the TheMapper
            //TheMapper
        }

		public List<RolesViewModel> GetAll()    
        {    
           try
           {
                var results = _RoleDal.GetAll();
                var datas = TheMapper.Map<List<RolesViewModel>>(results);
                return datas;
           }
           catch(Exception ex)
           {
                throw;
           }
        }    
        
        public async Task<IEnumerable<RolesViewModel>> GetAllAsync()    
        {    
                   try
                   {
                        var results = await _RoleDal.GetAllAsync();
                        var datas = await Task.FromResult(TheMapper.Map<List<RolesViewModel>>(results));
                        return datas;
                   }
                   catch(Exception ex)
                   {
                        throw;
                   }
        }    

        public int Add(RolesViewModel data)    
        {    
            try
           {
                return _RoleDal.Insert(TheMapper.Map<Roles>(data));
           }
           catch(Exception ex)
           {
                throw;
           }
        }   
        
         public async Task<int> AddAsync(RolesViewModel data)    
         {    
                    try
                   {
                        return await _RoleDal.InsertAsync(TheMapper.Map<Roles>(data));
                   }
                   catch(Exception ex)
                   {
                        throw;
                   }
         }   
        
        public int Update(RolesViewModel data)    
        {    
            try
           {
                return _RoleDal.Update(TheMapper.Map<Roles>(data));
           }
           catch(Exception ex)
           {
                throw;
           }
        }  
        
         public async Task<int> UpdateAsync(RolesViewModel data)    
         {    
                    try
                   {
                        return await _RoleDal.UpdateAsync(TheMapper.Map<Roles>(data));
                   }
                   catch(Exception ex)
                   {
                        throw;
                   }
         }  
        
        public int Delete(long Id)    
        {    
            try
           {
                return _RoleDal.Delete(Id);
           }
           catch(Exception ex)
           {
                throw;
           }
        }    
        
         public async Task<int> DeleteAsync(long Id)    
         {    
                    try
                   {
                        return await _RoleDal.DeleteAsync(Id);
                   }
                   catch(Exception ex)
                   {
                        throw;
                   }
         }    

        public RolesViewModel GetById(long Id)    
        {    
             try
           {
                var result = _RoleDal.GetById(Id);
                return TheMapper.Map<RolesViewModel>(result);
           }
           catch(Exception ex)
           {
                throw;
           }
        }    
        
         public async Task<RolesViewModel> GetByIdAsync(long Id)    
                {    
                     try
                   {
                        var result = await _RoleDal.GetByIdAsync(Id);
                        return await Task.FromResult(TheMapper.Map<RolesViewModel>(result));
                   }
                   catch(Exception ex)
                   {
                        throw;
                   }
                }    
	}
}
