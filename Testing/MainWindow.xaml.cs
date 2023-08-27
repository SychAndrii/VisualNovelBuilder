﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;
using Testing.Base;
using Testing.Elements;
using Testing.StoryDesignerElements;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Testing
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool hasDropped = false;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void canvas_DragOver(object sender, DragEventArgs e)
        {
            var dataObject = e.Data;
            var storyDesignElement = dataObject.GetData(typeof(StoryDesignerElementBase)) as StoryDesignerElementBase;

            if (storyDesignElement != null)
            {
                var elementStartingPointX = DragStartPositionProperties.GetDragStartX(storyDesignElement);
                var elementStartingPointY = DragStartPositionProperties.GetDragStartY(storyDesignElement);

                var position = e.GetPosition(StoryDesignerCanvas);

                if (StoryDesignerCanvas.Children.Contains(storyDesignElement))
                {
                    StoryDesignerCanvas.Children.Remove(storyDesignElement);
                }

                StoryDesignerCanvas.Children.Add(storyDesignElement);
                Canvas.SetTop(storyDesignElement, position.Y - elementStartingPointY);
                Canvas.SetLeft(storyDesignElement, position.X - elementStartingPointX);
            }
        }

        private void canvas_Drop(object sender, DragEventArgs e)
        {
            hasDropped = true;
        }
    }
}
