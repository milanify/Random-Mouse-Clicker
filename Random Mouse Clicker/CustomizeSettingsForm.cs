using System;
using System.Windows.Forms;
using Random_Mouse_Clicker.Properties;

namespace Random_Mouse_Clicker
{
    public partial class CustomizeSettingsForm : Form
    {
        public CustomizeSettingsForm()
        {
            InitializeComponent();
        }

        private void CustomizeSettingsForm_Load(object sender, EventArgs e)
        {
            textBoxUserDefinedShortcut.Text = (String) Settings.Default["ExitProgramHotkey"];
            checkBoxRestartProgramUsingShortcut.Checked = (bool) Settings.Default["RestartOnExit"];
            numericClickEachTime.Value = (decimal) Settings.Default["NumberOfClicksEachTime"];
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
                    Console.WriteLine(textBoxUserDefinedShortcut.Text);
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

        private void buttonSaveSettings_Click(object sender, EventArgs e)
        {
            Settings.Default["ExitProgramHotkey"] = textBoxUserDefinedShortcut.Text;
            Settings.Default["RestartOnExit"] = checkBoxRestartProgramUsingShortcut.Checked;
            Settings.Default["NumberOfClicksEachTime"] = numericClickEachTime.Value;
            Settings.Default.Save();
            this.Close();
        }
    }
}
