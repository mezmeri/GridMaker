using Microsoft.VisualBasic;
using System.Diagnostics;
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

        private Point startPoint_Player;
        private UIElement UIElement;
        private void SelectedPlayerToMove_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (UIElement == null)
            {
                throw new System.Exception();
            }

            UIElement = (UIElement) sender;
            startPoint_Player = e.GetPosition(this);

            UIElement.CaptureMouse();
        }

        private void MovePlayer(object sender, MouseEventArgs e)
        {
            UIElement = (UIElement) sender;
            if (e.LeftButton == MouseButtonState.Released)
            {
                UIElement.ReleaseMouseCapture();
            } else
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
        private void displayXYCoords(object sender, MouseEventArgs e)
        {
            Point point = e.GetPosition(this);
            MouseXPos.Text = "Mouse X: " + point.X.ToString();
            MouseYPos.Text = "Mouse Y: " + point.Y.ToString();
        }
    }
}