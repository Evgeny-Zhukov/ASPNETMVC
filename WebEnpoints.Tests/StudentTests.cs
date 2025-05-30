using WebEnpoints.Entities;

namespace WebEnpoints.Tests
{
    public class StudentModelTests
    {
        [Theory]
        [InlineData(0)]
        [InlineData(50)]
        [InlineData(120)]
        public void Age_ShouldBeInValidRange(int validAge)
        {
            var student = new Student { Age = validAge };

            Assert.InRange(student.Age, 0, 120);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(121)]
        public void Age_ShouldBeOutOfValidRange(int invalidAge)
        {
            var student = new Student { Age = invalidAge };

            Assert.False(student.Age >= 0 && student.Age <= 120, $"Возраст {invalidAge} не входит в диапазон [0..120]");
        }
    }
}
