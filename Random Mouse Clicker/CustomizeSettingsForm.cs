using System;
using System.Windows.Forms;
using Random_Mouse_Clicker.Properties;
using System.ComponentModel;

namespace Random_Mouse_Clicker
{
    public partial class CustomizeSettingsForm : Form
    {
        private MainForm mainForm;

        public CustomizeSettingsForm()
        {
            InitializeComponent();
        }

        public CustomizeSettingsForm(MainForm mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
        }

        private void CustomizeSettingsForm_Load(object sender, EventArgs e)
        {
            textBoxUserDefinedExitShortcut.Text = (String) Settings.Default["ExitProgramHotkey"];
            textBoxUserDefinedPauseShortcut.Text = (String) Settings.Default["PauseProgramHotkey"];
            numericClickEachTime.Value = (decimal) Settings.Default["NumberOfClicksEachTime"];
        }

        private void textBoxUserDefinedExitShortcut_KeyDown(object sender, KeyEventArgs e)
        {
            handleUserInputForShortcuts(sender, e, textBoxUserDefinedExitShortcut);
        }

        private void textBoxUserDefinedPauseShortcut_KeyDown(object sender, KeyEventArgs e)
        {
            handleUserInputForShortcuts(sender, e, textBoxUserDefinedPauseShortcut);
        }

        private void handleUserInputForShortcuts(object sender, KeyEventArgs e, TextBox textbox)
        {
            if (e.KeyCode != Keys.Back)
            {
                Keys modifierKeys = e.Modifiers;
                Keys pressedKey = e.KeyData ^ modifierKeys;
                KeysConverter converter = new KeysConverter();

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
            Settings.Default["PauseProgramHotkey"] = textBoxUserDefinedPauseShortcut.Text;
            Settings.Default["NumberOfClicksEachTime"] = numericClickEachTime.Value;
            Settings.Default.Save();
            mainForm.unregisterHotkey(mainForm.userExitHotkey);
            mainForm.setUserHotKey(mainForm.userExitHotkey, (String)Settings.Default["ExitProgramHotkey"], mainForm.Hk_Exit_OnPressed);
            mainForm.unregisterHotkey(mainForm.userPauseHotkey);
            mainForm.setUserHotKey(mainForm.userPauseHotkey, (String)Settings.Default["PauseProgramHotkey"], mainForm.Hk_Pause_OnPressed);
            this.Close();
        }
    }
}
