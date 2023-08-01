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
using Avalon.Clinic.ViewModels.PatientVM;
using Avalon.Clinic.Models;

namespace Avalon.Clinic.Services.Patients
{
	public  class PatientService : BaseService
	{
        private PatientDal _PatientDal = new PatientDal();

        public override void ConfigMapForService()
        {
            // access the TheMapper
                
        }

        // BindingList
		public List<PatientViewModel> GetAll()    
        {    
           try
           {
                var results = _PatientDal.GetAll();
                var datas = TheMapper.Map<List<PatientViewModel>>(results);
                return datas;
           }
           catch(Exception ex)
           {
                throw;
           }
        }

        public async Task<List<PatientViewModel>> GetAllAsync() {
            try {
                var results = await Task.Run<List<Patient>>(() => _PatientDal.GetAll());
                return await Task.FromResult<List<PatientViewModel>>(TheMapper.Map<List<PatientViewModel>>(results));
            }
            catch (Exception ex) {
                throw;
            }
        }

        public async Task<List<PatientViewModel>> SearchAsync(string text) {
            try {
                //var results = await Task.Run<List<Patient>>(() => _PatientDal.Search(text));
                return await Task.FromResult<List<PatientViewModel>>(TheMapper.Map<List<PatientViewModel>>(await Task.Run<List<Patient>>(() => _PatientDal.Search(text))));
            }
            catch (Exception ex) {
                throw;
            }
        }

        public int Add(Patient data)    
        {    
            try
           {
                return _PatientDal.Insert(data);
           }
           catch(Exception ex)
           {
                throw;
           }
        }

        public async Task<int> Add(PatientViewModel data) {
            try {
                return await Task.Run<int>(() => _PatientDal.Insert(TheMapper.Map<Patient>(data)));
            }
            catch (Exception ex) {
                throw;
            }
        }

        public async Task<int> Update(PatientViewModel data) {
            try {
                return await Task.Run<int>(()=>_PatientDal.Update(TheMapper.Map<Patient>(data)));
            }
            catch (Exception ex) {
                throw;
            }
        }
        public int Update(Patient data)    
        {    
            try
           {
                return _PatientDal.Update(data);
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
                return _PatientDal.Delete(Id);
           }
           catch(Exception ex)
           {
                throw;
           }
        }

        public async Task<int> DeleteAsync(long Id) {
            try {
                return  _PatientDal.Delete(Id);
            }
            catch (Exception ex) {
                throw;
            }
        }

        public async Task<PatientViewModel> GetByIdAsync(long Id)    
        {    
             try
           {
               return await Task.FromResult<PatientViewModel>(TheMapper.Map<PatientViewModel>(await _PatientDal.GetByIdAsync(Id)));
           }
           catch(Exception ex)
           {
                throw;
           }
        }    
	}
}
