using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Текстовый_редактор
{
    public partial class Form1 : Form
    {
        Color c;
        public Form1()
        {
            InitializeComponent();
            c = richTextBox1.BackColor;
            menuStrip_EN.Visible = false;
            toolStripButton5.Text = "РУС";
        }

        private void сreateToolStripMenuItem_Click(object sender, EventArgs e) //создать
        {
            Form1 newForm = new Form1();
            newForm.Show();
        }
        private void bt_open_Click(object sender, EventArgs e) //открыть
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "All files(*.*)|*.*| Text File(*.txt)|*.txt||";
            open.FilterIndex = 2;
            if (open.ShowDialog() == DialogResult.OK)
            {
                StreamReader reader = File.OpenText(open.FileName);
                richTextBox1.Text = reader.ReadToEnd();
                reader.Close();
            }
        }
        private void closeToolStripMenuItem_Click(object sender, EventArgs e) //закрыть и выйти
        {
            DialogResult result = DialogResult.Yes;
            result = MessageBox.Show("Сохранить перед выходом?", "Инфо", MessageBoxButtons.YesNo);
            if (result ==DialogResult.Yes ) {
                this.bt_save_Click(sender, e);
                this.Close();
            }
            else
            this.Close();
        }

        private void bt_save_Click(object sender, EventArgs e) //сохранить
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "TXT (*.txt)|*.txt|RTF (*.rtf)|*.rtf";

            if (save.ShowDialog() == DialogResult.OK)
            {
                StreamWriter writer = new StreamWriter(save.FileName);
                writer.Write(richTextBox1.Text);
                writer.Close();
            }
        }
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e) //сохранить как
        {
            SaveFileDialog save = new SaveFileDialog();
            save.FileName = richTextBox1.Text;
            save.FileName = "Документ_1";
            save.Filter = "TXT (*.txt)|*.txt|RTF (*.rtf)|*.rtf";

            if (save.ShowDialog() == DialogResult.OK)
            {
                StreamWriter writer = new StreamWriter(save.FileName);
                writer.Write(richTextBox1.Text);
                writer.Close();
            }
        }
      

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       private void russianToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (russianToolStripMenuItem.Checked == false)
            {
                russianToolStripMenuItem.Checked = true;
                русскийToolStripMenuItem.Checked = true;
                toolStripButton5.Text = "РУС";
                englishToolStripMenuItem.Checked = false;
                английскийToolStripMenuItem.Checked = false;
                menuStrip_EN.Visible = false;
                menuStrip_RU.Visible = true;
                MainMenuStrip = menuStrip_RU;
            }
        }

        private void английскийToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (английскийToolStripMenuItem.Checked == false)
            {
                английскийToolStripMenuItem.Checked = true;
                englishToolStripMenuItem.Checked = true;
                toolStripButton5.Text = "ENG";
                русскийToolStripMenuItem.Checked = false;
                russianToolStripMenuItem.Checked = false;
                menuStrip_RU.Visible = false;
                menuStrip_EN.Visible = true;
                MainMenuStrip = menuStrip_EN;
            }
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            if (russianToolStripMenuItem.Checked == false)
            {
                russianToolStripMenuItem.Checked = true;
                русскийToolStripMenuItem.Checked = true;
                toolStripButton5.Text = "РУС";
                englishToolStripMenuItem.Checked = false;
                английскийToolStripMenuItem.Checked = false;
                menuStrip_EN.Visible = false;
                menuStrip_RU.Visible = true;
                MainMenuStrip = menuStrip_RU;
            }
            else
            {
                английскийToolStripMenuItem.Checked = true;
                englishToolStripMenuItem.Checked = true;
                toolStripButton5.Text = "ENG";
                русскийToolStripMenuItem.Checked = false;
                russianToolStripMenuItem.Checked = false;
                menuStrip_RU.Visible = false;
                menuStrip_EN.Visible = true;
                MainMenuStrip = menuStrip_EN;
            }

        }

        private void font_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fontDialog1.Font = richTextBox1.SelectionFont;
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.SelectionFont = fontDialog1.Font;
            }
        }

        private void color_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = richTextBox1.SelectionColor;
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.SelectionColor = colorDialog1.Color;
            }
        }

        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = richTextBox1.BackColor;
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.BackColor = colorDialog1.Color;
            }

        }
    }
}
