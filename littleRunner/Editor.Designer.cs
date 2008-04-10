﻿namespace littleRunner
{
    partial class Editor
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Editor));
            this.level = new System.Windows.Forms.Panel();
            this.propertys = new System.Windows.Forms.PropertyGrid();
            this.openFile = new System.Windows.Forms.OpenFileDialog();
            this.menubar = new System.Windows.Forms.ToolStrip();
            this.saveFile = new System.Windows.Forms.SaveFileDialog();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.insertToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.floorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.designElementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.treeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.boxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.brickToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pipeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pointStarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enemyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.turtleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.spikaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gumbaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.levelEndToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.houseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gameLevelbeginToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scriptToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startGamecurrentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.objectContext = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toForegroundToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toBackgroundToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.actualFocus = new System.Windows.Forms.Label();
            this.showlevelSettings = new System.Windows.Forms.Button();
            this.trackBar = new System.Windows.Forms.TrackBar();
            this.curScrolling = new System.Windows.Forms.Label();
            this.tableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menu.SuspendLayout();
            this.objectContext.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).BeginInit();
            this.tableLayout.SuspendLayout();
            this.SuspendLayout();
            // 
            // level
            // 
            this.level.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.level.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.level.Location = new System.Drawing.Point(3, 3);
            this.level.Name = "level";
            this.tableLayout.SetRowSpan(this.level, 3);
            this.level.Size = new System.Drawing.Size(676, 558);
            this.level.TabIndex = 7;
            this.level.Paint += new System.Windows.Forms.PaintEventHandler(this.level_Paint);
            this.level.MouseMove += new System.Windows.Forms.MouseEventHandler(this.level_MouseMove);
            this.level.MouseClick += new System.Windows.Forms.MouseEventHandler(this.level_MouseClick);
            this.level.MouseDown += new System.Windows.Forms.MouseEventHandler(this.level_MouseDown);
            this.level.MouseUp += new System.Windows.Forms.MouseEventHandler(this.level_MouseUp);
            // 
            // propertys
            // 
            this.propertys.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.propertys.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.propertys.Location = new System.Drawing.Point(685, 93);
            this.propertys.Name = "propertys";
            this.propertys.PropertySort = System.Windows.Forms.PropertySort.Categorized;
            this.propertys.Size = new System.Drawing.Size(197, 468);
            this.propertys.TabIndex = 6;
            this.propertys.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.propertys_PropertyValueChanged);
            // 
            // openFile
            // 
            this.openFile.DefaultExt = "lrl";
            this.openFile.Filter = "littleRunner Levels (*.lrl)|*.lrl";
            this.openFile.InitialDirectory = "./Levels";
            this.openFile.RestoreDirectory = true;
            // 
            // menubar
            // 
            this.menubar.Location = new System.Drawing.Point(0, 24);
            this.menubar.Name = "menubar";
            this.menubar.Size = new System.Drawing.Size(909, 25);
            this.menubar.TabIndex = 5;
            this.menubar.Text = "toolStrip1";
            // 
            // saveFile
            // 
            this.saveFile.DefaultExt = "lrl";
            this.saveFile.FileName = "level.lrl";
            this.saveFile.Filter = "littleRunner Levels (*.lrl)|*.lrl";
            this.saveFile.InitialDirectory = "./Levels";
            this.saveFile.OverwritePrompt = false;
            this.saveFile.RestoreDirectory = true;
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Image = global::littleRunner.Properties.Resources.document_save;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Image = global::littleRunner.Properties.Resources.system_shutdown;
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Image = global::littleRunner.Properties.Resources.document_open;
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // menu
            // 
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.insertToolStripMenuItem,
            this.testToolStripMenuItem,
            this.startGamecurrentToolStripMenuItem});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(909, 24);
            this.menu.TabIndex = 4;
            this.menu.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.toolStripSeparator1,
            this.closeToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Image = global::littleRunner.Properties.Resources.document_save_as;
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.saveAsToolStripMenuItem.Text = "Save as";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // insertToolStripMenuItem
            // 
            this.insertToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.floorToolStripMenuItem,
            this.designElementToolStripMenuItem,
            this.boxToolStripMenuItem,
            this.brickToolStripMenuItem,
            this.pipeToolStripMenuItem,
            this.pointStarToolStripMenuItem,
            this.enemyToolStripMenuItem,
            this.levelEndToolStripMenuItem});
            this.insertToolStripMenuItem.Name = "insertToolStripMenuItem";
            this.insertToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.insertToolStripMenuItem.Text = "Insert";
            // 
            // floorToolStripMenuItem
            // 
            this.floorToolStripMenuItem.Name = "floorToolStripMenuItem";
            this.floorToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.floorToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.floorToolStripMenuItem.Text = "Floor";
            this.floorToolStripMenuItem.Click += new System.EventHandler(this.floorToolStripMenuItem_Click);
            // 
            // designElementToolStripMenuItem
            // 
            this.designElementToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.treeToolStripMenuItem});
            this.designElementToolStripMenuItem.Name = "designElementToolStripMenuItem";
            this.designElementToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.designElementToolStripMenuItem.Text = "Design Element";
            // 
            // treeToolStripMenuItem
            // 
            this.treeToolStripMenuItem.Name = "treeToolStripMenuItem";
            this.treeToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.T)));
            this.treeToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.treeToolStripMenuItem.Text = "Tree";
            this.treeToolStripMenuItem.Click += new System.EventHandler(this.treeToolStripMenuItem_Click);
            // 
            // boxToolStripMenuItem
            // 
            this.boxToolStripMenuItem.Name = "boxToolStripMenuItem";
            this.boxToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.B)));
            this.boxToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.boxToolStripMenuItem.Text = "Box";
            this.boxToolStripMenuItem.Click += new System.EventHandler(this.boxToolStripMenuItem_Click);
            // 
            // brickToolStripMenuItem
            // 
            this.brickToolStripMenuItem.Name = "brickToolStripMenuItem";
            this.brickToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.I)));
            this.brickToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.brickToolStripMenuItem.Text = "Brick";
            this.brickToolStripMenuItem.Click += new System.EventHandler(this.brickToolStripMenuItem_Click);
            // 
            // pipeToolStripMenuItem
            // 
            this.pipeToolStripMenuItem.Name = "pipeToolStripMenuItem";
            this.pipeToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.pipeToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.pipeToolStripMenuItem.Text = "Pipe";
            this.pipeToolStripMenuItem.Click += new System.EventHandler(this.pipeToolStripMenuItem_Click);
            // 
            // pointStarToolStripMenuItem
            // 
            this.pointStarToolStripMenuItem.Name = "pointStarToolStripMenuItem";
            this.pointStarToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.pointStarToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.pointStarToolStripMenuItem.Text = "Star (Point)";
            this.pointStarToolStripMenuItem.Click += new System.EventHandler(this.pointStarToolStripMenuItem_Click);
            // 
            // enemyToolStripMenuItem
            // 
            this.enemyToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.turtleToolStripMenuItem,
            this.spikaToolStripMenuItem,
            this.gumbaToolStripMenuItem});
            this.enemyToolStripMenuItem.Name = "enemyToolStripMenuItem";
            this.enemyToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.enemyToolStripMenuItem.Text = "Enemy";
            // 
            // turtleToolStripMenuItem
            // 
            this.turtleToolStripMenuItem.Name = "turtleToolStripMenuItem";
            this.turtleToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.U)));
            this.turtleToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.turtleToolStripMenuItem.Text = "Turtle";
            this.turtleToolStripMenuItem.Click += new System.EventHandler(this.turtleToolStripMenuItem_Click);
            // 
            // spikaToolStripMenuItem
            // 
            this.spikaToolStripMenuItem.Name = "spikaToolStripMenuItem";
            this.spikaToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.K)));
            this.spikaToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.spikaToolStripMenuItem.Text = "Spika";
            this.spikaToolStripMenuItem.Click += new System.EventHandler(this.spikaToolStripMenuItem_Click);
            // 
            // gumbaToolStripMenuItem
            // 
            this.gumbaToolStripMenuItem.Name = "gumbaToolStripMenuItem";
            this.gumbaToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.G)));
            this.gumbaToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.gumbaToolStripMenuItem.Text = "Gumba";
            this.gumbaToolStripMenuItem.Click += new System.EventHandler(this.gumbaToolStripMenuItem_Click);
            // 
            // levelEndToolStripMenuItem
            // 
            this.levelEndToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.houseToolStripMenuItem});
            this.levelEndToolStripMenuItem.Name = "levelEndToolStripMenuItem";
            this.levelEndToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.levelEndToolStripMenuItem.Text = "Level End";
            // 
            // houseToolStripMenuItem
            // 
            this.houseToolStripMenuItem.Name = "houseToolStripMenuItem";
            this.houseToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.H)));
            this.houseToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.houseToolStripMenuItem.Text = "House";
            this.houseToolStripMenuItem.Click += new System.EventHandler(this.houseToolStripMenuItem_Click);
            // 
            // testToolStripMenuItem
            // 
            this.testToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gameLevelbeginToolStripMenuItem,
            this.scriptToolStripMenuItem});
            this.testToolStripMenuItem.Name = "testToolStripMenuItem";
            this.testToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.testToolStripMenuItem.Text = "Test";
            // 
            // gameLevelbeginToolStripMenuItem
            // 
            this.gameLevelbeginToolStripMenuItem.Name = "gameLevelbeginToolStripMenuItem";
            this.gameLevelbeginToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.gameLevelbeginToolStripMenuItem.Text = "Game (Levelbegin)";
            this.gameLevelbeginToolStripMenuItem.Click += new System.EventHandler(this.gameLevelbeginToolStripMenuItem_Click);
            // 
            // scriptToolStripMenuItem
            // 
            this.scriptToolStripMenuItem.Image = global::littleRunner.Properties.Resources.text_x_script;
            this.scriptToolStripMenuItem.Name = "scriptToolStripMenuItem";
            this.scriptToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.scriptToolStripMenuItem.Text = "Script";
            this.scriptToolStripMenuItem.Click += new System.EventHandler(this.scriptToolStripMenuItem_Click);
            // 
            // startGamecurrentToolStripMenuItem
            // 
            this.startGamecurrentToolStripMenuItem.Name = "startGamecurrentToolStripMenuItem";
            this.startGamecurrentToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.startGamecurrentToolStripMenuItem.Size = new System.Drawing.Size(72, 20);
            this.startGamecurrentToolStripMenuItem.Text = "Start game";
            this.startGamecurrentToolStripMenuItem.Click += new System.EventHandler(this.startGamecurrentToolStripMenuItem_Click);
            // 
            // objectContext
            // 
            this.objectContext.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toForegroundToolStripMenuItem,
            this.toBackgroundToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.objectContext.Name = "objectContext";
            this.objectContext.Size = new System.Drawing.Size(157, 70);
            // 
            // toForegroundToolStripMenuItem
            // 
            this.toForegroundToolStripMenuItem.Name = "toForegroundToolStripMenuItem";
            this.toForegroundToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.toForegroundToolStripMenuItem.Text = "To foreground";
            this.toForegroundToolStripMenuItem.Click += new System.EventHandler(this.toForegroundToolStripMenuItem_Click);
            // 
            // toBackgroundToolStripMenuItem
            // 
            this.toBackgroundToolStripMenuItem.Name = "toBackgroundToolStripMenuItem";
            this.toBackgroundToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.toBackgroundToolStripMenuItem.Text = "To background";
            this.toBackgroundToolStripMenuItem.Click += new System.EventHandler(this.toBackgroundToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // actualFocus
            // 
            this.actualFocus.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.actualFocus.Font = new System.Drawing.Font("Bitstream Vera Sans", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.actualFocus.Location = new System.Drawing.Point(685, 60);
            this.actualFocus.Name = "actualFocus";
            this.actualFocus.Size = new System.Drawing.Size(197, 30);
            this.actualFocus.TabIndex = 14;
            this.actualFocus.Text = "Focus: nothing";
            // 
            // showlevelSettings
            // 
            this.showlevelSettings.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showlevelSettings.Location = new System.Drawing.Point(685, 3);
            this.showlevelSettings.Name = "showlevelSettings";
            this.showlevelSettings.Size = new System.Drawing.Size(197, 36);
            this.showlevelSettings.TabIndex = 16;
            this.showlevelSettings.Text = "Show level settings";
            this.showlevelSettings.UseVisualStyleBackColor = true;
            this.showlevelSettings.Click += new System.EventHandler(this.showlevelSettings_Click);
            // 
            // trackBar
            // 
            this.trackBar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBar.LargeChange = 50;
            this.trackBar.Location = new System.Drawing.Point(3, 567);
            this.trackBar.Maximum = 652;
            this.trackBar.Name = "trackBar";
            this.trackBar.Size = new System.Drawing.Size(676, 44);
            this.trackBar.SmallChange = 40;
            this.trackBar.TabIndex = 17;
            this.trackBar.TickFrequency = 50;
            this.trackBar.ValueChanged += new System.EventHandler(this.trackBar_ValueChanged);
            this.trackBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.trackBar_MouseDown);
            this.trackBar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.trackBar_MouseUp);
            // 
            // curScrolling
            // 
            this.curScrolling.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.curScrolling.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.curScrolling.Location = new System.Drawing.Point(685, 564);
            this.curScrolling.Name = "curScrolling";
            this.curScrolling.Size = new System.Drawing.Size(197, 50);
            this.curScrolling.TabIndex = 18;
            this.curScrolling.Text = "0";
            this.curScrolling.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tableLayout
            // 
            this.tableLayout.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayout.ColumnCount = 2;
            this.tableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 203F));
            this.tableLayout.Controls.Add(this.trackBar, 0, 3);
            this.tableLayout.Controls.Add(this.actualFocus, 1, 1);
            this.tableLayout.Controls.Add(this.curScrolling, 1, 3);
            this.tableLayout.Controls.Add(this.propertys, 1, 2);
            this.tableLayout.Controls.Add(this.showlevelSettings, 1, 0);
            this.tableLayout.Controls.Add(this.level, 0, 0);
            this.tableLayout.Location = new System.Drawing.Point(12, 52);
            this.tableLayout.Name = "tableLayout";
            this.tableLayout.RowCount = 4;
            this.tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayout.Size = new System.Drawing.Size(885, 614);
            this.tableLayout.TabIndex = 19;
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("newToolStripMenuItem.Image")));
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // Editor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(909, 675);
            this.Controls.Add(this.menubar);
            this.Controls.Add(this.tableLayout);
            this.Controls.Add(this.menu);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "Editor";
            this.Text = "littleRunner Game Editor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Editor_FormClosing);
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.objectContext.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).EndInit();
            this.tableLayout.ResumeLayout(false);
            this.tableLayout.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem pointStarToolStripMenuItem;
        private System.Windows.Forms.Panel level;
        private System.Windows.Forms.PropertyGrid propertys;
        private System.Windows.Forms.OpenFileDialog openFile;
        private System.Windows.Forms.ToolStrip menubar;
        private System.Windows.Forms.SaveFileDialog saveFile;
        private System.Windows.Forms.ToolStripMenuItem brickToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem insertToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem floorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem designElementToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem treeToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip objectContext;
        private System.Windows.Forms.ToolStripMenuItem toForegroundToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toBackgroundToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem enemyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem turtleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pipeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.Label actualFocus;
        private System.Windows.Forms.ToolStripMenuItem boxToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem spikaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gumbaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem levelEndToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem houseToolStripMenuItem;
        private System.Windows.Forms.Button showlevelSettings;
        private System.Windows.Forms.TrackBar trackBar;
        private System.Windows.Forms.Label curScrolling;
        private System.Windows.Forms.TableLayoutPanel tableLayout;
        private System.Windows.Forms.ToolStripMenuItem startGamecurrentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gameLevelbeginToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scriptToolStripMenuItem;
    }
}