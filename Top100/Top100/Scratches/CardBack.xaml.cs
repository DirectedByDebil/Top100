using SkiaSharp;
using SkiaSharp.Views.Maui;
using SkiaSharp.Views.Maui.Controls;

namespace Scratches
{

	public partial class CardBack : ContentView
	{

        public event Action Scratched;


        private const int MaxPoints = 20;

        private readonly SKPaint _paint;

        private SKCanvas _canvas;


        private List<SKPoint> _points;


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
		}



        private void OnPaintSurface(object sender, SKPaintSurfaceEventArgs e)
        {

            _canvas = e.Surface.Canvas;


            //#TODO גלוסעמ Clear DrawImage
            _canvas.Clear(SKColors.Orange);


            foreach (SKPoint point in _points)
            {

                _canvas.DrawCircle(point, 100, _paint);
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