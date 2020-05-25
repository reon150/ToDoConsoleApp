using System;

namespace ToDoConsoleApp
{
    static class Menu
    {
        private static int option;

        private static void NewItem()
        {
            TodoItem newItem = new TodoItem();

            Console.Write("Type a title for task: ");
            newItem.Title = Console.ReadLine();
            Console.Write("Type a description for task (Optional): ");
            newItem.Description = Console.ReadLine();
            newItem.Completed = false;

            ToDodb.AddItem(newItem);

            Principal($"Item {newItem.Title} added correctly");
        }

        private static void DeleteItem()
        {
            try
            {
                Console.Write("Type id of the task to delete: ");
                int id = int.Parse(Console.ReadLine());

                ToDodb.DeleteItem(id);
                Principal($"Item deleted correctly");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                DeleteItem();
            }

        }

        private static void CheckUncheck()
        {
            Console.Write("Type id Task to be Checked/UnChecked: ");
            string id = Console.ReadLine();
            ToDodb.ChangeCompleted(id);
            Principal();
        }

        private static void ViewItem()
        {
            Console.Write("Type id: ");
            string id = Console.ReadLine();
            Console.Clear();
            ToDodb.ViewOneItem(id);
            Console.WriteLine("Type enter to continue...");
            Console.ReadLine();
            Principal();
        }

        public static void Principal(string msg = "")
        {
            Console.Clear();

            //Check if there is messages to show
            if (msg != "") 
                Console.WriteLine("\n" + msg + "\n");

            // Options Menu
            Console.WriteLine("\tToDo App:\n");
            ToDodb.DisplayList();
            Console.WriteLine("Options:");
            Console.WriteLine("1.Add new Item");
            Console.WriteLine("2.Delete Item");
            Console.WriteLine("3.Check Uncheck item");
            Console.WriteLine("4.View an especific item");
            Console.WriteLine("5.Close App");
            Console.Write("Type an option: ");

            msg = "";
            try
            {
                option = int.Parse(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        NewItem();
                        break;
                    case 2:
                        DeleteItem();
                        break;
                    case 3:
                        CheckUncheck();
                        break;
                    case 4:
                        ViewItem();
                        break;
                    case 5:
                        Environment.Exit(0);
                        break;
                    default:
                        Principal("You typed an invalid option :(\nPlease try again ;)");
                        break;
                }
            }
            catch (Exception e)
            {
                Principal(e.Message);
            }

        }
    }
}
