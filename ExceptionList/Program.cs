namespace ExceptionList
{
    internal class Program
    {
        public delegate void Ascending(List<string> users);
        public delegate void Descending(List<string> users);
        public static event Ascending ascending;
        public static event Descending descending;

        public class MyException : Exception
        {
            public MyException()
            {

            }
            public MyException(string? message) : base(message)
            {
            }
        }

        public class ChoiceException : Exception
        {
            public ChoiceException()
            {

            }
            public ChoiceException(string? message) : base(message)
            {
            }
        }

        static void Main(string[] args)
        {
            CreateExceptionArray();
            SortList();
        }

        static void CreateExceptionArray()
        {
            Exception[] exceptionArray = new Exception[5];
            exceptionArray[0] = new MyException("My personal exception");
            exceptionArray[1] = new OverflowException();
            exceptionArray[2] = new TimeoutException();
            exceptionArray[3] = new DivideByZeroException();
            exceptionArray[4] = new KeyNotFoundException();

            foreach (Exception ex in exceptionArray)
            {
                try
                {
                    throw ex;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            Console.WriteLine();
        }

        static void SortList()
        {

            
            List<string> Users = new List<string>(5);
            Users.Add("Яблоков");
            Users.Add("Петров");
            Users.Add("Пятров");
            Users.Add("Борадавкин");
            Users.Add("Антонов");
            Console.WriteLine("1 - сортировка А-Я");
            Console.WriteLine("2 - сортировка Я-А");
            try
            {
                int choice = Convert.ToInt32(Console.ReadLine());
                if (choice == 1)
                {
                    ascending += sortAscending;
                    ascending.Invoke(Users);
                    ShowList(Users);
                }
                else if (choice == 2)
                {
                    descending += sortDescending;
                    descending.Invoke(Users);
                    ShowList(Users);
                }
                else
                {
                    throw new ChoiceException("Wrong choice. Should be 1 or 2");
                }
            }
            catch (Exception choiceExc)
            {
                Console.WriteLine(choiceExc.Message);
            }

        }
        static void ShowList(List<string> list)
        {
            foreach (var name in list)
            {
                Console.WriteLine(name);
            }

        }
        static void sortAscending(List<string> list)
        {
            list.Sort();
        }
        static void sortDescending(List<string> list)
        {
            list.Sort();
            list.Reverse();
        }
    }

}
