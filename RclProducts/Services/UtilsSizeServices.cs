using RclProducts.Services.Interfaces;

namespace RclProducts.Services
{
    public class UtilsSizeServices : IUtilsSizeServices
    {

        public int _value { get; set; } = 1;

        public float _valueRefSize { get; set; } = 0.00f;
        public int Index {
            get {
                return _value;
            }
            set {
                _value = value;
                NotificationOnChange();
            }
        }

        public float ValueRefSize
        {
            get { 
                return _valueRefSize; 
            }
            set { 
                _valueRefSize = value;
                NotificationOnChange();
            }
        }

        public event Action OnChange;

        private void NotificationOnChange() => OnChange?.Invoke();


    }
}
