using Assignment4.Entities;
using Assignment4.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4.UI
{
    public class ManageDepartment
    {
        IRepository<Department> repository;
        public ManageDepartment()
        {
            repository = new DepartmentRepository();
        }

        public void AddDepartment()
        {
            Department department = new Department();
            Console.Write("Enter Id:");
            department.Id = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Your Name:");
            department.Name = Console.ReadLine();
            Console.Write("Enter Your Location:");
            department.Location = Console.ReadLine();
            repository.Insert(department);
            Console.WriteLine("Add was Successful");
        }
        public void PrintAllDepartment()
        {
            var deptList = repository.GetAll();
            foreach(var dept in deptList)
            {
                Console.WriteLine($"{dept.Id} \t {dept.Name} \t {dept.Location}");
            }
        }
        public void DeleteDepartment()
        {
            Console.Write("Enter Id to Delete = ");
            int id = Convert.ToInt32(Console.ReadLine());
            repository.Delete(id);
            Console.WriteLine("Delete was Successful");
        }
        public void UpdateDepartment()
        {
            Department department = new Department();
            Console.Write("Enter Id to Update = ");
             department.Id = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter New Name:");
            department.Name = Console.ReadLine();
            Console.Write("Enter New Location:");
            department.Location = Console.ReadLine();
            repository.Update(department);
        }
        public void Run()
        {
            int choice = (int)Options.Exit;
            Menu menu = new Menu();
            do
            {
                Console.Clear();
                choice = menu.Print();
                switch (choice)
                {
                    case (int)Options.Insert:
                        AddDepartment();
                        break;

                    case (int)Options.Delete:
                        DeleteDepartment();
                        break;

                    case (int)Options.Print:
                        PrintAllDepartment();
                        break;

                    case (int)Options.Update:
                        UpdateDepartment();
                        break;

                    case (int)Options.Exit:
                        Console.WriteLine("Session has Ended");
                        break;

                    default:
                        Console.WriteLine("Error");
                        break;
                }
                Console.WriteLine("Press Enter to Continue");
                Console.ReadLine();
            }
            while (choice != (int)Options.Exit);
        }
    }
}
