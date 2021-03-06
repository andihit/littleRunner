using System;
using System.Collections.Generic;
using System.Text;

using littleRunner.GameObjects;
using System.Diagnostics;


namespace littleRunner
{
    public static class GamePhysics
    {
        public static class FallingClass<T> where T : GameObject
        {
            public static bool CheckFalling(List<T> list, GameObject go,
                float newtop, float newleft)
            {
                bool falling = true;

                for (int i=0; i<list.Count; i++)
                {
                    T el = list[i];

                    if (el.canStandOn)
                    {
                        if (go.Right+newleft > el.Left && go.Left+newleft < el.Right && // left+right ok?
                            Math.Abs(go.Bottom+newtop - el.Top) < Globals.Approximation)
                        {
                            falling = false;
                            break;
                        }
                    }
                }

                return falling;
            }
        }

        static public bool Falling(List<StickyElement> stickyelements,
            List<MovingElement> movingelements,
            List<Enemy> enemies,
            float newtop,
            float newleft,
            GameObject go)
        {
            if (!FallingClass<StickyElement>.CheckFalling(stickyelements, go, newtop, newleft))
                return false;
            else if (!FallingClass<MovingElement>.CheckFalling(movingelements, go, newtop, newleft))
                return false;
            else if (!FallingClass<Enemy>.CheckFalling(enemies, go, newtop, newleft))
                return false;

            return true;
        }


        public struct JumpData
        {
            public GameDirection direction;
            public float distance;
        }
        static public void Jumping(ref JumpData jumping, ref float newtop, ref float newleft)
        {
            if (jumping.direction == GameDirection.None)
                return;


            // jump left
            if (jumping.direction == GameDirection.Left)
            {
                float nleft = Globals.MGOMove.GO_X * GameAI.FrameFactor;
                float ntop = Globals.MGOMove.Jump * GameAI.FrameFactor;

                if (jumping.distance <= 250)
                {
                    newleft -= nleft;
                    newtop -= ntop;
                }
                else if (jumping.distance <= 500)
                {
                    newleft -= nleft;
                    newtop += ntop;
                }
                else
                    jumping.direction = GameDirection.None;

                jumping.distance += nleft + ntop;
            }

            // jump top
            if (jumping.direction == GameDirection.Top)
            {
                float ntop = Globals.MGOMove.Jump * GameAI.FrameFactor;

                if (jumping.distance <= 200)
                    newtop -= ntop;
                else if (jumping.distance <= 400)
                    newtop += ntop;
                else
                    jumping.direction = GameDirection.None;

                jumping.distance += ntop;
            }

            // jump right
            if (jumping.direction == GameDirection.Right)
            {
                float nleft = Globals.MGOMove.GO_X * GameAI.FrameFactor;
                float ntop = Globals.MGOMove.Jump * GameAI.FrameFactor;

                if (jumping.distance <= 250)
                {
                    newleft += nleft;
                    newtop -= ntop;
                }
                else if (jumping.distance <= 500)
                {
                    newleft += nleft;
                    newtop += ntop;
                }
                else
                    jumping.direction = GameDirection.None;

                jumping.distance += nleft + ntop;
            }
        }


        static public bool SingleCrashDetection(GameObject go, GameObject go2, out GameDirection direction, ref float newtop, ref float newleft, bool change)
        {
            bool crashedIn = false;
            direction = GameDirection.None;

            int enemy = 0;
            if (go2 is Enemy)
                enemy = 1;


            if (go.Right + newleft > go2.Left && go.Left + newleft < go2.Right && // left+right ok?
                go.Bottom + newtop + enemy > go2.Top && go.Top + newtop < go2.Bottom)
            {
                if (go.Right <= go2.Left) // crash into right
                {
                    if (change)
                        newleft = go2.Left - go.Right;
                    direction = GameDirection.Left;
                }
                else if (go.Left >= go2.Right)
                {
                    if (change)
                        newleft = -(go.Left - go2.Right);
                    direction = GameDirection.Right;
                }

                crashedIn = true;
            }

            // newleft may be changed, recheck!
            if (go.Right + newleft > go2.Left && go.Left + newleft < go2.Right && // left+right ok?
                go.Bottom + newtop + enemy > go2.Top && go.Top + newtop < go2.Bottom)
            {
                if (go.Bottom - 5 < go2.Top)
                {
                    if (change)
                        newtop = go2.Top - go.Bottom;
                    direction = GameDirection.Top;
                }
                else if (go.Top + 5 > go2.Bottom)
                {
                    if (change)
                        newtop = -(go.Top - go2.Bottom);
                    direction = GameDirection.Bottom;
                }

                crashedIn = true;
            }

            return crashedIn;
        }

