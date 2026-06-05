using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace s18wpf;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    // private void button_Clicked(object sender, RoutedEventArgs e)
    // {
    //     MessageBox.Show("You touched me!");
    // }

    public MainWindow()
    {
        InitializeComponent();
        Panel p = new StackPanel();
        TextBox t = new TextBox();
        Button b = new Button();  b.Content = "Click Me";

        p.Children.Add(t);
        p.Children.Add(b);

        this.Content = p;

        b.Click += (o,e) => t.Text += "click! \n";

        t.TextChanged += (o,e) => MessageBox.Show("Changed!");

        // b.Click += button_Clicked;
        // b.Click += (o,e) => MessageBox.Show("Second Delegate!");
    }
}