using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Threading;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;
using System.Collections;

namespace MazeHunter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public bool IsBFS { get; set; }
        public bool IsDFS { get; set; }
        public bool IsTSP { get; set; }
        public bool ToggleAnimation { get; set; }
        public static Grid MapGrid { get; set; }
        private String filePath { get; set; }


        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            MapGrid = new Grid
            {
                Height = 600,
                Width = 600,
                Margin = new Thickness(10)
            };
            Grid.SetColumn(MapGrid, 1);
            MainGrid.Children.Add(MapGrid);
        }

        private void OpenFileButton(object sender, RoutedEventArgs e)
        {

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = @"c:\temp\";
            openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == true) {
                //Get the path of specified file
                filePath = openFileDialog.FileName;
                MessageBox.Show(filePath);

                //Read the contents of the file into a stream
                var fileStream = openFileDialog.OpenFile();
                FileName.Text = System.IO.Path.GetFileName(filePath);
                MapGrid.Children.Clear();
                MapGrid.RowDefinitions.Clear();
                MapGrid.ColumnDefinitions.Clear();
                Peta map = new Peta();
                try
                {
                    map.readFrom(filePath);
                    int nRow = map.GetNumRow();
                    int nCol = map.GetNumCol();
                    GridLengthConverter gridLengthConverter = new GridLengthConverter();
                    for (int i = 0; i < nRow; i++)
                    {
                        MapGrid.RowDefinitions.Add(new RowDefinition());
                        MapGrid.RowDefinitions[i].Height = (GridLength)gridLengthConverter.ConvertFrom("*");
                    }

                    for (int i = 0; i < nCol; i++)
                    {
                        MapGrid.ColumnDefinitions.Add(new ColumnDefinition());
                        MapGrid.ColumnDefinitions[i].Width = (GridLength)gridLengthConverter.ConvertFrom("*");
                    }

                    for (int i = 0; i < nRow; i++)
                    {
                        for (int j = 0; j < nCol; j++)
                        {
                            Label txt = new Label();
                            Border border = new Border();
                            border.BorderThickness = new Thickness(0.5);
                            border.BorderBrush = Brushes.Gray;
                            Grid.SetRow(border, i);
                            Grid.SetColumn(border, j);
                            if (map.GetValue(j, i).Type == 0)
                            {
                                txt.Content = "START";
                                border.Background = Brushes.LightSeaGreen;
                                txt.HorizontalAlignment = HorizontalAlignment.Center;
                                txt.VerticalAlignment = VerticalAlignment.Center;
                            }
                            else if (map.GetValue(j, i).Type == 1)
                            {
                                border.Background = Brushes.Black;
                                border.BorderThickness = new Thickness(0);
                            }
                            else if (map.GetValue(j, i).Type == 2)
                            {
                                border.Background = Brushes.White;
                            }
                            else if (map.GetValue(j, i).Type == 3)
                            {
                                txt.Content = "TREASURE";
                                border.Background = Brushes.Yellow;
                                txt.HorizontalAlignment = HorizontalAlignment.Center;
                                txt.VerticalAlignment = VerticalAlignment.Center;
                            }
                            MapGrid.Children.Add(border);
                            border.Child = txt;
                        }
                    }
                } 
                catch (InvalidCharacterException ex)
                {
                    MessageBox.Show(ex.Message);

                }
                catch (RowInconsistentException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                
            }

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void VisualiseButton(object sender, RoutedEventArgs e)
        {
            if (IsBFS)
            {
                var watch = new System.Diagnostics.Stopwatch();
                BFS routeFinder = new BFS();
                routeFinder.readFrom(filePath);

                watch.Start();

                routeFinder.Solve(IsTSP);

                watch.Stop();

                string RouteString = routeFinder.Solusi.GetRouteDisplay();
                RouteTaken.Text = RouteString;
                ExecutionTime.Text = String.Format("{0} ms", watch.ElapsedMilliseconds);
                StepsTaken.Text = (routeFinder.Solusi.JalurAccessor.Count - 1).ToString();
                NodesChecked.Text = (routeFinder.SumNodesChecked()).ToString();

                foreach (Cell cell in routeFinder.Solusi.JalurAccessor)
                {
                    var childEnumerator = MapGrid.Children.GetEnumerator();
                    while (childEnumerator.MoveNext())
                    {
                        Border child = (Border)childEnumerator.Current;
                        if (Grid.GetColumn(child) == cell.X && Grid.GetRow(child) == cell.Y)
                        {
                            ((Border)childEnumerator.Current).Background = Brushes.LightGreen;
                        }
                    }
                }
            } else if (IsDFS)
            {
                var watch = new System.Diagnostics.Stopwatch();
                DFS routeFinder = new DFS();
                routeFinder.readFrom(filePath);

                watch.Start();

                routeFinder.Solve(IsTSP);

                watch.Stop();

                string RouteString = routeFinder.Solusi.GetRouteDisplay();
                RouteTaken.Text = RouteString;
                ExecutionTime.Text = String.Format("{0} ms", watch.ElapsedMilliseconds);
                StepsTaken.Text = (routeFinder.Solusi.JalurAccessor.Count - 1).ToString();
                NodesChecked.Text = (routeFinder.SumNodesChecked()).ToString();

                foreach (Cell cell in routeFinder.Solusi.JalurAccessor)
                {
                    var childEnumerator = MapGrid.Children.GetEnumerator();
                    while (childEnumerator.MoveNext())
                    {
                        Border child = (Border)childEnumerator.Current;
                        if (Grid.GetColumn(child) == cell.X && Grid.GetRow(child) == cell.Y)
                        {
                            ((Border)childEnumerator.Current).Background = Brushes.LightGreen;
                        }
                    }
                }
            } 
            else
            {
                MessageBox.Show("The algorithm has not been selected.");
                return;
            }



        }
    }
}
