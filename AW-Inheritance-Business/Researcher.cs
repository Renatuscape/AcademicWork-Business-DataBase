namespace AW_Inheritance_Business
{
    public class Researcher : Employee, IPrintInfo
    {
        public string AlmaMater { get; set; } = string.Empty;
        public string DissertationTopic { get; set; } = string.Empty;
        public Researcher(string firstName, string lastName, string almaMater, string dissertationTopic, int salary = 35000) : base(firstName, lastName, salary)
        {
            AlmaMater = almaMater;
            DissertationTopic = dissertationTopic;
        }

        public string InfoAsString()
        {
            return $"--------------------" +
                 $"\nName: {FirstName} {LastName}" +
                 $"\nPosition: {GetType().Name}" +
                 $"\nSalary: {Salary.ToString("C")}" +
                 $"\nAlma Mater: {AlmaMater}" +
                 $"\nDissertation topic: {DissertationTopic}";
        }
    }
}