using System;
using System.Collections.Generic;
using System.Linq;
using DevExpress.XtraPrinting.Native;
using DynamicDatagrid.DTO;

namespace DynamicDatagrid.Repositories
{
    public class UserRepo : IUserRepo
    {
        public DTO.GridContainerDTO<UserDTO> Load(IEnumerable<FieldInfoDTO> fields)
        {
            var list = new List<UserDTO>()
            {
                new UserDTO() { Id = 100, Name = "Petr" },
                new UserDTO() { Id = 101, Name = "Jan"},
                new UserDTO() { Id = 102, Name = "Daniel"},
                new UserDTO() { Id = 103, Name = "Miladka"},
            };

            var container = new GridContainerDTO<UserDTO>();
            container.Items = list;

            var fieldInfoDtos = fields as FieldInfoDTO[] ?? fields.ToArray();

            container.Fields = new List<FieldInfoDTO>(fieldInfoDtos.Length);

            fieldInfoDtos.ForEach(f =>
            {
                container.Fields.Add(f);
            });

            foreach (var itm in list)
            {
                itm.FieldsValues = new List<object>(fieldInfoDtos.Length);
                fieldInfoDtos.ForEach(f =>
                {
                    itm.FieldsValues.Add(CreateRandomValue(f));
                });
            }

            return container;
        }

        private Random rnd = new Random();

        private object CreateRandomValue(FieldInfoDTO field)
        {            
            if (field.DataType == typeof(int)) return rnd.Next(int.MinValue, int.MaxValue);
            if (field.DataType == typeof(decimal)) return (decimal)rnd.NextDouble();

            var str = new[] {"ahoj", "pokus", "dobry den", "tiskarna", "nejaky dlouhy text"};
            return str[rnd.Next(0, str.Length - 1)];
        }
    }
}