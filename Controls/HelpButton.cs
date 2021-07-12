using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MupenUtilities.Controls
{
    public class HelpButton : System.Windows.Forms.Button
    {
        public HelpButton()
        {
            
            this.MinimumSize = new Size(30, 27);
            this.Size = MinimumSize;
            this.Text = "?";

        }
    }
}