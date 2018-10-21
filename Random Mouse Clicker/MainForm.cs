using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using Random_Mouse_Clicker.Properties;

namespace Random_Mouse_Clicker
{
    public partial class MainForm : Form
    {
        private int x1;
        private int x2;
        private int y1;
        private int y2;
        private bool widthNotZero;
        private bool heightNotZero;
        private int displayedWidth;
        private int displayedHeight;
        private Point monitorOffset;
        private Thread clickingThread;
        private static Point location;
        private int originalFormWidth;
        private int originalFormHeight;
        private Random random = new Random();
        private Action<Point> moveAtMouseSpeed;
        private decimal[] minMax = new decimal[2];
        private readonly Hotkey defaultHotkey = new Hotkey();

        public Hotkey userExitHotkey = new Hotkey();
        public Hotkey userStartStopHotkey = new Hotkey();

        /**
         * Initializes the MainForm and stores width and height information
         * Sets default indices of combo boxes so that they aren't blank
         * */
        public MainForm()
        {
            InitializeComponent();

            originalFormWidth = this.Width;
            originalFormHeight = this.Height;
            comboBoxClickEvery.SelectedIndex = 1;
            comboBoxDuration.SelectedIndex = 0;
        }

        /**
         * Once form is loaded, registers all hot keys
         * */
        private void Form1_Load(object sender, EventArgs e)
        {
            setDefaultHotkey();
            setUserHotKey(userExitHotkey, (String)Settings.Default["ExitProgramHotkey"], Hk_Exit_OnPressed);
            setUserHotKey(userStartStopHotkey, (String)Settings.Default["StartStopProgramHotkey"], Hk_Start_Stop_OnPressed);
        }

        /**
         * Starts snipping when draw area is clicked
         * Makes the start button clickable
         * */
        private void drawAreaButton_Click(object sender, EventArgs e)
        {
            SnippingTool.Snip();
            buttonStart.Enabled = true;
        }

        /**
         * When the start button is clicked, stores the area's rectangle coordinates
         * x1 and y1 represents the upper left coordinate
         * x2 and y2 represents the bottom right coordinate
         * checkClickInterval runs to see the time between clicks
         * Checks mouse speed function needed and stores the method to a variable
         * runManualOrAutomatic runs to see how the program will end
         * */
        private void startButton_Click(object sender, EventArgs e)
        {
            x1 = SnippingTool.getDrawnRectangle().X;
            x2 = SnippingTool.getDrawnRectangle().X + SnippingTool.getRectangleWidth();
            y1 = SnippingTool.getDrawnRectangle().Y;
            y2 = SnippingTool.getDrawnRectangle().Y + SnippingTool.getRectangleHeight();

            checkClickInterval(comboBoxClickEvery, numericClickEveryMin.Value, numericClickEveryMax.Value);
            moveAtMouseSpeed = checkMouseSpeed();
            runManualOrAutomatic();
        }

        /**
         * Checks combo box text field to set the time
         * Stores minimum and maximum value in an array called minMax
         */
        private void checkClickInterval(ComboBox comboBox, decimal min, decimal max)
        {
            if (comboBox.Text == "millisecond(s)")
            {
                minMax[0] = min;
                minMax[1] = max;
            }

            else if (comboBox.Text == "second(s)")
            {
                minMax[0] = min * 1000;
                minMax[1] = max * 1000;
            }

            else if (comboBox.Text == "minute(s)")
            {
                minMax[0] = min * 1000 * 60;
                minMax[1] = max * 1000 * 60;
            }

            else if (comboBox.Text == "hour(s)")
            {
                minMax[0] = min * 1000 * 60 * 60;
                minMax[1] = max * 1000 * 60 * 60;
            }

            else if (comboBox.Text == "day(s)")
            {
                minMax[0] = min * 1000 * 60 * 60 * 24;
                minMax[1] = max * 1000 * 60 * 60 * 24;
            }
        }

        /**
         * Checks what the mouse speed is set to
         * Returns the function that should be ran
         * */
        private Action<Point> checkMouseSpeed()
        {
            if (radioSlow.Checked)
            {
                return MouseLinearSmoothMove.slow;
            }

            else if (radioNormal.Checked)
            {
                return MouseLinearSmoothMove.normal;
            }

            else if (radioFast.Checked)
            {
                return MouseLinearSmoothMove.fast;
            }

            else
            {
                return MouseLinearSmoothMove.instant;
            }
        }

