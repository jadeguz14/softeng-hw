using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoXaml.Models
{

    public enum Priority
    {
        Low,
        Normal,
        High
    }

    public class TodoItem// : INotifyPropertyChanged
    {
        private DateTimeOffset deadline;
        public DateTimeOffset Deadline
        {
            get => deadline;
            set
            {
                deadline = value;
                //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Deadline)));
            }
        }

        private string description;
        public string Description
        {
            get => description;
            set
            {
                description = value;
                //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Description)));
            }
        }

        private int id;
        public int Id
        {
            get => id;
            set
            {
                id = value;
                //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Id)));
            }
        }

        private bool isDone;
        public bool IsDone
        {
            get => isDone;
            set
            {
                isDone = value;
                //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsDone)));
            }
        }

        private string title;
        public string Title
        {
            get => title;
            set
            {
                title = value;
                //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Title)));
            }
        }

        private Priority priority;
        public Priority Priority
        {
            get => priority;
            set
            {
                priority = value;
                //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Priority)));
            }
        }

        //public event PropertyChangedEventHandler PropertyChanged;
    }
}
