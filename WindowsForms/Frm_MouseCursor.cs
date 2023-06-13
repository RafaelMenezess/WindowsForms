﻿using System;
using System.Windows.Forms;

namespace WindowsForms
{
    public partial class Frm_MouseCursor : Form
    {
        public Frm_MouseCursor()
        {
            InitializeComponent();
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            for (int i = 0; i <= 10; i++)
            {
                System.Threading.Thread.Sleep(1000);
            }

            this.Cursor = Cursors.Default;
        }
    }
}
