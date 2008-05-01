using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;


namespace littleRunner.GameObjects.StickyElements
{
    abstract class StickyImageElement : StickyElement
    {
        private Image curimg;
        private string curimgfn;

        public override void Draw(Graphics g)
        {
            if (curimgfn == Files.brick_invisible && World.PlayMode == PlayMode.Editor)
                g.DrawRectangle(Pens.Black, Left, Top, Width, Height);

            g.DrawImage(curimg, Left, Top, Width, Height);
        }
        protected string CurImgFilename
        {
            set
            {
                curimgfn = value;
                curimg = Image.FromFile(curimgfn);
                Width = curimg.Width;
                Height = curimg.Height;
            }
        }

        public StickyImageElement()
        {
        }
        public StickyImageElement(int top, int left)
        {
            Top = top;
            Left = left;
        }
        public StickyImageElement(int top, int left, string imgfn) : this(top, left)
        {
            CurImgFilename = imgfn;
        }
    }
}