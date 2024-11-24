using Microsoft.Maui.Graphics;
using Microsoft.Maui.Graphics.Platform;
using System.Reflection;

using IImage = Microsoft.Maui.Graphics.IImage;

namespace Scratches
{

	public partial class Cover : ContentView, IDrawable
	{

		public ImageSource Source { get; set; }


		public Cover()
		{

			InitializeComponent();
		}


        public void Draw(ICanvas canvas, RectF dirtyRect)
        {

			IImage sex;
			
			Assembly assembly = GetType().GetTypeInfo().Assembly;

			using (Stream stream = assembly.GetManifestResourceStream("GraphicsViewDemos.Resources.Images.games.png"))
			{

				sex = PlatformImage.FromStream(stream);
			}


			if(sex != null)
			{

                ImagePaint imagePaint = new ImagePaint
                {
                    Image = sex
                };

                canvas.SetFillPaint(imagePaint, RectF.Zero);
                canvas.FillRectangle(0, 0, 240, 300);
            }

		}
    }
}