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
        public static NonogramGameViewModel gameViewModel;
        public NonogramGameWindow()
        {
            gameViewModel = new NonogramGameViewModel();
            InitializeComponent();
        }

        private void Rect_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var cell = (Rectangle)sender;
            int row = Convert.ToInt16(cell.Name.Substring(4, 1));
            int column = Convert.ToInt16(cell.Name.Substring(5, 1));
            gameViewModel.NonogramCells[row, column].ToggleCellMarker();
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

        private void Rect_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            var cell = (Rectangle)sender;
            int row = Convert.ToInt16(cell.Name.Substring(4, 1));
            int column = Convert.ToInt16(cell.Name.Substring(5, 1));
            gameViewModel.NonogramCells[row, column].ToggleCellCross();
            cell.Fill = SetCellFill(gameViewModel.NonogramCells[row, column].State);
        }
    }
}
