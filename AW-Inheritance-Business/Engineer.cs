namespace AW_Inheritance_Business
{
    public class Engineer : Employee, IPrintInfo
    {
        public bool IsCSharpLiterate { get; set; }
        public int YearsOfExperience { get; set; }
        public string SubType { get; set; } = string.Empty;
        public Engineer(string firstName, string lastName, string subtype, int salary = 80000) : base(firstName, lastName, salary)
        {
            SubType = subtype;

        }

        public string InfoAsString()
        {
            return $"--------------------" +
                 $"\nName: {FirstName} {LastName}" +
                 $"\nPosition: {GetType().Name}" +
                 $"\nSalary: {Salary.ToString("C")}" +
                 $"\nExperience: {YearsOfExperience} years" +
                 $"\nType: {SubType}" +
                 $"\nC# Competent: {IsCSharpLiterate}";
        }
    }
}