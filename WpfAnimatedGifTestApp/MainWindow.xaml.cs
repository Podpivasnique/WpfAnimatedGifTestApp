using System;
using System.Windows;
using System.Windows.Media.Imaging;
using WpfAnimatedGif;

namespace WpfAnimatedGifTestApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int _currentStep = 0;

        private readonly BitmapImage _gif1;
        private readonly BitmapImage _gif1Reversed;
        private readonly BitmapImage _gif2;
        private readonly BitmapImage _gif2Reversed;
        public MainWindow()
        {
            InitializeComponent();
            _gif1 = new BitmapImage();
            _gif1.BeginInit();
            _gif1.UriSource = new Uri("pack://application:,,,/Images/1.gif");
            _gif1.EndInit();

            _gif1Reversed = new BitmapImage();
            _gif1Reversed.BeginInit();
            _gif1Reversed.UriSource = new Uri("pack://application:,,,/Images/1 reversed.gif");
            _gif1Reversed.EndInit();

            _gif2 = new BitmapImage();
            _gif2.BeginInit();
            _gif2.UriSource = new Uri("pack://application:,,,/Images/2.gif");
            _gif2.EndInit();

            _gif2Reversed = new BitmapImage();
            _gif2Reversed.BeginInit();
            _gif2Reversed.UriSource = new Uri("pack://application:,,,/Images/2 reversed.gif");
            _gif2Reversed.EndInit();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _currentStep++;
            ImageBehavior.SetAnimatedSource(ImageControl, null);
            GC.Collect(2, GCCollectionMode.Forced);
            switch (_currentStep)
            {
                case 1:
                    ImageBehavior.SetAnimatedSource(ImageControl, _gif1);
                    break;
                case 2:
                    ImageBehavior.SetAnimatedSource(ImageControl, _gif1Reversed);
                    break;
                case 3:
                    ImageBehavior.SetAnimatedSource(ImageControl, _gif2);
                    break;
                case 4:
                    ImageBehavior.SetAnimatedSource(ImageControl, _gif2Reversed);
                    _currentStep = 0;
                    break;
            }
        }
    }
}
