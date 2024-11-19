using AppDev.API.Models.EnumValidation;
using System.ComponentModel.DataAnnotations;

namespace AppDev.API.Models.Entities
{
    public enum StudentProgram
    {
        ComputerScience,
        InformationTechnology,
        Engineering,
        BusinessAdministration,
        Architecture,
        Nursing,
        MultimediaArts,
        Criminology,
    }

    public enum YearLevel
    {
        FirstYearFreshman,
        SecondYearSophomore,
        ThirdYearJunior,
        FourthYearSenior,
    }

    public enum Status
    {
        Regular,
        Irregular
    }

    public class Student
    {
        [Key]
        public Guid StudentIdentification { get; set; } = Guid.NewGuid(); // Automatically generate Guid

        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [ValidEnum(typeof(Program))] // Automatically uses the "IsValid()" in the user-defined EnumValidation
        public StudentProgram Program { get; set; } // Use the Program enum

        [Required]
        [ValidEnum(typeof(YearLevel))] // Automatically uses the "IsValid()" in the user-defined EnumValidation
        public YearLevel YearLevel { get; set; } // Use the YearLevel enum

        [Required]
        [ValidEnum(typeof(Status))] // Automatically uses the "IsValid()" in the user-defined EnumValidation
        public Status Status { get; set; } // Use the Status enum
    }
}
