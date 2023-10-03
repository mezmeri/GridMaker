using System.Windows;
using System.Windows.Controls;
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

        private bool isEditFormationActive = false;
        private bool isDrawRoutesActive = false;

        private bool isDrawingRoute = false;

        private void AllowEditFormation(object sender, RoutedEventArgs e)
        {
            isDrawRoutesActive = false;
            isEditFormationActive = true;
            Cursor = Cursors.Hand;
        }

        private void AllowDrawRoutes(object sender, RoutedEventArgs e)
        {
            isEditFormationActive = false;
            isDrawRoutesActive = true;
            Cursor = Cursors.Cross;
        }

        private Point startPoint_Player;
        private UIElement? UIElement;
        private void SelectedPlayer_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (isEditFormationActive)
            {
                startPoint_Player = e.GetPosition(this);
                UIElement = (UIElement) sender;
                UIElement.CaptureMouse();
            } else if (isDrawRoutesActive)
            {
                UIElement = (UIElement) sender;

                Border player = (Border) UIElement;
                string playerName = player.Name;
                MessageBox.Show(playerName);
            }
        }

        private void MovePlayer(object sender, MouseEventArgs e)
        {
            UIElement = (UIElement) sender;

            if (e.LeftButton == MouseButtonState.Released || isEditFormationActive == false)
            {
                UIElement.ReleaseMouseCapture();
            } else if (isEditFormationActive)
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

        // Logic for drawing routes

        // If the isDrawingRoutes is true, the user will be able to draw routes for the receivers. We will wait for the cursor to be on top of a player before we can initialize the drawing. While the left mouse button is pressed down, the route will be drawed.

        private Point drawingStartPoint;
        public void DrawRoutes(bool isDrawing, string player)
        {
            if (isDrawing && player != null)
            {

            } else
            {

            }
        }
    }
}