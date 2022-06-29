namespace SillyTaskmaster
{
    public class Tasks
    {
        public Tasks()
        {

        }
        public Tasks(int? id, String? title, String? description, bool done)
        {
            this.id = id;
            this.title = title; 
            this.description = description; 
            this.done = done;   

        }


        public int? id;
        public String? title;
        public String? description;
        public DateTime? deadLine;
        public Boolean done;

        public void ShowItem()
        {
            Console.WriteLine(this.id);
            Console.WriteLine(this.title);
            Console.WriteLine(this.description);
            Console.WriteLine(this.deadLine);
            Console.WriteLine(this.done);
            Console.WriteLine("--------");
        }
        public void SetDone()
        {
            done = true;   
        }
        
     }


    }
