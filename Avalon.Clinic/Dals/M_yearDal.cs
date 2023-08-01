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

namespace Avalon.Clinic.Dals {
    public class M_yearDal : BaseDal {
        public List<M_year> GetAll() {
            List<M_year> results = new List<M_year>();
            using (var connection = new MySqlConnection(ConnectionString)) {
                connection.Open();
                string query = @"Select  Id,YearNumberTH,YearNumberEN  From m_year";
                results = connection.Query<M_year>(query).ToList();
                connection.Close();
            }

            return results;
        }

        public int Insert(M_year data) {
            using (var connection = new MySqlConnection(ConnectionString)) {
                connection.Open();
                string sql = @"Insert into m_year (YearNumberTH,YearNumberEN )
                                                          values( @Id,@YearNumberTH,@YearNumberEN )
                            ";
                var affectedRows = connection.Execute(sql, new {
                        YearNumberTH = data.YearNumberTH, YearNumberEN = data.YearNumberEN
                    }
                );
                connection.Close();
                return affectedRows;
            }
        }

        public int Update(M_year data) {
            using (var connection = new MySqlConnection(ConnectionString)) {
                connection.Open();
                string sql = @"Update m_year set YearNumberTH=@YearNumberTH,YearNumberEN=@YearNumberEN  where Id=@Id";
                var affectedRows = connection.Execute(sql,
                    new { YearNumberTH = data.YearNumberTH, YearNumberEN = data.YearNumberEN }
                );
                connection.Close();
                return affectedRows;
            }
        }

        public int Delete(long Id) {
            using (MySqlConnection connection = new MySqlConnection(ConnectionString)) {
                connection.Open();
                string sql = @"Delete from m_year Where Id = @Id";
                var affectedRows = connection.Execute(sql, new { Id = Id });
                connection.Close();
                return affectedRows;
            }
        }

        public M_year GetById(long Id) {
            using (MySqlConnection connection = new MySqlConnection(ConnectionString)) {
                connection.Open();
                string sql = @"Select  Id,YearNumberTH,YearNumberEN  from m_year Where Id = @Id";
                var result = connection.QueryFirst<M_year>(sql, new { Id = Id });
                connection.Close();
                return result;
            }
        }
    }
}
