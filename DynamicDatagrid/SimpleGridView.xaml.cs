using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace DynamicDatagrid
{
    /// <summary>
    /// Interaction logic for SimpleGridView.xaml
    /// </summary>
    public partial class SimpleGridView : UserControl
    {
        public SimpleGridView()
        {
            InitializeComponent();
        }

        private void Init()
        {
            var tbl = new DataTable();

            tbl.Columns.Add("Id", typeof(int));
            tbl.Columns.Add("Name", typeof(string));

            var r = tbl.NewRow();
            r["Id"] = 1;
            r["Name"] = "Honza";
            tbl.Rows.Add(r);

            r = tbl.NewRow();
            r["Id"] = 2;
            r["Name"] = "Pepa";
            tbl.Rows.Add(r);

            GridSimple.ItemsSource = new DataView(tbl);
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            Init();
        }
    }
}
