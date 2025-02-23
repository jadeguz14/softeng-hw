using HelloXaml.Models;
using HelloXaml.ViewModels;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace HelloXaml.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PersonListPage : Page
    {
        public PersonListPage()
        {
            this.InitializeComponent();
            ViewModel = new PersonListPageViewModel();
        }

        public PersonListPageViewModel ViewModel { get; }

        public void AddButton_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.AddPersonToList();
        }

        public void DecreaseButton_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.DecreaseAge();
        }

        public void IncreaseButton_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.IncreaseAge();
        }
    }
}