        /**
         * For manual, program will only stop when the user presses a exit hotkey
         * Minimizes form so window it's not in the way
         * Performs clicking operations
         * 
         * For automatic, checks the duration from the combo box
         * Starts a stopwatch to keep track of time
         * If the duration is not zero, will begin clicking
         * The checkClickDuration method will return 0 if being automatically ended by a certain number of clicks, rather than a numeric amount of time
         * */
        private void runManualOrAutomatic()
        {
            if (radioEndManually.Checked)
            {
                ShowBalloonMessage("Press CTRL+WIN+ESC or your user defined hotkeys to exit/stop the program...", "Random Mouse Clicker");
                this.WindowState = FormWindowState.Minimized;
                clickUntilManuallyEnded();
            }

            else if (radioEndAutomatically.Checked)
            {
                decimal duration = checkClickDuration(comboBoxDuration, numericDuration.Value);
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();

                ShowBalloonMessage("Program will end after " + numericDuration.Value + " " + comboBoxDuration.Text + ", when CTRL+WIN+ESC is pressed, " +
                    "or when your user defined hotkeys are pressed...", "Random Mouse Clicker");
                this.WindowState = FormWindowState.Minimized;

                if (duration != 0)
                {
                    clickUntilAutomaticallyEnded(duration, stopwatch);
                }
            }
        }

