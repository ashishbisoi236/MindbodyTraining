using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace taskapp
{
    public class Task
    {
        public int id;
        public string name;
        public string title;
        public string message;
        public int completion = 1; // 0 - complete, 1- pending, 2- incomplete
        public int priority;
        public DateTime creationdate = DateTime.Today;
        public DateTime completionDate = DateTime.Today;

        public Task() { }
        public Task(int id, string name, string title, string message, int completion, int priority, DateTime completionDate)
        {
            this.id = id;
            this.name = name;
            this.title = title;
            this.message = message;
            this.completion = completion;
            this.priority = priority;
            this.completionDate = completionDate;
        }
    }
    class Program
    {
        public static List<Task> tlist = new List<Task>();
        static string path = "C:\\Users\\AshishKumar.Bisoi\\OneDrive - MINDBODY, Inc\\Desktop\\tasks.txt";
        
        public static string cst(int cstatus)
        {
            if (cstatus == 0)
                return "Complete";
            else if (cstatus == 1)
                return "Pending";
            else
                return "Incomplete";
        }
        public static void createTask()
        {
            tlist.Clear();
            tlist = XmlSerialization.ReadFromXmlFile<List<Task>>(path);

            int id;
            string name;
            string title;
            string message;
            int completion = 2; // 0 - complete, 1- pending, 2- incomplete
            int priority;
            DateTime completionDate;

            // mssg entry
            Console.WriteLine("Enter id: ");
            id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter name: ");
            name = Console.ReadLine();
            Console.WriteLine("Enter title: ");
            title = Console.ReadLine();
            Console.WriteLine("Enter message of task");
            message = Console.ReadLine();
            Console.WriteLine("Enter priority of task (0/1/2/3)");
            priority = Convert.ToInt32(Console.ReadLine());
            if (priority > 3)
                priority = 3;
            else if (priority < 0)
                priority = 0;
            Console.WriteLine("Enter completion date of task(mm/dd/yyyy)");
            completionDate = DateTime.Parse( Console.ReadLine());
            //completion = 2;
            while(completionDate < DateTime.Today)
            {
                Console.WriteLine("Enter valid completion date of task(mm/dd/yyyy)");
                completionDate = DateTime.Parse(Console.ReadLine());
            }
            Task t = new Task(id, name, title, message, completion, priority, completionDate);
            tlist.Add(t);
        }

        public static void viewAll()
        {
            tlist.Clear();
            tlist = XmlSerialization.ReadFromXmlFile<List<Task>>(path);
            int len = tlist.Count;

            Console.WriteLine("Number of tasks: " + len);
            int sort;
            Console.WriteLine("Choose sorting option:\n1. By id\n2. By priority\n3. By date");
            sort =  Convert.ToInt32(Console.ReadLine());


            List<Task> SortedList = new List<Task>();

            if (sort == 1)
            {
                SortedList = tlist.OrderBy(o => o.id).ToList();
            } else if(sort == 2)
            {
                SortedList = tlist.OrderByDescending(o => o.priority).ToList();
            } else
            {
                SortedList = tlist.OrderBy(o => o.completionDate).ToList();
            }


            foreach(var task in SortedList)
            {
                Console.WriteLine();
                Console.WriteLine("---------------------------------------------------");
                Console.WriteLine("     Task id: " + task.id);
                Console.WriteLine("     Task name: " + task.name);
                Console.WriteLine("     Task title: " + task.title);
                Console.WriteLine("     Task message: " + task.message);
                Console.WriteLine("     Task priority: " + task.priority);
                Console.WriteLine("     Task completion date: " + (task.creationdate).ToString());
                Console.WriteLine("     Task completion status: " + task.completion);
                Console.WriteLine("     Task completion date: " + (task.completionDate).ToString());
                Console.WriteLine("---------------------------------------------------");
            }
            Console.WriteLine();
        }

        public static void viewById()
        {
            tlist.Clear();
            tlist = XmlSerialization.ReadFromXmlFile<List<Task>>(path);
            int len = tlist.Count;

            //Console.WriteLine("Lenght on list: " + len);
            Console.WriteLine("Enter id of the task: ");
            int tid = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < len; i++)
            {
                if(tlist[i].id == tid)
                {
                    Console.WriteLine();
                    Console.WriteLine("---------------------------------------------------");
                    Console.WriteLine("     Task id: " + tlist[i].id);
                    Console.WriteLine("     Task name: " + tlist[i].name);
                    Console.WriteLine("     Task title: " + tlist[i].title);
                    Console.WriteLine("     Task message: " + tlist[i].message);
                    Console.WriteLine("     Task priority: " + tlist[i].priority);
                    Console.WriteLine("     Task completion date: " + (tlist[i].creationdate).ToString());
                    Console.WriteLine("     Task completion status: " + cst(tlist[i].completion));
                    Console.WriteLine("     Task completion date: " + (tlist[i].completionDate).ToString());
                    Console.WriteLine("---------------------------------------------------");
                }
                Console.WriteLine();

            }
        }

        public static void edit()
        {
            tlist.Clear();
            tlist = XmlSerialization.ReadFromXmlFile<List<Task>>(path);
            int len = tlist.Count;

            //Console.WriteLine("Lenght on list: " + len);
            Console.WriteLine("Enter id of the task to be edited: ");
            int tid = Convert.ToInt32(Console.ReadLine());
            int idx = -1;
            for(int i = 0; i < len; i++)
            {
                if(tlist[i].id == tid)
                {
                    idx = i;
                    break;
                }
            }

            if(idx == -1)
            {
                Console.WriteLine("Warning: no task found with such id");
                return;
            }

            int choice = 0;
            while(choice != 7)
            {
                Console.WriteLine("+----------------------------------------+");
                Console.WriteLine("|    Enter the field you want to edit:   |");
                Console.WriteLine("|    1. Name                             |");
                Console.WriteLine("|    2.Title                             |");
                Console.WriteLine("|    3. Message                          |");
                Console.WriteLine("|    4. Priority                         |");
                Console.WriteLine("|    5. Completion date                  |");
                Console.WriteLine("|    6. Completion status                |");
                Console.WriteLine("|    Press 7 to exit                     |");
                Console.WriteLine("+----------------------------------------+");
                choice = Convert.ToInt32((Console.ReadLine()));
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter new name");
                        string name = Console.ReadLine();
                        tlist[idx].name = name;
                        break;
                    case 2:
                        Console.WriteLine("Enter new title");
                        string title = Console.ReadLine();
                        tlist[idx].title = title;
                        break;
                    case 3:
                        Console.WriteLine("Enter new message");
                        string mssg = Console.ReadLine();
                        tlist[idx].message = mssg;
                        break;
                    case 4:
                        Console.WriteLine("Enter new priority");
                        int prio = Convert.ToInt32(Console.ReadLine());
                        tlist[idx].priority = prio;
                        break;
                    case 5:
                        Console.WriteLine("Enter new completion date(mm/dd/yyyy)");
                        string cdate = Console.ReadLine();
                        tlist[idx].completionDate = DateTime.Parse(cdate);
                        break;
                    case 6:
                        Console.WriteLine("Enter new completion status(0-complete, 1-pending, 2-incomplete)");
                        int cstatus = Convert.ToInt32(Console.ReadLine());
                        tlist[idx].completion = cstatus;
                        break;
                    case 7:
                        break;
                    default:
                        Console.WriteLine("Choose among the following...");
                        break;
                }

            }

            // deleting contents of xml file
            File.WriteAllText(path, "");

            //write new contents
            XmlSerialization.WriteToXmlFile<List<Task>>(path, tlist);

            Console.WriteLine();
            Console.WriteLine("Updated task: ");
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine("     Task id: " + tlist[idx].id);
            Console.WriteLine("     Task name: " + tlist[idx].name);
            Console.WriteLine("     Task title: " + tlist[idx].title);
            Console.WriteLine("     Task message: " + tlist[idx].message);
            Console.WriteLine("     Task priority: " + tlist[idx].priority);
            Console.WriteLine("     Task completion status: " + cst(tlist[idx].completion));
            Console.WriteLine("     Task completion date: " + (tlist[idx].completionDate).ToString()); 
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine();
        }

        public static void delete()
        {
            tlist.Clear();
            tlist = XmlSerialization.ReadFromXmlFile<List<Task>>(path);
            int len = tlist.Count;

            Console.WriteLine("Length on list: " + len);
            Console.WriteLine("Enter id of the task to be deleted: ");
            int tid = Convert.ToInt32(Console.ReadLine());
            int idx = -1;
            for(int i = 0; i < len; i++)
            {
                //Console.WriteLine("i: " + i);
                if (tlist[i].id == tid)
                {
                    idx = i;
                }
            }

            if (idx != -1)
            {
                tlist.RemoveAt(idx);
                Console.WriteLine("Task deleted !!");
            }
            // deleting contents of xml file
            File.WriteAllText(path, "");

            //write new contents
            XmlSerialization.WriteToXmlFile<List<Task>>(path, tlist);

        }

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to task app!!");
           
            int choice = 0;
            while(choice != 6)
            {
                Console.WriteLine("+-----------_ MENU ------------- +");
                Console.WriteLine("|    1. Create new task          |");
                Console.WriteLine("|    2. View by ID               |");
                Console.WriteLine("|    3. View all                 |");
                Console.WriteLine("|    4. Edit                     |");
                Console.WriteLine("|    5. Delete task              |");
                Console.WriteLine("|    6. Exit                     |");
                Console.WriteLine("+------------------------------- +");

                while (true)
                {
                    try
                    {
                        choice = Convert.ToInt32(Console.ReadLine());
                        break;
                    } catch(Exception e)
                    {
                        Console.WriteLine(e.Message);
                        Console.WriteLine("Choose correct option!");
                    }
                }
                
                switch (choice)
                {
                    case 1:
                        while (true)
                        {
                            char flag;
                            try
                            {
                                createTask();
                                XmlSerialization.WriteToXmlFile<List<Task>>(path, tlist);
                                break;
                            } catch(Exception e)
                            {
                                Console.WriteLine(e.Message);
                                Console.WriteLine("Enter task details again!");
                            }
                        }

                        //try
                        //{
                        //    createTask();
                        //    XmlSerialization.WriteToXmlFile<List<Task>>(path, tlist);
                        //}
                        //catch (Exception e)
                        //{
                        //    Console.WriteLine(e.Message);
                        //    createTask();
                        //}
                        
                        break;
                    case 2:
                        while (true)
                        {
                            try
                            {
                                viewById();
                                break;
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.Message);
                                Console.WriteLine("Enter ID again!");
                            }
                        }
                        
                        break;
                    case 3:
                        try
                        {
                            viewAll();
                        } catch(Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        
                        break;
                    case 4:
                        while (true)
                        {
                            try
                            {
                                edit();
                                break;
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.Message);
                                Console.WriteLine("Enter details again!");
                            }
                        }
                        
                        break;
                    case 5:
                        while (true)
                        {
                            try
                            {
                                delete();
                                break;
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.Message);
                                Console.WriteLine("Enter ID again!");
                            }
                        }
                        
                        break;
                    case 6:
                        break;
                    default:
                        Console.WriteLine("Choose valid  options...");
                        break;
                }
            }

        }
    }
}