        static public void CrashDetection(GameObject go, List<StickyElement> stickyelements, List<MovingElement> movingelements, GameEventHandler geventhandler, ref float newtop, ref float newleft)
        {
            for (int i = 0; i < stickyelements.Count; i++)
            {
                StickyElement se = stickyelements[i];
                if (se != go)
                {
                    GameDirection direction = GameDirection.None;
                    if (SingleCrashDetection(go, se, out direction, ref newtop, ref newleft, se.canStandOn))
                    {
                        se.onOver(geventhandler, GameAI.WhoIsIt(go), direction);
                    }
                }
            }

            for (int i = 0; i < movingelements.Count; i++)
            {
                MovingElement me = movingelements[i];
                if (me != go)
                {
                    GameDirection direction = GameDirection.None;
                    if (SingleCrashDetection(go, me, out direction, ref newtop, ref newleft, me.canStandOn))
                    {
                        me.onOver(geventhandler, GameAI.WhoIsIt(go), direction);
                    }
                }
            }
        }
       

        static public Enemy CrashEnemy(GameObject go, List<Enemy> enemies, GameEventHandler geventhandler, ref float newtop, ref float newleft)
        {
            Enemy crashedIn = null;

            for (int i=0; i<enemies.Count; i++)
            {
                Enemy enemie = enemies[i];

                if (enemie != go)
                {
                    GameDirection direction;
                    if (SingleCrashDetection(go, enemie, out direction, ref newtop, ref newleft, true))
                    {
                        if (!enemie.getCrashEvent(go, direction))
                            geventhandler(GameEvent.crashInEnemy, new Dictionary<GameEventArg, object>());
                        crashedIn = enemie;
                        break;
                    }
                }
            }

            return crashedIn;
        }



        static public bool SimpleCrashDetection(GameObject my, GameObject box, float newtop, float newleft)
        {
            return my.Left + newleft < box.Right && my.Right + newleft > box.Left &&
                   my.Top + newtop < box.Bottom && my.Bottom + newtop > box.Top;
        }

        private static class SimpleCrashDetectionClass<T> where T : GameObject
        {
            public static T SimpleCrashDetections(GameObject my, List<T> list,
                bool onlyWhenCanStandOn, float newtop, float newleft)
            {
                for (int i=0; i<list.Count; i++)
                {
                    T el = list[i];

                    if ((onlyWhenCanStandOn && el.canStandOn) || !onlyWhenCanStandOn)
                    {
                        if (SimpleCrashDetection(my, el, newtop, newleft))
                            return el;
                    }
                }
                return null;
            }
        }

        static public bool SimpleCrashDetections(GameObject my, List<StickyElement> stickyelements,
            List<MovingElement> movingelements,
            bool onlyWhenCanStandOn, float newtop, float newleft)
        {
            if (SimpleCrashDetectionClass<StickyElement>.SimpleCrashDetections(my, stickyelements, onlyWhenCanStandOn, newtop, newleft) != null)
                return true;

            if (SimpleCrashDetectionClass<MovingElement>.SimpleCrashDetections(my, movingelements, onlyWhenCanStandOn, newtop, newleft) != null)
                return true;
            return false;
        }

    }
}
