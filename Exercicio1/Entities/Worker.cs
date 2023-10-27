using Exercicio1.Entities.Enums;


namespace Exercicio1.Entities
{
    public class Worker
    {
        public string? Name { get; set; }
        public WorkerLevel Level { get; set; }
        public double BaseSalary { get; set; }
        public Department? Department { get; set; }

        public List<HourContract>? Contracts = new();

        public Worker()
        {
        }

        public Worker(string? name, WorkerLevel level, double baseSalary, Department? department)
        {
            Name = name;
            Level = level;
            BaseSalary = baseSalary;
            Department = department;
        }

        public void AddContract(HourContract contract)
        {
            Contracts?.Add(contract);
        }

        public void RemoveContract(HourContract contract)
        {
            Contracts?.Remove(contract);
        }

        public double Income(int year, int month)
        {
            double sum = 0;
           
            foreach(HourContract contract in Contracts)
            {
                if(contract.Date.Year == year && contract.Date.Month == month)
                {
                    sum += BaseSalary + contract.totalValue();
                }
            }

            return sum;
        }
    }
}
