namespace AW_Inheritance_Business
{
    public abstract class Employee
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public int Salary { get; set; }

        public Employee(string firstName, string lastName, int salary = 50000)
        {
            FirstName = firstName;
            LastName = lastName;
            Salary = salary;

        }
    }
}