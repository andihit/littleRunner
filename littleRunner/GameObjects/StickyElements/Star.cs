﻿using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace littleRunner.GameObjects.StickyElements
{
    enum StarStyle
    {
        Yellow
    }
    class Star : StickyImageElement
    {
        StarStyle style;

        override public bool canStandOn
        {
            get { return false; }
        }
        [Category("Star")]
        public StarStyle Style
        {
            get { return style; }
            set
            {
                style = value;
                switch (style)
                {
                    case StarStyle.Yellow:
                        CurImgFilename = Files.star;
                        break;
                }
            }
        }
        override public void onOver(GameEventHandler geventhandler, GameElement who, GameDirection direction)
        {
            base.onOver(geventhandler, who, direction);

            if (who == GameElement.MGO)
            {
                Dictionary<GameEventArg, object> pointArgs = new Dictionary<GameEventArg, object>();
                pointArgs[GameEventArg.points] = 1;
                geventhandler(GameEvent.gotPoints, pointArgs);

                World.StickyElements.Remove(this);
            }
        }


        public Star()
            : base()
        {
        }
        public Star(float top, float left)
            : base(top, left)
        {
            Style = StarStyle.Yellow;
        }


        public override Dictionary<string, object> Serialize()
        {
            Dictionary<string, object> ser = new Dictionary<string, object>(base.Serialize());
            ser["StarStyle"] = style;
            return ser;
        }
        public override void Deserialize(Dictionary<string, object> ser)
        {
            base.Deserialize(ser);
            Style = (StarStyle)ser["StarStyle"];
        }
    }
}
