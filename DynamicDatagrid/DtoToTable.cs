using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;

namespace DynamicDatagrid
{
    public class DtoToTable
    {
        private DataTable m_table = new DataTable();

        public DtoToTable(IEnumerable<UserDTO> list)
        {
            var props = CreateColumns(typeof(UserDTO));
            FillTable(list, props);
        }

        private PropertyInfo[] CreateColumns(Type type)
        {
            var props = type.GetProperties();
            foreach (var pi in props)
            {
                m_table.Columns.Add(pi.Name, pi.PropertyType);
            }

            return props;
        }

        private void FillTable(IEnumerable<UserDTO> list, PropertyInfo[] props)
        {
            foreach (var d in list)
            {
                var r = m_table.NewRow();

                foreach (var pi in props)
                {
                    r[pi.Name] = pi.GetValue(d);
                }

                m_table.Rows.Add(r);
            }
        }

        public DataTable GetTable()
        {
            return m_table;
        }
    }
}