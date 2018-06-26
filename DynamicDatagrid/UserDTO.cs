using System;
using System.Collections.Generic;

namespace DynamicDatagrid
{

    public abstract class GridDTO
    {
        //public IEnumerable<string> Fields { get; set; }

        public List<object> FieldsValues { get; set; }
    }

    public class FieldInfoDTO
    {
        public string Name { get; set; }

        public Type DataType { get; set; } = typeof(string);

        public override string ToString()
        {
            return Name;
        }
    }

    public class GridContainerDTO<TDto> 
        where TDto : GridDTO
    {
        public List<TDto> Items { get; set; }

        public List<FieldInfoDTO> Fields { get; set; }

        public Type GetTypeDTO()
        {
            return typeof(TDto);
        }
    }

    public class UserDTO : GridDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}