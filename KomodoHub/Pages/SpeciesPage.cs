using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace KomodoHub.Pages
{
    public partial class SpeciesPage : UserControl
    {
        public event Action? BackHomeRequested;

        private List<SpeciesData> allSpecies;

        public SpeciesPage()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            this.Paint += CustomPaint;

            LoadSpeciesData();

            txtSearch.TextChanged += (s, e) => FilterSpecies();
            btnBackHome.Click += (s, e) => BackHomeRequested?.Invoke();

            PopulateCards(allSpecies);
        }

        private void LoadSpeciesData()
        {
            allSpecies = new List<SpeciesData>
            {
                new("Sumatran Tiger", "Panthera tigris sumatrae", 80, "Declining", "Critical", "Sumatra", "The smallest surviving tiger subspecies, found only in Sumatra.", "Habitat loss, poaching, human-wildlife conflict"),
                new("Sumatran Elephant", "Elephas maximus sumatranus", 2400, "Declining", "Endangered", "Sumatra", "A subspecies of the Asian elephant native to Sumatra.", "Habitat loss, human-elephant conflict, poaching"),
                new("Javan Rhinoceros", "Rhinoceros sondaicus", 72, "Stable", "Critical", "Java (Ujung Kulon)", "One of the rarest large mammals, found only in Ujung Kulon.", "Habitat loss, natural disasters, disease, small population"),
                new("Banteng", "Bos javanicus", 8000, "Declining", "Endangered", "Java/Bali", "A species of wild cattle found in Southeast Asian forests.", "Habitat loss, hunting, hybridization with domestic cattle"),
                new("Javan Gibbon", "Hylobates moloch", 4000, "Declining", "Endangered", "West Java", "An agile primate endemic to the western part of Java.", "Habitat loss, illegal pet trade"),
                new("Orangutan", "Pongo spp.", 14000, "Declining", "Critical", "Sumatra/Borneo", "Great apes sharing 97% DNA with humans.", "Habitat loss, palm oil plantations, illegal trade"),
                new("Bekantan", "Nasalis larvatus", 7000, "Declining", "Endangered", "Borneo", "The proboscis monkey, known for its large nose, endemic to Borneo.", "Habitat loss, hunting"),
                new("Komodo Dragon", "Varanus komodoensis", 3000, "Stable", "Vulnerable", "Komodo/Lesser Sunda", "The world's largest living lizard.", "Climate change, habitat loss, prey decline"),
                new("Bali Myna", "Leucopsar rothschildi", 50, "Increasing", "Critical", "Bali", "A strikingly white bird, one of the rarest birds in the world.", "Illegal trapping, habitat loss"),
                new("Maleo", "Macrocephalon maleo", 5000, "Declining", "Endangered", "Sulawesi", "A megapode bird that buries its eggs in warm sand.", "Egg harvesting, habitat destruction"),
                new("Babirusa", "Babyrousa spp.", 5000, "Declining", "Vulnerable", "Sulawesi", "The pig-deer with remarkable upward-curving tusks.", "Hunting, habitat loss"),
                new("Anoa", "Bubalus depressicornis", 2500, "Declining", "Endangered", "Sulawesi", "The smallest buffalo species in the world.", "Hunting, habitat loss, disease"),
                new("Javan Eagle", "Nisaetus bartelsi", 60, "Declining", "Critical", "Java", "Indonesia's national bird, a powerful raptor.", "Habitat loss, illegal capture"),
                new("Tarsius", "Tarsius tarsier", 90, "Declining", "Critical", "Sulawesi", "Tiny primates with enormous eyes.", "Habitat loss, pet trade"),
                new("Celebes Crested Macaque", "Macaca nigra", 95, "Declining", "Critical", "North Sulawesi", "A distinctive black macaque with a mohawk-like crest.", "Hunting, habitat loss, crop raiding conflict")
            };
        }

        private void FilterSpecies()
        {
            string query = txtSearch.Text.ToLower();

            var filtered = allSpecies.FindAll(s =>
                s.Name.ToLower().Contains(query) ||
                s.Region.ToLower().Contains(query) ||
                s.ScientificName.ToLower().Contains(query));

            PopulateCards(filtered);
        }

        private void PopulateCards(List<SpeciesData> species)
        {
            cardsPanel.Controls.Clear();

            foreach (var sp in species)
            {
                var card = new Panel
                {
                    Size = new Size(240, 100),
                    BackColor = Color.FromArgb(35, 70, 45),
                    Margin = new Padding(5),
                    Cursor = Cursors.Hand
                };

                var lblName = new Label
                {
                    Text = sp.Name,
                    Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                    ForeColor = Color.White,
                    Location = new Point(10, 10),
                    AutoSize = true,
                    BackColor = Color.Transparent
                };

                var lblInfo = new Label
                {
                    Text = $"~{sp.Population:N0}  |  {sp.Status}",
                    Font = new Font("Segoe UI", 9F),
                    ForeColor = sp.Status == "Critical"
                        ? Color.FromArgb(255, 100, 100)
                        : sp.Status == "Endangered"
                            ? Color.FromArgb(255, 200, 100)
                            : Color.FromArgb(100, 200, 255),
                    Location = new Point(10, 35),
                    AutoSize = true,
                    BackColor = Color.Transparent
                };

                var lblRegion = new Label
                {
                    Text = $"{sp.Region}  |  {sp.Trend}",
                    Font = new Font("Segoe UI", 9F),
                    ForeColor = Color.FromArgb(180, 220, 180),
                    Location = new Point(10, 55),
                    AutoSize = true,
                    BackColor = Color.Transparent
                };

                card.Controls.Add(lblName);
                card.Controls.Add(lblInfo);
                card.Controls.Add(lblRegion);

                EventHandler click = (s, e) => ShowSpeciesDetail(sp);
                card.Click += click;
                lblName.Click += click;
                lblInfo.Click += click;
                lblRegion.Click += click;

                card.MouseEnter += (s, e) => card.BackColor = Color.FromArgb(46, 100, 60);
                card.MouseLeave += (s, e) => card.BackColor = Color.FromArgb(35, 70, 45);

                cardsPanel.Controls.Add(card);
            }
        }

        private void ShowSpeciesDetail(SpeciesData sp)
        {
            lblDetailTitle.Text = sp.Name;
            lblDetailStatus.Text = $"{sp.Status}  |  Population: ~{sp.Population:N0}  |  Trend: {sp.Trend}";

            txtDetail.Clear();

            txtDetail.SelectionFont = new Font("Segoe UI", 10F, FontStyle.Italic);
            txtDetail.SelectionColor = Color.FromArgb(180, 220, 180);
            txtDetail.AppendText(sp.ScientificName + "\n\n");

            txtDetail.SelectionFont = new Font("Segoe UI", 11F);
            txtDetail.SelectionColor = Color.White;
            txtDetail.AppendText(sp.Description + "\n\n");

            txtDetail.SelectionFont = new Font("Segoe UI", 10F, FontStyle.Bold);
            txtDetail.SelectionColor = Color.FromArgb(200, 255, 200);
            txtDetail.AppendText("Region: ");

            txtDetail.SelectionFont = new Font("Segoe UI", 10F);
            txtDetail.SelectionColor = Color.White;
            txtDetail.AppendText(sp.Region + "\n\n");

            txtDetail.SelectionFont = new Font("Segoe UI", 10F, FontStyle.Bold);
            txtDetail.SelectionColor = Color.FromArgb(255, 180, 180);
            txtDetail.AppendText("Threats: ");

            txtDetail.SelectionFont = new Font("Segoe UI", 10F);
            txtDetail.SelectionColor = Color.White;
            txtDetail.AppendText(sp.Threats);
        }
        private void txtDetail_TextChanged(object sender, EventArgs e)
        {
        }

        private void CustomPaint(object? sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle rect = this.ClientRectangle;
            if (rect.Width == 0 || rect.Height == 0) return;

            using var brush = new LinearGradientBrush(
                rect,
                Color.FromArgb(15, 35, 20),
                Color.FromArgb(25, 60, 35),
                45F);

            g.FillRectangle(brush, rect);
        }
    }

    public class SpeciesData
    {
        public string Name, ScientificName, Trend, Status, Region, Description, Threats;
        public int Population;

        public SpeciesData(string name, string sci, int pop, string trend, string status, string region, string desc, string threats)
        {
            Name = name;
            ScientificName = sci;
            Population = pop;
            Trend = trend;
            Status = status;
            Region = region;
            Description = desc;
            Threats = threats;
        }
    }
}