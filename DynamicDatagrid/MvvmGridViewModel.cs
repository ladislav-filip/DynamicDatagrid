using System.Data;

namespace DynamicDatagrid
{
    public class MvvmGridViewModel
    {
        public DataTable Table { get; set; }

        public MvvmGridViewModel()
        {
            Init();
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

            r = tbl.NewRow();
            r["Id"] = 3;
            r["Name"] = "Kevin";
            tbl.Rows.Add(r);

            Table = tbl;
        }
    }
}