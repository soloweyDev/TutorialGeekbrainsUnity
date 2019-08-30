using System;
using System.Windows.Forms;

namespace DZ2Ch5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            lblTimer.DataBindings.Add("Text", trackBar1, "Value");

        }

        string notepadFilename;

        private void timer1_Tick(object sender, EventArgs e)
        {
            tsslCurrentTime.Text = DateTime.Now.ToLongTimeString();
        }

        private void tsbCurrentTimeInsert_Click(object sender, EventArgs e)
        {
            //Вставляем текст в формате rtf
            string rtftext = @"{\rtf1\b " + DateTime.Now.ToString() + @"\b0\par\line}}";
            //Устанавливаем фокус ввода
            rtbNotepad.Focus();
            //Устанавливаем курсор в начало текстового поля    
            rtbNotepad.Select(0, 0);
            //Копируем в буфер обмена данные с указанием типа данных
            Clipboard.SetData(DataFormats.Rtf, (object)rtftext);
            //Вставляем данные из буфера обмена
            rtbNotepad.Paste();
            //Устанавливаем курсор для ввода данных
            rtbNotepad.Select(rtbNotepad.SelectionStart - 1, 0);

        }

        private void tsmiExit_Click(object sender, EventArgs e)
        {


            this.Close();
            //Application.Exit();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            //MessageBox.Show("!!!");
            rtbNotepad.SaveFile(notepadFilename);
            Properties.Settings.Default.notepadFilename = notepadFilename;
            Properties.Settings.Default.Save();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            notepadFilename = Properties.Settings.Default.notepadFilename;
            if (System.IO.File.Exists(notepadFilename)) rtbNotepad.LoadFile(notepadFilename);
        }

        private void tsmiSaveAs_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "Файл rtf|*.rtf|Все файлы|*.*";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                notepadFilename = dlg.FileName;
                rtbNotepad.SaveFile(notepadFilename);

            }

        }

        private void tsmiOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Файл rtf|*.rtf";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                notepadFilename = dlg.FileName;
                rtbNotepad.LoadFile(notepadFilename);

            }

        }

        private void tsmiNew_Click(object sender, EventArgs e)
        {
            rtbNotepad.Text = "";
        }

        private void tsmiSave_Click(object sender, EventArgs e)
        {
            rtbNotepad.SaveFile(notepadFilename);
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            timer2.Enabled = !timer2.Enabled;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            //lblTimer.Text = trackBar1.Value.ToString();
            if (trackBar1.Value > 0) trackBar1.Value--;
            else
            {
                timer2.Enabled = false;
                MessageBox.Show(textBox1.Text);
            }

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            //lblTimer.Text = trackBar1.Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dtpDeath.Value < dtpBirth.Value)
            {
                MessageBox.Show("Дата смерти меньше даты рождения.\nТакого быть не может.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var delta = (dtpDeath.Value - dtpBirth.Value).TotalDays;
            DateTime result = new DateTime().AddDays(delta);
            lblResult.Text = string.Format("Продолжительность жизни: {0} лет {1} месяцев {2} дней", result.Year -1, result.Month -1, result.Day -1 );
        }
    }
}