        /**
         * Checks if snip was completed on another monitor besides the main one
         * Windows sees monitor names as \\.\DISPLAY1, \\.\DISPLAY2, \\.\DISPLAY3, etc.
         * Have to add an extra backslash before each backslash in the name as an escape character
         * Currently not used, but is kept for possible future updates
         * */
        private bool checkMultiMonitor()
        {
            if (SnippingTool.monitorName == "\\\\.\\DISPLAY1")
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /**
         * Returns the duration of time to click for, if ending automatically
         * If the combo box is set to an amount of clicks, will return 0 since clicks aren't time based
         * Checks if user selected to divide portions of the screen into areas
         * Otherwise, will calculate and return the duration based on the time setting
         * */
        private decimal checkClickDuration(ComboBox comboBox, decimal duration)
        {
            if (comboBox.Text == "click(s)")
            {
                checkForDividedAreas(duration);
                return 0;
            }

            else if (comboBox.Text == "millisecond(s)")
            {
                return duration;
            }

            else if (comboBox.Text == "second(s)")
            {
                return duration * 1000;
            }

            else if (comboBox.Text == "minute(s)")
            {
                return duration * 1000 * 60;
            }

            else if (comboBox.Text == "hour(s)")
            {
                return duration * 1000 * 60 * 60;
            }

            else if (comboBox.Text == "day(s)")
            {
                return duration * 1000 * 60 * 60 * 24;
            }

            return 0;
        }

        /**
         * Starts a new thread so the hotkeys have no issues communicating with the main form
         * Runs an infinite loop and performs clicking in random locations
         * */
        private void clickUntilManuallyEnded()
        {
            clickingThread = new Thread(delegate ()
            {
                while (true)
                {
                    randomizeLocationAndClick();
                }
            });

            clickingThread.Start();
        }

        /**
         * Starts a new thread so the hotkeys have no issues communicating with the main form
         * Runs until the elapsed amount of time exceeds the defined duration
         * */
        private void clickUntilAutomaticallyEnded(decimal duration, Stopwatch stopwatch)
        {
            clickingThread = new Thread(delegate ()
            {
                while (true)
                {
                    if (stopwatch.ElapsedMilliseconds > duration)
                    {
                        ShowBalloonMessage("Program has finished clicking", "Random Mouse Clicker");
                        break;
                    }
                    else
                    {
                        randomizeLocationAndClick();
                    }
                }
            });

            clickingThread.Start();
        }
        
        /**
         * Randomizes the x,y coordinates and sets the location to within the user's selection
         * Adds monitor offset if clicking at a secondary monitor
         * Moves mouse at specified speed
         * Clicks once at the location
         * */
        private void randomizeLocationAndClick()
        {
            monitorOffset = SnippingTool.clickingScreen.Bounds.Location;

            location = new Point(random.Next(x1, x2), random.Next(y1, y2));
            location.X = location.X + monitorOffset.X;
            location.Y = location.Y + monitorOffset.Y;

            moveAtMouseSpeed(location);
            clickAndWait();
        }

        /**
         * Randomizes the x,y coordinates and sets the location to within the user's selection
         * Only randomizes within each specified area
         * For all of the pairs of x coordinates, randomizes for all pairs of y coordinates so that each area is clicked
         * Adds monitor offset if clicking at a secondary monitor
         * Moves mouse at specified speed
         * Clicks once at the location
         * */
        private void randomizeLocationAndClickEachArea()
        {
            monitorOffset = SnippingTool.clickingScreen.Bounds.Location;

            for (int i = 0; i < ImageSplitter.xCoordinates.Count - 1; i++)
            {
                for (int j = 0; j < ImageSplitter.yCoordinates.Count - 1; j++)
                {
                    location = new Point(random.Next(x1 + ImageSplitter.xCoordinates[i], x1 + ImageSplitter.xCoordinates[i + 1]),
                        random.Next(y1 + ImageSplitter.yCoordinates[j], y1 + ImageSplitter.yCoordinates[j + 1]));

                    location.X = location.X + monitorOffset.X;
                    location.Y = location.Y + monitorOffset.Y;

                    moveAtMouseSpeed(location);
                    clickAndWait();
                }             
            }          
        }

        /**
         * Performs the number of mouse clicks each time, defined in the user settings
         * Waits for a random amount of time, defined by the user's minimum and maximum
         * */
        private void clickAndWait()
        {
            for(int i = 0; i < (decimal)Settings.Default["NumberOfClicksEachTime"]; i++)
            {
                MouseActions.MouseClick();
            }

            Thread.Sleep(random.Next((int)minMax[0], (int)minMax[1]));      
        }

        /**
         * Runs if ending automatically from a certain number of clicks
         * If choosing to divide the region into split areas, sets the areas to be clicked
         * Clicks each area
         * Otherwise clicks randomly until finished, since not choosing to divide into split areas
         * */
        private void checkForDividedAreas(decimal duration)
        {
            if (checkBoxDivideInto.Checked)
            {
                ImageSplitter.setSplitAreas(comboBoxDividedAreas.SelectedIndex);
                clickAllAreas(numericClickEachArea.Value);
            }
            else
            {
                clickUntilFinished(duration);
            }
        }

        /**
         * Clicks until number of total clicks is reached
         * Performed when end automatically is checked
         * */
        private void clickUntilFinished(decimal numberOfClicks)
        {
            clickingThread = new Thread(delegate ()
            {
                for (int i = 0; i < numberOfClicks; i++)
                {
                    randomizeLocationAndClick();
                }
                ShowBalloonMessage("Program has finished clicking", "Random Mouse Clicker");
            });

            clickingThread.Start();
        }

        /**
         * Clicks areas, loops through if clicking each area multiple times
         * */
        private void clickAllAreas(decimal numberOfClicks)
        {
            clickingThread = new Thread(delegate ()
            {
                for (int i = 0; i < numberOfClicks; i++)
                {
                    randomizeLocationAndClickEachArea();
                }
                ShowBalloonMessage("Program has finished clicking", "Random Mouse Clicker");
            });

            clickingThread.Start();
        }            

        /**
         * When choosing to end manually, disables the automatic duration form components
         * */
        private void endManuallyRadio_CheckedChanged(object sender, EventArgs e)
        {
            setAutomaticDuration(false);
        }

        /**
         * When choosing to end automatically, enables the automatic duration form components
         * */
        private void endAutomaticallyRadio_CheckedChanged(object sender, EventArgs e)
        {
            setAutomaticDuration(true);
        }

        /**
         * Sets automatic duration form components on or off
         * */
        private void setAutomaticDuration(bool b)
        {
            groupBoxDuration.Enabled = b;
            numericDuration.Enabled = b;
            comboBoxDuration.Enabled = b;
        }

        /**
         * Listener method that runs when a tab is clicked
         * If basic tab selected, resizes form back to its original size
         * If advanced tab selected, sets the label and other components accordingly
         * If the displayed width or height does not match the rectangle, updates the display
         * If preview tab selected, shows the user's selection
         * Resizes the preview tab to display the entire image, accounting for the form's borders cutting off part of the image
         * If splitting the region into sub-areas, the preview tab will show the image with red lines drawn as dividers
         * */
        private void tabControl1_SelectedIndexChanged(Object sender, EventArgs e)
        {
            bool basicTabSelected = tabControl1.SelectedIndex == 0;
            bool advancedTabSelected = tabControl1.SelectedIndex == 1;
            bool previewTabSelected = tabControl1.SelectedIndex == 2;
            widthNotZero = SnippingTool.getRectangleWidth() != 0;
            heightNotZero = SnippingTool.getRectangleHeight() != 0;

            if (basicTabSelected)
            {
                resizeFormToDefault();
            }
            else if (advancedTabSelected && widthNotZero && heightNotZero)
            {
                resizeFormToDefault();

                labelWidthHeight.Text = "The area has a width of " + SnippingTool.getRectangleWidth() + " pixels\r\n"
                + " and a height of " + SnippingTool.getRectangleHeight() + " pixels";

                checkBoxDivideInto.Enabled = true;

                if (displayedWidth != SnippingTool.getRectangleWidth() || displayedHeight != SnippingTool.getRectangleHeight())
                {               
                    divideIntoEqualAreasDisplay();
                }
            }
            else if (previewTabSelected && widthNotZero && heightNotZero)
            {
                previewPictureBox.Visible = true;
                labelPreviewInstructions.Visible = false;
                
                if (SnippingTool.Image.Width > tabControl1.Width)
                {
                    this.Width = SnippingTool.Image.Width + (this.Width - tabControl1.Width) + 8;
                }
                
                if (SnippingTool.Image.Height > tabControl1.Height)
                {
                    this.Height = SnippingTool.Image.Height + (this.Height - tabControl1.Height) + 25;
                }

                if (checkBoxDivideInto.Checked)
                {
                   ImageSplitter.drawSplitImage(comboBoxDividedAreas.SelectedIndex, numericDivideIntoEqualAreas.Value);
                   previewPictureBox.Image = ImageSplitter.drawnImage;
                }
                else
                {
                    previewPictureBox.Image = SnippingTool.Image;
                }                                        
            }
        }

        /**
         * Makes the form go back to its original size
         * Used when going from the preview tab back to the basic or advanced tab
         * */
        private void resizeFormToDefault()
        {
            this.Width = originalFormWidth;
            this.Height = originalFormHeight;
        }

        /**
         * If choosing to divide the drawn region into sub-areas, then enables the advanced form components
         * Forces the use of an ending automatically because the user can set the amount of clicks per area
         * When unchecked, sets back to ending manually and disables advanced form components
         * */
        private void divideIntoEqualAreasCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxDivideInto.Checked && widthNotZero && heightNotZero)
            {
                divideIntoEqualAreasDisplay();
                enableDividedAreas(true);
                forceAutomaticEnd();
            }
            else
            {
                enableDividedAreas(false);
                setBackToManualEnd();
            }
        }

