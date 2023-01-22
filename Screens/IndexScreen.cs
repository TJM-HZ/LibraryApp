using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Screens
{
    class IndexScreen : Screen
    {
        public IndexScreen(App app) : base(app)
        {
        }

        public string FieldToSpacedString(string field, int maxLength, string spacingCharacter)
        {            
            if (field == null) {
                field = "";
            }
            string convertedField = field;


            if (field.Length > maxLength)
            {
                convertedField = field.Substring(0, maxLength) + "...";
            }
            int spacingNeeded = 30 - convertedField.Length; //TODO: Remove magic number here.
            string spacing = "";
            for (int i = 0; i < spacingNeeded; i++)
            {
                spacing += spacingCharacter;
            }
            convertedField += spacing;

            return convertedField;
        }
    }
}
