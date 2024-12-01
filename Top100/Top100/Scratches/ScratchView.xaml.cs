using Core;
using CommunityToolkit.Mvvm.Input;
using SkiaSharp;
using SkiaSharp.Views.Maui;
using SkiaSharp.Views.Maui.Controls;
using System.Diagnostics;
using Microsoft.Maui.Controls;

namespace Scratches
{
    public partial class ScratchView : ContentView
    {
        public event Action<ContentID>? Changed;

        private SKBitmap maskBitmap; // ����� ��� ���������� �������������
        private SKCanvas maskCanvas; // Canvas ��� ��������� �� �����
        private bool isMaskInitialized = false;

        public event Action<object>? Touch;

        public ScratchView()
        {
            InitializeComponent();
        }

        private void OnPaintSurface(object sender, SKPaintSurfaceEventArgs e)
        {
            var surface = e.Surface;
            var canvas = surface.Canvas;

            // ������� ���� �� ������ ����������
            canvas.Clear(SKColors.Transparent);

            // ������������� �����, ���� ��� �� ���� �������
            if (!isMaskInitialized)
            {
                maskBitmap = new SKBitmap(e.Info.Width, e.Info.Height);
                maskCanvas = new SKCanvas(maskBitmap);
                maskCanvas.Clear(SKColors.Gray); // ����� ���������� ����������
                isMaskInitialized = true;
            }

            // ������ �� ������ �����
            var paint = new SKPaint { BlendMode = SKBlendMode.SrcOver };
            canvas.DrawBitmap(maskBitmap, 0, 0, paint);
        }

        private void OnPanUpdated(object sender, PanUpdatedEventArgs e)
        {
            if (e.StatusType == GestureStatus.Running)
            {
                // �������� ������� SKCanvasView, ����� ��������� ��������� ����������
                var canvasView = (SKCanvasView)sender;
                var width = canvasView.Width;
                var height = canvasView.Height;

                // �������� ���������� ������� ������������ ������
                var touchPoint = new SKPoint((float)e.TotalX, (float)e.TotalY);

                Debug.WriteLine($"Pan updated: {e.TotalX}, {e.TotalY} (scaled to canvas: {touchPoint.X}, {touchPoint.Y})");

                // ������ �� �����
                using (var paint = new SKPaint
                {
                    //Color = SKColors.Transparent,
                    BlendMode = SKBlendMode.Clear,
                    IsAntialias = true,
                    StrokeWidth = 300f,  // ������ ��������
                    IsStroke = true
                })
                {
                    maskCanvas.DrawCircle(touchPoint.X, touchPoint.Y, 300, paint);
                }

                // ��������� ������ ��� �����������, ����� ������������ �� ��� �����
                ((SKCanvasView)sender).InvalidateSurface();
            }
        }

        private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object item = e.CurrentSelection[0];

            if (item is CardData card)
            {
                card.IsLocked = false;
                ContentID id = new(card.Name, card.Year);
                Changed?.Invoke(id);
            }
        }
    }
}
