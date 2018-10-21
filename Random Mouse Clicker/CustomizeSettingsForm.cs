using System;
using System.Windows.Forms;
using Random_Mouse_Clicker.Properties;

namespace Random_Mouse_Clicker
{
    public partial class CustomizeSettingsForm : Form
    {
        private MainForm mainForm;
        private KeysConverter converter = new KeysConverter();

        /**
         * Initializes the CustomizeSettingsForm
         * */
        public CustomizeSettingsForm()
        {
            InitializeComponent();
        }

        /**
         * Initializes the CustomizeSettingsForm
         * Sets the reference to the MainForm
         * */
        public CustomizeSettingsForm(MainForm mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
        }

        /**
         * Once the form is loaded, set all the fields based on the persistent application settings
         * */
        private void CustomizeSettingsForm_Load(object sender, EventArgs e)
        {
            textBoxUserDefinedExitShortcut.Text = (String) Settings.Default["ExitProgramHotkey"];
            textBoxUserDefinedStartStopShortcut.Text = (String) Settings.Default["StartStopProgramHotkey"];
            numericClickEachTime.Value = (decimal) Settings.Default["NumberOfClicksEachTime"];
        }

        /**
         * Handles the input for the user defined exit shortcut
         * */
        private void textBoxUserDefinedExitShortcut_KeyDown(object sender, KeyEventArgs e)
        {
            handleUserInputForShortcuts(sender, e, textBoxUserDefinedExitShortcut);
        }

        /**
         * Handles the input for the user defined start/stop shortcut
         * */
        private void textBoxUserDefinedStartStopShortcut_KeyDown(object sender, KeyEventArgs e)
        {
            handleUserInputForShortcuts(sender, e, textBoxUserDefinedStartStopShortcut);
        }

        /**
         * Deletes the field if the user hits backspace
         * Parses modifier keys such as Ctrl, Shift, and Alt along with any additional keys pressed
         * */
        private void handleUserInputForShortcuts(object sender, KeyEventArgs e, TextBox textbox)
        {
            if (e.KeyCode != Keys.Back)
            {
                Keys modifierKeys = e.Modifiers;
                Keys pressedKey = e.KeyData ^ modifierKeys;
                
                if (modifierKeys != Keys.None && pressedKey != Keys.None)
                {
                    textbox.Text = converter.ConvertToString(e.KeyData);
                }
            }
            else
            {
                e.Handled = false;
                e.SuppressKeyPress = true;
                textbox.Text = "";
            }
        }

        /**
         * Saves the values of the fields to the persistent settings
         * Unregisters the previous user hotkeys
         * Registers the new user hot keys
         * */
        private void buttonSaveSettings_Click(object sender, EventArgs e)
        {
            Settings.Default["ExitProgramHotkey"] = textBoxUserDefinedExitShortcut.Text;
            Settings.Default["StartStopProgramHotkey"] = textBoxUserDefinedStartStopShortcut.Text;
            Settings.Default["NumberOfClicksEachTime"] = numericClickEachTime.Value;
            Settings.Default.Save();

            unregisterOldHotkeys();
            registerNewHotkeys();

            this.Close();
        }

        /**
         * Unregister all user defined hot keys
         * */
        private void unregisterOldHotkeys()
        {
            mainForm.unregisterHotkey(mainForm.userExitHotkey);
            mainForm.unregisterHotkey(mainForm.userStartStopHotkey);
        }

        /**
         * Register all user defined hot keys
         * */
        private void registerNewHotkeys()
        {
            mainForm.setUserHotKey(mainForm.userExitHotkey, (String)Settings.Default["ExitProgramHotkey"], null);
            mainForm.setUserHotKey(mainForm.userStartStopHotkey, (String)Settings.Default["StartStopProgramHotkey"], null);
        }
    }
}
