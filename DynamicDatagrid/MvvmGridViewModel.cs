using System.Collections.Generic;
using DynamicDatagrid.DTO;
using DynamicDatagrid.Repositories;
using System.Data;

namespace DynamicDatagrid
{
    public class MvvmGridViewModel
    {
        private readonly IUserRepo m_userRepo;
        public DataTable Table { get; set; }

        public MvvmGridViewModel(IUserRepo userRepo)
        {
            m_userRepo = userRepo;
            InitConvert();
        }

        private void InitConvert()
        {
            var fields = new List<FieldInfoDTO>();
            fields.Add(new FieldInfoDTO() { Name = "Value", DataType = typeof(int)});
            fields.Add(new FieldInfoDTO() { Name = "Text", DataType = typeof(string) });
            fields.Add(new FieldInfoDTO() { Name = "Price", DataType = typeof(decimal) });

            var cnv = new DtoToTable<GridContainerDTO<UserDTO>, UserDTO>(m_userRepo.Load(fields));
            Table = cnv.GetTable();
        }
    }
}