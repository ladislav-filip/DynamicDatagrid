using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using DynamicDatagrid.Annotations;
using DynamicDatagrid.DTO;
using DynamicDatagrid.Repositories;

namespace DynamicDatagrid
{
    public class MvvmGridViewModel : INotifyPropertyChanged
    {
        private readonly IUserRepo m_userRepo;

        private ICommand m_clickCommand;

        private readonly List<FieldInfoDTO> m_fields = new List<FieldInfoDTO>();
        private bool m_isPrice;
        private bool m_isText;
        private bool m_isValue;

        public MvvmGridViewModel(IUserRepo userRepo)
        {
            m_userRepo = userRepo;
            Load();
        }

        public DataTable Table { get; set; }

        public bool IsValue
        {
            get => m_isValue;
            set
            {
                m_isValue = value;
                if (value)
                    m_fields.Add(new FieldInfoDTO {Name = "Value", DataType = typeof(int)});
                else
                    RemoveField();
                OnPropertyChanged();
            }
        }

        public bool IsText
        {
            get => m_isText;
            set
            {
                m_isText = value;
                if (value)
                    m_fields.Add(new FieldInfoDTO {Name = "Text", DataType = typeof(string)});
                else
                    RemoveField();
                OnPropertyChanged();
            }
        }

        public bool IsPrice
        {
            get => m_isPrice;
            set
            {
                m_isPrice = value;
                if (value)
                    m_fields.Add(new FieldInfoDTO {Name = "Price", DataType = typeof(decimal)});
                else
                    RemoveField();
                OnPropertyChanged();
            }
        }

        public ICommand RefreshCommand
        {
            get
            {
                return m_clickCommand ?? (m_clickCommand = new CommandHandler(() =>
                {
                    Load();
                    OnPropertyChanged(nameof(Table));
                }, true));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void Load()
        {
            var cnv = new DtoToTable<GridContainerDTO<UserDTO>, UserDTO>(m_userRepo.Load(m_fields));
            Table = cnv.GetTable();
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void RemoveField([CallerMemberName] string propertyName = null)
        {
            var name = propertyName.Substring(2);
            var f = m_fields.FirstOrDefault(p => p.Name == name);
            if (f != null) m_fields.Remove(f);
        }
    }
}