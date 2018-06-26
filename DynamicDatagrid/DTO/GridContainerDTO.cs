using System;
using System.Collections.Generic;

namespace DynamicDatagrid.DTO
{
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
}