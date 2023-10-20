using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace GridMaker
{
    public partial class MainWindow : Window
    {
        private bool _isEditFormationActive = false;
        private bool _isDrawRoutesActive = false;
        private void AllowEditFormation(object sender, RoutedEventArgs e)
        {
            _isDrawRoutesActive = false;
            _isEditFormationActive = true;
        }

        private void AllowDrawRoutes(object sender, RoutedEventArgs e)
        {
            _isEditFormationActive = false;
            _isDrawRoutesActive = true;
            Cursor = Cursors.Cross;
        }

        Point drawingStart;
        Point drawingEnd;
        bool isDrawing = false;
        private void DrawingCanvas(object sender, MouseButtonEventArgs e)
        {
            if (_isDrawRoutesActive)
            {
                drawingStart = e.GetPosition(OffensiveLineUpGrid);

                PathFigure routePath = new PathFigure();
                routePath.StartPoint = drawingStart;

                PathGeometry pathGeometry = new PathGeometry();
                pathGeometry.Figures.Add(routePath);

                Path path = new Path();
                path.Stroke = Brushes.Black;
                path.StrokeThickness = 2;
                path.Data = pathGeometry;

                this.MouseMove += (s, e) =>
                      {
                          if (e.LeftButton == MouseButtonState.Pressed)
                          {
                              drawingEnd = e.GetPosition(OffensiveLineUpGrid);
                              routePath.Segments.Add(new LineSegment(drawingEnd, true));
                          } else
                          {

                          }
                      };
                OffensiveLineUpGrid.Children.Add(path);
                Grid.SetColumnSpan(path, 3);
            }
        }
        private Point _startPoint_Player;
        private Point _startPoint_Drawing;
        private void SelectedPlayer_MouseDown(object sender, MouseButtonEventArgs e)
        {
            UIElement? _uIElement;

            if (_isEditFormationActive)
            {
                _startPoint_Player = e.GetPosition(this);
                _uIElement = (UIElement) sender;
                _uIElement.CaptureMouse();
            } else if (_isDrawRoutesActive)
            {
                //_uIElement = (UIElement) sender;
                //_startPoint_Drawing = e.GetPosition(this);
                //Border player = (Border) _uIElement;
                //DrawRoute(player, _startPoint_Drawing, e);
            }
        }

        private void MovePlayer(object sender, MouseEventArgs e)
        {
            UIElement? _uIElement;
            _uIElement = (UIElement) sender;

            if (e.LeftButton == MouseButtonState.Released || _isEditFormationActive == false)
            {
                _uIElement.ReleaseMouseCapture();
            } else if (_isEditFormationActive)
            {
                Point endPoint_Player = e.GetPosition(this);

                TranslateTransform? translateTansform = _uIElement.RenderTransform as TranslateTransform;
                if (translateTansform != null)
                {
                    translateTansform.X += endPoint_Player.X - _startPoint_Player.X;
                    translateTansform.Y += endPoint_Player.Y - _startPoint_Player.Y;

                    _startPoint_Player = endPoint_Player;
                }
            }
        }

        public MainWindow()
        {
            InitializeComponent();

            this.MouseMove += (o, e) =>
            {
                Point position = e.GetPosition(OffensiveLineUpGrid);
                Mouse_Pos.Text = $"X: {position.X} / Y: {position.Y}";

                IsMouseMoving.Text = $"Mouse-over: {OffensiveLineUpGrid.IsMouseOver}";
            };
        }
    }
}