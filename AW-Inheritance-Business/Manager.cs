using System.Data;

namespace AW_Inheritance_Business
{
    public class Manager : Employee, IPrintInfo
    {
        public int VacationDaysPerYear { get; set; }
        private int _meetingsPerWeek;
        public int MeetingsPerWeek
        {
            get
            {
                return _meetingsPerWeek;
            }
            set
            {
                try
                {
                    if (value >= 2)
                    {
                        _meetingsPerWeek = value;
                    }
                    else
                    {
                        throw new ArgumentOutOfRangeException("All managers must attend at least two meetings per week.");
                    }
                }
                catch
                {
                    _meetingsPerWeek = 2;
                }
            }
        }
        public Manager(string firstName, string lastName, int salary = 80000) : base(firstName, lastName, salary)
        {
            VacationDaysPerYear = 15;
            MeetingsPerWeek = 2;
        }

        public string InfoAsString()
        {
            return $"--------------------" +
                 $"\nName: {FirstName} {LastName}" +
                 $"\nPosition: {GetType().Name}" +
                 $"\nSalary: {Salary.ToString("C")}" +
                 $"\nMeetings: {MeetingsPerWeek}/week" +
                 $"\nVacation days: {VacationDaysPerYear}/year";
        }
    }
}