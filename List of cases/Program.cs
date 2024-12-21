namespace List_of_cases
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> list_tasks_names = new List<string>();
            List<bool> list_tasks_is_done = new List<bool>();
            bool is_start = true; 
            Console.WriteLine("List of tasks");
            while (is_start) {
                Console.WriteLine("Adding a task: 1");
                Console.WriteLine("Removal of all taskes: 2");
                Console.WriteLine("Performance note: 3");
                Console.WriteLine("Deleting a task: 4");
                Console.WriteLine("Go out: 5");
                Console.Write("Choose an action: ");
                int events = int.Parse(Console.ReadLine());
                Console.WriteLine();
                switch (events) {
                    case 1:
                        add_task(list_tasks_names,list_tasks_is_done);
                        break;
                    case 2:
                        removal_all_taskes(list_tasks_names, list_tasks_is_done);
                        break;
                    case 3:
                        performance_note(list_tasks_names, list_tasks_is_done);
                        break;
                    case 4:
                        deleting_task(list_tasks_names, list_tasks_is_done);
                        break;
                    case 5:
                        Console.WriteLine("The end of the program");
                        is_start = false;
                        break;
                    default:
                        Console.WriteLine("There is no such event, another one is being conducted\n");
                        break;
                }
            }
        }
        static void add_task(List<string> list_tasks_names, List<bool> list_tasks_is_done)
        {
            Console.Write("Input the task:");
            string task_name = Console.ReadLine();
            list_tasks_names.Add(task_name);
            list_tasks_is_done.Add(false);
            Console.WriteLine("\nThe task has been added");
        }
        static void removal_all_taskes(List<string> list_tasks_names, List<bool> list_tasks_is_done)
        {
            if (list_tasks_names.Count == 0)
            {
                Console.WriteLine("The task list is empty\n");
                return;
            }
            Console.WriteLine("Your tasks list\n");
            for (int i = 0; i < list_tasks_names.Count; i++)
            {
                string is_done = list_tasks_is_done[i] ? "Done": "Not done";
                Console.WriteLine($"{i+1}: {list_tasks_names[i]}: {is_done}\n");
            }
        }
        static void performance_note(List<string> list_tasks_names, List<bool> list_tasks_is_done)
        {
            if (list_tasks_names.Count == 0)
            {
                Console.WriteLine("The task list is empty\n");
                return;
            }
            else
            {
                removal_all_taskes(list_tasks_names, list_tasks_is_done);
                Console.Write("Input task number: ");
                if(int.TryParse(Console.ReadLine(), out int task_number) 
                    && task_number > 0 && task_number <= list_tasks_names.Count)
                {
                    if (list_tasks_is_done[task_number - 1] == true) {
                        Console.WriteLine("\nThis task has already been completed\n");
                        return ;
                    }
                    list_tasks_is_done[task_number-1] = true;
                    Console.WriteLine("Task done\n");
                }
                else 
                {
                    Console.WriteLine("Error: you input the wrong task number\n");
                }
            }
        }
        static void deleting_task(List<string> list_tasks_names, List<bool> list_tasks_is_done)
        {
            if (list_tasks_names.Count == 0)
            {
                Console.WriteLine("The task list is empty\n");
                return;
            }
            removal_all_taskes(list_tasks_names, list_tasks_is_done);
            Console.WriteLine("Input the number of the task you want to delete: ");
            if (int.TryParse(Console.ReadLine(), out int task_number)
                    && task_number > 0 && task_number <= list_tasks_names.Count)
            {
                list_tasks_names.RemoveAt(task_number-1);
                list_tasks_is_done.RemoveAt(task_number-1);
                Console.WriteLine("Task deleted\n");
            }
            else
            {
                Console.WriteLine("Error: you input the wrong task number\n");
            }
        }
    }
}
