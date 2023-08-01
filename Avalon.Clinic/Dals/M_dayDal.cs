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
	public  class M_dayDal : BaseDal
	{
		public List<M_day> GetAll()    
        {    
            List<M_day> results = new List<M_day>();    
            using (var connection = new MySqlConnection(ConnectionString))    
            {    
                connection.Open();    
                string query = @"Select  Id,DayNumber  From m_day";
                results = connection.Query<M_day>(query).ToList();    
                connection.Close();    
            }    
            return results;    
        }    

        public int Insert(M_day data)    
        {    
            using (var connection = new MySqlConnection(ConnectionString))    
            {    
                connection.Open(); 
                string sql = @"Insert into m_day ( Id,DayNumber )
                                                          values( @Id,@DayNumber )
                            ";
                var affectedRows = connection.Execute(sql,new { Id=data.Id,DayNumber=data.DayNumber } 
);    
                connection.Close();    
                return affectedRows;    
            }    
        }   
        
        public int Update(M_day data)    
        {    
            using (var connection = new MySqlConnection(ConnectionString))    
            {    
                connection.Open();    
                string sql = @"Update m_day set  Id=@Id,DayNumber=@DayNumber  where Id=@Id";
                var affectedRows = connection.Execute(sql,new { 
Id=data.Id,DayNumber=data.DayNumber } 
);    
                connection.Close();    
                return affectedRows;    
            }    
        }  
        
        public int Delete(long Id)    
        {    
            using (MySqlConnection connection = new MySqlConnection(ConnectionString))    
            {    
                connection.Open();    
                string sql = @"Delete from m_day Where Id = @Id";
                var affectedRows = connection.Execute(sql, new {Id = Id });    
                connection.Close();    
                return affectedRows;    
            }    
        }    

        public M_day GetById(long Id)    
        {    
            using (MySqlConnection connection = new MySqlConnection(ConnectionString))    
            {    
                connection.Open();    
                string sql = @"Select  Id,DayNumber  from m_day Where Id = @Id";
                var result  = connection.QueryFirst<M_day>(sql, new {Id = Id });    
                connection.Close();    
                return result;    
            }    
        }    
	}
}
