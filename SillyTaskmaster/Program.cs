using SillyTaskmaster;

class Program
{
    static void Main(string[] args)
    {
        var myTasks = new List<Tasks>();
        Tasks myTaskTemp = new Tasks();
        string menuSelect = "";


        // SEKCJA PIERWSZEJ INICJACJI
        //
        myTaskTemp.id = 1;
        myTaskTemp.title = "Dupa";
        myTaskTemp.description = "Wysrać się.";
        myTaskTemp.deadLine = DateTime.Now;
        myTasks.Add(myTaskTemp);

        myTaskTemp = new Tasks();
        myTaskTemp.id = 2;
        myTaskTemp.title = "Siki";
        myTaskTemp.description = "Wysikać się.";
        myTaskTemp.deadLine = DateTime.Now;
        myTasks.Add(myTaskTemp);
        myTaskTemp = new Tasks();
        //
        //


        Console.WriteLine("TASK MASTER v1.0\n");
        do
        {
            Console.WriteLine("\nMENU:\n");
            Console.WriteLine("1 - Show tasks list");
            Console.WriteLine("2 - Add new task");
            Console.WriteLine("3 - Delete Task");
            Console.WriteLine("4 - Set task as done");
            Console.WriteLine("X - Quit");
            Console.Write("Select: ");
            menuSelect = Console.ReadLine();
            //Console.Write("OK: " + menuSelect + "\n");


            if (menuSelect == "1")
            {
                Console.WriteLine("\nTask List: ");
                foreach (var task in myTasks)
                {
                    task.ShowItem();
                }
            }
            else if (menuSelect == "2")
            {
                myTaskTemp = new Tasks();
                Console.WriteLine("\nCreating new task... ");
                Console.WriteLine("\nSet task ID: ");
                myTaskTemp.id = System.Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("\nSet task title: ");
                myTaskTemp.title = Console.ReadLine();
                Console.WriteLine("\nSet task description: ");
                myTaskTemp.description = Console.ReadLine();
                myTaskTemp.deadLine = DateTime.Now;
                myTasks.Add(myTaskTemp);
                Console.WriteLine("\nTask added succesfully, press any key to continue ");
            } 
            else if (menuSelect == "3")
            {
                Console.WriteLine("\nSet task to delete [0-100]: ");
                myTasks.RemoveAt(System.Convert.ToInt32(Console.ReadLine()));
            }
            else if (menuSelect == "4" )
            {
                Console.WriteLine("\nSelect task ID to set as DONE: ");
                myTasks.

            }
            else if (menuSelect == "X")
            {
                Console.WriteLine("\nClosing application ");
            }
            else
            {
                Console.WriteLine("\nWrong selection, press any key to continue ");
                menuSelect = "X";
            }

            Console.ReadKey();
            Console.Clear();
        } while (menuSelect != "X" || menuSelect != "x");
        
    }
}
