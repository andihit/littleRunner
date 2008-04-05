﻿using System;
using System.Collections.Generic;
using System.Text;

namespace littleRunner.GameObjects.Objects
{
    enum BoxType
    {
        GoodMushroom,
        PoisonMushroom,
        FireFlower
    }
    enum BoxStyle
    {
        Yellow
    }
    class Box : StickyImageElement
    {
        BoxStyle style;
        BoxType btype;
        bool got;

        override public bool canStandOn
        {
            get { return true; }
        }
        public BoxStyle Style
        {
            get { return style; }
            set
            {
                style = value;
                switch (style)
                {
                    case BoxStyle.Yellow:
                        CurImgFilename = Files.f[gFile.box1];
                        break;
                }
            }
        }
        public BoxType BoxType
        {
            get { return btype; }
            set { btype = value; }
        }

        public override void onOver(GameEventHandler geventhandler, GameElement who, GameDirection direction)
        {
            base.onOver(geventhandler, who, direction);
            if (!got && direction == GameDirection.Bottom && who == GameElement.MGO)
            {
                if (btype == BoxType.GoodMushroom)
                {
                    Mushroom m = new Mushroom(MushroomType.Good, Top, Left);
                    m.Init(World);
                    World.MovingElements.Add(m);
                }
                else if (btype == BoxType.PoisonMushroom)
                {
                    Mushroom m = new Mushroom(MushroomType.Poison, Top, Left);
                    m.Init(World);
                    World.MovingElements.Add(m);
                }
                else if (btype == BoxType.FireFlower)
                {
                    FireFlower f = new FireFlower(Top, Left);
                    f.Init(World);
                    World.StickyElements.Add(f);
                }
                got = true;
            }
        }

        public Box()
            : base()
        {
            got = false;
        }
        public Box(int top, int left)
            : base(top, left)
        {
            got = false;
            Style = BoxStyle.Yellow;
        }


        public override Dictionary<string, object> Serialize()
        {
            Dictionary<string, object> ser = new Dictionary<string, object>(base.Serialize());
            ser["BoxType"] = btype;
            ser["BoxStyle"] = style;
            return ser;
        }
        public override void Deserialize(Dictionary<string, object> ser)
        {
            base.Deserialize(ser);
            btype = (BoxType)ser["BoxType"];
            Style = (BoxStyle)ser["BoxStyle"];
        }
    }
}
