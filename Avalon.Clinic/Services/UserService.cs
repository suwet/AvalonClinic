using System;
using System.Linq;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;
using Avalon.Clinic.Dals;
using Avalon.Clinic.Models;
using Avalon.Clinic.ViewModels.UsersVM;
using ReactiveUI;
using Dapper;

namespace Avalon.Clinic.Services {
    public class UserService : BaseService {
        private UserDal _UserDal = new UserDal();

        public override void ConfigMapForService() {
            // access the TheMapper
            //TheMapper
        }

        public List<UsersViewModel> GetAll() {
            try {
                var results = _UserDal.GetAll();
                var datas = TheMapper.Map<List<UsersViewModel>>(results);
                return datas;
            }
            catch (Exception ex) {
                throw;
            }
        }

        public async Task<IEnumerable<UsersViewModel>> GetAllAsync() {
            try {
                var results = await _UserDal.GetAllAsync();
                var datas = await Task.FromResult(TheMapper.Map<List<UsersViewModel>>(results));
                return datas;
            }
            catch (Exception ex) {
                throw;
            }
        }

        public int Add(UsersModel data) {
            try {
                return _UserDal.Insert(data);
            }
            catch (Exception ex) {
                throw;
            }
        }
        
        public async Task<int> AddAsync(UsersViewModel data) {
            try {
                return await _UserDal.InsertAsync(TheMapper.Map<UsersModel>(data));
            }
            catch (Exception ex) {
                throw;
            }
        }
        
        public async Task<int> AddAsync(UsersModel data) {
            try {
                return await _UserDal.InsertAsync(data);
            }
            catch (Exception ex) {
                throw;
            }
        }

        public int Update(UsersModel data) {
            try {
                return _UserDal.Update(data);
            }
            catch (Exception ex) {
                throw;
            }
        }

        public async Task<int> UpdateAsync(UsersViewModel data) {
            try {
                data.modifield_date = DateTime.Now;
                return await _UserDal.UpdateAsync(TheMapper.Map<UsersModel>(data));
            }
            catch (Exception ex) {
                throw;
            }
        }
        public async Task<int> UpdateAsync(UsersModel data) {
            try {
                return await _UserDal.UpdateAsync(data);
            }
            catch (Exception ex) {
                throw;
            }
        }

        public int Delete(long Id) {
            try {
                return _UserDal.Delete(Id);
            }
            catch (Exception ex) {
                throw;
            }
        }

        public async Task<int> DeleteAsync(long Id) {
            try {
                return await _UserDal.DeleteAsync(Id);
            }
            catch (Exception ex) {
                throw;
            }
        }

        public UsersViewModel GetById(long Id) {
            try {
                var result = _UserDal.GetById(Id);
                return TheMapper.Map<UsersViewModel>(result);
            }
            catch (Exception ex) {
                throw;
            }
        }

        public async Task<UsersViewModel> GetByIdAsync(long Id) {
            try {
                var result = await _UserDal.GetByIdAsync(Id);
                return await Task.FromResult(TheMapper.Map<UsersViewModel>(result));
            }
            catch (Exception ex) {
                throw;
            }
        }
    }
}
