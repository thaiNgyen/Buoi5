using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Buoi5
{
    public partial class frmSoanthaovanban : Form
    {
        public string path = ""; //biến toàn cục 
        public frmSoanthaovanban()
        {
            InitializeComponent();
        }

        private void địnhDạngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fontDlg = new FontDialog();
            fontDlg.ShowColor = true;
            fontDlg.ShowApply = true;
            fontDlg.ShowEffects = true;
            fontDlg.ShowHelp = true;
            if (fontDlg.ShowDialog() != DialogResult.Cancel)
            {
                richTextBox1.ForeColor = fontDlg.Color;
                richTextBox1.Font = fontDlg.Font;
            }
        }

        private void frmSoanthaovanban_Load(object sender, EventArgs e)
        {
            tsbSize.Text = "Tahoma";
            tsbFont.Text = "14";
            foreach (FontFamily font in new InstalledFontCollection().Families)
            {
                tsbSize.Items.Add(font.Name);
            }
            List<int> listSize = new List<int> { 8, 9, 10, 11, 12, 14, 16, 18, 20, 22, 24, 26, 28, 36, 48, 72 };
            foreach (var s in listSize)
            {
                tsbFont.Items.Add(s);
            }
        }


        private void mởTậpTinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Text file| .txt| RTF File | *.rtf";
            if(dlg.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.LoadFile(dlg.FileName, RichTextBoxStreamType.PlainText);   
                path = dlg.FileName;
            }
        }

        private void lưuNộiDungVănBảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.CheckPathExists = true;
            saveFileDialog.DefaultExt = "rtf";
            saveFileDialog.Filter = "RichText files| *.rtf";
            saveFileDialog.RestoreDirectory = true;
            if(saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.SaveFile(saveFileDialog.FileName, RichTextBoxStreamType.PlainText);
                MessageBox.Show("Luu file thanh cong !!" + saveFileDialog.FileName, "Thong Bao");
            }
              
        }

        private void tsbBold_Click(object sender, EventArgs e)
        {
            if(richTextBox1.SelectionFont.Bold)
            {
                richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, richTextBox1.SelectionFont.Style & FontStyle.Bold);

            }
            else
            {
                richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, richTextBox1.SelectionFont.Style | FontStyle.Bold);
            }

        }

        private void tsbitalic_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionFont.Italic)
            {
                // Nếu đoạn văn bản đã được định dạng nghiêng, bỏ định dạng nghiêng
                richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, richTextBox1.SelectionFont.Style & ~FontStyle.Italic);
            }
            else
            {
                // Nếu đoạn văn bản chưa được định dạng nghiêng, thêm định dạng nghiêng
                richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, richTextBox1.SelectionFont.Style | FontStyle.Italic);
            }
        }

        private void tsbUnderline_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionFont.Underline)
            {
                // Nếu đoạn văn bản đã được định dạng gạch chân, bỏ định dạng gạch chân
                richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, richTextBox1.SelectionFont.Style & ~FontStyle.Underline);
            }
            else
            {
                // Nếu đoạn văn bản chưa được định dạng gạch chân, thêm định dạng gạch chân
                richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, richTextBox1.SelectionFont.Style | FontStyle.Underline);
            }
        }

        private void tsbFont_SelectedIndexChanged(object sender, EventArgs e)
        {
            richTextBox1.SelectionFont = new Font(tsbFont.Text, float.Parse(tsbFont.Text));
        }

        private void tsbSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            richTextBox1.SelectionFont = new Font(tsbSize.Text, float.Parse(tsbSize.Text));
        }
    }
}
