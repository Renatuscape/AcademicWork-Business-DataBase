namespace AW_Inheritance_Business
{
    public class EmployeeManagement
    {
        private EmployeeDatabase _employeeDatabase;
        public EmployeeManagement()
        {
            _employeeDatabase = new();
        }

        public void AddManager(string firstName, string lastName)
        {
            Manager newManager = new(firstName, lastName);
            _employeeDatabase.EmployeeList.Add(newManager);
        }

        public void AddEngineer(string firstName, string lastName, string type, int experience)
        {
            Engineer newEngineer = new(firstName, lastName, type, experience);
            _employeeDatabase.EmployeeList.Add(newEngineer);
        }

        public void AddResearcher(string firstName, string lastName, string almaMater, string doctorateTopic)
        {
            Researcher newManager = new(firstName, lastName, almaMater, doctorateTopic);
            _employeeDatabase.EmployeeList.Add(newManager);
        }

        public List<Employee> FindEmployeesByLastName(string searchWord)
        {
            List<Employee> foundNames = new();

            foreach (Employee employee in _employeeDatabase.EmployeeList)
            {
                if (employee.LastName.ToLower().Contains(searchWord.ToLower()))
                {
                    foundNames.Add(employee);
                }
            }

            return foundNames;
        }

        public void DeleteEmployee(Employee employee)
        {
            _employeeDatabase.EmployeeList.Remove(employee);
        }
    }
}