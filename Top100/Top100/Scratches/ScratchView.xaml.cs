using Core;
using CommunityToolkit.Mvvm.Input;
using System.ComponentModel;
using System.Windows.Input;

namespace Scratches
{
    public partial class ScratchView : ContentView
    {
        public event Action<ContentID>? Changed;

        private bool _isDrawingEnabled = true;  // Управляет рисованием
        private bool _isEraserEnabled = false;  // Управляет ластиком

        // Множество состояний для каждой карточки (стерта или нет)
        private Dictionary<int, bool> erasedCards = new Dictionary<int, bool>(); // хранение состояния

        public bool IsDrawingEnabled
        {
            get => _isDrawingEnabled;
            set
            {
                _isDrawingEnabled = value;
                OnPropertyChanged(nameof(IsDrawingEnabled));
            }
        }

        public bool IsEraserEnabled
        {
            get => _isEraserEnabled;
            set
            {
                _isEraserEnabled = value;
                OnPropertyChanged(nameof(IsEraserEnabled));
            }
        }

        public ScratchView()
        {
            InitializeComponent();
        }

        private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object item = e.CurrentSelection[0];

            if (item is CardDataTest card)
            {
                card.IsLocked = false;
                int year = int.Parse(card.Year);
                ContentID id = new(card.Name, year);
                Changed?.Invoke(id);
            }
        }

        // Обработчик для завершения рисования
        private void OnDrawingLineCompleted(object sender, EventArgs e)
        {
            // После рисования сохраняем состояние карточки
            if (BindingContext is CardDataTest card)
            {
                if (!erasedCards.ContainsKey(card.GetHashCode()))
                {
                    erasedCards[card.GetHashCode()] = false; // Маркируем, что карточка не стерта
                }
            }
        }

        // Обработчик для завершения стирания
        private void OnEraseLineCompleted(object sender, EventArgs e)
        {
            // После стирания сохраняем состояние карточки как стертое
            if (BindingContext is CardDataTest card)
            {
                if (erasedCards.ContainsKey(card.GetHashCode()))
                {
                    erasedCards[card.GetHashCode()] = true; // Карточка стерта, запрещаем стирать дальше
                }
            }
        }

        // Метод для включения ластика
        private void OnEraseCommand()
        {
            IsDrawingEnabled = false;
            IsEraserEnabled = true;
        }

        // Метод для включения рисования
        private void OnDrawCommand()
        {
            IsDrawingEnabled = true;
            IsEraserEnabled = false;
        }

        // Проверка, была ли карточка стерта
        private bool IsCardErased(CardDataTest card)
        {
            return erasedCards.ContainsKey(card.GetHashCode()) && erasedCards[card.GetHashCode()];
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    // Данные карточки
    public class CardDataTest : INotifyPropertyChanged
    {
        private bool isLocked = true;

        public string Name { get; set; }
        public string Year { get; set; }

        public bool IsLocked
        {
            get => isLocked;
            set
            {
                if (isLocked != value)
                {
                    isLocked = value;
                    OnPropertyChanged(nameof(IsLocked));
                }
            }
        }

        public ICommand EraseCommand => new RelayCommand(OnErase);

        private void OnErase()
        {
            // Включение ластика
            IsLocked = false;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
