using System.Drawing;

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