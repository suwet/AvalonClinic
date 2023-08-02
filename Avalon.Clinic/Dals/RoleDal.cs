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
	public  class RoleDal : BaseDal
	{
		public List<Roles> GetAll()    
        {    
            List<Roles> results = new List<Roles>();    
            using (var connection = new MySqlConnection(ConnectionString))    
            {    
                connection.Open();    
                string query = @"Select  id,role_name,active,remark  From roles";
                results = connection.Query<Roles>(query).ToList();    
                connection.Close();    
            }    
            return results;    
        }    
        
        public async Task<IEnumerable<Roles>> GetAllAsync()    
        {    
                    IEnumerable<Roles> results = null;   
                    using (var connection = new MySqlConnection(ConnectionString))    
                    {    
                        await connection.OpenAsync();    
                        string query = @"Select  id,role_name,active,remark  From roles limit 10";
                        results = await connection.QueryAsync<Roles>(query);    
                        connection.CloseAsync();    
                    }    
                    return results;    
        }    

        public int Insert(Roles data)    
        {    
            using (var connection = new MySqlConnection(ConnectionString))    
            {    
                connection.Open(); 
                string sql = @"Insert into roles ( id,role_name,active,remark )
                                                          values( @id,@role_name,@active,@remark )
                            ";
                var affectedRows = connection.Execute(sql,new { 
id=data.id,role_name=data.role_name,active=data.active,remark=data.remark } 
);    
                connection.Close();    
                return affectedRows;    
            }    
        }   
        
         public async Task<int> InsertAsync(Roles data)    
                {    
                    using (var connection = new MySqlConnection(ConnectionString))    
                    {    
                        await connection.OpenAsync(); 
                        string sql = @"Insert into roles (role_name,active,remark )
                                                                  values(@role_name,@active,@remark )
                                    ";
                        var affectedRows = await connection.ExecuteAsync(sql,new { 
role_name=data.role_name,active=data.active,remark=data.remark } 
);    
                        await connection.CloseAsync();    
                        return affectedRows;    
                    }    
                }   
                
        
        public int Update(Roles data)    
        {    
            using (var connection = new MySqlConnection(ConnectionString))    
            {    
                connection.Open();    
                string sql = @"Update roles set role_name=@role_name,active=@active,remark=@remark  where Id=@Id";
                var affectedRows = connection.Execute(sql,new {
                    id = data.id,
                    role_name =data.role_name,active=data.active,remark=data.remark } );    
                connection.Close();    
                return affectedRows;    
            }    
        }  
        
          public async Task<int> UpdateAsync(Roles data)    
                {    
                    using (var connection = new MySqlConnection(ConnectionString))    
                    {    
                        await connection.OpenAsync();    
                        string sql = @"Update roles set role_name=@role_name,active=@active,remark=@remark  where Id=@Id";
                        var affectedRows = await connection.ExecuteAsync(sql,new { 
id=data.id,role_name=data.role_name,active=data.active,remark=data.remark } 
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
                string sql = @"Delete from roles Where Id = @Id";
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
                        string sql = @"Delete from roles Where Id = @Id";
                        var affectedRows = await connection.ExecuteAsync(sql, new {Id = Id });    
                        await connection.CloseAsync();    
                        return affectedRows;    
           }    
        }    

        public Roles GetById(long Id)    
        {    
            using (var connection = new MySqlConnection(ConnectionString))    
            {    
                connection.Open();    
                string sql = @"Select  id,role_name,active,remark  from roles Where Id = @Id";
                var result  = connection.QueryFirst<Roles>(sql, new {Id = Id });    
                connection.Close();    
                return result;    
            }    
        }    
        
         public async Task<Roles> GetByIdAsync(long Id)    
                {    
                    using (var connection = new MySqlConnection(ConnectionString))    
                    {    
                        await connection.OpenAsync();    
                        string sql = @"Select  id,role_name,active,remark  from roles Where Id = @Id";
                        var result  = await connection.QueryFirstAsync<Roles>(sql, new {Id = Id });    
                        await connection.CloseAsync();    
                        return result;    
                    }    
                }    
	}
}
