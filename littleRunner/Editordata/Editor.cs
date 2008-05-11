using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using littleRunner.Drawing;
using littleRunner.Drawing.Helpers;
using littleRunner.Gamedata.Worlddata;
using littleRunner.GameObjects;
using littleRunner.GameObjects.Enemies;
using littleRunner.GameObjects.MovingElements;
using littleRunner.GameObjects.StickyElements;


namespace littleRunner.Editordata
{
    public partial class Editor : Form
    {
        ProgramSwitcher programSwitcher;
        Game g;
        TmpFileHandler tmpHandler;
        Drawing.DrawHandler drawHandler;

        World world;
        GameObject focus;
        int defaultContextMenuItems;
        bool moving;
        bool enableBG;
        int mouseX, mouseY;
        List<Keys> pressedKeys;

        GamePoint startRectangle, endRectangle;
        Rectangle curRectangle;

        public Editor(ProgramSwitcher programSwitcher)
        {
            InitializeComponent();

            // extern inits
            drawHandler = GetDraw.DrawHandler(level, this.Update);
            AnimateImage.Refresh = false;
            EditorUI.drawHandler = drawHandler;
            EditorUI.properties = properties;


            this.programSwitcher = programSwitcher;
            World defaultWorld = new World();
            tmpHandler = new TmpFileHandler(openFile, saveFile, defaultWorld.Serialize, 5);
            defaultWorld = null;
            defaultContextMenuItems = objectContext.Items.Count;
            curRectangle = Rectangle.Empty;

            focus = null;
            moving = false;
            mouseX = 0;
            mouseY = 0;
            enableBG = true;
            pressedKeys = new List<Keys>();


            #region Images loading
            floorToolStripMenuItem.Image = Image.FromFile(Files.floor_middle);
            floorToolStripButton.Image = Image.FromFile(Files.floor_middle);

            designElementToolStripMenuItem.Image = Image.FromFile(Files.tree);
            treeToolStripMenuItem.Image = Image.FromFile(Files.tree);
            treeToolStripButton.Image = Image.FromFile(Files.tree);

            brickToolStripMenuItem.Image = Image.FromFile(Files.brick_blue);
            brickToolStripButton.Image = Image.FromFile(Files.brick_blue);

            boxToolStripMenuItem.Image = Image.FromFile(Files.box1);
            boxToolStripButton.Image = Image.FromFile(Files.box1); ;

            pipeToolStripMenuItem.Image = Image.FromFile(Files.pipe_green_up);
            pipeToolStripButton.Image = Image.FromFile(Files.pipe_green_up); ;

            pointStarToolStripMenuItem.Image = Image.FromFile(Files.star);
            starToolStripButton.Image = Image.FromFile(Files.star); ;

            platformToolStripMenuItem.Image = Image.FromFile(Files.brick_blue);
            bricksToolStripMenuItem.Image = Image.FromFile(Files.brick_blue);
            bricksToolStripButton.Image = Image.FromFile(Files.brick_blue); ;

            enemyToolStripMenuItem.Image = AnimateImage.FirstImage(Files.turtle_green).ToGDI();
            turtleToolStripMenuItem.Image = AnimateImage.FirstImage(Files.turtle_green).ToGDI();
            turtleToolStripButton.Image = AnimateImage.FirstImage(Files.turtle_green).ToGDI();

            spikaToolStripMenuItem.Image = Image.FromFile(Files.spika_green);
            spikaToolStripButton.Image = Image.FromFile(Files.spika_green); ;

            gumbaToolStripMenuItem.Image = AnimateImage.FirstImage(Files.gumba_brown).ToGDI();
            gumbaToolStripButton.Image = AnimateImage.FirstImage(Files.gumba_brown).ToGDI();

            levelEndToolStripMenuItem.Image = Image.FromFile(Files.levelend_house);
            houseToolStripMenuItem.Image = Image.FromFile(Files.levelend_house);
            houseToolStripButton.Image = Image.FromFile(Files.levelend_house); ;


            gameLevelbeginToolStripMenuItem.Image = Image.FromFile(Files.icon_png);
            gameWindowToolStripMenuItem.Image = Image.FromFile(Files.icon_png);

            startGameCurrentToolStripMenuItem.Image = Image.FromFile(Files.icon_png);
            startGameCurrentToolStripButton.Image = Image.FromFile(Files.icon_png);
            #endregion

            newToolStripMenuItem_Click(new object(), new EventArgs());
        }


