using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MupenUtils
{
    public static class DataHelper
    {
        public static string GetMovieStartupType(short stype)
        {
            string type;
            switch (stype)
            {
                case 1:
                    type = "Snapshot";
                    break;
                case 2:
                    type = "Power on";
                    break;
                case 4:
                    type = "EEPROM";
                    break;
                default:
                    type = "Unknown";
                    break;
            }
            return type;
        }
        public static string GetCountryCode(ushort ccode)
        {
            string code = "Error";
            switch(ccode&0xFF)
	        {
	        /* Demo */
	        case 0:
                    code = "Demo";
	        	break;
	        case '7':
                    code = "Beta";
	        	break;

	        case 0x41:
                    code = "USA/Japan";
	        	break;

	        /* Germany */
	        case 0x44:
                    code = "German";
	        	break;

	        /* USA */
	        case 0x45:
                case 0x60:
                    code = "USA";
	        	break;

	        /* France */
	        case 0x46:
                    code = "France";
	        	break;

	        /* Italy */
	        case 'I':
                    code = "Italy";
	        	break;

	        /* Japan */
	        case 0x4A:
                    code = "Japan";
	        	break;

	        case 'S':	/* Spain */
                    code = "Spain";
	        	break;

	        /* Australia */
	        case 0x55:
	        case 0x59:
                    code = "Australia";
	        	break;

            case 0x50:
            case 0x58:
	        case 0x20:
	        case 0x21:
	        case 0x38:
	        case 0x70:
                    code = "Europe";
	        	break;

	        default:
                    code = "Unknown (" + ccode + ")";
	        	break;
	        }
            return code;
        }

    }
}
