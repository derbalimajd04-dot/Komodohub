using KomodoHub.Pages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace KomodoHub
{
    public partial class KomodoHub : Form
    {
        public static string UserRole = "";
        public KomodoHub()
        {
            InitializeComponent();
            panel2.Visible = false;
            panel2.Dock = DockStyle.Left;
            panel2.BringToFront();

            loginForm2.Dock = DockStyle.Fill;
            loginForm2.Location = new Point(0, 0);

            Properties.Settings.Default.LoggedIn = 0;
            Properties.Settings.Default.Save();

            hideAllPages();
            loginForm2.Show();

            loginForm2.LoginStateChanged += (state) =>
            {
                Properties.Settings.Default.LoggedIn = state;
                Properties.Settings.Default.Save();
                doOnce = false;

                panel2.Visible = true;

                hideAllPages();
                homePage1.Show();
            };

            loginForm2.RegisterRequested += () =>
            {
                hideAllPages();
                registerPage1.Show();
            };

            registerPage1.BackToLoginRequested += () =>
            {
                hideAllPages();
                loginForm2.Show();
            };

            registerPage1.RegisterCompleted += () =>
            {
                Properties.Settings.Default.LoggedIn = 1;
                Properties.Settings.Default.Save();
                doOnce = false;

                hideAllPages();
                homePage1.Show();
            };

            homePage1.LogoutRequested += () =>
            {
                Properties.Settings.Default.LoggedIn = 0;
                Properties.Settings.Default.Save();
                doOnce = false;

                panel2.Visible = false;

                hideAllPages();
                loginForm2.Show();
            };
            homePage1.OpenLibraryRequested += () =>
            {
                if (!RoleHelper.IsLoggedIn())
                {
                    MessageBox.Show("Please log in to access your findings.","Login Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                hideAllPages();
                library1.Show();
            };

            library1.BackHomeRequested += () =>
            {
                hideAllPages();
                homePage1.Show();
            };
            library1.PublicActivitiesRequested += () =>
            {
                hideAllPages();
                publicActivites1.Show();
            };
            publicActivites1.BackHomeRequested += () =>
            {
                hideAllPages();
                homePage1.Show();
            };

            publicActivites1.BackToLibraryRequested += () =>
            {
                hideAllPages();
                library1.Show();
            };
            teacherPage1.BackHomeRequested += () =>
            {
                hideAllPages();
                homePage1.Show();
            };
            teacherPage1.OpenFeedbackRequested += () =>
            {
                hideAllPages();
                teacherFeedbackPage1.Show();
            };
            teacherPage1.OpenSubscriptionRequested += () =>
            {
                if (!RoleHelper.IsAdmin())
                {
                    MessageBox.Show("Access denied. Admins only.", "Access Restricted", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                hideAllPages();
                subscriptionPage1.Show();
            };
            subscriptionPage1.BackHomeRequested += () =>
            {
                hideAllPages();
                homePage1.Show();
            };
            submissionPage1.BackHomeRequested += () =>
            {
                hideAllPages();
                homePage1.Show();
            };
            homePage1.OpenSubmissionRequested += () =>
            {
                hideAllPages();
                submissionPage1.Show();
            };
            teacherFeedbackPage1.BackHomeRequested += () =>
            {
                hideAllPages();
                homePage1.Show();
            };
            homePage1.OpenSightingRequested += () =>
            {
                hideAllPages();
                sightingsPage1.Show();
            };
            sightingsPage1.BackHomeRequested += () =>
            {
                hideAllPages();
                homePage1.Show();
            };
            homePage1.OpenEnrolmentRequested += () =>
            {
                hideAllPages();
                enrolmentPage1.Show();
            };

            enrolmentPage1.BackHomeRequested += () =>
            {
                hideAllPages();
                homePage1.Show();
            };
        }

        private void KomodoHub_Load(object sender, EventArgs e)
        {

        }

        private void loginForm1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
        }

        private void loginForm1_Load_1(object sender, EventArgs e)
        {

        }

        private void loginForm2_Load(object sender, EventArgs e)
        {

        }

        private void loginForm2_MouseDown(object sender, MouseEventArgs e)
        {

        }

        bool doOnce = false;
        private void BackgroundChecker_Tick(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.LoggedIn > 0 && doOnce == false)
            {
                panel2.Visible = true;
                homePage1.Show();
                doOnce = true;
            }
        }

        private void hideAllPages()
        {
            library1.Hide();
            loginForm2.Hide();
            homePage1.Hide();
            registerPage1.Hide();
            teacherPage1.Hide();
            teacherFeedbackPage1.Hide();
            publicActivites1.Hide();
            submissionPage1.Hide();
            sightingsPage1.Hide();
            enrolmentPage1.Hide();
            subscriptionPage1.Hide();
        }

        private void LibraryButton_Click(object sender, EventArgs e)
        {
            if (!RoleHelper.IsLoggedIn())
            {
                MessageBox.Show("Please log in to access your findings.",
                                "Login Required",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                return;
            }

            hideAllPages();
            library1.Show();
            library1.BringToFront();
        }

        private void teacherPage1_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (!RoleHelper.IsTeacherOrAdmin())
            {
                MessageBox.Show("Access denied. This area is for teachers and admins only.",
                                "Access Restricted",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }
            hideAllPages();
            teacherPage1.Show();
        }
    }
}
