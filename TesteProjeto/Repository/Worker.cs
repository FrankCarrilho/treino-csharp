using System;
using System.Globalization;
using System.Collections.Generic;
using TesteProjeto.Repository.Enum;

namespace TesteProjeto.Repository
{
    class Worker
    {
        public string Name { get; set; }
        public WorkerLevel Level { get; set; }
        public double BaseSalary { get; set; }
        public Department Department { get; set; }
        public List<HourContact> Contacts { get; set; } = new List<HourContact>();

        public Worker()
        {
        }

        public Worker(string name, WorkerLevel level, double baseSalary, Department department)
        {
            Name = name;
            Level = level;
            BaseSalary = baseSalary;
            Department = department;
        }

        public void AddContact(HourContact contact)
        {
            Contacts.Add(contact);
        }

        public void RemoveContact(HourContact contact)
        {
            Contacts.Remove(contact);
        }

        public double Income(int year, int month)
        {
            double sum = BaseSalary;
            foreach (HourContact contact in Contacts)
            {
                if (contact.Date.Year == year && contact.Date.Month == month)
                {
                    sum += contact.TotalValue();
                }
            }
            return sum;
        }
    }
}
