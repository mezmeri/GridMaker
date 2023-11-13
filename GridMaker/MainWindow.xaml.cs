using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using GridMaker.Controllers;

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
            Cursor = Cursors.Arrow;
        }

        private void AllowDrawRoutes(object sender, RoutedEventArgs e)
        {
            _isEditFormationActive = false;
            _isDrawRoutesActive = true;
            Cursor = Cursors.Cross;
        }

        private void DrawRoutes_LeftMouseDown(object sender, MouseButtonEventArgs e)
        {
            MouseEventHandler mouseEventHandler = null;
            Point startPoint;
            Point endPoint;

            // Graphics for route
            Path path = new Path();
            path.StrokeThickness = 4;
            path.Stroke = Brushes.Black;

            PathFigure pathFigure;
            PathGeometry pathGeometry;

            if (_isDrawRoutesActive && OffensiveLineUpGrid.IsMouseOver)
            {
                pathFigure = new();
                pathGeometry = new();

                List<Point> routePoints = new List<Point>();
                startPoint = e.GetPosition(OffensiveLineUpGrid);
                routePoints.Add(startPoint);
                pathFigure.StartPoint = routePoints[0];
                Mouse_Pos.Text = $"X: {startPoint.X} / Y: {startPoint.Y}";

                int minDistance = 17;
                mouseEventHandler = (s, e) =>
                {
                    if (e.LeftButton == MouseButtonState.Released)
                    {
                        OffensiveLineUpGrid.MouseMove -= mouseEventHandler;
                    } else
                    {
                        endPoint = e.GetPosition(OffensiveLineUpGrid);

                        double distance = DistanceCalculator.CalculateDistanceBetweenPoints(endPoint.X, startPoint.X, endPoint.Y, startPoint.Y);
                        if (distance > minDistance)
                        {
                            startPoint = endPoint;
                            Mouse_Pos.Text = $"X: {startPoint.X} / Y: {startPoint.Y}";

                            routePoints.Add(startPoint);

                            pathGeometry.Figures.Add(pathFigure);
                            path.Data = pathGeometry;

                            pathFigure.Segments.Add(new QuadraticBezierSegment(routePoints[routePoints.Count - 2], endPoint, true));
                        }

                    }
                };
                OffensiveLineUpGrid.MouseMove += mouseEventHandler;
                OffensiveLineUpGrid.Children.Add(path);
                Grid.SetColumnSpan(path, 3);
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
                // Handle player menus etc
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
        private async void Add_Player_Click(object sender, RoutedEventArgs e)
        {
            Border player = FieldController.AddPlayerToField();

            OffensiveLineUpGrid.Children.Add(player);
        }
        public MainWindow()
        {
            InitializeComponent();
        }

    }
}