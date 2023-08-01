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
using Avalon.Clinic.ViewModels.M_dayVM;
using Avalon.Clinic.Models;

namespace Avalon.Clinic.Services
{
	public  class MdayService : BaseService
	{
        private M_dayDal _M_dayDal = new M_dayDal();

        public override void ConfigMapForService()
        {
            // access the TheMapper
            //TheMapper
        }

        // BindingList
		public List<M_dayViewModel> GetAll()    
        {    
           try
           {
                var results = _M_dayDal.GetAll();
                var datas = TheMapper.Map<List<M_dayViewModel>>(results);
                return datas;
           }
           catch(Exception ex)
           {
                throw;
           }
        }    

        public int Add(M_day data)    
        {    
            try
           {
                return _M_dayDal.Insert(data);
           }
           catch(Exception ex)
           {
                throw;
           }
        }   
        
        public int Update(M_day data)    
        {    
            try
           {
                return _M_dayDal.Update(data);
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
                return _M_dayDal.Delete(Id);
           }
           catch(Exception ex)
           {
                throw;
           }
        }    

        public M_dayViewModel GetById(long Id)    
        {    
             try
           {
                var result = _M_dayDal.GetById(Id);
                return TheMapper.Map<M_dayViewModel>(result);
           }
           catch(Exception ex)
           {
                throw;
           }
        }    
	}
}
