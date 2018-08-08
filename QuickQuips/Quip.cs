using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuickQuips
{
    class Quip
    {
        public int id;
        public QuipMode mode;
        public string text;
        public string displayText;


        public void executeQuip(object sender, EventArgs e)
        {

            switch (mode)
            {
                case QuipMode.Clipboard:
                    executeClipboardMode();
                    break;
                case QuipMode.Program:
                    executeProgram();
                    break;
                
            }
        }

        public void executeClipboardMode()
        {
            Clipboard.SetText(text);
        }
        public void executeProgram()
        {
            Process.Start(text);
        }

        public override string ToString()
        {
            var prefixText = "";

            switch (mode)
            {
                case QuipMode.Clipboard:
                    prefixText = "📋 ";
                    break;
                case QuipMode.Program:
                    prefixText = "🏃‍ ";
                    break;

            }
            return prefixText + displayText;
        }
    }



    public enum QuipMode : uint
    {
        Clipboard = 1,
        Program = 2
    }


}
