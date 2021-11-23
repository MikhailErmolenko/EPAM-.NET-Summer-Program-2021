using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace InheritanceTask
{
    public class Company
	{
        private Employee[] employees;

        public Company(Employee[] _employees)
        {
            employees = _employees;
        }

        public void GiveEverybodyBonus(decimal companyBonus)
		{
            foreach (var employee in employees)
			{
                employee.SetBonus(companyBonus);
			}
		}
        public decimal TotalToPay()
		{
            decimal total=0;
            foreach (var employee in employees)
			{
                total += employee.ToPay();
			}
            return total;
		}
        public string NameMaxSalary()
        {
            int index = 0;
            string name=employees[index].Name;
            for (int i=1; i<employees.Length; i++)
			{
                if (employees[i].ToPay()>employees[index].ToPay())
				{
                    index = i;
                    name = employees[i].Name;
				}
			}
            return name;
		}
	}
}
