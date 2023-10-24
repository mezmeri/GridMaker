using System;
using System.Collections.Generic;
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

        private Point drawingStartPoint;
        private Point drawingEndPoint;

        private void DrawingCanvas(object sender, MouseButtonEventArgs e)
        {
            List<Point> routePoints = new List<Point>();

            if (_isDrawRoutesActive)
            {
                drawingStartPoint = e.GetPosition(OffensiveLineUpGrid);

                Path? routePath = null;

                double minDistance = 10;

                OffensiveLineUpGrid.MouseMove += (s, e) =>
                {
                    if (e.LeftButton == MouseButtonState.Pressed)
                    {
                        drawingEndPoint = e.GetPosition(OffensiveLineUpGrid);

                        if (drawingStartPoint == default(Point))
                        {
                            drawingStartPoint = drawingEndPoint;
                            return;
                        }

                        // Pythagorean theorem to calculate the distance between two points :p
                        double distance = Math.Sqrt(Math.Pow(drawingEndPoint.X - drawingStartPoint.X, 2) + Math.Pow(drawingEndPoint.Y - drawingStartPoint.Y, 2));

                        if (distance >= minDistance)
                        {
                            routePoints.Add(drawingEndPoint);
                            drawingStartPoint = drawingEndPoint;
                        }
                    }
                    
                    if (e.LeftButton == MouseButtonState.Released)
                    {

                        PathFigure pathFigure = new PathFigure();

                        PathGeometry pathGeometry = new PathGeometry();
                        pathGeometry.Figures.Add(pathFigure);

                        Path path = new Path();
                        path.Stroke = Brushes.Black;
                        path.StrokeThickness = 2;
                        path.Data = pathGeometry;

                        if (routePoints.Count >= 3)
                        {
                            pathFigure.Segments.Add(new QuadraticBezierSegment(routePoints[routePoints.Count - 2], drawingEndPoint, true));
                        }
                        OffensiveLineUpGrid.Children.Add(path);
                        Grid.SetColumnSpan(path, 3);
                    }
                };
            }
        }

        private Point _startPoint_Player;
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
                // Handle player menues etc
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