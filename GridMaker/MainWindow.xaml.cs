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

            List<Point> routePoints = new List<Point>();
            MouseEventHandler mouseEventHandler = null;
            Point startPoint = default(Point);
            Point endPoint = default(Point);
            if (_isDrawRoutesActive && OffensiveLineUpGrid.IsMouseOver)
            {
                if (e.LeftButton == MouseButtonState.Pressed)
                {
                    startPoint = e.GetPosition(OffensiveLineUpGrid);
                    Mouse_Pos.Text = $"X: {startPoint.X} / Y: {startPoint.Y}";
                    routePoints.Add(startPoint);
                }

                DistanceCalculator distanceCalculator = new DistanceCalculator();
                int minDistance = 50;
                mouseEventHandler = (s, e) =>
                {
                    if (e.LeftButton == MouseButtonState.Released)
                    {
                        OffensiveLineUpGrid.MouseMove -= mouseEventHandler;
                    } else
                    {
                        endPoint = e.GetPosition(OffensiveLineUpGrid);

                        double distance = distanceCalculator.CalculateDistanceBetweenPoints(endPoint.X, startPoint.X, endPoint.Y, startPoint.Y);
                        if (distance > minDistance)
                        {
                            startPoint = endPoint;
                            Mouse_Pos.Text = $"X: {startPoint.X} / Y: {startPoint.Y}";
                        }

                    }
                };

                OffensiveLineUpGrid.MouseMove += mouseEventHandler;
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

        public MainWindow()
        {
            InitializeComponent();
        }
    }
}