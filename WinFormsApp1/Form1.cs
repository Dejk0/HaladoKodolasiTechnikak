namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            _statusMessage.Visible = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            NonEnglishValidation(textBox1.Text);
        }
        private void NonEnglishValidation(string name)
        {
            for (int i = 0; i < HungarianChars.Length; i++)
            {
                var hungarianChar = HungarianChars[i];
                if (name.Contains(hungarianChar))
                {
                    _statusMessage.Text = "Non english word.";
                    _statusMessage.ForeColor = Color.Red;
                    _statusMessage.Visible = true;
                    return;
                }
                _statusMessage.Visible = false ;
            }
        }
        private readonly char[] HungarianChars = {
    'Á', 'á', 'É', 'é', 'Í', 'í', 'Ó', 'ó',
    'Ö', 'ö', 'Õ', 'õ', 'Ú', 'ú', 'Ü', 'ü', 'Û', 'û'
        };

        private bool WindowValidation()
        {
            return _statusMessage.Visible;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (WindowValidation()) {
                MessageBox.Show("The window validasion is get an error.");
                return;
            }
            //pass
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
