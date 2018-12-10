using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System;


namespace Headline_Randomizer
{
    public class FixText
    {
        static public string FirstLetterUpper(string line)
        {
            char firstLetter = line[0];
            string firstLetterStr = Convert.ToString(firstLetter);
            return $"{firstLetterStr.ToUpper()}{line.Substring(1, line.Length - 1)}";
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
                    while (tb.Text[middleChar] != 32)
                    {
                        middleChar = middleChar + 1;
                    }
                    tb.Text = tb.Text.Insert(middleChar + 1, "\r\n");
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
    }
}
