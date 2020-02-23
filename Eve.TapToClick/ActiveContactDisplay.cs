using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eve.TapToClick
{
    public partial class ActiveContactDisplay : UserControl
    {
        private int contactIndex;
        private bool active;
        private uint pressure;
        private uint x;
        private uint y;

        public int ContactIndex
        {
            get
            {
                return contactIndex;
            }

            set
            {
                contactIndex = value;
                valueGroupBox.Text = $"Contact #{contactIndex + 1}";
            }
        }

        public bool Active
        {
            get
            {
                return active;
            }

            set
            {
                active = value;
                activeCheckbox.Checked = active;
            }
        }

        public uint Pressure
        {
            get
            {
                return pressure;
            }

            set
            {
                pressure = value;
                pressureValueLabel.Text = pressure.ToString();
            }
        }

        public uint X
        {
            get
            {
                return x;
            }

            set
            {
                x = value;
                xLabel.Text = x.ToString();
            }
        }

        public uint Y
        {
            get
            {
                return y;
            }

            set
            {
                y = value;
                yLabel.Text = y.ToString();
            }
        }
        
        public ActiveContactDisplay()
        {
            InitializeComponent();
        }
    }
}
