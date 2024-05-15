using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using NoreaApp.Models.Repositories;
using NoreaApp.ViewModels;

namespace Views;
/// <summary>
/// Interaction logic for SermonWindow.xaml
/// </summary>
public partial class SermonWindow : Window
{
    public SermonWindow()
    {
        InitializeComponent();
        SermonWindowsViewModel mvm = new SermonWindowsViewModel();
        DataContext = mvm;
    }
}
