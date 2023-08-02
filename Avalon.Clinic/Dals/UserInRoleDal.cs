using System;
using System.Linq;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;
using MySqlConnector;
using Avalon.Clinic.Models;

namespace Avalon.Clinic.Dals {
    public class UserInRoleDal : BaseDal {
        public List<UserInRole> GetAll() {
            List<UserInRole> results = new List<UserInRole>();
            using (var connection = new MySqlConnection(ConnectionString)) {
                connection.Open();
                string query = @"Select  id,user_id,role_id,active,create_date,modifiel_date,remark  From  user_in_role";
                results = connection.Query<UserInRole>(query).ToList();
                connection.Close();
            }
            return results;
        }

        public async Task<IEnumerable<UserInRole>> GetAllAsync() {
            IEnumerable<UserInRole> results = null;
            using (var connection = new MySqlConnection(ConnectionString)) {
                await connection.OpenAsync();
                string query = @"Select  id,user_id,role_id,active,create_date,modifiel_date,remark  From  user_in_role limit 10";
                results = await connection.QueryAsync<UserInRole>(query);
                connection.CloseAsync();
            }
            return results;
        }

        public int Insert(UserInRole data) {
            using (var connection = new MySqlConnection(ConnectionString)) {
                connection.Open();
                string sql = @"Insert into  user_in_role ( id,user_id,role_id,active,create_date,modifiel_date,remark )
                                                          values( @id,@user_id,@role_id,@active,@create_date,@modifiel_date,@remark )
                            ";
                var affectedRows = connection.Execute(sql, new {
                    id = data.id,
                    user_id = data.user_id,
                    role_id = data.role_id,
                    active = data.active,
                    create_date = data.create_date,
                    modifiel_date = data.modifiel_date,
                    remark = data.remark
                }
);
                connection.Close();
                return affectedRows;
            }
        }

        public async Task<int> InsertAsync(UserInRole data) {
            using (var connection = new MySqlConnection(ConnectionString)) {
                await connection.OpenAsync();
                string sql = @"Insert into  user_in_role ( id,user_id,role_id,active,create_date,modifiel_date,remark )
                                                                  values( @id,@user_id,@role_id,@active,@create_date,@modifiel_date,@remark )
                                    ";
                var affectedRows = await connection.ExecuteAsync(sql, new {
                    id = data.id,
                    user_id = data.user_id,
                    role_id = data.role_id,
                    active = data.active,
                    create_date = data.create_date,
                    modifiel_date = data.modifiel_date,
                    remark = data.remark
                }
);
                await connection.CloseAsync();
                return affectedRows;
            }
        }


        public int Update(UserInRole data) {
            using (var connection = new MySqlConnection(ConnectionString)) {
                connection.Open();
                string sql = @"Update  user_in_role set  id=@id,user_id=@user_id,role_id=@role_id,active=@active,create_date=@create_date,modifiel_date=@modifiel_date,remark=@remark  where Id=@Id";
                var affectedRows = connection.Execute(sql, new {
                    id = data.id,
                    user_id = data.user_id,
                    role_id = data.role_id,
                    active = data.active,
                    create_date = data.create_date,
                    modifiel_date = data.modifiel_date,
                    remark = data.remark
                }
);
                connection.Close();
                return affectedRows;
            }
        }

        public async Task<int> UpdateAsync(UserInRole data) {
            using (var connection = new MySqlConnection(ConnectionString)) {
                await connection.OpenAsync();
                string sql = @"Update  user_in_role set  id=@id,user_id=@user_id,role_id=@role_id,active=@active,create_date=@create_date,modifiel_date=@modifiel_date,remark=@remark  where Id=@Id";
                var affectedRows = await connection.ExecuteAsync(sql, new {
                    id = data.id,
                    user_id = data.user_id,
                    role_id = data.role_id,
                    active = data.active,
                    create_date = data.create_date,
                    modifiel_date = data.modifiel_date,
                    remark = data.remark
                }
);
                await connection.CloseAsync();
                return affectedRows;
            }
        }

        public int Delete(long Id) {
            using (var connection = new MySqlConnection(ConnectionString)) {
                connection.Open();
                string sql = @"Delete from  user_in_role Where Id = @Id";
                var affectedRows = connection.Execute(sql, new { Id = Id });
                connection.Close();
                return affectedRows;
            }
        }

        public async Task<int> DeleteAsync(long Id) {
            using (var connection = new MySqlConnection(ConnectionString)) {
                await connection.OpenAsync();
                string sql = @"Delete from  user_in_role Where Id = @Id";
                var affectedRows = await connection.ExecuteAsync(sql, new { Id = Id });
                await connection.CloseAsync();
                return affectedRows;
            }
        }

        public UserInRole GetById(long Id) {
            using (var connection = new MySqlConnection(ConnectionString)) {
                connection.Open();
                string sql = @"Select  id,user_id,role_id,active,create_date,modifiel_date,remark  from  user_in_role Where Id = @Id";
                var result = connection.QueryFirst<UserInRole>(sql, new { Id = Id });
                connection.Close();
                return result;
            }
        }

        public async Task<UserInRole> GetByIdAsync(long Id) {
            using (var connection = new MySqlConnection(ConnectionString)) {
                await connection.OpenAsync();
                string sql = @"Select  id,user_id,role_id,active,create_date,modifiel_date,remark  from  user_in_role Where Id = @Id";
                var result = await connection.QueryFirstAsync<UserInRole>(sql, new { Id = Id });
                await connection.CloseAsync();
                return result;
            }
        }
        public  async Task<bool> ExitsUserInRoleByUserIdRoleIdAsync(int  user_id,int role_id) {
            using (var connection = new MySqlConnection(ConnectionString)) {
                await connection.OpenAsync();
                string sql = @"Select  id,user_id,role_id,active,create_date,modifiel_date,remark  from  user_in_role Where user_id = @user_id and role_id=@role_id";
                var result = await connection.QueryFirstOrDefaultAsync<UserInRole>(sql, new {@user_id = user_id ,@role_id=role_id});
                await connection.CloseAsync();
                return result != null;
            }
        }
    }
}