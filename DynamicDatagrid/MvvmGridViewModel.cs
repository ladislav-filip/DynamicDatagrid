using System.Collections.Generic;
using System.Data;
using System.Windows.Documents;

namespace DynamicDatagrid
{
    public class MvvmGridViewModel
    {
        public DataTable Table { get; set; }

        public MvvmGridViewModel()
        {
            //InitRaw();
            InitConvert();
        }

        private void InitRaw()
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

        private void InitConvert()
        {
            var list = new List<UserDTO>()
            {
                new UserDTO() { Id = 100, Name = "Petr"},
                new UserDTO() { Id = 101, Name = "Jan"},
                new UserDTO() { Id = 102, Name = "Daniel"},
                new UserDTO() { Id = 103, Name = "Miladka"},
            };
            var cnv = new DtoToTable(list);
            Table = cnv.GetTable();
        }
    }
}