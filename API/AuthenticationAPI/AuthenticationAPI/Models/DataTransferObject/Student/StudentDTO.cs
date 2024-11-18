namespace AppDev.API.Models.DataTransferObject.Student
{
    public class StudentDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        // Enums are serialized as strings for readability
        public string Program { get; set; }
        public string YearLevel { get; set; }
        public string Status { get; set; }
    }
}
