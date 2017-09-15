using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Indicium
{
    public partial class Messager : Form
    {
        public Messager(string s)
        {
            InitializeComponent();
            Options.ApplyTheme(this);

            msg.Text = s;
        }

        private void Messager_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            this.BringToFront();
        }

        private void yesbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
