using Lab1.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.ViewModel
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        #region Поля

        private HeatSettingsModel _heatSettings = new();

        private string _iParallepipedSize;
        private string _jParallepipedSize;
        private string _kParallepipedSize;

        private string _aBoudary;
        private string _aaBoudary;
        private string _bBoudary;
        private string _bbBoudary;
        private string _cBoudary;
        private string _ccBoudary;

        private string _h;
        private string _tau;
        private string _a;
        private string _maxTime;

        #endregion

        #region Свойства

        public string Aboundary
        {
            get => _aBoudary;
            set
            {
                double temp;
                if (double.TryParse(value, out temp) || double.TryParse(value + "0", out temp))
                {
                    _aBoudary = value;
                    _heatSettings.Aboundary = temp;
                    OnPropertyChanged(nameof(Aboundary));
                }
            }
        }

        public string AAboundary
        {
            get => _aaBoudary;
            set
            {
                double temp;
                if (double.TryParse(value, out temp) || double.TryParse(value + "0", out temp))
                {
                    _aaBoudary = value;
                    _heatSettings.AAboundary = temp;
                    OnPropertyChanged(nameof(AAboundary));
                }
            }
        }

        public string Bboundary
        {
            get => _bBoudary;
            set
            {
                double temp;
                if (double.TryParse(value, out temp) || double.TryParse(value + "0", out temp))
                {
                    _aaBoudary = value;
                    _heatSettings.Bboundary = temp;
                    OnPropertyChanged(nameof(Bboundary));
                }
            }
        }

        public string BBboundary
        {
            get => _bbBoudary;
            set
            {
                double temp;
                if (double.TryParse(value, out temp) || double.TryParse(value + "0", out temp))
                {
                    _bbBoudary = value;
                    _heatSettings.BBboundary = temp;
                    OnPropertyChanged(nameof(BBboundary));
                }
            }
        }

        public string Cboundary
        {
            get => _cBoudary;
            set
            {
                double temp;
                if (double.TryParse(value, out temp) || double.TryParse(value + "0", out temp))
                {
                    _cBoudary = value;
                    _heatSettings.Cboundary = temp;
                    OnPropertyChanged(nameof(Cboundary));
                }
            }
        }

        public string CCboundary
        {
            get => _ccBoudary;
            set
            {
                double temp;
                if (double.TryParse(value, out temp) || double.TryParse(value + "0", out temp))
                {
                    _ccBoudary = value;
                    _heatSettings.CCboundary = temp;
                    OnPropertyChanged(nameof(CCboundary));
                }
            }
        }

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

        public string H
        {
            get => _h;
            set
            {
                double temp;
                if (double.TryParse(value, out temp) || double.TryParse(value + "0", out temp))
                {
                    _h = value;
                    _heatSettings.H = temp;
                    OnPropertyChanged(nameof(H));
                    OnPropertyChanged(nameof(IsStable));
                }
            }
        }

        public string Tau
        {
            get => _tau;
            set
            {
                double temp;
                if (double.TryParse(value, out temp) || double.TryParse(value + "0", out temp))
                {
                    _tau = value;
                    _heatSettings.Tau = temp;
                    OnPropertyChanged(nameof(Tau));
                    OnPropertyChanged(nameof(IsStable));
                }
            }
        }

        public string Alfa
        {
            get => _a;
            set
            {
                double temp;
                if (double.TryParse(value, out temp) || double.TryParse(value + "0", out temp))
                {
                    _a = value;
                    _heatSettings.Alfa = temp;
                    OnPropertyChanged(nameof(Alfa));
                   OnPropertyChanged(nameof(IsStable));
                }
            }
        }

        public string MaxTime
        {
            get => _maxTime;
            set
            {
                double temp;
                if (double.TryParse(value, out temp) || double.TryParse(value + "0", out temp))
                {
                    _maxTime = value;
                    _heatSettings.MaxTime = temp;
                    OnPropertyChanged(nameof(MaxTime));
                }
            }
        }

        public bool IsStable
        {
            get => _heatSettings.IsStable;
            set => OnPropertyChanged(nameof(IsStable));
        }

        #endregion

        #region Конструкторы

        public MainWindowViewModel()
        {
            _iParallepipedSize = _heatSettings.IParallepipedSize.ToString();
            _jParallepipedSize = _heatSettings.JParallepipedSize.ToString();
            _kParallepipedSize = _heatSettings.KParallepipedSize.ToString();
            _h = _heatSettings.H.ToString();
            _tau = _heatSettings.Tau.ToString();
            _a = _heatSettings.Alfa.ToString();
            _maxTime = _heatSettings.MaxTime.ToString();
            _aBoudary = _heatSettings.Aboundary.ToString();
            _aaBoudary = _heatSettings.AAboundary.ToString();
            _bBoudary = _heatSettings.Bboundary.ToString();
            _bbBoudary = _heatSettings.BBboundary.ToString();
            _cBoudary = _heatSettings.Cboundary.ToString();
            _ccBoudary = _heatSettings.CCboundary.ToString();
        }

        #endregion

        #region PropertyChanged

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
