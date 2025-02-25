using Lab1.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.ViewModel
{
    public class MainWindowViewModel
    {
        private HeatSettingsModel _heatSettings = new();

        private string _iParallepipedSize;
        private string _jParallepipedSize;
        private string _kParallepipedSize;

        public string IParallepipedSize
        {
            get => _iParallepipedSize;
            set
            {
                double temp;
                if (double.TryParse(value, out temp) || double.TryParse(value + "0", out temp))
                {
                    _iParallepipedSize = value;
                    _heatSettings.IParallepipedSize = temp;
                    OnPropertyChanged(nameof(IParallepipedSize));
                }
            }
        }
        public string JParallepipedSize
        {
            get => _jParallepipedSize;
            set
            {
                double temp;
                if (double.TryParse(value, out temp) || double.TryParse(value + "0", out temp))
                {
                    _jParallepipedSize = value;
                    _heatSettings.JParallepipedSize = temp;
                    OnPropertyChanged(nameof(JParallepipedSize));
                }
            }
        }
        public string KParallepipedSize
        {
            get => _kParallepipedSize;
            set
            {
                double temp;
                if (double.TryParse(value, out temp) || double.TryParse(value + "0", out temp))
                {
                    _kParallepipedSize = value;
                    _heatSettings.KParallepipedSize = temp;
                    OnPropertyChanged(nameof(KParallepipedSize));
                }
            }
        }

        public MainWindowViewModel()
        {
            _iParallepipedSize = _heatSettings.IParallepipedSize.ToString();
            _jParallepipedSize = _heatSettings.JParallepipedSize.ToString();
            _kParallepipedSize = _heatSettings.KParallepipedSize.ToString();
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
