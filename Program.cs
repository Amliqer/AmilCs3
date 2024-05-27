using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmilCS
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FullTimeEmployee fullTimeEmployee1 = new FullTimeEmployee();
            fullTimeEmployee1.FullName = "Name Surname Patrionymic";
            fullTimeEmployee1.Position = "Director";

            while (true)
            {
                if (fullTimeEmployee1.Salary == 0)
                {
                    Console.WriteLine("Введите зарплату: ");
                    fullTimeEmployee1.Salary = Convert.ToInt32(Console.ReadLine());
                }
                else if (fullTimeEmployee1.Bonus == 0)
                {
                    Console.WriteLine("Введите бонус: ");
                    fullTimeEmployee1.Bonus = double.Parse(Console.ReadLine());
                }
                else break;
            }

            double resultSalary = fullTimeEmployee1.CalculateSalary();
            Console.WriteLine($"Итоговая зарплата: {resultSalary}");
        }

    }

    /// <summary>
    /// Класс компании
    /// </summary>
    public class Company
    {
        /// <summary>
        /// Имя компании
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Список отделов
        /// </summary>
        List<Department> Departments { get; set; } = new List<Department>();
    }
    /// <summary>
    /// Класс отдела компании
    /// </summary>
    public class Department
    {
        /// <summary>
        /// Название отдела
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Количество сотрудников в отделе
        /// </summary>
        public int CountOfEmployee { get; set; }
    }
    /// <summary>
    /// Класс сотрудника
    /// </summary>
    public class Employee
    {
        /// <summary>
        /// ФИО сотрудника
        /// </summary>
        public string FullName { get; set; }
        /// <summary>
        /// Должность сотрудника
        /// </summary>
        public string Position { get; set; }
        private double _salary;
        /// <summary>
        /// Зарплата сотрудника
        /// </summary>
        public double Salary
        {
            get
            {
                return _salary;
            }
            set
            {
                try
                {
                    if (value < 0)
                    {
                        throw new ArgumentException("Введена отрицательная зарплата ");
                    }
                    else
                    {
                        _salary = value;
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        /// <summary>
        /// Метод по подсчёту зарплаты сотруднику
        /// </summary>
        /// <returns></returns>
        public double CalculateSalary()
        {
            return Salary;
        }
    }
    public class FullTimeEmployee : Employee
    {
        /// <summary>
        ///  Поле бонус
        /// </summary>
        private double _bonus;
        public double Bonus
        {
            get
            {
                return _bonus;
            }
            set
            {
                try
                {
                    if (value < 0)
                    {
                        throw new BonusException("Введён отрицательный бонус", value);
                    }
                    else _bonus = value;
                }
                catch (BonusException ex)
                {
                    Console.WriteLine("Ошибка: " + ex.Message);
                    Console.WriteLine($"Значение, которое вызвало ошибку: {ex.BonusError}");
                }
                _bonus = value;
            }
        }
    }
}