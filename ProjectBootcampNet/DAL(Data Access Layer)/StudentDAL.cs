using ProjectBootcampNet.Models;
using System.Data.SqlClient;

namespace ProjectBootcampNet.DAL_Data_Access_Layer_
{
    public class StudentDAL :InterfaceStudent
    {
        private readonly IConfiguration _config;

        public StudentDAL(IConfiguration config)
        {
            _config = config;
        }

       

        public IEnumerable<StudentModel> GetAllStudent()
        {
            using (SqlConnection conn = new SqlConnection(GetConn()))
            {
                List<StudentModel> liststudents = new List<StudentModel>();
                string strSql = @"select * from [Table Coba Student] order by LastName asc";
                SqlCommand cmd = new SqlCommand(strSql, conn);
                conn.Open();

                //bacadata
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        liststudents.Add(new StudentModel()
                        {
                            ID = Convert.ToInt32(dr["Id"]),
                            LastName = dr["LastName"].ToString()
                        });
                    }
                }
                dr.Close();
                cmd.Dispose();
                conn.Close();
                return liststudents;
            }
        }

        public StudentModel GetById(int id)
        {
            using (SqlConnection conn = new SqlConnection(GetConn()))
            {
                StudentModel studentid = new StudentModel();
            string strSql = @"select * from [Table Coba Student] where ID=@Id";
            SqlCommand cmd = new SqlCommand(strSql,conn);
                cmd.Parameters.AddWithValue("@id",id);
                conn.Open();

                SqlDataReader drforId = cmd.ExecuteReader();
                if (drforId.HasRows)
                {
                    drforId.Read();
                    studentid.ID = Convert.ToInt32(drforId["Id"]);
                    studentid.LastName = drforId["LastName"].ToString();
                }
                drforId.Close();
                cmd.Dispose();
                conn.Close();
                return studentid;



            }
        }

        public IEnumerable<StudentModel> GetByName (string Lastname)
        {
            using (SqlConnection conn = new SqlConnection(GetConn()))
            {
                List<StudentModel> studentsname = new List<StudentModel>();
                string strSql = @"select * from [Table Coba Student] where LastName
                                    like @LastName order by LastName asc ";
                SqlCommand cmd = new SqlCommand(strSql,conn);
                cmd.Parameters.AddWithValue("@LastName", "%" + Lastname + "%");

                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        studentsname.Add(new StudentModel()
                        {
                            ID = Convert.ToInt32(dr["Id"]),
                            LastName = dr["LastName"].ToString()
                            
                        });

                    }


                }
                dr.Close();
                cmd.Dispose();
                conn.Close();
                return studentsname;

            }
           
        }

        public StudentModel Insert(StudentModel student)
        {
           using (SqlConnection conn = new SqlConnection(GetConn()))
            {
                string strSql = @"insert into [Table Coba Student](LastName) 
                                    values(@LastName);select @@identity";
                SqlCommand cmd = new SqlCommand (strSql,conn);
                cmd.Parameters.AddWithValue("LastName",student.LastName);
                try
                {
                    conn.Open();
                    int idNum = Convert.ToInt32(cmd.ExecuteScalar());
                    student.ID = idNum;
                    return student;

                }
                catch (Exception x)
                {

                    throw new Exception($"Error:{x.Message}");
                }
                finally
                {
                    cmd.Dispose();
                    conn.Close();
                }
            }
        }

        public StudentModel Update(StudentModel student)
        {
            using (SqlConnection conn = new SqlConnection(GetConn()))
            {
                string strSql = @"update [Table Coba Student] set LastName=@LastName where ID=@ID";
                    SqlCommand cmd = new SqlCommand(strSql, conn);
                cmd.Parameters.AddWithValue("@LastName", student.LastName);
                cmd.Parameters.AddWithValue("@ID", student.ID);

                try
                {
                    conn.Open();
                    int status = cmd.ExecuteNonQuery();
                    if (status != 1)
                        throw new Exception("Gagal Update Data Student, Data Tidak Ditemukan");
                    return student;
                }
                catch (Exception ex)
                {

                    throw new Exception ($"Error :{ex.Message}");
                }
                finally
                {
                    cmd.Dispose();
                    conn.Close();
                }

            }

        }
        public void Delete(int id)
        {
           using (SqlConnection conn = new SqlConnection (GetConn()))
            {
                string strSql = @"delete from [Table Coba Student] where ID=@ID";
                SqlCommand cmd = new SqlCommand (strSql, conn);
                cmd.Parameters.AddWithValue("@ID", id);

                try
                {
                    conn.Open();
                    int status = cmd.ExecuteNonQuery();
                    if (status != 1)
                        throw new Exception($"Gagal Delete Data Dengan ID {id}");
                }
                catch (SqlException ex)
                {

                    throw new Exception (ex.Message);
                }
                finally
                {
                    cmd.Dispose();
                    conn.Close();
                }
            }
        }

        private string GetConn()
        {
            return _config.GetConnectionString("StudentConnection");
        }
    }
}
