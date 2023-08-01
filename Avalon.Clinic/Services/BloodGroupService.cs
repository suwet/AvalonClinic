using System;
using System.Linq;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;
using ReactiveUI;
using Dapper;
using Avalon.Clinic.Dals;
using Avalon.Clinic.ViewModels.BloodGroupVM;
using Avalon.Clinic.Models;

namespace Avalon.Clinic.Services.BloodGroups
{
	public  class BloodGroupService : BaseService
	{
        private BloodGroupDal _BloodGroupDal = new BloodGroupDal();

        public override void ConfigMapForService()
        {
            // access the TheMapper
            //TheMapper
        }

        // BindingList
		public List<BloodGroupViewModel> GetAll()    
        {    
           try
           {
                var results = _BloodGroupDal.GetAll();
                var datas = TheMapper.Map<List<BloodGroupViewModel>>(results);
                return datas;
           }
           catch(Exception ex)
           {
                throw;
           }
        }    

        public int Add(BloodGroup data)    
        {    
            try
           {
                return _BloodGroupDal.Insert(data);
           }
           catch(Exception ex)
           {
                throw;
           }
        }   
        
        public int Update(BloodGroup data)    
        {    
            try
           {
                return _BloodGroupDal.Update(data);
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
                return _BloodGroupDal.Delete(Id);
           }
           catch(Exception ex)
           {
                throw;
           }
        }    

        public BloodGroupViewModel GetById(long Id)    
        {    
             try
           {
                var result = _BloodGroupDal.GetById(Id);
                return TheMapper.Map<BloodGroupViewModel>(result);
           }
           catch(Exception ex)
           {
                throw;
           }
        }    
	}
}
