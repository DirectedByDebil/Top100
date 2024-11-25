using Core;
using CommunityToolkit.Mvvm.Input;
using System.ComponentModel;
using System.Windows.Input;

namespace Scratches
{
    public partial class ScratchView : ContentView
    {
        public event Action<ContentID>? Changed;

        private bool _isDrawingEnabled = true;  // ��������� ����������
        private bool _isEraserEnabled = false;  // ��������� ��������

        // ��������� ��������� ��� ������ �������� (������ ��� ���)
        private Dictionary<int, bool> erasedCards = new Dictionary<int, bool>(); // �������� ���������

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

        // ���������� ��� ���������� ���������
        private void OnDrawingLineCompleted(object sender, EventArgs e)
        {
            // ����� ��������� ��������� ��������� ��������
            if (BindingContext is CardDataTest card)
            {
                if (!erasedCards.ContainsKey(card.GetHashCode()))
                {
                    erasedCards[card.GetHashCode()] = false; // ���������, ��� �������� �� ������
                }
            }
        }

        // ���������� ��� ���������� ��������
        private void OnEraseLineCompleted(object sender, EventArgs e)
        {
            // ����� �������� ��������� ��������� �������� ��� �������
            if (BindingContext is CardDataTest card)
            {
                if (erasedCards.ContainsKey(card.GetHashCode()))
                {
                    erasedCards[card.GetHashCode()] = true; // �������� ������, ��������� ������� ������
                }
            }
        }

        // ����� ��� ��������� �������
        private void OnEraseCommand()
        {
            IsDrawingEnabled = false;
            IsEraserEnabled = true;
        }

        // ����� ��� ��������� ���������
        private void OnDrawCommand()
        {
            IsDrawingEnabled = true;
            IsEraserEnabled = false;
        }

        // ��������, ���� �� �������� ������
        private bool IsCardErased(CardDataTest card)
        {
            return erasedCards.ContainsKey(card.GetHashCode()) && erasedCards[card.GetHashCode()];
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    // ������ ��������
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
            // ��������� �������
            IsLocked = false;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
