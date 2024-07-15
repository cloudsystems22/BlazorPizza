using RclProducts.Services.Interfaces;

namespace RclProducts.Services
{
    public class CardsUtilsServices : ICardsUtilsServices
    {
        public int _value { get; set; } = 0;
        public int Index
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value;
                NotificationOnChange();
            }

        }

        private int _valueCont { get; set; } = 0;
        public int CountSlide
        {
            get
            {
                return _valueCont;
            }
            set
            {
                _valueCont = value;
                NotificationOnChange();
            }

        }

        private float _valueWidthSlide { get; set; } = 0.00f;

        public float WidthSlide
        {
            get
            {
                return _valueWidthSlide;
            }
            set
            {
                _valueWidthSlide = value;
                NotificationOnChange();
            }
        }

        public List<string> _marginLeftSlide = new List<string>();

        public List<string> MarginLeftSlide
        {
            get
            {
                return _marginLeftSlide;
            }
            set
            {
                _marginLeftSlide = value;
                NotificationOnChange();
            }
        }

        public event Action OnChange;

        private void NotificationOnChange() => OnChange?.Invoke();
    }
}
