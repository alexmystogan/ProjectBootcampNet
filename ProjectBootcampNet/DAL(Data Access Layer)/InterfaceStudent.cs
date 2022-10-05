using ProjectBootcampNet.Models;

namespace ProjectBootcampNet.DAL_Data_Access_Layer_
{
    public interface InterfaceStudent
    {
        public IEnumerable<StudentModel> GetAllStudent();
        public StudentModel GetById(int id);

        public IEnumerable<StudentModel> GetByName(string Lastname);

        public StudentModel Insert(StudentModel student);

        public StudentModel Update( StudentModel student);

        public void Delete(int id);
    }
}
