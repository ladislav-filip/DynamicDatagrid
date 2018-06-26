using DynamicDatagrid.DTO;
using System;
using System.Data;
using System.Linq;
using System.Reflection;

namespace DynamicDatagrid
{

    public static class PropsExtend
    {
        public static PropertyInfo[] GetColProps(this PropertyInfo[] props)
        {
            return props.Where(p => p.PropertyType.IsValueType || p.PropertyType == typeof(string)).ToArray();
        }
    }

    public class DtoToTable<TContainer, TDto> where TContainer : GridContainerDTO<TDto>
        where TDto: GridDTO
    {
        private readonly TContainer m_container;

        private DataTable m_table = new DataTable();

        public DtoToTable(TContainer container)
        {
            m_container = container;
            var typeDto = m_container.GetTypeDTO();
            var props = CreateColumns(typeDto);
            CreateFieldsFromColumns();
            FillTable(props);            
        }

        private PropertyInfo[] CreateColumns(Type type)
        {
            var props = type.GetProperties();
            foreach (var pi in props.GetColProps())
            {
                m_table.Columns.Add(pi.Name, pi.PropertyType);
            }

            return props;
        }

        private void CreateFieldsFromColumns()
        {
            if (m_container.Fields != null)
            {
                m_container.Fields.ForEach(f => m_table.Columns.Add(f.Name, f.DataType));
            }
        }

        private void FillTable(PropertyInfo[] props)
        {
            var isFields = m_container.Fields != null;
            foreach (var d in m_container.Items)
            {
                var r = m_table.NewRow();

                foreach (var pi in props.GetColProps())
                {
                    r[pi.Name] = pi.GetValue(d);
                }

                if (isFields)
                {
                    FillRowFromFields(r, d);
                }

                m_table.Rows.Add(r);
            }
        }

        private void FillRowFromFields(DataRow r, TDto dto)
        {
            for (var i = 0; i < m_container.Fields.Count; i++)
            {
                var f = m_container.Fields[i];
                r[f.Name] = dto.FieldsValues[i];
            }
        }

        public DataTable GetTable()
        {
            return m_table;
        }
    }    
}