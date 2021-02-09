using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StopWatch
{
    public partial class FormClock : Form
    {
        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;
        private DateTime d1 = DateTime.Now;
        private DateTime d2 = DateTime.Now;

        public FormClock()
        {
            InitializeComponent();
            //
            TopMost = true;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            d2 = DateTime.Now;
            TimeSpan dt = d2 - d1;
            lblClock.Text = dt.ToString(@"hh\:mm\:ss");
        }

        private void FormClock_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.Location;
        }

        private void FormClock_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(dif));
            }
        }

        private void FormClock_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            Opacity = 0.1;
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            Opacity = 0.3;
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            Opacity = 0.5;
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            Opacity = 0.8;
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            Opacity = 1.0;
        }

        private void clearTimerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer.Enabled = false;
            d1 = DateTime.Now;
            d2 = DateTime.Now;
            TimeSpan dt = d2 - d1;
            lblClock.Text = dt.ToString(@"hh\:mm\:ss");
        }

        private void stopTimerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer.Enabled = false;
        }

        private void startTimerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer.Enabled = true;
            d1 = DateTime.Now;
        }
    }
}
