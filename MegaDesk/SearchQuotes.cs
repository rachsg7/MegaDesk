using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MegaDesk_Schutz
{
    public partial class SearchQuotes : Form
    {
        public SearchQuotes()
        {
            InitializeComponent();
        }

        private void searchQuotesBackButton_Click(object sender, EventArgs e)
        {
            MainMenu viewMainMenu = (MainMenu)Tag;
            viewMainMenu.Show();
            this.Close();
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            panel1.Controls.Clear();

            MainMenu.getAllDeskQuotes();
            int count = 0;
            foreach (DeskQuote quote in MainMenu.deskQuotes)
            {
                if (quote.customerDesk.material.ToString() == comboBox1.SelectedItem.ToString())
                {
                    // Create panel
                    Panel quotePanel = new Panel();
                    quotePanel.Location = new Point(0, (0 + (434 * count)));
                    quotePanel.Size = new Size(400, 414);
                    quotePanel.BackColor = Color.WhiteSmoke;


                    /*if ( MainMenu.deskQuotes.Count < 1 && quote.customerDesk.material.ToString() == comboBox1.SelectedItem.ToString())
                    {
                        quotePanel.Size = new Size(426, 414);
                    }*/

                    // User Name Label
                    Label userNameLabel = new Label();
                    userNameLabel.Text = "Name: " + quote.customerName;
                    userNameLabel.Location = new Point(60, 40);
                    userNameLabel.Size = new Size(280, 34);
                    userNameLabel.BackColor = Color.Gainsboro;
                    userNameLabel.TextAlign = ContentAlignment.MiddleLeft;
                    userNameLabel.Font = new Font("Segoe UI", 12);

                    // Date Label
                    Label dateLabel = new Label();
                    dateLabel.Text = "Date: " + quote.quoteDate;
                    dateLabel.Location = new Point(60, 84);
                    dateLabel.Size = new Size(280, 34);
                    dateLabel.BackColor = Color.Gainsboro;
                    dateLabel.TextAlign = ContentAlignment.MiddleLeft;
                    dateLabel.Font = new Font("Segoe UI", 12);

                    // Specs Label
                    Label specsLabel = new Label();
                    specsLabel.Text = "Specifications \n Width: " + quote.customerDesk.width + "\n Depth: " + quote.customerDesk.depth +
                                      "\n Drawers: " + quote.customerDesk.drawers + "\n Material: " + quote.customerDesk.material;
                    specsLabel.Location = new Point(60, 128);
                    specsLabel.Size = new Size(280, 180);
                    specsLabel.BackColor = Color.Gainsboro;
                    specsLabel.TextAlign = ContentAlignment.MiddleLeft;
                    specsLabel.Font = new Font("Segoe UI", 12);

                    // Overall Price Label
                    Label overallPriceLabel = new Label();
                    overallPriceLabel.Text = "Total Quote Price: $" + quote.totalCost;
                    overallPriceLabel.Location = new Point(60, 340);
                    overallPriceLabel.Size = new Size(280, 34);
                    overallPriceLabel.BackColor = Color.Gainsboro;
                    overallPriceLabel.TextAlign = ContentAlignment.MiddleLeft;
                    overallPriceLabel.Font = new Font("Segoe UI", 12);


                    //add each panel to the parent panel
                    quotePanel.Controls.Add(userNameLabel);
                    quotePanel.Controls.Add(dateLabel);
                    quotePanel.Controls.Add(specsLabel);
                    quotePanel.Controls.Add(overallPriceLabel);

                    panel1.Controls.Add(quotePanel);
                    count++;
                }
                
            }

            //if no quoetes matched the material selected
            if (count == 0)
            {
                // Create panel
                Panel quotePanel = new Panel();
                quotePanel.Size = new Size(426, 414);
                quotePanel.BackColor = Color.WhiteSmoke;
                panel1.Controls.Add(quotePanel);

                // User Name Label
                Label noQuotes = new Label();
                noQuotes.Text = "No Quotes were found with this material.";
                noQuotes.Location = new Point(50, 40);
                noQuotes.Size = new Size(300, 100);
                noQuotes.BackColor = Color.Gainsboro;
                noQuotes.TextAlign = ContentAlignment.MiddleCenter;
                noQuotes.Font = new Font("Segoe UI", 12);

                quotePanel.Controls.Add(noQuotes);

                panel1.Controls.Add(quotePanel);
            }
        }

        private void SearchQuotes_Load(object sender, EventArgs e)
        {
            List<DesktopMaterial> materialsList = Enum.GetValues(typeof(DesktopMaterial)).Cast<DesktopMaterial>().ToList();

            comboBox1.DataSource = materialsList;
            comboBox1.Text = "Select Material";
        }
    }
}
