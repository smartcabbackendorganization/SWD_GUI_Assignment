using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using SWD_GUI_Assignment.Annotations;

namespace SWD_GUI_Assignment.Models
{
    public class MeasurementTree: INotifyPropertyChanged
    {
    public MeasurementTree()
    {
        Antal = 1;
        Sort = "Sort";
    }

    private string _sort;
    private int _antal;

    public int Id { get; set; }

    public string Sort
    {
        get => _sort;
        set
        {
            if (value == "")
            {
                _sort = value;
                OnPropertyChanged();
                throw new ApplicationException("Sort is mandatory");
            }

            _sort = value;
            OnPropertyChanged();
        }
    }

    public int Antal
    {
        get => _antal;
        set
        {
            if (value == 0)
            {
                _antal = value;
                OnPropertyChanged();
                throw new ApplicationException("Count shuold be above zero");
            }

            _antal = value;
            OnPropertyChanged();
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    }
}
