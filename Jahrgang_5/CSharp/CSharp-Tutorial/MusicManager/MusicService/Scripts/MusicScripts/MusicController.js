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

var selectedSong = null;
var baseurl = 'http://localhost:6008/api/';

$(function () {
    loadInterpreters('#selInterpreter');
    $('#selInterpreter').change(function () {
        loadSongs(this.value);
    });
    $('#saveButton').click(function () {
        selectedSong.Name = $('#name').val();
        selectedSong.Duration = $('#duration').val();
        saveSong(selectedSong);
    });
})

function loadInterpreters(select) {
    $.getJSON(baseurl + 'interpreter', function (data) {
        $.each(data, function (index, item) {
            $('<option value = ' + item.InterpreterId + '>' + item.Name + '</option>')
                .appendTo(select);
        });
    });
}

function loadSongs() {
    $('#tableSongs tbody tr').remove();
    $.getJSON(baseurl + 'song?interpreterid=' + $('#selInterpreter').val(), function (data) {
        $.each(data, function (index, item) {
            $('<tr><td>' + item.Name +
                '</td><td>' + item.Duration +
                '</td><td>' + //item.Ablum.Name +
                '</td></tr>')
                .appendTo('#tableSongs')
                .hover(function () {
                    $(this).css('background-color', 'lightblue');
                }, function () {
                    $(this).css('background-color', '');
                })
                .click(function () {
                    editSong(item);
                });
        });
    });
}

function editSong(song) {
    selectedSong = song;
    $('#name').val(song.Name);
    $('#duration').val(song.Duration);
}

function saveSong(song) {
    var url = baseurl + 'song/' + song.SongId;
    $.ajax({
        url: url,
        type: 'PUT',
        data: song,
        success: function () {
            loadSongs($('#selInterpreters').val());
        },
        error: function (xhr, status, msg) {
            alert(msg);
        }
    });
}
