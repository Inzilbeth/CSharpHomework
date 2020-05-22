using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Forms
{
    /// <summary>
    /// Pairgame form.
    /// </summary>
    public partial class PairForm : Form
    {
        private int size;
        private Controller controller;

        /// <summary>
        /// Constructor with size setting.
        /// </summary>
        /// <param name="size"></param>
        public PairForm(int size)
        {
            controller = new Controller(size);
            this.size = size;
            InitializeComponent();
            InitializeButtons();
        }

        /// <summary>
        /// Initializes buttons on a form.
        /// </summary>
        public void InitializeButtons()
        {
            for (int i = 0; i < size; ++i)
            {
                for (int j = 0; j < size; ++j)
                {
                    Controls.Add(controller.buttonArray[i, j]);
                    controller.buttonArray[i, j].MouseClick += new MouseEventHandler(S_MouseClick);
                }
            }
        }

        /// <summary>
        /// On button click event.
        /// </summary>
        private void S_MouseClick(object sender, MouseEventArgs e)
        {
            int i = PointToClient(Cursor.Position).X / 40;
            int j = PointToClient(Cursor.Position).Y / 40;

            controller.Click(i, j);
            if(controller.WinCheck())
            {
                MessageBox.Show("You won!");
            }
        }
    }
}
