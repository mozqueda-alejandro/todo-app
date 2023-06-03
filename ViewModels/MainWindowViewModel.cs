using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using System.Text;
using ToDo.Models;
using ToDo.Services;

namespace ToDo.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    private ViewModelBase _content;
    public MainWindowViewModel(Database db)
    {
        Content = List = new ToDoListViewModel(db.GetItems());
    }
    
    public ViewModelBase Content
    {
        get => _content;
        private set => this.RaiseAndSetIfChanged(ref _content, value);
    }

    public ToDoListViewModel List { get; }
    
    public void AddItem()
    {
        var vm = new AddItemViewModel();

        Observable.Merge(
                vm.Ok,
                vm.Cancel.Select(_ => (ToDoItem)null))
            .Take(1)
            .Subscribe(model =>
            {
                if (model != null)
                {
                    List.Items.Add(model);
                }

                Content = List;
            });

        Content = vm;
    }
}