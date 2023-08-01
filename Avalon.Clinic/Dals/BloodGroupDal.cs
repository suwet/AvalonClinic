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
    public class BloodGroupDal : BaseDal {
        public List<BloodGroup> GetAll() {
            List<BloodGroup> results = new List<BloodGroup>();
            using (var connection = new MySqlConnection(ConnectionString)) {
                connection.Open();
                string query =
                    @"Select  Id,BloodGroupName,BloodGroupDescription,Active,CreatedDate,ModifieldDate  From bloodgroup";
                results = connection.Query<BloodGroup>(query).ToList();
                connection.Close();
            }

            return results;
        }

        public int Insert(BloodGroup data) {
            using (var connection = new MySqlConnection(ConnectionString)) {
                connection.Open();
                string sql =
                    @"Insert into bloodgroup (BloodGroupName,BloodGroupDescription,Active,CreatedDate,ModifieldDate )
                                                          values( @Id,@BloodGroupName,@BloodGroupDescription,@Active,@CreatedDate,@ModifieldDate )
                            ";
                var affectedRows = connection.Execute(sql, new {
                        BloodGroupName = data.BloodGroupName,
                        BloodGroupDescription = data.BloodGroupDescription,
                        Active = data.Active,
                        CreatedDate = data.CreatedDate,
                        ModifieldDate = data.ModifieldDate
                    }
                );
                connection.Close();
                return affectedRows;
            }
        }

        public int Update(BloodGroup data) {
            using (var connection = new MySqlConnection(ConnectionString)) {
                connection.Open();
                string sql =
                    @"Update bloodgroup set  BloodGroupName=@BloodGroupName,BloodGroupDescription=@BloodGroupDescription,Active=@Active,CreatedDate=@CreatedDate,ModifieldDate=@ModifieldDate  where Id=@Id";
                var affectedRows = connection.Execute(sql, new {
                        BloodGroupName = data.BloodGroupName,
                        BloodGroupDescription = data.BloodGroupDescription, Active = data.Active,
                        CreatedDate = data.CreatedDate, ModifieldDate = data.ModifieldDate
                    }
                );
                connection.Close();
                return affectedRows;
            }
        }

        public int Delete(long Id) {
            using (MySqlConnection connection = new MySqlConnection(ConnectionString)) {
                connection.Open();
                string sql = @"Delete from bloodgroup Where Id = @Id";
                var affectedRows = connection.Execute(sql, new { Id = Id });
                connection.Close();
                return affectedRows;
            }
        }

        public BloodGroup GetById(long Id) {
            using (MySqlConnection connection = new MySqlConnection(ConnectionString)) {
                connection.Open();
                string sql =
                    @"Select  Id,BloodGroupName,BloodGroupDescription,Active,CreatedDate,ModifieldDate  from bloodgroup Where Id = @Id";
                var result = connection.QueryFirst<BloodGroup>(sql, new { Id = Id });
                connection.Close();
                return result;
            }
        }
    }
}
