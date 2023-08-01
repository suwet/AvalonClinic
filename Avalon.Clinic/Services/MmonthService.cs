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
using Avalon.Clinic.ViewModels.M_monthVM;
using Avalon.Clinic.Models;

namespace Avalon.Clinic.Services
{
	public  class MmonthService : BaseService
	{
        private M_monthDal _M_monthDal = new M_monthDal();

        public override void ConfigMapForService()
        {
            // access the TheMapper
            //TheMapper
        }

        // BindingList
		public List<M_monthViewModel> GetAll()    
        {    
           try
           {
                var results = _M_monthDal.GetAll();
                var datas = TheMapper.Map<List<M_monthViewModel>>(results);
                return datas;
           }
           catch(Exception ex)
           {
                throw;
           }
        }    

        public int Add(M_month data)    
        {    
            try
           {
                return _M_monthDal.Insert(data);
           }
           catch(Exception ex)
           {
                throw;
           }
        }   
        
        public int Update(M_month data)    
        {    
            try
           {
                return _M_monthDal.Update(data);
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
                return _M_monthDal.Delete(Id);
           }
           catch(Exception ex)
           {
                throw;
           }
        }    

        public M_monthViewModel GetById(long Id)    
        {    
             try
           {
                var result = _M_monthDal.GetById(Id);
                return TheMapper.Map<M_monthViewModel>(result);
           }
           catch(Exception ex)
           {
                throw;
           }
        }    
	}
}
