using System;
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
using System.Windows.Shapes;

namespace NonogramGame
{
    /// <summary>
    /// Interaction logic for NonogramGameWindow.xaml
    /// </summary>
    public partial class NonogramGameWindow : Window
    {
        public NonogramGameViewModel gameViewModel { get; set; }
                public NonogramGameWindow()
        {
            gameViewModel = new NonogramGameViewModel();
            InitializeComponent();
        }

        private void Rect_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ToggleCell(sender, "Left");
        }

        private void Rect_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            ToggleCell(sender, "Right");
        }

        private void Rect_MouseEnter(object sender, MouseEventArgs e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed)
            {
                Rect_MouseLeftButtonDown(sender, null);
            }
            else if (Mouse.RightButton == MouseButtonState.Pressed)
            {
                Rect_MouseRightButtonDown(sender, null);
            }
        }
        
        private void ToggleCell(object sender, string clickButton)
        {
            var cell = (Rectangle)sender;
            int row = Convert.ToInt16(cell.Name.Substring(4, 1));
            int column = Convert.ToInt16(cell.Name.Substring(5, 1));
            if (clickButton == "Left")
            {
                gameViewModel.NonogramCells[row, column].ToggleCellMarker();
            }
            else
            {
                gameViewModel.NonogramCells[row, column].ToggleCellCross();
            }
            cell.Fill = SetCellFill(gameViewModel.NonogramCells[row, column].State);
        }

        private Brush SetCellFill(CellState state)
        {
            
            switch (state)
            {
                case CellState.Clear:
                    return (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFF4F4F5"));
                case CellState.Marked:
                    return Brushes.Black;
                case CellState.Cross:
                    return new ImageBrush { ImageSource = new BitmapImage(new Uri("pack://application:,,,/NonogramGame;component/images/CrossCell.png", UriKind.Absolute)) };
                default:
                    return new ImageBrush { ImageSource = new BitmapImage(new Uri("/images/CrossCell.png")) };
            }
        }

    }
}
