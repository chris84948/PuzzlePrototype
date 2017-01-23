using JustMVVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace PuzzlePrototype
{
    public class Block : MVVMBase
    {
        public static List<Color> ColorList = new List<Color>()
        {
            (Color)ColorConverter.ConvertFromString("#860DFF"),
            (Color)ColorConverter.ConvertFromString("#3D0CE8"),
            (Color)ColorConverter.ConvertFromString("#000CFF"),
            (Color)ColorConverter.ConvertFromString("#0C50E8"),
            (Color)ColorConverter.ConvertFromString("#0D97FF")
        };

        public int BlockSize { get; set; } = MainWindowViewModel.BLOCK;

        private double _bottom;
        public double Bottom
        {
            get { return _bottom; }
            set
            {
                _bottom = value;
                OnPropertyChanged();
            }
        }

        private double _left;
        public double Left
        {
            get { return _left; }
            set
            {
                _left = value;
                OnPropertyChanged();
            }
        }

        private int _x;
        public int X
        {
            get { return _x; }
            set
            {
                _x = value;
                Left = _x * MainWindowViewModel.BLOCK;
            }
        }

        private int _y;
        public int Y
        {
            get { return _y; }
            set
            {
                _y = value;
                Bottom = _y * MainWindowViewModel.BLOCK;
            }
        }

        public Color Color { get; set; }
        private static Random _random = new Random(DateTime.Now.Millisecond);

        public Block(int x, int y)
            : this(x, y, ColorList[_random.Next(ColorList.Count)])
        { }

        public Block(int x, int y, Color color)
        {
            X = x;
            Y = y;

            Color = color;
        }

        public override string ToString()
        {
            return $"({ X }, {Y}), { Color.ToString() }";
        }
    }
}
