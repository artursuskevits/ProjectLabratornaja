using Microsoft.VisualBasic.ApplicationServices;
using System.Numerics;
using System;
using System.Reflection.Emit;
using System.Security.Cryptography.Xml;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ProjectLabratornaja
{
    public partial class MainForm : Form
    {
        MenuStrip Ms;
        ToolStrip Ts;
        PictureBox Pb;
        Panel Pl;
        System.Windows.Forms.TrackBar Tb;
        System.Windows.Forms.Label Lb;
        public MainForm()
        {
            //Foarm settings
            this.Text = "Bad Paint";
            this.Height = 800;
            this.Width = 1200; 

            //MenuStrip settings
            Ms = new MenuStrip();
            Ms.Width = this.Width;
            Ms.Height = 30;
            Ms.BackColor = Color.White;
            Ms.Location = new Point (0, 0);
            
            //ToolStrip settings
            Ts = new ToolStrip();
            Ts.Width = 150;
            Ts.Height = this.Height ;  
            Ts.Location = new Point(0, Ms.Height);
            Ts.BackColor = Color.White;
            Ts.Anchor = AnchorStyles.Left;
            
            //PicturBox Settings
            Pb = new PictureBox();
            Pb.Height = 650;
            Pb.Width = 1000;
            Pb.Location = new Point(Ts.Width, Ms.Height);
            Pb.BackColor = Color.LightPink;
            Pb.MouseMove += Pb_MouseMove;
            Pb.MouseDown += Pb_MouseDown;

            //Panel Settings
            Pl = new Panel();
            Pl.Height = 50;
            Pl.Width = 1000;
            Pl.Location = new Point(Ts.Width, Ms.Height+Pb.Height);
            Pl.BackColor = Color.LightBlue;
            Pl.Text = "0,0";
            Pl.ForeColor = Color.Black;

            //Label Settings
            Lb = new System.Windows.Forms.Label();
            Lb.Height = 30;
            Lb.Width = 300;
            Lb.Text = "0,0";
            Lb.BackColor = Color.LightBlue;
            Pl.Controls.Add(Lb);

            //TrackBar settings
            Tb = new System.Windows.Forms.TrackBar();
            Tb.Height = 30;
            Tb.Width = 300;
            Tb.BackColor = Color.LightBlue;
            Tb.Location = new Point(Ts.Width + 650, Ms.Height + Pb.Height+2);



            //Menu Strip Fill
            ToolStripMenuItem FileItem = new ToolStripMenuItem("File");
            ToolStripMenuItem NewFileItem = new ToolStripMenuItem("New");
            ToolStripMenuItem OpenFileItem = new ToolStripMenuItem("Open");
            ToolStripMenuItem SaveFileItem = new ToolStripMenuItem("Save");
            ToolStripMenuItem ExitFileItem = new ToolStripMenuItem("Exit");
            FileItem.DropDownItems.Add(NewFileItem);
            FileItem.DropDownItems.Add(OpenFileItem);
            FileItem.DropDownItems.Add(SaveFileItem);
            FileItem.DropDownItems.Add(ExitFileItem);
            Ms.Items.Add(FileItem);
            NewFileItem.Click += NewFileItem_Click;

            ToolStripMenuItem EditItem = new ToolStripMenuItem("Edit");
            ToolStripMenuItem UndoEditItem = new ToolStripMenuItem("Undo");
            ToolStripMenuItem RenoEditItem = new ToolStripMenuItem("Reno");
            ToolStripMenuItem PenEditItem = new ToolStripMenuItem("Pen");
            EditItem.DropDownItems.Add(UndoEditItem);
            EditItem.DropDownItems.Add(RenoEditItem);
            EditItem.DropDownItems.Add(PenEditItem);
            PenEditItem.Checked = true;
                ToolStripMenuItem StylePenItem = new ToolStripMenuItem("Style");
                ToolStripMenuItem ColorPenItem = new ToolStripMenuItem("Color");
                PenEditItem.DropDownItems.Add(ColorPenItem);
                PenEditItem.DropDownItems.Add(StylePenItem);
                StylePenItem.Checked = true;
                    ToolStripMenuItem SolidStyleItem = new ToolStripMenuItem("Solid");
                    ToolStripMenuItem DotStyleItem = new ToolStripMenuItem("Dot");
                    ToolStripMenuItem DashDotDotStyleItem = new ToolStripMenuItem("DashDotDot");
                    StylePenItem.DropDownItems.Add(SolidStyleItem);
                    StylePenItem.DropDownItems.Add(DotStyleItem);
                    StylePenItem.DropDownItems.Add(DashDotDotStyleItem);
                    SolidStyleItem.Checked = true;
            Ms.Items.Add(EditItem);

            ToolStripMenuItem HelpItem = new ToolStripMenuItem("Help"); 
            ToolStripMenuItem AboutHelpItem = new ToolStripMenuItem("About");
            HelpItem.DropDownItems.Add(AboutHelpItem);
            Ms.Items.Add(HelpItem);
            AboutHelpItem.Click += AboutHelpItem_Click;

            //Tool Strip Fill
            Ts.LayoutStyle = ToolStripLayoutStyle.VerticalStackWithOverflow;
            ToolStripButton NewButton = new ToolStripButton("New");
            NewButton.Size = new Size(50, 30);
            ToolStripButton OpenButton = new ToolStripButton("Open");
            OpenButton.Size = new Size(150, 30);
            ToolStripButton SaveButton = new ToolStripButton("Save");
            SaveButton.Size = new Size(150, 30);
            ToolStripButton ColorButton = new ToolStripButton("Color");
            ColorButton.Size = new Size(150, 30);
            ToolStripButton ExitButton = new ToolStripButton("Exit");
            ExitButton.Size = new Size(150, 30);

            NewButton.DisplayStyle = ToolStripItemDisplayStyle.Text;
            OpenButton.DisplayStyle = ToolStripItemDisplayStyle.Text;
            SaveButton.DisplayStyle = ToolStripItemDisplayStyle.Text;
            ColorButton.DisplayStyle = ToolStripItemDisplayStyle.Text;
            ExitButton.DisplayStyle = ToolStripItemDisplayStyle.Text;

            
            Ts.Items.Add(NewButton);
            Ts.Items.Add(OpenButton);
            Ts.Items.Add(SaveButton);
            Ts.Items.Add(ColorButton);
            Ts.Items.Add(ExitButton);

            //Add all elements to form
            this.Controls.Add(Ts);
            this.Controls.Add(Ms);
            this.Controls.Add(Pb);
            this.Controls.Add(Pl);
            this.Controls.Add(Tb);


            Pl.SendToBack();
            Tb.BringToFront();
        }

        private void Pb_MouseDown(object? sender, MouseEventArgs e)
        {
            if (Pb.Image==null)
            {
                MessageBox.Show("Before Create New File");
                return;
            }
            
        }

        private void NewFileItem_Click(object? sender, EventArgs e)
        {
            Bitmap pic = new Bitmap(650, 1000);
            Pb.Image = pic;
            
        }

        private void AboutHelpItem_Click(object? sender, EventArgs e)
        {
            Helpform helpform = new Helpform();
            helpform.ShowDialog();
        }

        private void Pb_MouseMove(object? sender, MouseEventArgs e)
        {
            Lb.Text = $"X: {e.X}, Y: {e.Y}";
        }
    }
}