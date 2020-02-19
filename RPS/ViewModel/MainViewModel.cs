using RPS.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace RPS.ViewModel
{
    class MainViewModel : INotifyPropertyChanged
    {
        private RPSResult _player;
        private RPSResult _computer;

        private Random _rand;

        public ParametrizedRelayCommand Play { get; private set; }

        public MainViewModel()
        {
            Player = RPSResult.None;
            Computer = RPSResult.None;
            _rand = new Random();
            Play = new ParametrizedRelayCommand(
                (param) =>
                {
                    if (param is /*RPSResult*/ string)
                    {
                        switch (param)
                        {
                            //case RPSResult.None: Player = RPSResult.None; break;
                            case /*RPSResult.Rock*/ "1": Player = RPSResult.Rock; break;
                            case /*RPSResult.Scissors*/ "2": Player = RPSResult.Scissors; break;
                            case /*RPSResult.Paper*/ "3": Player = RPSResult.Paper; break;
                            default: Player = RPSResult.None; break;
                        }
                        Computer = (RPSResult)_rand.Next(3) + 1;
                    }
                },
                () => true
            );
        }

        public RPSResult Player
        {
            get
            {
                return _player;
            }
            set
            {
                _player = value;
                NotifyPropertyChanged();
            }
        }

        public RPSResult Computer
        {
            get
            {
                return _computer;
            }
            set
            {
                _computer = value;
                NotifyPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
