// Original from: http://stackoverflow.com/a/3124252/122195

using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace Random_Mouse_Clicker
{
    public sealed partial class SnippingTool : Form
    {
        #region Public members
        public static event EventHandler Cancel;
        public static event EventHandler AreaSelected;
        public static Image Image { get; set; }
        #endregion

        #region Private members
        private static SnippingTool[] _forms;
        private static Rectangle rectSelection;
        private Point pointStart;
        #endregion

        #region Constructor
        public SnippingTool(Image screenShot, int x, int y, int width, int height)
        {
            InitializeComponent();
            BackgroundImage = screenShot;
            BackgroundImageLayout = ImageLayout.Stretch;
            ShowInTaskbar = false;
            FormBorderStyle = FormBorderStyle.None;
            StartPosition = FormStartPosition.Manual;
            SetBounds(x, y, width, height);
            WindowState = FormWindowState.Maximized;
            DoubleBuffered = true;
            Cursor = Cursors.Cross;
            TopMost = true;
        }
        #endregion

        #region Private methods
        private void OnCancel(EventArgs e)
        {
            Cancel?.Invoke(this, e);
        }

        private void OnAreaSelected(EventArgs e)
        {
            AreaSelected?.Invoke(this, e);
        }

        private void CloseForms()
        {
            for (int i = 0; i < _forms.Length; i++)
            {
                _forms[i].Dispose();
            }
        }
        #endregion

        #region Public methods
        public static void Snip()
        {
            var screens = ScreenHelper.GetMonitorsInfo();
            _forms = new SnippingTool[screens.Count];
            for (int i = 0; i < screens.Count; i++)
            {
                int hRes = screens[i].HorizontalResolution;
                int vRes = screens[i].VerticalResolution;
                int top = screens[i].MonitorArea.Top;
                int left = screens[i].MonitorArea.Left;
                var bmp = new Bitmap(hRes, vRes, PixelFormat.Format32bppPArgb);
                using (var g = Graphics.FromImage(bmp))
                {
                    g.CopyFromScreen(left, top, 0, 0, bmp.Size);
                }
                _forms[i] = new SnippingTool(bmp, left, top, hRes, vRes);
                _forms[i].Show();
            }
        }

        public static Rectangle getDrawnRectangle()
        {
            return rectSelection;
        }

        public static int getRectangleWidth()
        {
            return rectSelection.Width;
        }

        public static int getRectangleHeight()
        {
            return rectSelection.Height;
        }
        #endregion

        #region Overrides
        protected override void OnMouseDown(MouseEventArgs e)
        {
            // Start the snip on mouse down
            if (e.Button != MouseButtons.Left)
            {
                return;
            }
            pointStart = e.Location;
            rectSelection = new Rectangle(e.Location, new Size(0, 0));
            Invalidate();
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            // Modify the selection on mouse move
            if (e.Button != MouseButtons.Left)
            {
                return;
            }
            int x1 = Math.Min(e.X, pointStart.X);
            int y1 = Math.Min(e.Y, pointStart.Y);
            int x2 = Math.Max(e.X, pointStart.X);
            int y2 = Math.Max(e.Y, pointStart.Y);
            rectSelection = new Rectangle(x1, y1, x2 - x1, y2 - y1);
            Invalidate();
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            // Complete the snip on mouse-up
            if (rectSelection.Width <= 0 || rectSelection.Height <= 0)
            {
                CloseForms();
                OnCancel(new EventArgs());
                return;
            }

            Image = new Bitmap(rectSelection.Width, rectSelection.Height);
            var hScale = BackgroundImage.Width / (double)Width;
            var vScale = BackgroundImage.Height / (double)Height;
            using (Graphics gr = Graphics.FromImage(Image))
            {
                gr.DrawImage(BackgroundImage,
                    new Rectangle(0, 0, Image.Width, Image.Height),
                    new Rectangle((int)(rectSelection.X * hScale), (int)(rectSelection.Y * vScale), (int)(rectSelection.Width * hScale), (int)(rectSelection.Height * vScale)),
                    GraphicsUnit.Pixel);
            }

            CloseForms();
            OnAreaSelected(new EventArgs());
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            // Draw the current selection
            using (Brush br = new SolidBrush(Color.FromArgb(120, Color.White)))
            {
                int x1 = rectSelection.X;
                int x2 = rectSelection.X + rectSelection.Width;
                int y1 = rectSelection.Y;
                int y2 = rectSelection.Y + rectSelection.Height;
                e.Graphics.FillRectangle(br, new Rectangle(0, 0, x1, Height));
                e.Graphics.FillRectangle(br, new Rectangle(x2, 0, Width - x2, Height));
                e.Graphics.FillRectangle(br, new Rectangle(x1, 0, x2 - x1, y1));
                e.Graphics.FillRectangle(br, new Rectangle(x1, y2, x2 - x1, Height - y2));
            }
            using (Pen pen = new Pen(Color.Red, 2))
            {
                e.Graphics.DrawRectangle(pen, rectSelection);
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            // Allow canceling the snip with the Escape key
            if (keyData == Keys.Escape)
            {
                Image = null;
                CloseForms();
                OnCancel(new EventArgs());
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        #endregion

        private void SnippingTool_Load(object sender, EventArgs e)
        {

        }
    }
}