        /**
         * Enables the components that divide the drawn region
         * */
        private void enableDividedAreas(bool b)
        {
            numericDivideIntoEqualAreas.Enabled = b;
            labelClickEachArea.Enabled = b;
            labelClickEachTimes.Enabled = b;
            labelOf.Enabled = b;
            labelCannotBeChanged.Visible = b;
            comboBoxDividedAreas.Enabled = b;
            numericClickEachArea.Enabled = b;
        }

        /**
         * Sets form components to match ending automatically through a number of clicks
         * Used when dividing the region into sub-areas
         * */
        private void forceAutomaticEnd()
        {          
            radioEndAutomatically.Checked = true;
            radioEndManually.Enabled = false;
            comboBoxDuration.Enabled = false;
            comboBoxDuration.SelectedIndex = 0;
            numericDuration.Value = updateTotalClicksDisplay();
            numericDuration.Enabled = false;
        }

        /**
         * Enables form components to accomodate ending manually
         * */
        private void setBackToManualEnd()
        {
            radioEndManually.Checked = true;
            radioEndManually.Enabled = true;
            numericDuration.Value = 1;
        }

        /**
         * Updates based on the number of areas the user wants to divide into, minimum and default is 2
         * */
        private void numericDivideIntoEqualAreas_ValueChanged(object sender, EventArgs e)
        {
            divideIntoEqualAreasDisplay();
            numericDuration.Value = updateTotalClicksDisplay();
        }

        /**
         * Update the combo box to provide all the different ways the area can be divided into
         * Gets dimensions based on number of areas
         * Clears combo box of any previous data
         * Adds dimension selection into the combo box
         * Stores the displayed width and height for error checking
         * The displayed width is always at the beginning of the width array, and height at the end of the height array
         * */
        private void divideIntoEqualAreasDisplay()
        {
            ImageSplitter.getDimensions((int)numericDivideIntoEqualAreas.Value);
            comboBoxDividedAreas.Items.Clear();

            for (int i = 0; i < ImageSplitter.dimensions.Count(); i++)
            {
                String s = ImageSplitter.dimensionWidths[i] + " x " + ImageSplitter.dimensionHeights[i];
                comboBoxDividedAreas.Items.Add(s);
            }
            displayedWidth = ImageSplitter.dimensionWidths[0];
            displayedHeight = ImageSplitter.dimensionHeights[ImageSplitter.dimensionHeights.Count - 1];
        }

