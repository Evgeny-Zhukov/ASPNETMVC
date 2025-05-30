using WebEnpoints.Entities;

namespace WebEnpoints.Services
{
    public interface IStudentDao
    {
        List<Student> GetAllStudents();
        Student? GetById(int id);
        List<Student> GetByAge(int min, int max);
        List<Student> Search(string name);
        void Add(Student student);
    }
}
