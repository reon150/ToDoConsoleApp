using System;

namespace ToDoConsoleApp
{
    static class Menu
    {
        private static int option;

        private static void NewItem()
        {
            String title = "title";
            Principal($"Item {title} added correctly");
        }

        private static void EditItem()
        {
            String title = "title";
            Principal($"Item {title} edited correctly");
        }

        private static void DeleteItem()
        {
            String title = "title";
            Principal($"Item {title} deleted correctly");
        }

        private static void CheckUncheck()
        {
            bool isCompleted = false;
            if (isCompleted)
                Principal("Item Checked");
            else
                Principal("Item Unchecked");
        }

        private static void ViewItem()
        {
            Console.Clear();
            string item = "awd";
            Console.WriteLine($"Title: {item}");
            Console.WriteLine($"Description: {item}");
            Console.WriteLine($"Completed: {item}");
            Console.WriteLine("Press enter to go back to principal menu");
            Console.ReadLine();
            Principal();
        }

        public static void Principal(string msg = "")
        {
            Console.Clear();

            //Check if there is messages to show
            if (msg != "") 
                Console.WriteLine(msg + "\n");

            // Options Menu
            Console.WriteLine("\tToDo App:\n");
            Console.WriteLine("Options:");
            Console.WriteLine("1.Add new Item");
            Console.WriteLine("2.Edit Item");
            Console.WriteLine("3.Delete Item");
            Console.WriteLine("4.Check Uncheck item");
            Console.WriteLine("5.View an especific item");
            Console.WriteLine("6.Close App");

            msg = "";
            option = int.Parse(Console.ReadLine());
            switch (option)
            {
                case 1:
                    NewItem();
                    break;
                case 2:
                    EditItem();
                    break;
                case 3:
                    DeleteItem();
                    break;
                case 4:
                    CheckUncheck();
                    break;
                case 5:
                    ViewItem();
                    break;
                case 6:
                    Environment.Exit(0);
                    break;
                default:
                    Principal("You typed an invalid option :(\nPlease try again ;)");
                    break;
            }
        }
    }
}
