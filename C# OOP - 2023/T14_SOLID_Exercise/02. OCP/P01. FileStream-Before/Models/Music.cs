﻿namespace P01._FileStream_Before
{
    class Music : File
    {
        public Music(string name, int length, int sent, string artist, string album)
            : base(name, length, sent)
        {
            Artist = artist;
            Album = album;
        }

        public string Artist { get; set; }

        public string Album { get; set; }
    }
}
