using System;


namespace ToDoConsoleApp
{
    class TodoItem
    {
        private string title;
        private string description;
        private bool completed;

        public string Title 
        { 
            get { return title; } 
        }

        public string Description
        {
            get { return description; }
        }

        public bool Completed
        {
            get { return completed; }
        }

        TodoItem(string title, string description, bool completed)
        {
            this.title = title;
            this.description = description;
            this.completed = completed;
        }
    }
}
