using Plugin.SimpleAudioPlayer;
using Plugin.SimpleAudioPlayer.Abstractions;
using Xamarin.Forms;
using System.Threading.Tasks;
using System;

namespace Afinador.ViewModels
{
    public class metronomoViewModel : BaseViewModel
    {
        public Command startStopCommand { get; }
        public bool play;
        public int delay;
        ISimpleAudioPlayer up = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.CreateSimpleAudioPlayer();
        ISimpleAudioPlayer down = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.CreateSimpleAudioPlayer();

        private int _sliderValue;
        public int SliderValue
        {
            get { return _sliderValue; }
            set
            {
                if (SetProperty(ref _sliderValue, value))
                {
                    Frequency = $"{SliderValue} bpm";
                    delay = Convert.ToInt32(Math.Floor(Convert.ToDouble((60.0 / (SliderValue)) * 1000))) - 16;
                }
            }
        }

        private string _frequency;
        public string Frequency
        {
            get { return _frequency; }
            set { SetProperty(ref _frequency, value); }
        }

        private int _minimo;
        public int Minimo
        {
            get { return _minimo; }
            set { SetProperty(ref _minimo, value); }
        }

        private int _maximo;
        public int Maximo
        {
            get { return _maximo; }
            set { SetProperty(ref _maximo, value); }
        }

        public metronomoViewModel()
        {
            startStopCommand = new Command(ExecuteStartStopCommand);
            down.Load("metronomeDown.flac");
            up.Load("metronomeUp.wav");
            play = false;
            Maximo = 218;
            Minimo = 40;
            SliderValue = 80;
        }

        void ExecuteStartStopCommand()
        {
            play = !play;
            PlayMetronome();
        }

        async void PlayMetronome()
        {
            while (play)
            {
                if (play) up.Play();
                else break;
                await Task.Delay(delay);
                if (play) down.Play();
                else break;
                await Task.Delay(delay);
                if (play) down.Play();
                else break;
                await Task.Delay(delay);
                if (play) down.Play();
                else break;
                await Task.Delay(delay);
            }
        }
    }
}
