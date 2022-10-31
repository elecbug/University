using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace P1102_S
{
    public partial class MainForm : Form
    {
        private string[] data;
        private Panel panel;
        private Graphics graphics;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.Text = "View";
            this.ClientSize = new Size(800, 950);

            this.panel = new Panel()
            {
                Location = new Point(0, 0),
                Size = this.ClientSize,
                Parent = this,
                Visible = true,
                Dock = DockStyle.Fill,
                BackColor = Color.Black,
                AllowDrop = true,
            };
            this.panel.DragEnter += PanelDragEnter;
            this.panel.DragDrop += PanelDragDrop;

            this.graphics = this.panel.CreateGraphics();
        }

        private void PanelDragEnter(object? sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void PanelDragDrop(object? sender, DragEventArgs e)
        {
            string[] files = e.Data.GetData(DataFormats.FileDrop) as string[];

            for (int fs = 0; fs < files.Length; fs++)
            {
                StreamReader reader = new StreamReader(files[fs]);

                this.data = reader.ReadToEnd().Split('\n');
                Debug.WriteLine(reader.ToString());
                reader.Close();

                new Label()
                {
                    Location = new Point(5, 5),
                    Parent = this.panel,
                    Visible = true,
                    ForeColor = Color.White,
                    Text = this.data[0],
                };

                for (int i = 1; i < this.data.Length - 1; i++)
                {
                    try
                    {
                        Point p1 = new Point(30 * i, this.panel.Height - int.Parse(this.data[i].Trim().Split(":")[0]) / 5 - 30);
                        Point p2 = new Point(30 * (i + 1), this.panel.Height - int.Parse(this.data[i + 1].Trim().Split(":")[0]) / 5 - 30);
                        Pen pen = new Pen(Color.Blue);

                        this.graphics.DrawLine(pen, p1, p2);
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex);
                    }
                    try
                    {
                        Point p1 = new Point(30 * i, this.panel.Height - int.Parse(this.data[i].Trim().Split(":")[1]) / 5 - 30);
                        Point p2 = new Point(30 * (i + 1), this.panel.Height - int.Parse(this.data[i + 1].Trim().Split(":")[1]) / 5 - 30);
                        Pen pen = new Pen(Color.Red);

                        this.graphics.DrawLine(pen, p1, p2);
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex);
                    }
                }
            }
        }
    }
}
