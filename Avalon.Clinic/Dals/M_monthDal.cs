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
    public class M_monthDal : BaseDal {
        public List<M_month> GetAll() {
            List<M_month> results = new List<M_month>();
            using (var connection = new MySqlConnection(ConnectionString)) {
                connection.Open();
                string query = @"Select  Id,MonthNumber,MonthNameTH,MonthNameEN  From m_month";
                results = connection.Query<M_month>(query).ToList();
                connection.Close();
            }

            return results;
        }

        public int Insert(M_month data) {
            using (var connection = new MySqlConnection(ConnectionString)) {
                connection.Open();
                string sql = @"Insert into m_month (MonthNumber,MonthNameTH,MonthNameEN )
                                                          values( @Id,@MonthNumber,@MonthNameTH,@MonthNameEN )
                            ";
                var affectedRows = connection.Execute(sql, new {
                        MonthNumber = data.MonthNumber,
                        MonthNameTH = data.MonthNameTH,
                        MonthNameEN = data.MonthNameEN
                    }
                );
                connection.Close();
                return affectedRows;
            }
        }

        public int Update(M_month data) {
            using (var connection = new MySqlConnection(ConnectionString)) {
                connection.Open();
                string sql =
                    @"Update m_month set MonthNumber=@MonthNumber,MonthNameTH=@MonthNameTH,MonthNameEN=@MonthNameEN  where Id=@Id";
                var affectedRows = connection.Execute(sql, new {
                        MonthNumber = data.MonthNumber,
                        MonthNameTH = data.MonthNameTH,
                        MonthNameEN = data.MonthNameEN
                    }
                );
                connection.Close();
                return affectedRows;
            }
        }

        public int Delete(long Id) {
            using (MySqlConnection connection = new MySqlConnection(ConnectionString)) {
                connection.Open();
                string sql = @"Delete from m_month Where Id = @Id";
                var affectedRows = connection.Execute(sql, new { Id = Id });
                connection.Close();
                return affectedRows;
            }
        }

        public M_month GetById(long Id) {
            using (MySqlConnection connection = new MySqlConnection(ConnectionString)) {
                connection.Open();
                string sql = @"Select  Id,MonthNumber,MonthNameTH,MonthNameEN  from m_month Where Id = @Id";
                var result = connection.QueryFirst<M_month>(sql, new { Id = Id });
                connection.Close();
                return result;
            }
        }
    }
}
