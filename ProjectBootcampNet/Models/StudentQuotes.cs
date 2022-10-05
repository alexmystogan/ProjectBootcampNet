namespace ProjectBootcampNet.Models
{
    public class StudentQuotes
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public StudentModel Student    { get; set; }
        public int StudentId { get; set; }
    }
}