        #region Drag 'n' Drop Events
        private void level_MouseDown(object sender, MouseEventArgs e)
        {
            List<GameObject> gos = world.AllElements;
            bool found = false;
            for (int i = gos.Count - 1; i >= 0; i--)
            {
                GameObject go = gos[i];
                if (go.Hit(e.Y - world.Viewport.Y, e.X - world.Viewport.X))
                {
                    focus = go;

                    moving = true;
                    mouseX = e.X - go.Left;
                    mouseY = e.Y - go.Top;
                    found = true;
                    break;
                }
            }


            if (found)
            {
                if (!pressedKeys.Contains(Keys.ControlKey))
                    properties.SelectedObjects = new object[] { focus };
            }
            else
            {
                focus = null;
                properties.SelectedObjects = new object[] { };
            }

            startRectangle = new GamePoint(e.X - world.Viewport.X, e.Y - world.Viewport.Y);
        }
        private void level_MouseUp(object sender, MouseEventArgs e)
        {
            moving = false;

            if (endRectangle != null)
            {
                EditorUI.FetchElementsInRectangle(curRectangle, ref world, ref properties);

                startRectangle = null;
                endRectangle = null;
                curRectangle = Rectangle.Empty;
            }

            drawHandler.Update(); // paint again, with background
        }

        private void level_MouseMove(object sender, MouseEventArgs e)
        {
            bool repaint = false;

            if (moving && focus != null)
            {
                int movementTop = (e.Y - mouseY) - focus.Top;
                int movementLeft = (e.X - mouseX) - focus.Left;

                focus.Top += movementTop;
                focus.Left += movementLeft;

                for (int i = 0; i < properties.SelectedObjects.Length; i++)
                {
                    if (properties.SelectedObjects[i] != focus &&
                        properties.SelectedObjects[i] is GameObject)
                    {
                        ((GameObject)properties.SelectedObjects[i]).Top += movementTop;
                        ((GameObject)properties.SelectedObjects[i]).Left += movementLeft;
                    }
                }

                repaint = true;
            }

            if (startRectangle != null && focus == null)
            {
                endRectangle = new GamePoint(e.X - world.Viewport.X, e.Y - world.Viewport.Y);
                curRectangle = GamePoint.GetRectangle(startRectangle, endRectangle);

                repaint = true;
            }


            if (repaint)
                drawHandler.Update();
        }

        private void level_MouseClick(object sender, MouseEventArgs e)
        {
            if (focus != null)
            {
                if (!pressedKeys.Contains(Keys.ControlKey))
                    properties.SelectedObjects = new object[] { focus };
                else
                {
                    if (Array.IndexOf<object>(properties.SelectedObjects, focus) == -1)
                    {
                        if (properties.SelectedObjects.Length == 1 && properties.SelectedObject is LevelSettings)
                        {
                            properties.SelectedObjects = new object[] { focus };
                        }
                        else
                        {
                            object[] selected = properties.SelectedObjects;
                            Array.Resize<object>(ref selected, selected.Length + 1);
                            selected[selected.Length - 1] = focus;

                            properties.SelectedObjects = selected;
                        }
                    }
                }


                if (e.Button == MouseButtons.Right)
                {
                    ViewContextMenue(Cursor.Position.X, Cursor.Position.Y);
                    mouseX = e.X - focus.Left;
                    mouseY = e.Y - focus.Top;
                }
            }
        }

        private void level_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (focus != null && Array.IndexOf<object>(properties.SelectedObjects, focus) != -1)
            {
                List<object> selected = new List<object>(properties.SelectedObjects);
                selected.Remove(focus);
                properties.SelectedObjects = selected.ToArray();
            }
        }


        private void ViewContextMenue(int x, int y)
        {
            for (int i = objectContext.Items.Count - 1; i >= defaultContextMenuItems; i--) // start from end
            {                                               // easier to understand, because otherwise
                objectContext.Items.RemoveAt(i);            // you 've to remove always the 3. element
            }

            List<ToolStripItem> newitems = EditorUI.GenerateProperties();
            objectContext.Items.AddRange(newitems.ToArray());
            objectContext.Show(Cursor.Position.X, Cursor.Position.Y);
        }
        #endregion

        private void showlevelSettings_Click(object sender, EventArgs e)
        {
            properties.SelectedObjects = new object[] { world.Settings };
        }

        private void setDelegateHandlers()
        {
            world.Settings.cGameWindowWidth = changedGameWindowWidth;
            world.Settings.cGameWindowHeight = changedGameWindowHeight;
            world.Settings.cLevelWidth = changedLevelWidth;
            world.Settings.cLevelHeight = changedLevelHeight;

            changedGameWindowWidth();
            changedGameWindowHeight();
            changedLevelWidth();
            changedLevelHeight();
        }

