using System.Collections;
using System.Runtime.Serialization;
using System.Collections.Generic;

namespace SillyTaskmaster
{

    [Serializable]
    public class Tasks //: IComparable<Tasks>
    {
        private static int id_Counter = 0;
        private Dictionary<int, string> taskCategory => new Dictionary<int, string>()
        {
            { 1, "Nauka" },
            { 2, "DJ"},
            { 3, "Naprawa"},
            { 4, "Zdrowie"},
            { 5, "Pieniądze"},
            { 6, "Rodzina"},
            { 7, "Inne"},
        };
        public IDictionary<int, string> Category { get; private set; }
        public int catID { get; set; }
        public int id { get; set; }
        public String? title { get; set; }
        public String? description { get; set; }
        public DateTime? deadLine { get; set; }
        public Boolean done;

        //public int categoryID { get; set; }
        // ????????
        //TasksCategories taskCategory { get; set; }
        //static Dictionary<int, Ta> categories = new List<TasksCategories>();


        public Tasks() 
        { 
            this.id = System.Threading.Interlocked.Increment(ref id_Counter); 
        }
        public Tasks(String title, String description, DateTime deadLine)
        {
            this.id = System.Threading.Interlocked.Increment(ref id_Counter);
            this.title = title; 
            this.description = description; 
            this.deadLine = deadLine;
        }
        public Tasks(int id, string? title, string? description, DateTime? deadLine, bool done)
        {
            this.id = System.Threading.Interlocked.Increment(ref id_Counter);
            this.title = title;
            this.description = description;
            this.deadLine = deadLine;
            this.done = done;
        }
        public void ShowItem()
        {
            Console.WriteLine("ID: " + id);
            Console.WriteLine("Title: " + title);
            Console.WriteLine("Description: " + description);
            Console.WriteLine("Deadline: " + deadLine);
            Console.WriteLine("Is done: " + done);
            Console.WriteLine("Category: " + taskCategory[catID]);
            Console.WriteLine("--------" );
        }
        public void ShowTitles()
        {
            Console.WriteLine("ID: " + id);
            Console.WriteLine("Title: " + title);
            Console.WriteLine("--------");
        }
        public void ShowCategories()
        {
            Console.WriteLine("CATEGORIES:\n\n");
            Console.WriteLine("ID\tCategory name\n");
            foreach ( KeyValuePair<int, string> kvp in taskCategory)
            {
                Console.WriteLine("{0}.\t{1}",
                kvp.Key, kvp.Value);
            }
        }

        
        public void SetDone() =>    this.done = true;
    }


    }
