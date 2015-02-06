/************************************************************************
 * Copyright (C) 2015 Richard Bäck <richard.baeck@openmailbox.org>
 *
 * This file is part of assets-cli.
 *
 * assets-cli is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * assets-cli is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with assets-cli.  If not, see <http://www.gnu.org/licenses/>.
 ***********************************************************************/

using MusicClient.ViewModel;
using MusicDataLayer;
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

namespace MusicClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = Factory.Get<ViewModel.ViewModelSongList>();
        }

        private void DataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ManageSongDialog dlg = new ManageSongDialog
            {
                DataContext = ((ViewModelSongList)DataContext).ViewModelManageSong
            };
            dlg.ShowDialog();
        }
    }
}
