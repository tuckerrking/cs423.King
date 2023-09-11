﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lab03
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int animationCount = 0;
        private int treeDepth = 0;
        private int depthLimit = 10;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnStart_Click(object sender, RoutedEventArgs e)
        {
            Canvas1.Children.Clear();
            tbLabel.Text = "";
            animationCount = 0;
            treeDepth = 1;
            CompositionTarget.Rendering += StartAnimation;
        }

        private void StartAnimation(object sender, EventArgs e)
        {
            animationCount += 1;
            if (animationCount % 60 == 0)
            {
                DrawBinaryTree(
                     Canvas1,
                     treeDepth,
                     new Point(Canvas1.Width / 2, 0.83 * Canvas1.Height),
                     0.2 * Canvas1.Width,
                     -Math.PI / 2
                );
                string str = "Binary Tree - Depth = " +
                             treeDepth.ToString();
                tbLabel.Text = str;
                treeDepth += 1;
                if (treeDepth > depthLimit)
                {
                    tbLabel.Text = "Binary Tree - Depth = 10. Finished";
                    CompositionTarget.Rendering -= StartAnimation;
                }
            }
        }

        private double lengthScale = 0.75;
        private double deltaTheta = Math.PI / 5;

        private void DrawBinaryTree(Canvas canvas, int depth, Point pt,
             double length, double theta)
        {
            double x1 = pt.X + length * Math.Cos(theta);
            double y1 = pt.Y + length * Math.Sin(theta);
            Line line = new Line();
            line.Stroke = Brushes.Blue;
            line.X1 = pt.X;
            line.Y1 = pt.Y;
            line.X2 = x1;
            line.Y2 = y1;
            canvas.Children.Add(line);
            if (depth < depthLimit)
            {
                DrawBinaryTree(canvas, depth + 1,
                     new Point(x1, y1),
                     length * lengthScale, theta + deltaTheta);
                DrawBinaryTree(canvas, depth + 1,
                     new Point(x1, y1),
                     length * lengthScale, theta - deltaTheta);
            }
            else
                return;
        }
    }
}
