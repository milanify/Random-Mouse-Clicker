using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

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
        private static Point location;
        private int originalFormWidth;
        private int originalFormHeight;
        private Random random = new Random();
        private decimal[] minMax = new decimal[2];
        private readonly Hotkey hotkey = new Hotkey();

        /**
         * Initialize the MainForm and store width and height information
         * Set indexes of comboboxes so that they aren't blank
         * Add event listener for when tab is changed
         * */
        public MainForm()
        {
            InitializeComponent();

            originalFormWidth = this.Width;
            originalFormHeight = this.Height;
            comboBoxClickEvery.SelectedIndex = 1;
            comboBoxDuration.SelectedIndex = 0;

            tabControl1.SelectedIndexChanged += tabControl1_SelectedIndexChanged;
        }

        /**
         * Once form is loaded, register the hot key
         * */
        private void Form1_Load(object sender, EventArgs e)
        {
            RegisterHotKey();
        }

        /**
         * Start snipping when select area is clicked
         * Make the start button clickable
         * */
        private void selectAreaButton_Click(object sender, EventArgs e)
        {
            SnippingTool.Snip();
            buttonStart.Enabled = true;
        }

        /**
         * When start button clicked, stores rectangle coordinates
         * x1 and x2 are the upper left and right corner
         * x1 and x2 are the lower left and right corner
         * checkClickInterval runs to see the time between clicks
         * checkManualOrAutomatic runs to see how the program will end
         * */
        private void startButton_Click(object sender, EventArgs e)
        {
            x1 = SnippingTool.getDrawnRectangle().X;
            x2 = SnippingTool.getDrawnRectangle().X + SnippingTool.getRectangleWidth();
            y1 = SnippingTool.getDrawnRectangle().Y;
            y2 = SnippingTool.getDrawnRectangle().Y + SnippingTool.getRectangleHeight();

            checkClickInterval(comboBoxClickEvery, numericClickEveryMin.Value, numericClickEveryMax.Value);
            checkManualOrAutomatic();
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
         * For manual, program will only stop when user presses CTRL+WIN+ESC
         * Minimizes form so window is not in the way
         * Performs clicking operations
         * 
         * For automatic, checks the duration from the combo box
         * Starts a stopwatch to keep track of time
         * If the duration is not zero, will begin clicking
         * The checkClickDuration method will return 0 if being automatically ended by a certain number of clicks, rather than a numeric amount of time
         * */
        private void checkManualOrAutomatic()
        {
            if (radioEndManually.Checked)
            {
                ShowBalloonMessage("Press CTRL+WIN+ESC to exit the program...", "Random Mouse Clicker");
                this.WindowState = FormWindowState.Minimized;
                clickUntilManuallyEnded();
            }

            else if (radioEndAutomatically.Checked)
            {
                decimal duration = checkClickDuration(comboBoxDuration, numericDuration.Value);
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();

                ShowBalloonMessage("Program will end after " + numericDuration.Value + " " + comboBoxDuration.Text + " or when CTRL+WIN+ESC is pressed" +
                    "...", "Random Mouse Clicker");
                this.WindowState = FormWindowState.Minimized;

                if (duration != 0)
                {
                    clickUntilAutomaticallyEnded(duration, stopwatch);
                }
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
         * Starts a new thread so the hotkey has no issues exiting the program
         * Runs an infinite loop and performs clicking in random locations
         * */
        private void clickUntilManuallyEnded()
        {
            new Thread(delegate () {

                while (true)
                {
                    randomizeLocationAndClick();
                }

            }).Start();
        }

        /**
         * Starts a new thread so the hotkey has no issues exiting the program
         * Runs until the elapsed amount of time exceeds the defined duration
         * */
        private void clickUntilAutomaticallyEnded(decimal duration, Stopwatch stopwatch)
        {
            new Thread(delegate () {

                while (true)
                {
                    if (stopwatch.ElapsedMilliseconds > duration)
                    {
                        break;
                    }
                    else
                    {
                        randomizeLocationAndClick();
                    }
                }

            }).Start();
        }
        
        /**
         * Randomizes the x,y coordinates and sets the location to within the user's selection
         * Checks the speed that the mouse should move to the location, and does so
         * Clicks once at the specified location
         * */
        private void randomizeLocationAndClick()
        {
            location = new Point(random.Next(x1, x2), random.Next(y1, y2));
            checkMouseSpeedAndMove(location);
            clickAndWait();
        }

        /**
         * Randomizes the x,y coordinates and sets the location to within the user's selection
         * Only randomizes within each specified area
         * For all of the pairs of x coordinates, randomizes for all pairs of y coordinates so that each area is clicked
         * Checks the speed that the mouse should move to the location, and does so
         * Clicks once at the specified location
         * */
        private void randomizeLocationAndClickEachArea()
        {
            for (int i = 0; i < ImageSplitter.xCoordinates.Count - 1; i++)
            {
                for (int j = 0; j < ImageSplitter.yCoordinates.Count - 1; j++)
                {
                    location = new Point(random.Next(x1 + ImageSplitter.xCoordinates[i], x1 + ImageSplitter.xCoordinates[i + 1]),
                        random.Next(y1 + ImageSplitter.yCoordinates[j], y1 + ImageSplitter.yCoordinates[j + 1]));

                    checkMouseSpeedAndMove(location);
                    clickAndWait();
                }             
            }          
        }

        /**
         * Checks what the mouse speed is set to
         * Runs method that moves mouse to the location at the specified speed
         * */
        private void checkMouseSpeedAndMove(Point location)
        {
            if (radioSlow.Checked)
            {
                MouseLinearSmoothMove.slow(location);
            }

            else if (radioNormal.Checked)
            {
                MouseLinearSmoothMove.normal(location);
            }

            else if (radioFast.Checked)
            {
                MouseLinearSmoothMove.fast(location);
            }

            else if (radioInstant.Checked)
            {
                MouseLinearSmoothMove.instant(location);
            }
        }

        /**
         * Performs a mouse click
         * Waits for a random amount of time, defined by the user's minimum and maximum
         * */
        private void clickAndWait()
        {
            MouseActions.MouseClick();
            Thread.Sleep(random.Next((int)minMax[0], (int)minMax[1]));
        }

        /**
         * Runs if ending automatically from a certain number of clicks
         * If choosing to divide the region into areas, sets the areas to be clicked
         * Clicks each area
         * Otherwise clicks randomly until finished, since not choosing to divide into areas
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
         * Clicks until number of clicks is reached
         * Performed when end automatically is checked
         * */
        private void clickUntilFinished(decimal numberOfClicks)
        {
            new Thread(delegate () {

                for (int i = 0; i < numberOfClicks; i++)
                {
                    randomizeLocationAndClick();                 
                }

            }).Start();
        }

        /**
         * Clicks areas, loops through if clicking each area multiple times
         * */
        private void clickAllAreas(decimal numberOfClicks)
        {
            new Thread(delegate () {

                for (int i = 0; i < numberOfClicks; i++)
                {
                    randomizeLocationAndClickEachArea();
                }

            }).Start();
        }            

        /**
         * When choosing to end manually, disable the automatic duration form components
         * */

        private void endManuallyRadio_CheckedChanged(object sender, EventArgs e)
        {
            setAutomaticDuration(false);
        }

        /**
         * When choosing to end automatically, enable the automatic duration form components
         * */
        private void endAutomaticallyRadio_CheckedChanged(object sender, EventArgs e)
        {
            setAutomaticDuration(true);
        }

        /**
         * Set automatic duration form components on or off
         * */
        private void setAutomaticDuration(bool b)
        {
            groupBoxDuration.Enabled = b;
            numericDuration.Enabled = b;
            comboBoxDuration.Enabled = b;
        }

        /**
         * Listener method that runs when a tab is clicked
         * If basic tab selected, resize form back to original size
         * If advanced tab selected, set the label and other components accordingly
         * If the displayed width or height does not match the rectangle, update the display
         * If preview tab selected, show the user's selection
         * Resizes the preview tab to display entire image, accounting for the form's borders cutting off part of the image
         * If splitting the region into areas, the preview tab will show the image with red lines drawn as dividers
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
         * Make form go back to the original size
         * Used when going from the preview tab back to the basic or advanced tab
         * */
        private void resizeFormToDefault()
        {
            this.Width = originalFormWidth;
            this.Height = originalFormHeight;
        }

        /**
         * If choosing to divide region into areas, then enable the advanced form components
         * Forces the use of an automatic end because the user can set the amount of clicks per area
         * Otherwise when unchecked, sets back to manual end and disables advanced form components
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
         * Enable the components that divide the region
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
         * Used when dividing region into areas
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
         * Enables form compnents to accomodate ending manually
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
         * Displayed width is always at the beginning of the width array, and height at the end of the height array
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
        * When changing the amount of times each area will be clicked, updates the total of clicks
        * */
        private void numericClickEachArea_ValueChanged(object sender, EventArgs e)
        {
            numericDuration.Value = updateTotalClicksDisplay();
        }

        /**
         * Update the total amount of clicks needed for the automatic end
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
         * Registers the hotkey
         * */
        private void RegisterHotKey()
        {
            hotkey.Control = true;
            hotkey.Windows = true;
            hotkey.KeyCode = Keys.Escape;
            
            hotkey.Pressed += Hk_Win_ESC_OnPressed;

            if (!hotkey.GetCanRegister(this))
            {
                Console.WriteLine("Already registered");
            }
            else
            {
                hotkey.Register(this);
            }
        }

        /**
         * When hotkey is pressed, exits program
         * */
        private void Hk_Win_ESC_OnPressed(object sender, HandledEventArgs handledEventArgs)
        {
            Exit();
        }

        /**
         * Unregisters hotkey
         * */
        private void UnregisterHotkey()
        {
            if (hotkey.Registered)
            {
                hotkey.Unregister();
            }
        }

        /**
        * Exits program
        * */
        private void menuExit_Click_1(object sender, EventArgs e)
        {
            Exit();
        }

        /**
         * Hides and removes taskbar icon
         * Unregisters hotkey from windows
         * Exits application
         * */
        private void Exit()
        {
            notifyIcon.Visible = false;
            notifyIcon.Dispose();
            UnregisterHotkey();
            Application.Exit();
            Environment.Exit(0);
        }       
    }
}
