using System;
using System.Drawing;
using System.Windows.Forms;

namespace KomodoHub.Pages
{
    public partial class HomePage : UserControl
    {
        public event Action? OpenEnrolmentRequested;
        public event Action? OpenSubmissionRequested;
        public event Action? OpenTeacherToolsRequested;
        public event Action? LogoutRequested;
        public event Action? OpenLibraryRequested;
        public event Action? OpenSpeciesRequested; // NEW: event for Species button
        public event Action? OpenSightingRequested;
        public HomePage()
        {
            InitializeComponent();

            // This attachs the logic to the buttons you will create in the designer!!!
            btnLibrary.Click += BtnLibrary_Click;
            btnLogout.Click += BtnLogout_Click;
            this.VisibleChanged += HomePage_VisibleChanged;
            ApplyDecoratedRainforestTheme();
            btnSubmit.Click += button2_Click;
            btnEnrolment.Click += btnEnrolment_Click;
        }

        private void BtnLibrary_Click(object sender, EventArgs e)
        {
            string currentUsername = Properties.Settings.Default.Username;

            if (string.IsNullOrWhiteSpace(currentUsername))
            {
                MessageBox.Show("Please log in first.");
                return; // This stops the code right here so the library doesn't open!!!
            }

            // If they ARE logged in, open the library!!!
            OpenLibraryRequested?.Invoke();
        }
        private void btnEnrolment_Click(object sender, EventArgs e)
        {
            if (!RoleHelper.IsLoggedIn())
            {
                MessageBox.Show("Please log in to enroll in a program.");
                return;
            }
            OpenEnrolmentRequested?.Invoke();
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            LogoutRequested?.Invoke();
        }

        private void HomePage_VisibleChanged(object? sender, EventArgs e)
        {
            if (this.Visible)
            {
                if (Properties.Settings.Default.LoggedIn == 2)
                {
                    lblMode.Text = "Mode: Guest";
                }
                else if (Properties.Settings.Default.LoggedIn == 1)
                {
                    string currentUsername = Properties.Settings.Default.Username;
                    lblMode.Text = "Logged in as " + currentUsername;
                }
                else
                {
                    lblMode.Text = "Mode: Logged out";
                }
            }
        }

        private void ApplyDecoratedRainforestTheme()
        {
            // 1.This is the color fr

            this.BackColor = Color.FromArgb(20, 40, 25);

            // 2. Attach the custom background painter 
            this.Paint -= HomePage_CustomPaint; // This prevents painting twice if called again!!!
            this.Paint += HomePage_CustomPaint;
            this.Resize += (s, e) => this.Invalidate(); // This tells the form to redraw if resized!!!

            // 3. Style for the TYPED out info!!!
            lblTitle.Text = "KOMODO HUB";
            lblTitle.ForeColor = Color.White;
            lblTitle.Font = new Font("Segoe UI Black", 32F, FontStyle.Bold);

            // I made the welcome text transparent so the gradient shows through perfectly!!!
            lblWelcome.BackColor = Color.Transparent;
            lblWelcome.ForeColor = Color.FromArgb(200, 255, 200);
            lblWelcome.Font = new Font("Segoe UI", 16F, FontStyle.Regular);

            lblMode.BackColor = Color.Transparent;
            lblMode.ForeColor = Color.FromArgb(180, 220, 180);
            lblMode.Font = new Font("Segoe UI", 12F, FontStyle.Italic);

            lblTitle.BackColor = Color.Transparent;

            // 4. This is to style Buttons!!!
            StyleButton(btnLibrary, Color.FromArgb(46, 139, 87), Color.White);
            StyleButton(btnLogout, Color.FromArgb(210, 82, 60), Color.White);
            StyleButton(btnSubmit, Color.FromArgb(46, 100, 139), Color.White);
            StyleButton(btnEnrolment, Color.FromArgb(139, 90, 46), Color.White);
        }

        // This method draws the stylish gradient and modern abstract shapes!!!
        private void HomePage_CustomPaint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            Rectangle rect = this.ClientRectangle;
            if (rect.Width == 0 || rect.Height == 0) return;

            // 1. this is to draw a neat diagonal gradient!!!
            Color colorTopLeft = Color.FromArgb(15, 35, 20);    // Very dark green
            Color colorBottomRight = Color.FromArgb(34, 100, 50); // Vibrant forest green

            using (System.Drawing.Drawing2D.LinearGradientBrush brush =
                new System.Drawing.Drawing2D.LinearGradientBrush(rect, colorTopLeft, colorBottomRight, 45F))
            {
                g.FillRectangle(brush, rect);
            }

            // 2. These are modern shapes for more swag!!!
            // The "15" here is the alpha (transparency), making it very soft and glassy for more swagger!!!
            using (SolidBrush overlayBrush = new SolidBrush(Color.FromArgb(15, 255, 255, 255)))
            {
                // Top right decorative circle
                g.FillEllipse(overlayBrush, this.Width - 150, -50, 300, 300);

                // Bottom left decorative circle
                g.FillEllipse(overlayBrush, -100, this.Height - 150, 250, 250);

                // THIS IS A tiny accent bubble
                g.FillEllipse(overlayBrush, this.Width / 2 + 100, this.Height / 2 - 100, 80, 80);
            }
        }

        private void StyleButton(Button btn, Color bgColor, Color textColor)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.BackColor = bgColor;
            btn.ForeColor = textColor;
            btn.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btn.Cursor = Cursors.Hand;

            // this is to make the buttons a bit taller for a modern, clickable feel boy!!!
            btn.Height = 50;

            // This is for the modern rounded "pill" edges boy!!!
            btn.Paint += (sender, e) =>
            {
                System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
                int radius = 20;

                path.AddArc(0, 0, radius, radius, 180, 90);
                path.AddArc(btn.Width - radius, 0, radius, radius, 270, 90);
                path.AddArc(btn.Width - radius, btn.Height - radius, radius, radius, 0, 90);
                path.AddArc(0, btn.Height - radius, radius, radius, 90, 90);
                path.CloseFigure();

                btn.Region = new Region(path);
            };
        }
        private void panelWelcome_Paint(object sender, PaintEventArgs e)
        {
        }

        private void label2_Click(object sender, EventArgs e)
        {
        }

        // The designer wires speciesbutton.Click to this handler.
        private void button1_Click(object sender, EventArgs e)
        {
            var speciesPage = new SpeciesPage();
            speciesPage.Dock = DockStyle.Fill;

            speciesPage.BackHomeRequested += () =>
            {
                this.Controls.Clear();
                InitializeComponent(); // reload homepage UI
            };

            this.Controls.Clear();
            this.Controls.Add(speciesPage);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!RoleHelper.IsLoggedIn())
            {
                MessageBox.Show("Please log in to submit work.");
                return;
            }
            OpenSubmissionRequested?.Invoke();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
        }

        private void btnSighting_Click(object sender, EventArgs e)
        {
            if (!RoleHelper.IsLoggedIn())
            {
                MessageBox.Show("Please log in to view sighting reports.", "Login Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            OpenSightingRequested?.Invoke();
        }

        private void button2_Click_2(object sender, EventArgs e)
        {
            msgSystem msg = new msgSystem();
            msg.Show();
        }

        private void btnLibrary_Click_1(object sender, EventArgs e)
        {

        }

        private void btnEnrolment_Click_1(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Profile pf = new Profile();
            pf.Show();
        }
    }
}