namespace AW_Inheritance_Business
{
    public class EmployeeDatabase
    {
        private List<Employee> _employeeList = new();
        public List<Employee> EmployeeList { get { return new(_employeeList); } private set { } }
    }
}