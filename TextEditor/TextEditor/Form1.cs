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

namespace TextEditor
{
    public partial class Form1 : Form
    {
        private String path;

        public Form1()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult openResult = openFileDialog1.ShowDialog();

            if (openResult == DialogResult.OK)
            {
                path = openFileDialog1.FileName;

                try
                {
                    StreamReader fileOpen = new StreamReader(path);
                    String contents = fileOpen.ReadToEnd();
                    textEditor.Text = contents;
                    fileOpen.Close();
                }
                catch (IOException ex)
                {
                    MessageBox.Show("Error Opening File" + ex.Message);
                }
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textEditor.Clear();
            path = "";
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult saveResult = saveFileDialog1.ShowDialog();

            if (saveResult == DialogResult.OK)
            {
                path = saveFileDialog1.FileName;

                try
                {
                    StreamWriter writer = new StreamWriter(path);
                    writer.Write(textEditor.Text);
                    writer.Close();
                }
                catch (IOException ex)
                {
                    MessageBox.Show("Error Saving File: " + ex.Message);
                }
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (path == String.Empty)
            {
                DialogResult saveResult = saveFileDialog1.ShowDialog();

                if (saveResult == DialogResult.OK)
                {
                    path = saveFileDialog1.FileName;

                    try
                    {
                        StreamWriter writer = new StreamWriter(path);
                        writer.Write(textEditor.Text);
                        writer.Close();
                    }
                    catch (IOException ex)
                    {
                        MessageBox.Show("Error Saving File: " + ex.Message);
                    }
                }
            }
            else
            {
                try
                {
                    StreamWriter writer = new StreamWriter(path);
                    writer.Write(textEditor.Text);
                    writer.Close();
                }
                catch (IOException ex)
                {
                    MessageBox.Show("Error Saving File: " + ex.Message);
                }
            }
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(textEditor.SelectedText);
            SendKeys.Send("{DELETE}");
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(textEditor.SelectedText);
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textEditor.Paste(Clipboard.GetText());
        }

        private void textWrapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (textWrapToolStripMenuItem.Checked == true)
            {
                textEditor.WordWrap = true;
            }
            else
            {
                textEditor.WordWrap = false;
            }
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult fontResult = fontDialog1.ShowDialog();

            if (fontResult == DialogResult.OK)
            {
                textEditor.Font = fontDialog1.Font;
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This text editor was made based on a YouTube video.  This is free software.");
        }
    }
}
