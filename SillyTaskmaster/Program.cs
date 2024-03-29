﻿using SillyTaskmaster;
using System.Diagnostics.Metrics;
using System.Globalization;
using System.Collections.Generic;

class Program
{
    //static Dictionary<> 
    /*
    static Dictionary<int, TasksCategories> GetTasksCategories()
    {
        return new Dictionary<int, TasksCategories>
        {
            { 101, new TasksCategories(1, "Nauka") },
            { 102, new TasksCategories(2, "DJ") },
            { 103, new TasksCategories(3, "Naprawa") },
            { 104, new TasksCategories(4, "Zdrowie") },
            { 105, new TasksCategories(5, "Pieniądze") },
            { 106, new TasksCategories(6, "Rodzina") },
            { 107, new TasksCategories(7, "Inne") },
        };
    }
    */
    static void Main(string[] args)
    {
        //Dictionary<int, TasksCategories> tasksCategories = GetTasksCategories();
        
        var myTasks = new List<Tasks>();
        Tasks myTaskTemp = new Tasks();
        string menuSelect = "";
        string strTempTask = "";
        DateTime dateTimeTemp;
        string autoSavePath = "E:/SillyTaskmasterDefault";

        //TasksCategories SelectedCategory = tasksCategories[7];
        //

        if (File.Exists(autoSavePath)) myTasks = BinarySerialization.ReadFromBinaryFile<List<Tasks>>(autoSavePath);
        do
        {
        Console.WriteLine("TASK MASTER v1.0\n");
        Console.WriteLine("\nMENU:\n");
        Console.WriteLine("1 - Show tasks list");
        Console.WriteLine("2 - Add new task");
        Console.WriteLine("3 - Delete Task");
        Console.WriteLine("4 - Set task as done");
        Console.WriteLine("5 - Sort tasks");
        Console.WriteLine("6 - Show Task Categories");
        Console.WriteLine("7 - Save");
        Console.WriteLine("X - Quit");
        Console.Write("Select: ");

            switch (menuSelect = Console.ReadLine().ToUpper())
            {
                // Show Tasks
                case "1":
                    Console.WriteLine("\nTask List: ");
                    foreach (var task in myTasks)
                    {
                        task.ShowItem();
                    }
                    break;
                // Create New Task
                case "2":
                    myTaskTemp = new Tasks();
                    Console.WriteLine("\nCreating new task... ");
                    Console.WriteLine("\nSet task title: ");
                    myTaskTemp.title = Console.ReadLine();
                    Console.WriteLine("\nSet task description: ");
                    myTaskTemp.description = Console.ReadLine();
                    Console.WriteLine("\nSet task deadline (DD/MM/YYYY)");

                    while (!DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out dateTimeTemp))
                    {
                        Console.WriteLine("Invalid date, please retry");
                        strTempTask = Console.ReadLine();
                    }
                    myTaskTemp.deadLine = dateTimeTemp;
                    Console.WriteLine("\nSelect Category: ");
                    ////////////////////////////////////
                    /// TU BĘDZIE KIEDYŚ ŻE WYSWIETLA SIĘ LISTA KATEGORII I WYBIERASZ
                    /// EDIT: MYYYYYYYYK!!
                    myTaskTemp.ShowCategories();
                    Console.WriteLine("\n\nSelect category ID: ");
                    
                    try
                    {
                        myTaskTemp.catID = System.Convert.ToInt32(Console.ReadLine());
                            
                    } catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        throw;
                    }
                    /// 
                    /*
                    myTaskTemp.categoryID = int.Parse(Console.ReadLine());// (Console.ReadLine());
                    SelectedCategory = tasksCategories[myTaskTemp.categoryID];
                    */

                    //myTaskTemp.Category.

                    //////
                    //////
                    ///




                    myTasks.Add(myTaskTemp);
                    myTasks.Sort((t1, t2) => t1.title.CompareTo(t2.title)); //domyslne sortowanie po tytule po dodaniu zadania
                    Console.WriteLine("\nTask added succesfully, press any key to continue ");
                    break;
                // Delete Task
                case "3":
                    foreach (var task in myTasks)
                    {
                        task.ShowTitles();
                    }
                    
                    /* >>>> W RAMACH ĆWICZEŃ xD
                    Console.WriteLine("\nSet task ID to delete [0-" + myTasks.Count + "]: ");
                    */
                    try
                    {
                        myTasks.RemoveAt(System.Convert.ToInt32(Console.ReadLine()));

                    } catch (Exception ex) { Console.WriteLine(ex.Message); }
                    break;
                // Set Task as DONE
                case "4":
                    foreach (var task in myTasks)
                    {
                        task.ShowTitles();
                    }
                    Console.WriteLine("\nSelect task ID to set as DONE: ");
                    myTasks[System.Convert.ToInt32(Console.ReadLine())].SetDone();
                    break;
                // Sort By
                case "5":
                    Console.WriteLine("Sort tasks by: ");
                    Console.WriteLine("1 = Title \n" + "2. Deadline date \n");
                    switch (Console.ReadLine())
                    {
                        case "1":
                            myTasks.Sort((t1, t2) => t1.title.CompareTo(t2.title));
                            break;
                        case "2":
                            myTasks.Sort((t1, t2) => DateTime.Compare((DateTime)t1.deadLine, (DateTime)t2.deadLine));
                            break; 
                    }
                    break;

                // Show avaiable categories from Dictionary   
                case "6":
                    myTaskTemp.ShowCategories();
                    break;

                // Saveing File
                case "7":
                    Console.WriteLine("\nSaving file...");
                    try
                    {
                        BinarySerialization.WriteToBinaryFile<List<Tasks>>(autoSavePath, myTasks);
                        Console.WriteLine("\nSaved succesfully at file location: " + autoSavePath);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        throw;
                    }
                    break;
                // Closing program
                case "X":
                    Console.WriteLine("\nClosing application ");
                    BinarySerialization.WriteToBinaryFile<List<Tasks>>(autoSavePath, myTasks);
                    break;
                // Wczytanie testowych danych 
                case "CLEAR":
                    myTasks.Clear();
                    Console.WriteLine("\nALL Data cleared...");
                    break;

                case "TESTDATA":
                    myTaskTemp = new Tasks();
                    myTaskTemp.title = "Odrobić Przyrode";
                    myTaskTemp.description = "Wakacyjne zadania z przyrody.";
                    myTaskTemp.deadLine = new DateTime(2024, 4, 10, 23, 59, 59);
                    myTaskTemp.catID = 1;
                    myTasks.Add(myTaskTemp);

                    myTaskTemp = new Tasks();
                    myTaskTemp.title = "Kanapki";
                    myTaskTemp.description = "Zrobić chleb z masłem i powidłami";
                    myTaskTemp.deadLine = DateTime.Now + new TimeSpan(1, 0, 0);
                    myTaskTemp.catID = 4;
                    myTasks.Add(myTaskTemp);

                    myTaskTemp = new Tasks();
                    myTaskTemp.title = "Cwiczenia";
                    myTaskTemp.description = "Pompki 4x20";
                    myTaskTemp.deadLine = new DateTime(2022, 12, 31);
                    myTaskTemp.catID = 4;
                    myTasks.Add(myTaskTemp);
                    // TEST
                    //Console.WriteLine(myTasks.IndexOf(myTaskTemp));
                    myTaskTemp = new Tasks();
                    break;

                default:
                    Console.WriteLine("\nWrong selection, press any key to continue ");
                    Console.WriteLine("\n " + menuSelect);
                    break;
            }
            Console.WriteLine("\n " + "\nPress any key to continue...");
            Console.ReadKey();
            Console.Clear();
        } while (menuSelect != "X");
    }
}

