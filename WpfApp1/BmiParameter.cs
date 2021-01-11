using System.Windows.Input;

namespace WpfApp1
{
    public class BmiParameter : NotifyPropertyBase
    {
        private ICommand _changeCommand;
        private decimal _height;
        private decimal _result;
        private decimal _weight;

        public decimal Height
        {
            get => _height;
            set => SetProperty(ref _height, value);
        }

        public decimal Weight
        {
            get => _weight;
            set => SetProperty(ref _weight, value);
        }

        public decimal Result
        {
            get => _result;
            set => SetProperty(ref _result, value);
        }

        public ICommand ChangeCommand
        {
            get { return _changeCommand ??= new BmiCommand(x => Result = Weight / (Height * Height)); }
        }
    }
}