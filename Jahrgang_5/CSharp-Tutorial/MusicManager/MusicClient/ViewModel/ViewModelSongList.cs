using MusicDataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicClient.ViewModel
{
    public class ViewModelSongList : ViewModelBase
    {
        private RESTRepository rest = 
            new RESTRepository("http://localhost:6008/api/");

        public IEnumerable<InterpreterDTO> Interpreters
        {
            get
            {
                return rest.Get<InterpreterDTO>();
            }
        }        

        public IEnumerable<SongDTO> Songs
        {
            get
            {
                return selectedInterpreter != null ?
                    rest.Get<SongDTO>("?interpreterid=" + 
                    selectedInterpreter.InterpreterId.ToString()) :
                    new SongDTO[0];
            }
        }        

        // stores a selection coming from the XAML
        private InterpreterDTO selectedInterpreter;
        public InterpreterDTO SelectedInterpreter
        {
            get { return selectedInterpreter; }
            set
            {
                selectedInterpreter = value;
                OnPropertyChanged("SelectedInterpreter");
                OnPropertyChanged("Songs");
            }
        }

        // stores a selection coming from the XAML
        private SongDTO selectedSong;
        public SongDTO SelectedSong 
        {
            get { return selectedSong; }
            set
            {
                selectedSong = value;
                OnPropertyChanged("SelectedSong");
                OnPropertyChanged("ViewModelManageSong");
            }
        }

        public ViewModelManageSong ViewModelManageSong
        {
            get
            {
                var vmpm = Factory.Get<ViewModelManageSong>();
                vmpm.Song = selectedSong;
                vmpm.ViewModelParent = this;
                return vmpm;
            }
        }
    }
}
