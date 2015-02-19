using MusicDataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MusicClient.ViewModel
{
    public class ViewModelManageSong : ViewModelBase
    {
        // To estimate the right port run your project!
        private RESTRepository rest = 
            new RESTRepository("http://localhost:6008/api/");        

        private ViewModelBase vmParent;
        public ViewModelBase ViewModelParent 
        { 
            set { vmParent = value; } 
        }

        private SongDTO song = new SongDTO();
        public SongDTO Song 
        {
            get { return song; }
            set { song = value ?? new SongDTO(); }
        }

        public string Name 
        {
            get { return song.Name; }
            set { song.Name = value; }
        }

        public int Duration 
        {
            get { return song.Duration; }
            set { song.Duration = value; }
        }

        public int InterpreterId 
        {
            get { return song.InterpreterId; }
            set { song.InterpreterId = value; }
        }

        public int AlbumId 
        {
            get { return song.AlbumId; }
            set { song.AlbumId = value; }
        }

        public AlbumDTO Album 
        {
            get { return song.Album; }
            set { song.Album = value; }
        }

        // The next to properties enable editing those 
        // values in a user control (seeh ManageSongUserControl.xml)
        public IEnumerable<AlbumDTO> Albums
        {
            get
            {
                return rest.Get<AlbumDTO>();
            }
        }

        public IEnumerable<InterpreterDTO> Interpreters
        {
            get
            {
                return rest.Get<InterpreterDTO>();
            }
        }

        public ICommand Save
        {
            get
            {
                return new RelayCommand(
                    p =>
                    {
                        rest.Update<SongDTO>(song, song.SongId);

                        if (vmParent != null)
                            vmParent.OnPropertyChanged("Songs");
                    }
                );
            }
        }

        public ICommand Delete
        {
            get
            {
                return new RelayCommand(
                    p =>
                    {
                        rest.Delete<SongDTO>(song, song.SongId);

                        if (vmParent != null)
                            vmParent.OnPropertyChanged("Songs");
                    }
                );
            }
        }

        public ICommand Create
        {
            get
            {
                return new RelayCommand(
                    p =>
                    {
                        rest.Create<SongDTO>(song);

                        if (vmParent != null)
                            vmParent.OnPropertyChanged("Songs");
                    }
                );
            }
        }
    }
}
