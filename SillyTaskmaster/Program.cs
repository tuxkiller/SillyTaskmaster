using SillyTaskmaster;

class Program
{
    static void Main(string[] args)
    {
        var myTasks = new List<Tasks>();
        Tasks myTaskTemp = new Tasks();
        string menuSelect = "";
        string filePath = "E:/SillyTaskmaster.bin";
        string autoSavePath = "E:/SillyTaskmasterDefault";


        if (File.Exists(autoSavePath)) myTasks = BinarySerialization.ReadFromBinaryFile<List<Tasks>>(autoSavePath);

        Console.WriteLine("TASK MASTER v1.0\n");
        do
        {
            Console.WriteLine("\nMENU:\n");
            Console.WriteLine("1 - Show tasks list");
            Console.WriteLine("2 - Add new task");
            Console.WriteLine("3 - Delete Task");
            Console.WriteLine("4 - Set task as done");
            Console.WriteLine("5 - Sort tasks");
            Console.WriteLine("6 - Save");
            Console.WriteLine("X - Quit");
            Console.Write("Select: ");
            menuSelect = Console.ReadLine();

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
            else if (menuSelect == "4")
            {
                Console.WriteLine("\nSelect task ID to set as DONE: ");
                myTasks[System.Convert.ToInt32(Console.ReadLine())].SetDone();

            }
            else if (menuSelect == "5")
            {
                string sortBy;
                Console.WriteLine("Sort tasks by: ");
                Console.WriteLine("1 = Title " + "2. Deadline date ");
                sortBy = Console.ReadLine();
                if (sortBy == "1")
                {
                    myTasks.Sort((t1, t2) => t1.title.CompareTo(t2.title));

                } else if (sortBy == "2")
                {
                    myTasks.Sort((t1, t2) => DateTime.Compare((DateTime) t1.deadLine, (DateTime) t2.deadLine));
                    
                }
            }
            else if (menuSelect == "6")
            {
                Console.WriteLine("\nSaving file...");
                //
                try
                {
                    BinarySerialization.WriteToBinaryFile<List<Tasks>>(autoSavePath, myTasks);
                    Console.WriteLine("\nSaved succesfully at " + autoSavePath);
                }
                catch (Exception)
                {

                    throw;
                }
            }
            else if (menuSelect.ToUpper() == "X")
            {
                Console.WriteLine("\nClosing application ");
                BinarySerialization.WriteToBinaryFile<List<Tasks>>(autoSavePath, myTasks);
            }
            else if (menuSelect == "Default")
            {
                myTaskTemp = new Tasks();
                myTaskTemp.id = 1;
                myTaskTemp.title = "Odrobić Przyrode";
                myTaskTemp.description = "Wakacyjne zadania z przyrody.";
                myTaskTemp.deadLine = new DateTime(2024, 4, 10, 23, 59, 59);
                myTasks.Add(myTaskTemp);

                myTaskTemp = new Tasks();
                myTaskTemp.id = 2;
                myTaskTemp.title = "Kanapki";
                myTaskTemp.description = "Zrobić chleb z masłem i powidłami";
                myTaskTemp.deadLine = DateTime.Now + new TimeSpan(1, 0, 0);
                myTasks.Add(myTaskTemp);

                myTaskTemp = new Tasks();
                myTaskTemp.id = 3;
                myTaskTemp.title = "Cwiczenia";
                myTaskTemp.description = "Pompki 4x20";
                myTaskTemp.deadLine = new DateTime(2022, 12, 31);
                myTasks.Add(myTaskTemp);
                myTaskTemp = new Tasks();
            }
            else if (menuSelect == "Clear")
            {
                myTasks.Clear();
                BinarySerialization.WriteToBinaryFile<List<Tasks>>(autoSavePath, myTasks);
            }
            else
            {
                Console.WriteLine("\nWrong selection, press any key to continue ");
                //menuSelect = "X";
            }
            Console.ReadKey();
            Console.Clear();
        } while (menuSelect.ToUpper() != "X");
        
    }
}
