namespace Route_oop1
{
    //part 1
    //internal class Program
    //{

    //    struct Point
    //    {
    //        public double X;
    //        public double Y;
    //    }
    //    struct Person
    //    {
    //        public string Name;
    //        public int Age;
    //    }

    //    static void Main(string[] args)
    //    {
    //        //Q1
    //        //Console.WriteLine("Enter the coordinates of the first point:");
    //        //Point point1 = GetPointFromUser();

    //        //Console.WriteLine("Enter the coordinates of the second point:");
    //        //Point point2 = GetPointFromUser();

    //        //double distance = CalculateDistance(point1, point2);

    //        //Console.WriteLine($"Distance between the points: {distance}");
    //        //Q2
    //        //Person[] persons = new Person[3];

    //        //for (int i = 0; i < persons.Length; i++)
    //        //{
    //        //    Console.WriteLine($"Enter details of person {i + 1}:");
    //        //    persons[i] = GetPersonFromUser();
    //        //}

    //        //Person oldestPerson = FindOldestPerson(persons);

    //        //Console.WriteLine($"The oldest person is {oldestPerson.Name} with age {oldestPerson.Age}");



    //    }
    //    static Point GetPointFromUser()
    //    {
    //        Point point;
    //        Console.Write("X: ");
    //        point.X = double.Parse(Console.ReadLine());
    //        Console.Write("Y: ");
    //        point.Y = double.Parse(Console.ReadLine());
    //        return point;
    //    }

    //    static double CalculateDistance(Point point1, Point point2)
    //    {
    //        double deltaX = point2.X - point1.X;
    //        double deltaY = point2.Y - point1.Y;
    //        return Math.Sqrt(deltaX * deltaX + deltaY * deltaY);
    //    }

    //    static Person GetPersonFromUser()
    //    {
    //        Person person;
    //        Console.Write("Name: ");
    //        person.Name = Console.ReadLine();
    //        Console.Write("Age: ");
    //        person.Age = int.Parse(Console.ReadLine());
    //        return person;
    //    }

    //    static Person FindOldestPerson(Person[] persons)
    //    {
    //        Person oldest = persons[0];

    //        for (int i = 1; i < persons.Length; i++)
    //        {
    //            if (persons[i].Age > oldest.Age)
    //            {
    //                oldest = persons[i];
    //            }
    //        }

    //        return oldest;
    //    }
    //}


    //part 2
    using System;

    public enum SecurityLevel
    {
        Guest,
        Developer,
        Secretary,
        DBA,
        FullPermission
    }

    public class HiringDate
    {
        private int day;
        private int month;
        private int year;

        public int Day
        {
            get { return day; }
            set
            {
                if (value > 0 && value <= 31)
                {
                    day = value;
                }
                else
                {
                    Console.WriteLine("Invalid day value. Day set to 1.");
                    day = 1;
                }
            }
        }

        public int Month
        {
            get { return month; }
            set
            {
                if (value > 0 && value <= 12)
                {
                    month = value;
                }
                else
                {
                    Console.WriteLine("Invalid month value. Month set to 1.");
                    month = 1;
                }
            }
        }

        public int Year
        {
            get { return year; }
            set
            {
                if (value >= 1900) // Assuming valid historical range
                {
                    year = value;
                }
                else
                {
                    Console.WriteLine("Invalid year value. Year set to 1900.");
                    year = 1900;
                }
            }
        }

        public HiringDate(int day, int month, int year)
        {
            Day = day;
            Month = month;
            Year = year;
        }
    }

    public class Employee
    {
        private int id;
        private string name;
        private SecurityLevel securityLevel;
        private decimal salary;
        private HiringDate hireDate;
        private char gender;

        public int ID { get; set; }
        public string Name { get; set; }
        public SecurityLevel SecurityLevel { get; set; }
        public decimal Salary { get; set; }
        public HiringDate HireDate { get; set; }

        public char Gender
        {
            get { return gender; }
            set
            {
                if (char.ToUpper(value) == 'M' || char.ToUpper(value) == 'F')
                {
                    gender = char.ToUpper(value);
                }
                else
                {
                    Console.WriteLine("Invalid gender. Gender set to 'M'.");
                    gender = 'M';
                }
            }
        }

        public Employee(int id, string name, SecurityLevel securityLevel, decimal salary, HiringDate hireDate, char gender)
        {
            ID = id;
            Name = name;
            SecurityLevel = securityLevel;
            Salary = salary;
            HireDate = hireDate;
            Gender = gender;
        }

        public override string ToString()
        {
            return $"ID: {ID}, Name: {Name}, Security Level: {SecurityLevel}, Salary: {Salary:C}, Hire Date: {HireDate.Day}/{HireDate.Month}/{HireDate.Year}, Gender: {Gender}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Employee[] empArr = new Employee[3];

            // Create employees
            empArr[0] = new Employee(1, "John Doe", SecurityLevel.DBA, 5000, new HiringDate(1, 1, 2010), 'M');
            empArr[1] = new Employee(2, "Jane Smith", SecurityLevel.Guest, 2000, new HiringDate(5, 7, 2015), 'F');
            empArr[2] = new Employee(3, "David Lee", SecurityLevel.FullPermission, 7000, new HiringDate(3, 12, 2008), 'M');

            // Sort employees by hire date
            SortEmployeesByHireDate(empArr);

            // Print sorted employees
            Console.WriteLine("Sorted Employees:");
            foreach (Employee emp in empArr)
            {
                Console.WriteLine(emp);
            }

            Console.ReadKey();
        }

        static void SortEmployeesByHireDate(Employee[] employees)
        {
            for (int i = 0; i < employees.Length - 1; i++)
            {
                for (int j = i + 1; j < employees.Length; j++)
                {
                    if (CompareHireDates(employees[i].HireDate, employees[j].HireDate) > 0)
                    {
                        // Swap employees
                        Employee temp = employees[i];
                        employees[i] = employees[j];
                        employees[j] = temp;
                    }
                }
            }
        }

        static int CompareHireDates(HiringDate date1, HiringDate date2)
        {
            if (date1.Year < date2.Year)
            {
                return -1;
            }
            else if (date1.Year > date2.Year)
            {
                return 1;
            }
            else if (date1.Month < date2.Month)
            {
                return -1;
            }
            else if (date1.Month > date2.Month)
            {
                return 1;
            }
            else if (date1.Day < date2.Day)
            {
                return -1;
            }
            else if (date1.Day > date2.Day)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
}
