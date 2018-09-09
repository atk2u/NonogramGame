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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NonogramGame
{
    public enum CellState
    {
        Clear, Marked, Cross
    }
    public class NonogramCell
    {
        public NonogramCell()
        {
            State = CellState.Clear;
        }

        public CellState State { get; set; }

        internal void ToggleCellMarker()
        {
            if (State == CellState.Clear)
            {
                State = CellState.Marked;
            }
            else if (State == CellState.Marked)
            {
                State = CellState.Clear;
            }
        }

        internal void ToggleCellCross()
        {
            if (State == CellState.Cross)
            {
                State = CellState.Clear;
            }
            else
            {
                State = CellState.Cross;
            }
        }
    }
}