        #region Main MenuBar Events
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tmpHandler.New())
            {
                this.Text = "littleRunner Level Editor";
                world = new World();
                tmpHandler.SaveHandler = world.Serialize;
                setDelegateHandlers();

                showlevelSettings_Click(sender, e);
                hScroll.Value = hScroll.Minimum;
                vScroll.Value = vScroll.Minimum;
                drawHandler.Update();
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tmpHandler.Open())
            {
                this.Text = "littleRunner Level Editor - " + tmpHandler.OrigFilename;
                hScroll.Value = hScroll.Minimum;
                vScroll.Value = vScroll.Minimum;

                world = new World(tmpHandler.TmpFilename, drawHandler, new GameSession(), PlayMode.Editor);
                tmpHandler.SaveHandler = world.Serialize;
                setDelegateHandlers();

                showlevelSettings_Click(sender, e);
                drawHandler.Update();
            }
        }


        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tmpHandler.SaveReal();
            this.Text = "littleRunner Level Editor - " + tmpHandler.OrigFilename;
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tmpHandler.SaveAsReal();
            this.Text = "littleRunner Level Editor - " + tmpHandler.OrigFilename;
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void gameLevelbeginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tmpHandler.updateTMP();

            g = new Game(programSwitcher, tmpHandler.TmpFilename, PlayMode.Game);

            g.ShowDialog();
            g = null;
            AnimateImage.Refresh = false;
        }

        private void setCurrentViewport(ref Game g)
        {
            g.AI.World.MGO.Left += hScroll.Value - hScroll.Minimum;
            g.AI.World.MGO.Top += (vScroll.Value - vScroll.Minimum);
            g.AI.World.Viewport.X -= hScroll.Value - hScroll.Minimum;
            g.AI.World.Viewport.Y -= vScroll.Value - vScroll.Minimum;
        }

        private void gameWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tmpHandler.updateTMP();

            g = new Game(programSwitcher, tmpHandler.TmpFilename, PlayMode.Game);
            setCurrentViewport(ref g);

            g.ShowDialog();
            g = null;
            AnimateImage.Refresh = false;
        }

        private void startGamecurrentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tmpHandler.updateTMP();

            int levelTop = this.Top + menu.Top + menubar.Top + tableLayout.Top + level.Top;
            int levelLeft = this.Left + tableLayout.Left + level.Left;
            g = new Game(programSwitcher, tmpHandler.TmpFilename, PlayMode.GameInEditor, levelTop, levelLeft);
            setCurrentViewport(ref g);


            string oldtext = this.Text;
            this.Text = "littleRunner Level Editor [press ESC to quit game]";

            g.ShowDialog();
            g = null;
            AnimateImage.Refresh = false;

            this.Text = oldtext;
        }



        private void editScriptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Scripteditor se = new Scripteditor();
            se.ScriptText = world.Settings.Script;

            if (se.ShowDialog() == DialogResult.OK)
                world.Settings.Script = se.ScriptText;
        }

        private void checkScriptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (world != null)
            {
                string exception = world.InitScript();
                if (exception == "")
                    MessageBox.Show("Script seems to be OK!", "Script check", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Script is not OK, exception traced:\n\n" + exception, "Script check", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void moveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (world != null)
            {
                int offset;
                string convertText = moveToolStripTextBox1.Text.Replace(" ", "");
                convertText = convertText.Replace("px", "");

                if (Int32.TryParse(convertText, out offset))
                {
                    EditorTransformations.Move(offset, ref world);
                    drawHandler.Update();
                }
                else
                    MessageBox.Show("Please write an offset in the field below this button!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion


        #region Insert GameObject - Handlers
        private void addElement(GameObject go, bool alwaysAddToSelection)
        {
            go.Init(world, GameAI.NullAiEventHandlerMethod);
            world.Add(go);
            drawHandler.Update();

            // focus on it
            if (pressedKeys.Contains(Keys.ControlKey) || alwaysAddToSelection)
            {
                object[] selected = properties.SelectedObjects;
                Array.Resize<object>(ref selected, selected.Length + 1);
                selected[selected.Length - 1] = go;

                properties.SelectedObjects = selected;
            }
            else if (properties.SelectedObjects.Length == 1)
            {
                properties.SelectedObjects = new object[] { go };
            }
        }
        private void addElement(GameObject go)
        {
            addElement(go, false);
        }


        private void floorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Floor f = new Floor(-world.Viewport.Y, -world.Viewport.X, FloorColor.Green);
            addElement(f);
        }


        private void treeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DesignElements tree = new DesignElements(-world.Viewport.Y, -world.Viewport.X, DesignElement.Tree);
            addElement(tree);
        }

        private void boxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Box b = new Box(-world.Viewport.Y, -world.Viewport.X, BoxStyle.Yellow);
            addElement(b);
        }

        private void brickToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Brick b = new Brick(-world.Viewport.Y, -world.Viewport.X, BrickColor.Blue);
            addElement(b);
        }

        private void pipeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Pipe p = new Pipe(-world.Viewport.Y, -world.Viewport.X, PipeColor.Green);
            addElement(p);
        }

        private void pointStarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Star p = new Star(-world.Viewport.Y, -world.Viewport.X);
            addElement(p);
        }

        private void turtleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Turtle t = new Turtle(-world.Viewport.Y, -world.Viewport.X, TurtleStyle.Green);
            addElement(t);
        }


        private void spikaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Spika s = new Spika(-world.Viewport.Y, -world.Viewport.X);
            addElement(s);
        }

        private void gumbaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Gumba g = new Gumba(-world.Viewport.Y, -world.Viewport.X);
            addElement(g);
        }

        private void houseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LevelEnd l = new LevelEnd(-world.Viewport.Y, -world.Viewport.X, LevelEndImg.House);
            addElement(l);
        }


        private void bricksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bricks b = new Bricks(-world.Viewport.Y, -world.Viewport.X, BrickColor.Blue);
            addElement(b);
        }



        private void menubar_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem == newToolStripButton)
                newToolStripMenuItem_Click(sender, e);

            else if (e.ClickedItem == openToolStripButton)
                openToolStripMenuItem_Click(sender, e);

            else if (e.ClickedItem == saveToolStripButton)
                saveToolStripMenuItem_Click(sender, e);


            else if (e.ClickedItem == floorToolStripButton)
                floorToolStripMenuItem_Click(sender, e);

            else if (e.ClickedItem == treeToolStripButton)
                treeToolStripMenuItem_Click(sender, e);

            else if (e.ClickedItem == boxToolStripButton)
                boxToolStripMenuItem_Click(sender, e);

            else if (e.ClickedItem == brickToolStripButton)
                brickToolStripMenuItem_Click(sender, e);

            else if (e.ClickedItem == pipeToolStripButton)
                pipeToolStripMenuItem_Click(sender, e);

            else if (e.ClickedItem == starToolStripButton)
                pointStarToolStripMenuItem_Click(sender, e);

            else if (e.ClickedItem == bricksToolStripButton)
                bricksToolStripMenuItem_Click(sender, e);

            else if (e.ClickedItem == turtleToolStripButton)
                turtleToolStripMenuItem_Click(sender, e);

            else if (e.ClickedItem == spikaToolStripButton)
                spikaToolStripMenuItem_Click(sender, e);

            else if (e.ClickedItem == gumbaToolStripButton)
                gumbaToolStripMenuItem_Click(sender, e);

            else if (e.ClickedItem == houseToolStripButton)
                houseToolStripMenuItem_Click(sender, e);

            else if (e.ClickedItem == treeToolStripButton)
                treeToolStripMenuItem_Click(sender, e);


            else if (e.ClickedItem == startGameCurrentToolStripButton)
                startGamecurrentToolStripMenuItem_Click(sender, e);

            else if (e.ClickedItem == editScriptToolStripButton)
                editScriptToolStripMenuItem_Click(sender, e);

            else if (e.ClickedItem == checkScriptToolStripButton)
                checkScriptToolStripMenuItem_Click(sender, e);
        }
        #endregion


        #region Contextmenue
        private void toForegroundToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (object o in properties.SelectedObjects)
            {
                if (!(o is LevelSettings))
                {
                    GameObject gameObject = (GameObject)o;
                    world.SetLast(gameObject);
                }
            }

            drawHandler.Update();
        }

        private void toBackgroundToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (object o in properties.SelectedObjects)
            {
                if (!(o is LevelSettings))
                {
                    GameObject gameObject = (GameObject)o;
                    world.SetFirst(gameObject);
                }
            }

            drawHandler.Update();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            object[] selected = properties.SelectedObjects;
            properties.SelectedObjects = new object[] { };

            foreach (object o in selected)
            {
                if (!(o is LevelSettings))
                {
                    GameObject go = (GameObject)o;
                    Dictionary<string,object> serialized = go.Serialize();

                    GameObject cloned = (GameObject)Activator.CreateInstance(go.GetType());
                    cloned.Deserialize(serialized);
                    cloned.Left = go.Right + 5;
                    addElement(cloned, true);
                }
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (object o in properties.SelectedObjects)
            {
                if (!(o is LevelSettings))
                {
                    GameObject gameObject = (GameObject)o;
                    world.Remove(gameObject);
                }
            }

            properties.SelectedObjects = new object[] { };
            drawHandler.Update();
        }
        #endregion


        private void Editor_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (tmpHandler.saveChanges())
            {
                tmpHandler.Dispose();
                tmpHandler = null;

                programSwitcher.Show();
            }
            else
                e.Cancel = true;
        }

        private void Update(Draw d)
        {
            bool drawBg = true;
            if (enableBG)
                drawBg = !moving; // when moving == true, drawBg = false

            if (drawBg && curRectangle != Rectangle.Empty)
                drawBg = false;


            world.Update(d, drawBg, properties.SelectedObjects);

            if (curRectangle != Rectangle.Empty)
            {
                d.MoveCoords(world.Viewport.X, world.Viewport.Y);

                d.DrawRectangle(dPen.FromGDI(Pens.DodgerBlue), curRectangle.X, curRectangle.Y, curRectangle.Width, curRectangle.Height);
                dColor color = new dColor(Color.DodgerBlue);
                color.A = 15;
                d.FillRectangle(new dPen(color), curRectangle.X, curRectangle.Y, curRectangle.Width, curRectangle.Height);

                d.MoveCoords(-world.Viewport.X, -world.Viewport.Y);
            }
        }

        private void properties_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            drawHandler.Update();
        }

        #region Level-Setting changed
        private void changedGameWindowWidth()
        {
            this.Width = 64 + world.Settings.GameWindowWidth + properties.Width;
        }
        private void changedGameWindowHeight()
        {
            this.Height = 118 + world.Settings.GameWindowHeight;
        }
        private void changedLevelWidth()
        {
            hScroll.Maximum = world.Settings.LevelWidth;
            hScroll_ValueChanged(new object(), new EventArgs());
        }
        private void changedLevelHeight()
        {
            vScroll.Minimum = world.Settings.GameWindowHeight;
            vScroll.Maximum = world.Settings.LevelHeight;
            vScroll_ValueChanged(new object(), new EventArgs());
        }
        #endregion

        #region Scrollbar events
        private void setcurScrollingText()
        {
            curScrolling.Text = "(" + hScroll.Value.ToString() + " | " + vScroll.Value.ToString() + ")";
        }

        private void hScroll_ValueChanged(object sender, EventArgs e)
        {
            world.Viewport.X = -(hScroll.Value - hScroll.Minimum);
            setcurScrollingText();

            drawHandler.Update();
        }

        private void hScroll_MouseCaptureChanged(object sender, EventArgs e)
        {
            if (enableBG)
            {
                // disable background
                enableBG = false;
            }
            else
            {
                // enable background
                enableBG = true;
                drawHandler.Update();
            }
        }


        private void vScroll_ValueChanged(object sender, EventArgs e)
        {
            world.Viewport.Y = -(vScroll.Value-vScroll.Minimum);
            setcurScrollingText();

            drawHandler.Update();
        }

        private void vScroll_MouseCaptureChanged(object sender, EventArgs e)
        {
            hScroll_MouseCaptureChanged(sender, e);
        }
        #endregion


        private void properties_SelectedObjectsChanged(object sender, EventArgs e)
        {
            if (properties.SelectedObjects.Length == 1)
                actualFocus.Text = "Focus: " + properties.SelectedObjects[0].GetType().Name;
            else
                actualFocus.Text = "selected " + properties.SelectedObjects.Length + " objects";

            drawHandler.Update();
        }

        #region Editor Key Events
        private void Editor_KeyDown(object sender, KeyEventArgs e)
        {
            if (!pressedKeys.Contains(e.KeyCode))
                pressedKeys.Add(e.KeyCode);

            if (e.Control)
            {
                switch (e.KeyCode)
                {
                    case Keys.Delete:
                        deleteToolStripMenuItem_Click(sender, e);
                        break;
                }
            }
        }

        private void Editor_KeyUp(object sender, KeyEventArgs e)
        {
            pressedKeys.Remove(e.KeyCode);
        }
        #endregion

        private void level_SizeChanged(object sender, EventArgs e)
        {
            if (world != null && WindowState != FormWindowState.Minimized)
            {
                world.Settings.GameWindowWidth = level.Width;
                world.Settings.GameWindowHeight = level.Height;

                showlevelSettings_Click(sender, e);
            }
        }

    }
}