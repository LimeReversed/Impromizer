using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System;
using System.Collections.Generic;

namespace Headline_Randomizer
{
    public class Common
    {
        static public List<Control> controlItems = new List<Control>();
        static public List<Control> invertedControlItems = new List<Control>();
        static public List<ToolStripMenuItem> menuItems = new List<ToolStripMenuItem>();
        static public List<ToolStripMenuItem> invertedmenuItems = new List<ToolStripMenuItem>();
        static public string version;
        static public string password = "RjlÖ?%jNl3$92jAL";
        static public Form form = new Form();
        public static bool helpOpen = false;
        public static bool fullVersion = false;

        static public string myDocumentsPath = $"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\\Impromizer\\";
        static public string baseDirectoryPath = $"{AppDomain.CurrentDomain.BaseDirectory}";

        //object.image = Image.FromFile(filelocation)

        static public string FirstLetterUpper(string line)
        {
            if (line == "")
            {
                MessageBox.Show("Det fanns inget att generera");
                return "";
            }
            else
            {
                string firstLetter = line[0].ToString().ToUpper();
                return $"{firstLetter}{line.Substring(1, line.Length - 1)}";
            }
        }

        // Method for sizing text automatically
        static private float GetFontSize(TextBox label, string text, int margin, float min_size, float max_size)
        {
            // Only bother if there's text.
            if (text.Length == 0) return min_size;

            // See how much room we have, allowing a bit
            // for the Label's internal margin.
            int wid = label.Width - margin;
            int hgt = label.Height - margin;

            // Make a Graphics object to measure the text.
            using (Graphics gr = label.CreateGraphics())
            {
                while (max_size - min_size > 0.1f)
                {
                    float pt = (min_size + max_size) / 2f;
                    using (Font test_font =
                        new Font(label.Font.FontFamily, pt))
                    {
                        // See if this font is too big.
                        SizeF text_size =
                            gr.MeasureString(text, test_font);
                        if ((text_size.Width > wid) ||
                            (text_size.Height > hgt))
                            max_size = pt;
                        else
                            min_size = pt;
                    }
                }
                return min_size;
            }
        }

        static public void AdjustSize(TextBox tb)
        {
            // If the text is long enough, then split the text into two lines. 
            // It begins in the middle and then searches upwards to find the nearest space to make the split. 
            if (tb.Text.Count() > 35)
            {
                if (!tb.Text.Contains("\r\n"))
                {
                    int middleChar = tb.Text.Count() / 2;
                    int stepCount = 0;
                    while (tb.Text[middleChar + stepCount] != 32 && tb.Text[middleChar - stepCount] != 32)
                    {
                        stepCount++;
                    }

                    if (tb.Text[middleChar + stepCount] == 32)
                    {
                        tb.Text = tb.Text.Insert(middleChar + stepCount, "\r\n");
                    }
                    else
                    {
                        tb.Text = tb.Text.Insert(middleChar - stepCount, "\r\n");
                    }
                        
                    
                }

                tb.Location = new System.Drawing.Point(10, 8);
                tb.Font = new System.Drawing.Font("Adobe Fan Heiti Std", GetFontSize(tb, tb.Text, 3, 1f, 100f), System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            }
            else
            {
                tb.Font = new System.Drawing.Font("Adobe Fan Heiti Std", GetFontSize(tb, tb.Text, 3, 1f, 100f), System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                tb.Location = new System.Drawing.Point(10, 25);
            }
        }

        static public void ToFile(string text)
        {
            StreamWriter writer = new StreamWriter($"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\\Impromizer\\LatestResult.txt");
            writer.Write($"{text}.   ");
            writer.Close();
        }

        static public void SetVersion()
        {
            for (int i = 0; i < controlItems.Count; i++)
            {
                controlItems[i].Enabled = Common.fullVersion;
                controlItems[i].Visible = Common.fullVersion;
            }

            for (int i = 0; i < invertedControlItems.Count; i++)
            {
                invertedControlItems[i].Enabled = !Common.fullVersion;
                invertedControlItems[i].Visible = !Common.fullVersion;
            }

            for (int i = 0; i < menuItems.Count; i++)
            {
                menuItems[i].Enabled = Common.fullVersion;
                menuItems[i].Visible = Common.fullVersion;
            }

            for (int i = 0; i < invertedmenuItems.Count; i++)
            {
                invertedmenuItems[i].Enabled = !Common.fullVersion;
                invertedmenuItems[i].Visible = !Common.fullVersion;
            }

            form.Text = Common.fullVersion ? "Impromizer" : "Impromizer (Free)";
        }

        static public void InsertText(RichTextBox tbx, string file)
        {

            tbx.Rtf = File.ReadAllText($"{AppDomain.CurrentDomain.BaseDirectory}{file}");
            tbx.SelectAll();
            tbx.SelectionIndent += 20;
            tbx.SelectionRightIndent += 20;
            tbx.SelectionLength = 0;
            tbx.DeselectAll();
        }
    }
}
