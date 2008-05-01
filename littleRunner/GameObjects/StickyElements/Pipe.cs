﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.ComponentModel;

namespace littleRunner.GameObjects.StickyElements
{
    enum PipeColor
    {
        Green
    }
    class Pipe : StickyElement
    {
        private PipeColor color;
        private Image imgU, imgM;

        public override void Draw(Graphics g)
        {
            // Ceiling (round to x % 32 == 0)
            if (Height < 32)
                Height = 32;

            int rest = Height % 32;
            if (rest != 0)
            {
                if (rest < 16)
                    Height -= rest;
                else
                    Height += 32 - rest;
            }

            g.DrawImage(imgU, Left, Top, Width, imgU.Height);

            int occurences = Height / 32 - 1;
            for (int i = 0; i < occurences; i++)
            {
                g.DrawImage(imgM, Left, Top + imgU.Height + i * (32), Width, imgM.Height);
            }
        }


        override public bool canStandOn
        {
            get { return true; }
        }
        [Category("Pipe")]
        public PipeColor Color
        {
            get { return color; }
            set
            {
                color = value;
                switch (color)
                {
                    case PipeColor.Green:
                        imgU = Image.FromFile(Files.pipe_green_up);
                        imgM = Image.FromFile(Files.pipe_green_main);
                        break;
                }
            }
        }

        public Pipe()
            : base()
        {
        }
        public Pipe(int top, int left, PipeColor color)
            : this()
        {
            Top = top;
            Left = left;

            Color = color;

            Width = imgU.Width;
            Height = imgU.Height + imgM.Height;
        }

        public override Dictionary<string, object> Serialize()
        {
            Dictionary<string, object> ser = new Dictionary<string, object>(base.Serialize());
            ser["PipeColor"] = color;
            return ser;
        }
        public override void Deserialize(Dictionary<string, object> ser)
        {
            base.Deserialize(ser);
            Color = (PipeColor)ser["PipeColor"];
        }
    }
}