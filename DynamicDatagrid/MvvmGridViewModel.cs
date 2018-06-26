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
            InitConvert();
        }

        private void InitConvert()
        {
            var list = new List<UserDTO>()
            {
                new UserDTO()
                {
                    Id = 100, Name = "Petr",
                    FieldsValues = new List<object>() { 580, 2}
                },
                new UserDTO() { Id = 101, Name = "Jan", FieldsValues = new List<object>() { 500, 1}},
                new UserDTO() { Id = 102, Name = "Daniel", FieldsValues = new List<object>() { 2500, 8}},
                new UserDTO() { Id = 103, Name = "Miladka", FieldsValues = new List<object>() { 300, 12}},
            };

            var container = new GridContainerDTO<UserDTO>();
            container.Items = list;
            container.Fields = new List<FieldInfoDTO>()
            {
                new FieldInfoDTO() { Name = "Cena", DataType = typeof(decimal)},
                new FieldInfoDTO() { Name = "Poradi", DataType = typeof(int)}
            };            

            var cnv = new DtoToTable<GridContainerDTO<UserDTO>, UserDTO>(container);
            Table = cnv.GetTable();
        }
    }
}