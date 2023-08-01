using System;
using System.Linq;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;
using Avalon.Clinic.Models;
using MySqlConnector;

namespace Avalon.Clinic.Dals 
{
	public  class UserDal : BaseDal
	{
		public List<UsersModel> GetAll()    
        {    
            List<UsersModel> results = new List<UsersModel>();    
            using (var connection = new MySqlConnection(ConnectionString))    
            {    
                connection.Open();    
                string query = @"Select r.id,r.username,r.password,r.password_sha,r.password_hash,r.firstname,r.lastname,r.email,r.active,r.created_date,r.modifield_date,r.remark 
,(SELECT EXISTS(select ur.user_id from user_in_role ur join roles ro on ur.role_id=ro.id WHERE ur.user_id=r.id and ur.role_id=3 limit 1)) as isadmin 
,(SELECT EXISTS(select ur.user_id from user_in_role ur join roles ro on ur.role_id=ro.id WHERE ur.user_id=r.id and ur.role_id=4 limit 1)) as isaccount 
 from users r";
                results = connection.Query<UsersModel>(query).ToList();    
                connection.Close();    
            }    
            return results;    
        }    
        
        public async Task<IEnumerable<UsersModel>> GetAllAsync()    
        {    
                    IEnumerable<UsersModel> results = null;   
                    using (var connection = new MySqlConnection(ConnectionString))    
                    {    
                        await connection.OpenAsync();    
                        string query = @"Select r.id,r.username,r.password,r.password_sha,r.password_hash,r.firstname,r.lastname,r.email,r.active,r.created_date,r.modifield_date,r.remark 
,(SELECT EXISTS(select ur.user_id from user_in_role ur join roles ro on ur.role_id=ro.id WHERE ur.user_id=r.id and ur.role_id=3 limit 1)) as isadmin 
,(SELECT EXISTS(select ur.user_id from user_in_role ur join roles ro on ur.role_id=ro.id WHERE ur.user_id=r.id and ur.role_id=4 limit 1)) as isaccount 
 from users r";
                        results = await connection.QueryAsync<UsersModel>(query);    
                        connection.CloseAsync();    
                    }    
                    return results;    
        }    

        public int Insert(UsersModel data)    
        {    
            using (var connection = new MySqlConnection(ConnectionString))    
            {    
                connection.Open(); 
                string sql = @"Insert into users ( id,username,password,password_sha,password_hash,firstname,lastname,email,active,created_date,modifield_date,remark )
                                                          values( @id,@username,@password,@password_sha,@password_hash,@firstname,@lastname,@email,@active,@created_date,@modifield_date,@remark )
                            ";
                var affectedRows = connection.Execute(sql,new { 
id=data.id,username=data.username,password=data.password,password_sha=data.password_sha,password_hash=data.password_hash,firstname=data.firstname,lastname=data.lastname,email=data.email,active=data.active,created_date=data.created_date,modifield_date=data.modifield_date,remark=data.remark } 
);    
                connection.Close();    
                return affectedRows;    
            }    
        }   
        
         public async Task<int> InsertAsync(UsersModel data)    
                {    
                    using (var connection = new MySqlConnection(ConnectionString))    
                    {    
                        await connection.OpenAsync(); 
                        string sql = @"Insert into users (username,password,firstname,lastname,email,active,remark )
                                                                  values(@username,@password,@firstname,@lastname,@email,@active,@remark )
                                    ";
                        var affectedRows = await connection.ExecuteAsync(sql,new { 
username=data.username,password=data.password,firstname=data.firstname,lastname=data.lastname,email=data.email,active=data.active,remark=data.remark } 
);    
                        await connection.CloseAsync();    
                        return affectedRows;    
                    }    
                }   
                
        
        public int Update(UsersModel data)    
        {    
            using (var connection = new MySqlConnection(ConnectionString))    
            {    
                connection.Open();    
                string sql = @"Update users set username=@username,password=@password,firstname=@firstname,lastname=@lastname,email=@email,active=@active,modifield_date=@modifield_date,remark=@remark  where Id=@Id";
                var affectedRows = connection.Execute(sql,new { 
id=data.id,username=data.username,password=data.password,firstname=data.firstname,lastname=data.lastname,email=data.email,active=data.active,modifield_date=data.modifield_date,remark=data.remark } 
);    
                connection.Close();    
                return affectedRows;    
            }    
        }  
        
