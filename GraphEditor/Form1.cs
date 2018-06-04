using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Globalization;
using System.Resources;
using System.Reflection;

namespace PWSG_WinForms_2
{
    public partial class GraphDrawer : Form
    {
        int size = 36;
        int lineSize = 3;
        Color c = Color.Black;
        StringFormat stringFormat;
        ResourceManager rm = PWSG_WinForms_2.Res.pl_PL.ResourceManager;

        GraphPoint choosed = null;
        List<GraphPoint> vertices;
        List<(int v1, int v2)> edges;
        Point mouseStartPosition = Point.Empty;
        Point basePosition = Point.Empty;
        bool releasedMiddleButton = true;

        public GraphDrawer()
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("pl-PL");
            InitializeComponent();
            InitializeNewGraphEditor();
            this.KeyPreview = true;
            stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Center;
            stringFormat.LineAlignment = StringAlignment.Center;
        }

        private void chooseColorButton_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                c = colorDialog1.Color;
                shownColor.BackColor = c;
                if (choosed != null)
                {
                    choosed.color = c;
                    drawingArea.Refresh();
                }
            }
        }

        private void removeVerticeButton_Click(object sender, EventArgs e)
        {
            RemoveChoosedVerticeAndDisableButton();
        }

        private void clearGraphButton_Click(object sender, EventArgs e)
        {
            InitializeNewGraphEditor();
            drawingArea.Refresh();
        }

        void ChangeLanguageWithInitialize(string culture)
        {
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(culture);
            var curSize = this.Size;
            Controls.Clear();
            InitializeComponent();
            shownColor.BackColor = c;
            this.Size = curSize;
            this.UpdateBounds();
        }

        void ChangeLanguageWithRecurrencion(string culture)
        {
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(culture);
            ComponentResourceManager resources = new ComponentResourceManager(typeof(GraphDrawer));
            var curSize = this.Size;
            resources.ApplyResources(this, "$this");
            ApplyResources(resources, this.Controls);
            this.Size = curSize;
            this.UpdateBounds();
        }

        private void polishLangButton_Click(object sender, EventArgs e)
        {
            ChangeLanguageWithRecurrencion("pl-PL");
            //ChangeLanguageWithInitialize("pl-PL");       
            rm = PWSG_WinForms_2.Res.pl_PL.ResourceManager;
        }

        private void englishLangButton_Click(object sender, EventArgs e)
        {
            ChangeLanguageWithRecurrencion("en-US");
            //ChangeLanguageWithInitialize("en-US");
            rm = PWSG_WinForms_2.Res.en_US.ResourceManager;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter str = new StreamWriter(saveFileDialog1.FileName))
                {
                    foreach (var vertice in vertices)
                        str.WriteLine($"{vertice.position.X},{vertice.position.Y},{vertice.color.ToArgb()}");
                    foreach (var edge in edges)
                        str.WriteLine($"{edge.v1},{edge.v2}");
                }
                MessageBox.Show(rm.GetString("okSave"), "", MessageBoxButtons.OK);
            }
            drawingArea.Refresh();
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                HashSet<GraphPoint> hsv = new HashSet<GraphPoint>(new GraphPointEqualityComparer());
                HashSet<(int v1, int v2)> hse = new HashSet<(int v1, int v2)>();
                bool error = false;
                using (StreamReader str = new StreamReader(openFileDialog1.FileName))
                {
                    while (!str.EndOfStream)
                    {
                        string[] t = str.ReadLine().Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                        if (t.Length == 3)
                        {
                            if (!int.TryParse(t[0], out int x) | !int.TryParse(t[1], out int y) | !int.TryParse(t[2], out int c))
                            {
                                error = true;
                                break;
                            }
                            hsv.Add(new GraphPoint(new Point(x, y), Color.FromArgb(c), size));
                        }
                        else if (t.Length == 2)
                        {
                            if ((!int.TryParse(t[0], out int v1) | !int.TryParse(t[1], out int v2) || v1 < 0 || v2 < 0))
                            {
                                error = true;
                                break;
                            }
                            if (!hse.Contains((v2, v1)))
                                hse.Add((v1, v2));
                        }
                        else
                        {
                            error = true;
                            break;
                        }
                    }
                }

                foreach (var edge in hse)
                {
                    if (edge.v1 >= hsv.Count || edge.v2 >= hsv.Count)
                        error = true;
                }

                if (error)
                {
                    MessageBox.Show(rm.GetString("error"), "", MessageBoxButtons.OK);
                }
                else
                {
                    vertices = hsv.ToList();
                    edges = hse.ToList();
                    drawingArea.Refresh();
                    MessageBox.Show(rm.GetString("okLoad"), "", MessageBoxButtons.OK);
                }
            }
        }

        private void GraphDrawer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                RemoveChoosedVerticeAndDisableButton();
        }

        private void drawingArea_MouseMove(object sender, MouseEventArgs e)
        {
            if ((e.Button == MouseButtons.Middle || !releasedMiddleButton) && choosed != null)
            {
                releasedMiddleButton = false;
                if (mouseStartPosition.IsEmpty)
                {
                    mouseStartPosition = new Point(e.X, e.Y);
                    basePosition = new Point(choosed.position.X, choosed.position.Y);
                }
                else
                {
                    choosed.UpdatePosition(basePosition.X + e.X - mouseStartPosition.X, basePosition.Y + e.Y - mouseStartPosition.Y);
                    drawingArea.Refresh();
                }
            }
            else
            {
                mouseStartPosition = Point.Empty;
                releasedMiddleButton = true;
            }
        }

        private void drawingArea_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Middle && choosed != null)
            {
                releasedMiddleButton = true;
                if (choosed.center.X < 0)
                    choosed.UpdatePosition(-size / 2, choosed.position.Y);
                else if (choosed.center.X > drawingArea.Width)
                    choosed.UpdatePosition(drawingArea.Width - size / 2, choosed.position.Y);

                if (choosed.center.Y < 0)
                    choosed.UpdatePosition(choosed.position.X, -size / 2);
                else if (choosed.center.Y > drawingArea.Height)
                    choosed.UpdatePosition(choosed.position.X, drawingArea.Height - size / 2);
                drawingArea.Refresh();
            }
        }

        private void drawingArea_MouseDown(object sender, MouseEventArgs e)
        {
            GraphPoint g = new GraphPoint(new Point(e.X - size / 2, e.Y - size / 2), c, size);
            bool add = true;
            int number = 0;
            GraphPoint closest = null;
            double minDist = double.MaxValue;
            int minNumber = 0;
            foreach (var item in vertices)
            {
                if (CheckCollision(item, e.X, e.Y))
                {
                    add = false;
                    closest = closest == null ? item : closest;
                    if (GetDistanceBetweenCenters(item, e.X, e.Y) < minDist)
                    {
                        closest = item;
                        minDist = GetDistanceBetweenCenters(item, e.X, e.Y);
                        minNumber = number;
                    }
                }
                number++;
            }
            number = minNumber;
            if (!add && e.Button == MouseButtons.Right)
            {
                choosed = closest;
                mouseStartPosition = Point.Empty;
                deleteVerticeButton.Enabled = true;
            }
            else if (!add && e.Button == MouseButtons.Left && choosed != null)
            {
                int index = vertices.FindIndex((GraphPoint it) => it == choosed);
                if (!edges.Remove((index, number)) && !edges.Remove((number, index)))
                    edges.Add((index, number));
            }

            if (add && e.Button == MouseButtons.Left)
                vertices.Add(g);
            else if (add && e.Button == MouseButtons.Right)
            {
                choosed = null;
                deleteVerticeButton.Enabled = false;
            }
            drawingArea.Refresh();
        }

        private void drawingArea_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            using (Pen p = new Pen(Color.Black, lineSize))
            {
                foreach (var edge in edges)
                    e.Graphics.DrawLine(p, vertices[edge.v1].center, vertices[edge.v2].center);
            }

            int number = 0;
            using (Brush b2 = new SolidBrush(Color.White))
            using (Font font = new Font("Calibri", 12, FontStyle.Regular, GraphicsUnit.Point))
            {
                foreach (var g in vertices)
                {
                    number++;
                    e.Graphics.FillEllipse(b2, g.position.X, g.position.Y, size, size);

                    using (Brush b = new SolidBrush(g.color))
                    {
                        e.Graphics.DrawString(number.ToString(), font, b, g.center, stringFormat);
                        using (Pen p = new Pen(b, lineSize))
                        {
                            if (g == choosed)
                                p.DashPattern = new float[] { 3, 3 };
                            e.Graphics.DrawEllipse(p, g.position.X, g.position.Y, size, size);
                        }
                    }
                }
            }
        }


        class GraphPoint
        {
            public Point position;
            public Point center;
            public Color color;
            int size;

            public GraphPoint(Point pos, Color c, int size)
            {
                this.size = size;
                this.position = pos;
                this.color = c;
                center = new Point(pos.X + size / 2, pos.Y + size / 2);
            }

            public void UpdatePosition(int x, int y)
            {
                position.X = x;
                position.Y = y;
                center.X = x + size / 2;
                center.Y = y + size / 2;
            }
        }

        void InitializeNewGraphEditor()
        {
            choosed = null;
            vertices = new List<GraphPoint>();
            edges = new List<(int v1, int v2)>();
            deleteVerticeButton.Enabled = false;
        }

        private void ApplyResources(ComponentResourceManager resources, Control.ControlCollection ctls)
        {
            foreach (Control ctl in ctls)
            {
                resources.ApplyResources(ctl, ctl.Name);
                ApplyResources(resources, ctl.Controls);
            }
        }

        double GetDistanceBetweenCenters(GraphPoint p1, int x, int y)
        {
            double dx = p1.center.X - x;
            double dy = p1.center.Y - y;
            return dx * dx + dy * dy;
        }

        bool CheckCollision(GraphPoint p1, int x, int y)
        {
            return GetDistanceBetweenCenters(p1, x, y) <= size * size;
        }

        void RemoveChoosedVerticeAndDisableButton()
        {
            if (choosed == null)
                return;
            int index = vertices.FindIndex(it => it == choosed);
            edges.RemoveAll(t => t.v1 == index || t.v2 == index);
            for (int i = 0; i < edges.Count; i++)
            {
                if (edges[i].v1 >= index)
                    edges[i] = (edges[i].v1 - 1, edges[i].v2);
                if (edges[i].v2 >= index)
                    edges[i] = (edges[i].v1, edges[i].v2 - 1);
            }
            vertices.Remove(choosed);
            choosed = null;
            deleteVerticeButton.Enabled = false;
            drawingArea.Refresh();
        }

        class GraphPointEqualityComparer : IEqualityComparer<GraphPoint>
        {
            public bool Equals(GraphPoint p1, GraphPoint p2)
            {
                return p1.position.X == p2.position.X && p1.position.Y == p2.position.Y;
            }

            public int GetHashCode(GraphPoint p)
            {
                return p.position.X ^ p.position.Y;
            }
        }
    }
}
