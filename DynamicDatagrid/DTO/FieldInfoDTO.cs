using System;

namespace DynamicDatagrid.DTO
{
    public class FieldInfoDTO
    {
        public string Name { get; set; }

        public Type DataType { get; set; } = typeof(string);

        public override string ToString()
        {
            return Name;
        }
    }
}