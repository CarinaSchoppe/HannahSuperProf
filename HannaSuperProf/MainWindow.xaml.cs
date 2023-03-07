using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace HannaSuperProf;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window {
    public MainWindow() {
        Main.Start();
        InitializeComponent();
    }

    private void Window_MouseDown(object sender, MouseButtonEventArgs e) {
        if (e.ChangedButton == MouseButton.Left) {
            this.DragMove();
        }
    }


    private void GroupByBu_SelectionChanged(object sender, SelectionChangedEventArgs e) { }

    private void btnBookBeenden_Click(object sender, RoutedEventArgs e) {
        this.Close();
    }

    private void btnBookHours_Click(object sender, RoutedEventArgs e) { }

    private void btnBookServiceMaterial_Click(object sender, RoutedEventArgs e) { }

    private void btnBookHalterungen_Click(object sender, RoutedEventArgs e) { }
}