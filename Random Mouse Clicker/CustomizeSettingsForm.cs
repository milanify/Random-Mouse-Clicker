using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Random_Mouse_Clicker
{
    public partial class CustomizeSettingsForm : Form
    {
        public CustomizeSettingsForm()
        {
            InitializeComponent();
        }

        private void textBoxUserDefinedShortcut_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Back)
            {
                Keys modifierKeys = e.Modifiers;
                Keys pressedKey = e.KeyData ^ modifierKeys; //remove modifier keys

                if (modifierKeys != Keys.None && pressedKey != Keys.None)
                {
                    //do stuff with pressed and modifier keys
                    var converter = new KeysConverter();
                    textBoxUserDefinedShortcut.Text = converter.ConvertToString(e.KeyData);
                    //At this point, we know a one or more modifiers and another key were pressed
                    //modifierKeys contains the modifiers
                    //pressedKey contains the other pressed key
                    //Do stuff with results here
                }
            }
            else
            {
                e.Handled = false;
                e.SuppressKeyPress = true;

                textBoxUserDefinedShortcut.Text = "";
            }
        }
    }
}