          public async Task<int> UpdateAsync(UsersModel data)    
                {    
                    using (var connection = new MySqlConnection(ConnectionString))    
                    {    
                        await connection.OpenAsync();    
                        string sql = @"Update users set  username=@username,password=@password,firstname=@firstname,lastname=@lastname,email=@email,active=@active,modifield_date=@modifield_date,remark=@remark  where Id=@Id";
                        var affectedRows = await connection.ExecuteAsync(sql,new { 
id=@data.id,username=data.username,password=data.password,firstname=data.firstname,lastname=data.lastname,email=data.email,active=data.active,modifield_date=data.modifield_date,remark=data.remark } 
);    
                        await connection.CloseAsync();    
                        return affectedRows;    
                    }    
                }  
        
        public int Delete(long Id)    
        {    
            using (var connection = new MySqlConnection(ConnectionString))    
            {    
                connection.Open();    
                string sql = @"Delete from users Where Id = @Id";
                var affectedRows = connection.Execute(sql, new {Id = Id });    
                connection.Close();    
                return affectedRows;    
            }    
        }    
        
        public async Task<int> DeleteAsync(long Id)    
        {    
           using (var connection = new MySqlConnection(ConnectionString))    
           {    
                        await connection.OpenAsync();    
                        string sql = @"Delete from users Where Id = @Id";
                        var affectedRows = await connection.ExecuteAsync(sql, new {Id = Id });    
                        await connection.CloseAsync();    
                        return affectedRows;    
           }    
        }    

        public UsersModel GetById(long Id)    
        {    
            using (var connection = new MySqlConnection(ConnectionString))    
            {    
                connection.Open();    
                string sql = @"Select r.id,r.username,r.password,r.password_sha,r.password_hash,r.firstname,r.lastname,r.email,r.active,r.created_date,r.modifield_date,r.remark 
,(SELECT EXISTS(select ur.user_id from user_in_role ur join roles ro on ur.role_id=ro.id WHERE ur.user_id=r.id and ur.role_id=3 limit 1)) as isadmin 
,(SELECT EXISTS(select ur.user_id from user_in_role ur join roles ro on ur.role_id=ro.id WHERE ur.user_id=r.id and ur.role_id=4 limit 1)) as isaccount 
 from users r
Where r.id = @Id";
                var result  = connection.QueryFirst<UsersModel>(sql, new {id = Id });    
                connection.Close();    
                return result;    
            }    
        }    
        
         public async Task<UsersModel> GetByIdAsync(long Id)    
                {    
                    using (var connection = new MySqlConnection(ConnectionString))    
                    {    
                        await connection.OpenAsync();    
                        string sql = @"Select r.id,r.username,r.password,r.password_sha,r.password_hash,r.firstname,r.lastname,r.email,r.active,r.created_date,r.modifield_date,r.remark 
,(SELECT EXISTS(select ur.user_id from user_in_role ur join roles ro on ur.role_id=ro.id WHERE ur.user_id=r.id and ur.role_id=3 limit 1)) as isadmin 
,(SELECT EXISTS(select ur.user_id from user_in_role ur join roles ro on ur.role_id=ro.id WHERE ur.user_id=r.id and ur.role_id=4 limit 1)) as isaccount 
 from users r
Where r.id = @Id";
                        var result  = await connection.QueryFirstAsync<UsersModel>(sql, new {id = Id });    
                        await connection.CloseAsync();    
                        return result;    
                    }    
                }    
	}
}
