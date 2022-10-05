using ProjectBootcampNet.Models;

namespace ProjectBootcampNet.DAL_Data_Access_Layer_
{
    public class StudentDAL_EF : InterfaceStudent
    {
        private AppDbContext _appDbContext;

        public StudentDAL_EF(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<StudentModel> GetAllStudent()
        {
            var results = _appDbContext.Students.OrderBy(s=>s.LastName).ToList();
            return results;
        }

        public StudentModel GetById(int id)
        {
            var result =_appDbContext.Students.FirstOrDefault(s=>s.ID == id);
            if (result == null)
                throw new Exception($"Data id {id} tidak ditemukan");
            return result;
        }

        public IEnumerable<StudentModel> GetByName(string Lastname)
        {
            var results = _appDbContext.Students.Where(s=> s.LastName.Contains(Lastname)).OrderBy(s=>s.LastName);
            return results;
        }

        public StudentModel Insert(StudentModel student)
        {
            try
            {
                _appDbContext.Students.Add(student);
                _appDbContext.SaveChanges();
                return student;
            }
            catch (Exception ex)
            {

                throw new Exception (ex.Message);
            }
        }

        public StudentModel Update(StudentModel student)
        {
            throw new NotImplementedException();
        }
    }
}
