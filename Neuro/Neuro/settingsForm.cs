using System;
using System.Windows.Forms;

namespace Neuro
{
    public partial class settingsForm : Form
    {
        public Boolean ItsClosed
        {
            get;
            private set;
        }
        public Int32 GetNeuronCount
        {
            private set;
            get;
        }
        public Int32 GetImageWidth
        {
            private set;
            get;
        }
        public Int32 GetImageHeight
        {
            private set;
            get;
        }

        public settingsForm(Int32 neuronCount, Int32 imageWidth, Int32 imageHeight)
        {
            GetImageHeight = imageHeight;
            GetImageWidth = imageWidth;
            GetNeuronCount = neuronCount;
            InitializeComponent();
            numericUpDown2.Value = GetNeuronCount;
            numericUpDown3.Value = GetImageWidth;
            numericUpDown4.Value = GetImageHeight;
        }

        private void settingsForm_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Пере инициализация нейросети приведет к повторной необходимости обучения сети.\r\nВы хотите пере инициализировать сеть?", "Внимание!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                GetNeuronCount = (Int32)numericUpDown2.Value;
                GetImageWidth = (Int32)numericUpDown3.Value;
                GetImageHeight = (Int32)numericUpDown4.Value;
                ItsClosed = false;
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ItsClosed = true;
            this.Close();
        }
    }
}
