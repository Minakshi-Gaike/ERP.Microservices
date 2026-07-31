namespace CachingInApis.Dtos
{
    public class EmployeeDto
    {
        public int BusinessEntityId { get; set; }
        public string JobTitle { get; set; } = null!;
        public DateOnly BirthDate { get; set; }
        //public string MaritalStatus { get; set; } = null!;
        //public string Gender { get; set; } = null!;
        //public DateOnly HireDate { get; set; }
    }

}
