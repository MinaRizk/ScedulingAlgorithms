using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sceduling_Algorithms
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            //Form1.Form1.listToPrint
            TableLayoutPanel tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel1.Location = new System.Drawing.Point(50, 466);

            //tableLayoutPanel1.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            tableLayoutPanel1.Name = "TableLayoutPanel1";
            //const int layoutWidth = 500;
            //tableLayoutPanel1.Size = new System.Drawing.Size(layoutWidth, 500);
            tableLayoutPanel1.BackColor = Color.White;
            tableLayoutPanel1.TabIndex = 0;
            tableLayoutPanel1.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            Controls.Add(tableLayoutPanel1);

            // initiateForm1.Form1.listToPrint();
            int startingTime = Form1.listToPrint[0].start;
            int finishTime = Form1.listToPrint[Form1.listToPrint.Count() - 1].finish;
            int totalTime = finishTime - startingTime;

            // Add rows and columns
            tableLayoutPanel1.ColumnCount = Form1.listToPrint.Count();
            //tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            //tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            //tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            Label[] labels = new Label[Form1.listToPrint.Count()];
            Label[] startLabel = new Label[Form1.listToPrint.Count()];
            Label[] finishLabel = new Label[Form1.listToPrint.Count()];
            Panel[] panels = new Panel[Form1.listToPrint.Count()];
            //int totalsize = 0;
            for (int i = 0; i < Form1.listToPrint.Count(); i++)
            {
                //1st row
                labels[i] = new Label();
                if (Form1.listToPrint[i].id == -1)
                    labels[i].Text = "IDLE";
                else
                    labels[i].Text = "P" + Form1.listToPrint[i].id.ToString();
                //labels[i].BackColor = Color.Green;
                //labels[i].MinimumSize = new Size(50, 0);
                //labels[i].AutoSize = true;
                labels[i].Dock = DockStyle.Fill;
                //labels[i].Anchor = AnchorStyles.None;
                labels[i].TextAlign = ContentAlignment.MiddleCenter;
                tableLayoutPanel1.Controls.Add(labels[i], i, 0);
                int burstTime = Form1.listToPrint[i].finish - Form1.listToPrint[i].start;



                float timePercentage = ((float)burstTime / totalTime) * 100;

                tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, timePercentage));
                //tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute,50));
                //2nd row
                panels[i] = new Panel();
                //panels[i].BackColor = Color.Yellow;
                panels[i].Dock = DockStyle.Fill;
                startLabel[i] = new Label();
                startLabel[i].Text = Form1.listToPrint[i].start.ToString();
                startLabel[i].BackColor = Color.Blue;
                //startLabel[i].Dock = DockStyle.Left;
                startLabel[i].Dock = DockStyle.Bottom;
                startLabel[i].AutoSize = true;

                panels[i].Controls.Add(startLabel[i]);
                //startLabel[i].Anchor = AnchorStyles.Left | AnchorStyles.Bottom;


                finishLabel[i] = new Label();
                finishLabel[i].BackColor = Color.Red;
                finishLabel[i].Text = Form1.listToPrint[i].finish.ToString();
                finishLabel[i].TextAlign = ContentAlignment.TopRight;

                //finishLabel[i].TextAlign = ContentAlignment.MiddleCenter;
                panels[i].Controls.Add(finishLabel[i]);
                //finishLabel[i].Anchor = AnchorStyles.Right;
                //finishLabel[i].Dock = DockStyle.Bottom;
                finishLabel[i].Dock = DockStyle.Right;
                //finishLabel[i].Dock = DockStyle.Bottom;
                //finishLabel[i].Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
                //finishLabel[i].Anchor = AnchorStyles.Right;
                finishLabel[i].AutoSize = true;
                //panels[i].MinimumSize = new Size(startLabel[i].Width + finishLabel[i].Width, 0);
                tableLayoutPanel1.Controls.Add(panels[i], i, 1);
                //tableLayoutPanel1.ColumnStyles[i].Width = panels[i].Width;
                //tableLayoutPanel1.MinimumSize = new Size(panels[i].Width, 0);
                //totalsize += panels[i].Width;
                //tableLayoutPanel1.MinimumSize = new Size(totalsize, 0);


                //panels[i].AutoSize = true;

                tableLayoutPanel1.MaximumSize = new Size(1200, 0);
                tableLayoutPanel1.AutoSize = true;
                //tableLayoutPanel1.AutoScroll = false;
                //tableLayoutPanel1.VerticalScroll.Enabled = false;

                tableLayoutPanel1.AutoScroll = true;
                if (tableLayoutPanel1.VerticalScroll.Enabled == true)
                    tableLayoutPanel1.Height = 120;


                //tableLayoutPanel1.VerticalScroll.Enabled = false;
                //int vertScrollWidth = SystemInformation.HorizontalScrollBarHeight;

                //tableLayoutPanel1.Padding = new Padding(0, 0, vertScrollWidth, 0);
                //tableLayoutPanel1.Controls.Add(finishLabel[i], i, 1);

            }
        }
        
    }
}
