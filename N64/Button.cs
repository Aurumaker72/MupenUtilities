using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MupenUtils.N64
{
    public class Button
    {
        public int indexInStruct;

        public bool internalPressed;
        public bool userPressed;
        public bool autoFire;

        public Button(int indexInStruct)
        {
            this.indexInStruct = indexInStruct;
        }
    }
}
