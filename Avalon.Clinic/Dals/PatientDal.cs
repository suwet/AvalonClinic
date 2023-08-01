using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Avalon.Clinic.Models;
using Dapper;
using MySqlConnector;

namespace Avalon.Clinic.Dals; 

public class PatientDal : BaseDal {
    public List<Patient> GetAll() {
        var results = new List<Patient>();
        try {
            using (var connection = new MySqlConnection(ConnectionString)) {
                connection.Open();
                var query = @"SELECT t.*,
		                            (SELECT BloodGroupName FROM bloodgroup WHERE t.BloodGroupId=Id LIMIT 1) AS BloodGroupName
                               FROM patient t";
                results = connection.Query<Patient>(query).ToList();
                connection.Close();
            }
        }
        catch (Exception e) {
            Console.WriteLine(e);
            throw;
        }

        return results;
    }

    public List<Patient> Search(string search = "") {
        var results = new List<Patient>();
        using (var connection = new MySqlConnection(ConnectionString)) {
            connection.Open();
            var query = @"SELECT t.*,
		                            (SELECT BloodGroupName FROM bloodgroup WHERE t.BloodGroupId=Id LIMIT 1) AS BloodGroupName
                               FROM patient t
                               where concat(firstname, ' ', lastname,' ',email,' ',IDCard,' ',Address,' ',MobliePhone) like concat('%', replace(@search, ' ', '%'), '%')
                                            ";
            results = connection.Query<Patient>(query, new { search }).ToList();
            connection.Close();
        }

        return results;
    }

    //where concat(firstname, ' ', lastname) like concat('%', replace($search, ' ', '%'), '%')

    public int Insert(Patient data) {
        using (var connection = new MySqlConnection(ConnectionString)) {
            connection.Open();
            var sql =
                @"Insert into patient (IDCard,FirstName,LastName,Email,Address,BirthDate,MobliePhone,Age,Sex,BloodGroupId,ChronicDisease,Ocipation,Nationality,CreatedDate,ModifieldDate,Remark,Active )
                                                          values(@IDCard,@FirstName,@LastName,@Email,@Address,@BirthDate,@MobliePhone,@Age,@Sex,@BloodGroupId,@ChronicDisease,@Ocipation,@Nationality,@CreatedDate,@ModifieldDate,@Remark,@Active )
                            ";
            var affectedRows = connection.Execute(sql, new {
                    data.IDCard,
                    data.FirstName,
                    data.LastName,
                    data.Email,
                    data.Address,
                    data.BirthDate,
                    data.MobliePhone,
                    data.Age,
                    data.Sex,
                    data.BloodGroupId,
                    data.ChronicDisease,
                    data.Ocipation,
                    data.Nationality,
                    CreatedDate = DateTime.Now,
                    ModifieldDate = DateTime.Now,
                    data.Remark,
                    Active = "Y"
                }
            );
            connection.Close();
            return affectedRows;
        }
    }

    public int Update(Patient data) {
        using (var connection = new MySqlConnection(ConnectionString)) {
            connection.Open();
            var sql =
                @"Update patient set IDCard=@IDCard,FirstName=@FirstName,LastName=@LastName,Email=@Email,Address=@Address,BirthDate=@BirthDate,MobliePhone=@MobliePhone,Age=@Age,Sex=@Sex,BloodGroupId=@BloodGroupId,ChronicDisease=@ChronicDisease,Ocipation=@Ocipation,Nationality=@Nationality,ModifieldDate=@ModifieldDate,Remark=@Remark,Active=@Active  where Id=@Id";
            var affectedRows = connection.Execute(sql, new {
                    data.IDCard,
                    data.FirstName,
                    data.LastName,
                    data.Email,
                    data.Address,
                    data.BirthDate,
                    data.MobliePhone,
                    data.Age,
                    data.Sex,
                    data.BloodGroupId,
                    data.ChronicDisease,
                    data.Ocipation,
                    data.Nationality,
                    ModifieldDate = DateTime.Now,
                    data.Remark,
                    data.Active,
                    data.Id
                }
            );
            connection.Close();
            return affectedRows;
        }
    }

    public int Delete(long Id) {
        using (var connection = new MySqlConnection(ConnectionString)) {
            connection.Open();
            var sql = @"Delete from patient Where Id = @Id";
            var affectedRows = connection.Execute(sql, new { Id });
            connection.Close();
            return affectedRows;
        }
    }

    public async Task<int> DeleteAsync(long Id) {
        return await Task.Run(async () => {
            using (var connection = new MySqlConnection(ConnectionString)) {
                await connection.OpenAsync();
                var sql = @"Delete from patient Where Id = @Id";
                var affectedRows = await connection.ExecuteAsync(sql, new { Id });
                await connection.CloseAsync();
                return affectedRows;
            }
        });
    }

    public async Task<Patient> GetByIdAsync(long Id) {
        using (var connection = new MySqlConnection(ConnectionString)) {
            await connection.OpenAsync();
            var sql =
                @"Select  Id,IDCard,FirstName,LastName,Email,Address,BirthDate,MobliePhone,Age,Sex,BloodGroupId,ChronicDisease,Ocipation,Nationality,CreatedDate,ModifieldDate,Remark,Active  from patient Where Id = @Id";
            var result = await connection.QueryFirstAsync<Patient>(sql, new { Id });
            await connection.CloseAsync();
            return result;
        }
    }
}
