﻿using System.Windows;
using System.Windows.Media;

namespace SIG.Model
{
    internal class Bomb : Sprite
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public Bomb(string p_graphics, Brush p_foreground, Size p_pixelSize, Point p_position, int[] p_sequence)
            : base(p_graphics, p_foreground, p_pixelSize, p_position, p_sequence)
        {
        }

        /// <summary>
        /// Animate enemy sprite
        /// </summary>
        public void Animate()
        {
            if (SequenceIndex < Sequence.Length - 1)
            {
                SequenceIndex++;
            }
            else
            {
                SequenceIndex = 0;
            }
            //LoadGraphics(SequenceIndex);
            Select(SequenceIndex);
        }
    }
}