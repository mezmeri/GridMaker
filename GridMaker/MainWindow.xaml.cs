using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace GridMaker
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        bool isEditFormationActive = false;
        bool isDrawRoutesActive = false;

        bool isDrawingRoute = false;

        private void AllowEditFormation(object sender, RoutedEventArgs e)
        {
            isDrawRoutesActive = false;
            isEditFormationActive = true;
        }

        private void AllowDrawRoutes(object sender, RoutedEventArgs e)
        {
            isEditFormationActive = false;
            isDrawRoutesActive = true;
        }



        private Point startPoint_Player;
        private UIElement UIElement;
        private void SelectedPlayerToMove_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (isEditFormationActive == true)
            {
                startPoint_Player = e.GetPosition(this);
                UIElement = (UIElement)sender;
                UIElement.CaptureMouse();
            }
        }

        private void MovePlayer(object sender, MouseEventArgs e)
        {
            UIElement = (UIElement)sender;

            if (e.LeftButton == MouseButtonState.Released || isEditFormationActive == false)
            {
                UIElement.ReleaseMouseCapture();
            }
            else if (isEditFormationActive)
            {
                Point endPoint_Player = e.GetPosition(this);

                TranslateTransform? translateTansform = UIElement.RenderTransform as TranslateTransform;
                if (translateTansform != null)
                {
                    translateTansform.X += endPoint_Player.X - startPoint_Player.X;
                    translateTansform.Y += endPoint_Player.Y - startPoint_Player.Y;

                    startPoint_Player = endPoint_Player;
                }
            }
        }
    }
}