        /**
        * When changing the amount of times each area will be clicked, updates the total number of clicks
        * */
        private void numericClickEachArea_ValueChanged(object sender, EventArgs e)
        {
            numericDuration.Value = updateTotalClicksDisplay();
        }

        /**
         * Updates the total amount of clicks needed for ending automatically
         * */
        private int updateTotalClicksDisplay()
        {
            return (int)numericDivideIntoEqualAreas.Value * (int)numericClickEachArea.Value;
        }

       /**
        * Shows tooltip balloon message on the taskbar
        * */
        private void ShowBalloonMessage(string text, string title)
        {
            notifyIcon.BalloonTipText = text;
            notifyIcon.BalloonTipTitle = title;
            notifyIcon.ShowBalloonTip(1000);
        }

        /**
        * Opens the CustomizableSettingsForm
        * */
        private void linkLabelCustomize_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var form = new CustomizeSettingsForm(this);
            form.Show();
        }

        /**
         * Sets the default hotkey
         * */
        private void setDefaultHotkey()
        {
            defaultHotkey.Control = true;
            defaultHotkey.Windows = true;
            defaultHotkey.KeyCode = Keys.Escape;

            defaultHotkey.Pressed += Hk_Exit_OnPressed;
            registerHotkey(defaultHotkey);
        }

        /**
         * Sets the user defined hotkeys
         * */
        public void setUserHotKey(Hotkey hotkey, String hotkeyString, HandledEventHandler onPressMethod)
        {
            String[] splitHotkeys = hotkeyString.Split('+');
            Keys keycode;

            foreach (var keyString in splitHotkeys)
            {
                Enum.TryParse(keyString, out keycode);

                if (keycode == Keys.Control || keycode == Keys.ControlKey || keycode == Keys.LControlKey || keycode == Keys.RControlKey || keyString.ToUpper().Equals("CTRL"))
                {
                    hotkey.Control = true;
                }

                else if (keycode == Keys.Alt || keyString.ToUpper().Equals("ALT"))
                {
                    hotkey.Alt = true;
                }

                else if (keycode == Keys.Shift || keycode == Keys.ShiftKey || keycode == Keys.LShiftKey || keycode == Keys.RShiftKey || keyString.ToUpper().Equals("SHIFT"))
                {
                    hotkey.Shift = true;
                }

                else
                {
                    hotkey.KeyCode = keycode;
                }
            }

            hotkey.Pressed += onPressMethod;
            registerHotkey(hotkey);
        }

        /**
         * Registers a specified hotkey
         * */
        public bool registerHotkey(Hotkey hotkey)
        {
            if (!hotkey.GetCanRegister(this))
            {
                return false;
            }
            else
            {
                hotkey.Register(this);
                return true;
            }
        }

        /**
         * Unregisters a specified hotkey
         * */
        public void unregisterHotkey(Hotkey hotkey)
        {
            if (hotkey.Registered)
            {
                hotkey.Unregister();
            }
        }

        /**
        * When the start/stop hotkey is pressed, either shutdown the clicking thread or start a new one
        * */
        public void Hk_Start_Stop_OnPressed(object sender, HandledEventArgs handledEventArgs)
        {
            if(clickingThread != null && clickingThread.IsAlive)
            {
                clickingThread.Abort();
                ShowBalloonMessage("Program has been stopped, click the start button or press the hotkey again to resume", "Random Mouse Clicker");
            }
            else if (buttonStart.Enabled)
            {
                startButton_Click(null, null);
            }
        }

        /**
        * When the hotkey is pressed, exits the program
        * */
        public void Hk_Exit_OnPressed(object sender, HandledEventArgs handledEventArgs)
        {
            Exit();
        }

        /**
        * Exits the program
        * */
        private void menuExit_Click_1(object sender, EventArgs e)
        {
            Exit();
        }

        /**
         * Hides and removes the taskbar icon
         * Unregisters hotkeys
         * Exits the application
         * */
        public void Exit()
        {
            notifyIcon.Visible = false;
            notifyIcon.Dispose();
            unregisterHotkey(defaultHotkey);
            unregisterHotkey(userExitHotkey);
            unregisterHotkey(userStartStopHotkey);
            Application.Exit();
            Environment.Exit(0);
        }
    }
}
