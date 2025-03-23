using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace WpfCanvasPOC
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            System.Diagnostics.FileVersionInfo fvi = System.Diagnostics.FileVersionInfo.GetVersionInfo(assembly.Location);
            if (fvi != null && fvi.FileVersion != null)
            {
                string version = fvi.FileVersion;
                Title = $"{Title} {version}";
            }

            Canvas.DefaultDrawingAttributes = new()
            {
                Color = Colors.Black,
                Width = 4,
                Height = 4
            };
        }

        private void MenuItem_Save_Click(object sender, RoutedEventArgs e)
        {
            // Define the dimensions of the canvas
            double width = Canvas.ActualWidth;
            double height = Canvas.ActualHeight;

            // Ensure the canvas is measured and arranged
            Canvas.Measure(new Size(width, height));
            //Canvas.Arrange(new Rect(new Size(width, height)));

            // Create a RenderTargetBitmap to render the canvas
            RenderTargetBitmap renderBitmap = new RenderTargetBitmap(
                (int)width, (int)height, 96, 96, PixelFormats.Pbgra32);

            // Render the canvas to the bitmap
            renderBitmap.Render(Canvas);

            // Create a JpegBitmapEncoder to save the image as a JPEG
            JpegBitmapEncoder jpegEncoder = new JpegBitmapEncoder();
            jpegEncoder.Frames.Add(BitmapFrame.Create(renderBitmap));

            // Save the image to a file
            using (FileStream fileStream = new FileStream("c:/work/temp.jpg", FileMode.Create))
            {
                jpegEncoder.Save(fileStream);
            }
        }
    }
}