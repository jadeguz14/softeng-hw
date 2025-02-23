using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using HelloXaml.Models;
using Microsoft.UI.Xaml;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloXaml.ViewModels
{
    public partial class PersonListPageViewModel : ObservableObject
    {
        public Person NewPerson { get; set; }

        public ObservableCollection<Person> People { get; set; }

        public bool IsDecrementEnabled => NewPerson.Age > 0;
        public bool IsIncrementEnabled => NewPerson.Age < 150;
        public bool IsAddEnabled => !string.IsNullOrWhiteSpace(NewPerson.Name);
        public RelayCommand IncreaseAgeCommand { get; }

        public PersonListPageViewModel()
        {
            NewPerson = new Person()
            {
                Name = "Eric Cartman",
                Age = 8
            };

            NewPerson.PropertyChanged += (_, _) =>
            {
                OnPropertyChanged(nameof(IsDecrementEnabled));
                OnPropertyChanged(nameof(IsIncrementEnabled));
                OnPropertyChanged(nameof(IsAddEnabled));
                DecreaseAgeCommand.NotifyCanExecuteChanged();
                IncreaseAgeCommand.NotifyCanExecuteChanged();
            };


            People = new ObservableCollection<Person>()
            {
                new Person() { Name = "Peter Griffin", Age = 40 },
                new Person() { Name = "Homer Simpson", Age = 42 },
            };


            IncreaseAgeCommand = new RelayCommand(IncreaseAge, () => IsIncrementEnabled);
        }

        public void AddPersonToList()
        {
            if (!string.IsNullOrWhiteSpace(NewPerson.Name))
            {
                People.Add(new Person()
                {
                    Name = NewPerson.Name,
                    Age = NewPerson.Age,
                });
            }

            NewPerson.Name = string.Empty;
            NewPerson.Age = 0;
        }

        [RelayCommand(CanExecute = nameof(IsDecrementEnabled))]
        public void DecreaseAge()
        {
            if(NewPerson.Age > 0)
            {
                NewPerson.Age--;
            }
        }

        public void IncreaseAge()
        {
            if(NewPerson.Age < 150)
            {
                NewPerson.Age++;
            }
        }
    }
}
