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
            textBoxUserDefinedShortcut.Text = (String) Settings.Default["ExitProgramHotkey"];
            checkBoxRestartProgramUsingShortcut.Checked = (bool) Settings.Default["RestartOnExit"];
            numericClickEachTime.Value = (decimal) Settings.Default["NumberOfClicksEachTime"];
        }

        private void textBoxUserDefinedShortcut_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Back)
            {
                Keys modifierKeys = e.Modifiers;
                Keys pressedKey = e.KeyData ^ modifierKeys;

                if (modifierKeys != Keys.None && pressedKey != Keys.None)
                {
                    textBoxUserDefinedShortcut.Text = converter.ConvertToString(e.KeyData);
                    String temp = textBoxUserDefinedShortcut.Text;
                    textBoxUserDefinedShortcut.Text = temp;
                    Console.WriteLine(textBoxUserDefinedShortcut.Text);
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
            registerUserHotKey();
            this.Close();
        }

        public void registerUserHotKey()
        {
            String hotkey = (String) Settings.Default["ExitProgramHotkey"];
            String[] hotkeys = hotkey.Split('+');
            //mainForm.userHotkey.KeyCode = (Keys) converter.ConvertFromString(hotkey);
            Keys keycode;
            foreach(var key in hotkeys)
            {
                Enum.TryParse(key, out keycode);
                Console.WriteLine("Listing out the key " + key);
                if(keycode == Keys.Shift || keycode == Keys.ShiftKey || keycode == Keys.LShiftKey || keycode == Keys.RShiftKey)
                {
                    mainForm.userHotkey.Shift = true;
                    Console.WriteLine("Contains shift");
                }

                else if (keycode == Keys.Control || keycode == Keys.ControlKey || keycode == Keys.LControlKey || keycode == Keys.RControlKey || key.Equals("Ctrl"))
                {
                    mainForm.userHotkey.Control = true;
                    Console.WriteLine("Contains control");
                }

                else if (keycode == Keys.Alt)
                {
                    mainForm.userHotkey.Alt = true;
                    Console.WriteLine("Contains alt");
                }

                else if (keycode == Keys.LWin || keycode == Keys.RWin)
                {
                    mainForm.userHotkey.Windows = true;
                    Console.WriteLine("Contains windows button");
                }

                else
                {
                    mainForm.userHotkey.KeyCode = keycode;
                    Console.WriteLine("Contains " + keycode);
                }
            }
            Console.WriteLine("Registering user hotkey " + hotkey + " and " + mainForm.userHotkey.KeyCode);
           mainForm.userHotkey.Pressed += test;
           mainForm.userHotkey.Register(mainForm);
        }

        public void test(object sender, HandledEventArgs handledEventArgs)
        {
            Console.WriteLine("Test worked");
        }
    }
}
