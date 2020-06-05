using System;
using System.Collections.Generic;
using System.Text;

namespace BeatSaberToSeriousGameConverter
{
    public class NoteIn
    {
        public float _time { get; set; }
        public int _lineIndex { get; set; }
        public int _lineLayer { get; set; }
        public int _type { get; set; }
        public int _cutDirection { get; set; }
    }
}
