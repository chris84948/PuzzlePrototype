using JustMVVM;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzlePrototype
{
    public class MainWindowViewModel : MVVMBase
    {
        public const int NUM_COLS = 10;
        public const int NUM_ROWS = 16;
        public const int BLOCK = 40;

        private ObservableCollection<Block> _blocks;
        public ObservableCollection<Block> Blocks
        {
            get { return _blocks; }
            set
            {
                _blocks = value;
                OnPropertyChanged();
            }
        }

        public double Width { get { return NUM_COLS * BLOCK; } }
        public double Height { get { return NUM_ROWS * BLOCK; } }

        public MainWindowViewModel()
        {
            Blocks = new ObservableCollection<Block>();

            Task.Run(async () =>
            {
                try
                {
                    for (int row = 0; row < NUM_ROWS; row++)
                    {
                        for (int col = 0; col < NUM_COLS; col++)
                        {
                            var newBlock = new Block(0, NUM_ROWS - 1);

                            App.Current.Dispatcher.Invoke(() => Blocks.Add(newBlock));
                            await Task.Delay(400);
                            App.Current.Dispatcher.Invoke(() => { newBlock.X = col; newBlock.Y = row; });
                            await Task.Delay(200);
                        }
                    }
                }
                catch (Exception ex)
                {
                    System.Windows.MessageBox.Show(ex.ToString());
                }
            });
        }
    }
}
