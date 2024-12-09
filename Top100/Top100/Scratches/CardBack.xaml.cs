using System.Diagnostics;
using SkiaSharp;
using SkiaSharp.Views.Maui;
using SkiaSharp.Views.Maui.Controls;
using Microsoft.Maui.ApplicationModel;

namespace Scratches
{

	public partial class CardBack : ContentView
	{

        public event Action Scratched;

        private const int MaxPoints = 15;

        private readonly SKPaint _paint;

        private SKCanvas _canvas;

        private List<SKPoint> _points;

        private SKBitmap _backgroundImage;


        public CardBack()
		{

            _paint = new SKPaint()
            {

                IsAntialias = true,

                Style = SKPaintStyle.Fill,

                Color = SKColors.Aquamarine,

                BlendMode = SKBlendMode.Clear
            };


            _points = new List<SKPoint>();


            InitializeComponent();


            LoadBackgroundImage();


            Application.Current.RequestedThemeChanged += OnThemeChanged;

        }


        private void OnThemeChanged(object sender, AppThemeChangedEventArgs e)
        {
            LoadBackgroundImage();
        }


        private void LoadBackgroundImage()
        {
            var assembly = typeof(CardBack).Assembly;
            string resourceName = Application.Current?.RequestedTheme == AppTheme.Dark
                ? "Top100.Resources.Shirts.rubashka_gold_dark.png"
                : "Top100.Resources.Shirts.rubashka_gold_light.png";

            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            {
                if (stream == null)
                {
                    Debug.WriteLine($"{resourceName} не найден.");
                    return;
                }

                _backgroundImage = SKBitmap.Decode(stream);
            }
        }


        private void OnPaintSurface(object sender, SKPaintSurfaceEventArgs e)
        {

            _canvas = e.Surface.Canvas;

            var _info = e.Info;

            _canvas.Clear(SKColors.Transparent);


            if (_backgroundImage != null)
            {

                var destRect = new SKRect(0, 0, _info.Width, _info.Height);

                _canvas.DrawBitmap(_backgroundImage, destRect);

            }

            foreach (SKPoint point in _points)
            {

                _canvas.DrawCircle(point, 200, _paint);

            }
        }


        private void OnPanTouched(object sender, SKTouchEventArgs e)
        {

            SKCanvasView view = (SKCanvasView)sender;


            if (e.ActionType == SKTouchAction.Moved)
            {

                SKPoint point = e.Location;


                if (!_points.Contains(point))
                {

                    _points.Add(point);


                    CheckLocked();
                }

                view.InvalidateSurface();
            }


            e.Handled = true;
        }


        private void CheckLocked()
        {

            if (_points.Count > MaxPoints)
            {
                
                IsEnabled = false;

                IsVisible = false;

                Scratched?.Invoke();
            }
        }
    }
}