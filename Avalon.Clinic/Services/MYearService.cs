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
using Avalon.Clinic.ViewModels.M_yearVM;
using Avalon.Clinic.Models;

namespace Avalon.Clinic.Services
{
	public  class MYearService : BaseService
	{
        private M_yearDal _m_yearDal = new M_yearDal();

        public override void ConfigMapForService()
        {
            // access the TheMapper
            //TheMapper
        }

        // BindingList
		public List<M_yearViewModel> GetAll()    
        {    
           try
           {
                var results = _m_yearDal.GetAll();
                var datas = TheMapper.Map<List<M_yearViewModel>>(results);
                return datas;
           }
           catch(Exception ex)
           {
                throw;
           }
        }    

        public int Add(M_year data)    
        {    
            try
           {
                return _m_yearDal.Insert(data);
           }
           catch(Exception ex)
           {
                throw;
           }
        }   
        
        public int Update(M_year data)    
        {    
            try
           {
                return _m_yearDal.Update(data);
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
                return _m_yearDal.Delete(Id);
           }
           catch(Exception ex)
           {
                throw;
           }
        }    

        public M_yearViewModel GetById(long Id)    
        {    
             try
           {
                var result = _m_yearDal.GetById(Id);
                return TheMapper.Map<M_yearViewModel>(result);
           }
           catch(Exception ex)
           {
                throw;
           }
        }    
	}
}
