using System.Collections;

namespace NetInterfacesNetsApp
{
    class Company
    {
        public string? Title { set; get; }

        public Company(string? title)
        {
            Title = title;
        }
        public override string? ToString()
        {
            return Title;
        }
    }
    class User : ICloneable, IComparable
    {
        public string? Name { get; set; }
        public int Age { get; set; }
        public Company Company { get; set; }
        public User(string? name, int age, Company company)
        {
            Name = name;
            Age = age;
            Company = company;
        }
        public object Clone()
        {
            //return new User(Name, Age, Company);
            //return MemberwiseClone();

            return new User(Name, Age, new Company(Company.Title));
        }

        public override string ToString()
        {
            return $"Name: {Name}, Age: {Age}, Company: {Company}";
        }

        public int CompareTo(object? obj)
        {
            if (obj is User user)
                return Name.CompareTo(user.Name);
            else
                throw new ArgumentException();
        }
    }


    class UserAgeComparer : IComparer<User>
    {
        public int Compare(User? x, User? y)
        {
            return x.Age.CompareTo(y.Age);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            User user1 = new("Bob", 32, new Company("Yandex"));
            User user2 = (User)user1.Clone();

            Console.WriteLine($"User1: {user1}\nUser2: {user2}");

            user2.Name = "Joe";
            user2.Age = 21;
            user2.Company.Title = "Ozon";
            Console.WriteLine($"User1: {user1}\nUser2: {user2}");

            int[] array = new int[10];
            Random rand = new Random();
            for(int i = 0; i < array.Length; i++)
                array[i] = rand.Next(0, 100);
            foreach(int item in array)
                Console.Write($"{item} ");
            Console.WriteLine();

            Array.Sort(array);

            foreach (int item in array)
                Console.Write($"{item} ");
            Console.WriteLine();

            User[] users = new[]
            {
                new User("Leo", 23, new Company("c1")),
                new User("Joe", 45, new Company("c1")),
                new User("Sam", 18, new Company("c1")),
                new User("Tim", 34, new Company("c1")),
                new User("Bob", 22, new Company("c1")),
            };

            Array.Sort(users, new UserAgeComparer());

            foreach(var item in users)
                Console.WriteLine(item);

        }
    }
}