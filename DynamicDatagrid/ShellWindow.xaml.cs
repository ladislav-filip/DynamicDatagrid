using System.Windows;

namespace DynamicDatagrid
{
    /// <summary>
    /// Interaction logic for ShellWindow.xaml
    /// </summary>
    public partial class ShellWindow : Window
    {
        public ShellWindow()
        {
            InitializeComponent();

            SimpleButton.Click += Button_Click;
            MvvmButton.Click += Button_Click;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ContentPanel.Children.Clear();

            if (sender == SimpleButton)
            {
                ShowSimple();
            }
            else
            {
                ShowMvvm();
            }
        }

        private void ShowMvvm()
        {
            var model = new MvvmGridViewModel();
            var view = new MvvmGridView();
            view.DataContext = model;
            view.VerticalAlignment = VerticalAlignment.Stretch;
            view.HorizontalAlignment = HorizontalAlignment.Stretch;
            ContentPanel.Children.Add(view);
        }

        private void ShowSimple()
        {
            var view = new SimpleGridView();
            view.VerticalAlignment = VerticalAlignment.Stretch;
            view.HorizontalAlignment = HorizontalAlignment.Stretch;
            ContentPanel.Children.Add(view);
        }
    }
}
