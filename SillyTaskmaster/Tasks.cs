using System.Collections;

namespace SillyTaskmaster
{

    [Serializable]
    public class Tasks //: IComparable<Tasks>
    {
        public int id = GenID();
        public String? title;
        public String? description;
        public DateTime? deadLine;
        public Boolean done;

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
        static int GenID()
        {
            int idGen = 0;
            return idGen += 1;
        }



    }


    }
