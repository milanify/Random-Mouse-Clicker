using System;
using System.Windows.Forms;
using Random_Mouse_Clicker.Properties;
using System.ComponentModel;

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

        private void CustomizeSettingsForm_Load(object sender, EventArgs e)
        {
            textBoxUserDefinedExitShortcut.Text = (String) Settings.Default["ExitProgramHotkey"];
            textBoxUserDefinedStartStopShortcut.Text = (String) Settings.Default["StartStopProgramHotkey"];
            numericClickEachTime.Value = (decimal) Settings.Default["NumberOfClicksEachTime"];
        }

        private void textBoxUserDefinedExitShortcut_KeyDown(object sender, KeyEventArgs e)
        {
            handleUserInputForShortcuts(sender, e, textBoxUserDefinedExitShortcut);
        }

        private void textBoxUserDefinedStartStopShortcut_KeyDown(object sender, KeyEventArgs e)
        {
            handleUserInputForShortcuts(sender, e, textBoxUserDefinedStartStopShortcut);
        }

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

        private void unregisterOldHotkeys()
        {
            mainForm.unregisterHotkey(mainForm.userExitHotkey);
            mainForm.unregisterHotkey(mainForm.userStartStopHotkey);
        }

        private void registerNewHotkeys()
        {
            mainForm.setUserHotKey(mainForm.userExitHotkey, (String)Settings.Default["ExitProgramHotkey"], null);
            mainForm.setUserHotKey(mainForm.userStartStopHotkey, (String)Settings.Default["StartStopProgramHotkey"], null);
        }
    }
}
