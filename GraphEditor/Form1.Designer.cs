namespace PWSG_WinForms_2
{
    partial class GraphDrawer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GraphDrawer));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.colorButton = new System.Windows.Forms.Button();
            this.shownColor = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.drawingArea = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.deleteVerticeButton = new System.Windows.Forms.Button();
            this.clearGraphButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.polishLangButton = new System.Windows.Forms.Button();
            this.englishLangButton = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.saveButton = new System.Windows.Forms.Button();
            this.loadButton = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.shownColor)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.drawingArea)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            resources.ApplyResources(this.splitContainer1, "splitContainer1");
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            resources.ApplyResources(this.splitContainer1.Panel1, "splitContainer1.Panel1");
            this.splitContainer1.Panel1.Controls.Add(this.colorButton);
            // 
            // splitContainer1.Panel2
            // 
            resources.ApplyResources(this.splitContainer1.Panel2, "splitContainer1.Panel2");
            this.splitContainer1.Panel2.Controls.Add(this.shownColor);
            this.splitContainer1.TabStop = false;
            // 
            // colorButton
            // 
            resources.ApplyResources(this.colorButton, "colorButton");
            this.colorButton.Name = "colorButton";
            this.colorButton.TabStop = false;
            this.colorButton.UseVisualStyleBackColor = true;
            this.colorButton.Click += new System.EventHandler(this.chooseColorButton_Click);
            // 
            // shownColor
            // 
            resources.ApplyResources(this.shownColor, "shownColor");
            this.shownColor.BackColor = System.Drawing.Color.Black;
            this.shownColor.Name = "shownColor";
            this.shownColor.TabStop = false;
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.drawingArea, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // drawingArea
            // 
            resources.ApplyResources(this.drawingArea, "drawingArea");
            this.drawingArea.BackColor = System.Drawing.Color.White;
            this.drawingArea.Cursor = System.Windows.Forms.Cursors.Cross;
            this.drawingArea.Name = "drawingArea";
            this.drawingArea.TabStop = false;
            this.drawingArea.Paint += new System.Windows.Forms.PaintEventHandler(this.drawingArea_Paint);
            this.drawingArea.MouseDown += new System.Windows.Forms.MouseEventHandler(this.drawingArea_MouseDown);
            this.drawingArea.MouseMove += new System.Windows.Forms.MouseEventHandler(this.drawingArea_MouseMove);
            this.drawingArea.MouseUp += new System.Windows.Forms.MouseEventHandler(this.drawingArea_MouseUp);
            // 
            // tableLayoutPanel2
            // 
            resources.ApplyResources(this.tableLayoutPanel2, "tableLayoutPanel2");
            this.tableLayoutPanel2.Controls.Add(this.groupBox2, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 1);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            // 
            // groupBox2
            // 
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Controls.Add(this.tableLayoutPanel6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // tableLayoutPanel6
            // 
            resources.ApplyResources(this.tableLayoutPanel6, "tableLayoutPanel6");
            this.tableLayoutPanel6.Controls.Add(this.deleteVerticeButton, 0, 1);
            this.tableLayoutPanel6.Controls.Add(this.splitContainer1, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.clearGraphButton, 0, 2);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            // 
            // deleteVerticeButton
            // 
            resources.ApplyResources(this.deleteVerticeButton, "deleteVerticeButton");
            this.deleteVerticeButton.Name = "deleteVerticeButton";
            this.deleteVerticeButton.TabStop = false;
            this.deleteVerticeButton.UseVisualStyleBackColor = true;
            this.deleteVerticeButton.Click += new System.EventHandler(this.removeVerticeButton_Click);
            // 
            // clearGraphButton
            // 
            resources.ApplyResources(this.clearGraphButton, "clearGraphButton");
            this.clearGraphButton.Name = "clearGraphButton";
            this.clearGraphButton.TabStop = false;
            this.clearGraphButton.UseVisualStyleBackColor = true;
            this.clearGraphButton.Click += new System.EventHandler(this.clearGraphButton_Click);
            // 
            // tableLayoutPanel3
            // 
            resources.ApplyResources(this.tableLayoutPanel3, "tableLayoutPanel3");
            this.tableLayoutPanel3.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.groupBox3, 0, 1);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            // 
            // groupBox1
            // 
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Controls.Add(this.tableLayoutPanel4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // tableLayoutPanel4
            // 
            resources.ApplyResources(this.tableLayoutPanel4, "tableLayoutPanel4");
            this.tableLayoutPanel4.Controls.Add(this.polishLangButton, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.englishLangButton, 0, 1);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            // 
            // polishLangButton
            // 
            resources.ApplyResources(this.polishLangButton, "polishLangButton");
            this.polishLangButton.Name = "polishLangButton";
            this.polishLangButton.TabStop = false;
            this.polishLangButton.UseVisualStyleBackColor = true;
            this.polishLangButton.Click += new System.EventHandler(this.polishLangButton_Click);
            // 
            // englishLangButton
            // 
            resources.ApplyResources(this.englishLangButton, "englishLangButton");
            this.englishLangButton.Name = "englishLangButton";
            this.englishLangButton.TabStop = false;
            this.englishLangButton.UseVisualStyleBackColor = true;
            this.englishLangButton.Click += new System.EventHandler(this.englishLangButton_Click);
            // 
            // groupBox3
            // 
            resources.ApplyResources(this.groupBox3, "groupBox3");
            this.groupBox3.Controls.Add(this.tableLayoutPanel5);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.TabStop = false;
            // 
            // tableLayoutPanel5
            // 
            resources.ApplyResources(this.tableLayoutPanel5, "tableLayoutPanel5");
            this.tableLayoutPanel5.Controls.Add(this.saveButton, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.loadButton, 0, 1);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            // 
            // saveButton
            // 
            resources.ApplyResources(this.saveButton, "saveButton");
            this.saveButton.Name = "saveButton";
            this.saveButton.TabStop = false;
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // loadButton
            // 
            resources.ApplyResources(this.loadButton, "loadButton");
            this.loadButton.Name = "loadButton";
            this.loadButton.TabStop = false;
            this.loadButton.UseVisualStyleBackColor = true;
            this.loadButton.Click += new System.EventHandler(this.loadButton_Click);
            // 
            // saveFileDialog1
            // 
            resources.ApplyResources(this.saveFileDialog1, "saveFileDialog1");
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            resources.ApplyResources(this.openFileDialog1, "openFileDialog1");
            // 
            // GraphDrawer
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "GraphDrawer";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GraphDrawer_KeyDown);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.shownColor)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.drawingArea)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.PictureBox drawingArea;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Button polishLangButton;
        private System.Windows.Forms.Button englishLangButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button loadButton;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.PictureBox shownColor;
        private System.Windows.Forms.Button colorButton;
        private System.Windows.Forms.Button deleteVerticeButton;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button clearGraphButton;
    }
}

