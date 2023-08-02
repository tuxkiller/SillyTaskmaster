using System.Collections;
using System.Runtime.Serialization;

namespace SillyTaskmaster
{

    [Serializable]
    public class Tasks //: IComparable<Tasks>
    {
        private static int id_Counter = 0;
        public int id { get; set; }
        public String? title { get; set; }
        public String? description { get; set; }
        public DateTime? deadLine { get; set; }
        public Boolean done;


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
            Console.WriteLine("--------");
        }
        public void ShowTitles()
        {
            Console.WriteLine("ID: " + id);
            Console.WriteLine("Title: " + title);
            Console.WriteLine("--------");
        }
        public void SetDone() =>    this.done = true;
    }


    }
