using System.Text.RegularExpressions;
using System.Windows;

namespace WpfCanvasPOC
{
    /// <summary>
    /// Interaction logic for BrushSizeDialog.xaml
    /// </summary>
    public partial class BrushSizeDialog : Window
    {
        private static Regex regexNumberOnly = new Regex("[^0-9]+");
        public BrushSizeDialogData? BrushSizeDialogData { get; set; }
        public BrushSizeDialog(BrushSizeDialogData brushSizeDialogData)
        {
            InitializeComponent();
            if (brushSizeDialogData != null)
            {
                BrushSizeDialogData = brushSizeDialogData!;
            }
            else
            {
                BrushSizeDialogData = new BrushSizeDialogData(0, 0);
            }
            if (BrushSizeDialogData != null)
            {
                Width.Text = BrushSizeDialogData.Width.ToString();
                Height.Text = BrushSizeDialogData.Height.ToString();
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            if (BrushSizeDialogData != null)
            {
                BrushSizeDialogData.Width = Convert.ToDouble(Width.Text);
                BrushSizeDialogData.Height = Convert.ToDouble(Height.Text);
                DialogResult = true;
            }
            Close();
        }

        private void NumberOnly(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            e.Handled = regexNumberOnly.IsMatch(e.Text);
        }
    }
}
