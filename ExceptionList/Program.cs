namespace ExceptionList
{
    internal class Program
    {
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
            CreateExceptionList();
            SortList();

            Environment.Exit(0);
        }

        static void CreateExceptionList()
        {
            List<Exception> exceptions = new List<Exception>();
            exceptions.Add(new MyException("My personal exception"));
            exceptions.Add(new OverflowException());
            exceptions.Add(new TimeoutException());
            exceptions.Add(new DivideByZeroException());
            exceptions.Add(new KeyNotFoundException());

            foreach (Exception ex in exceptions)
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
            Users.Add("Кузнецов");
            Users.Add("Борадавкин");
            Users.Add("Антонов");
            Console.WriteLine("1 - сортировка А-Я");
            Console.WriteLine("2 - сортировка Я-А");
            try
            {
                int choice = Convert.ToInt32(Console.ReadLine());
                if (choice == 1)
                {
                    Users.Sort();
                    ShowList(Users);
                }
                else if (choice == 2)
                {
                    Users.Sort();
                    Users.Reverse();
                    ShowList(Users);
                }
                else
                {
                    throw new ChoiceException("Wrong choice. Should be 1 or 2");
                }
            }
            catch (Exception choiceExc )
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
    }

}
