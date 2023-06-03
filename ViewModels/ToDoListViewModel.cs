using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using ToDo.Models;

namespace ToDo.ViewModels
{
    public class ToDoListViewModel : ViewModelBase
    {
        public ToDoListViewModel(IEnumerable<ToDoItem> items)
        {
            Items = new ObservableCollection<ToDoItem>(items);
        }

        public ObservableCollection<ToDoItem> Items { get; }
    }
}