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
        Art = "Art";
    }

    private string _art;
    private int _antal;

    public string Art
    {
        get => _art;
        set
        {
            if (value == "")
            {
                _art = value;
                OnPropertyChanged();
                throw new ApplicationException("Art is mandatory");
            }

            _art = value;
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
