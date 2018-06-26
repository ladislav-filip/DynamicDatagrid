using System.Collections.Generic;
using DynamicDatagrid.DTO;

namespace DynamicDatagrid.Repositories
{
    public interface IUserRepo
    {
        GridContainerDTO<UserDTO> Load(IEnumerable<DTO.FieldInfoDTO> fields);
    }
}