using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
                    quotePanel.Location = new System.Drawing.Point(0, (0 + (335 * count)));
                    quotePanel.Size = new System.Drawing.Size(519, 321);
                    quotePanel.BackColor = Color.WhiteSmoke;

                    // User Name Label
                    Label userNameLabel = new Label();
                    userNameLabel.Text = "Name: " + quote.customerName;
                    userNameLabel.Location = new Point(133, 12);
                    userNameLabel.Size = new Size(280, 23);
                    userNameLabel.BackColor = Color.Gainsboro;
                    userNameLabel.TextAlign = ContentAlignment.MiddleLeft;

                    // Date Label
                    Label dateLabel = new Label();
                    dateLabel.Text = "Date: " + quote.quoteDate;
                    dateLabel.Location = new Point(133, 80);
                    dateLabel.Size = new Size(280, 23);
                    dateLabel.BackColor = Color.Gainsboro;
                    dateLabel.TextAlign = ContentAlignment.MiddleLeft;

                    // Specs Label
                    Label specsLabel = new Label();
                    specsLabel.Text = "Specifications \n Width: " + quote.customerDesk.width + "\n Depth: " + quote.customerDesk.depth +
                                      "\n Drawers: " + quote.customerDesk.drawers + "\n Material: " + quote.customerDesk.material;
                    specsLabel.Location = new Point(133, 150);
                    specsLabel.Size = new Size(280, 150);
                    specsLabel.BackColor = Color.Gainsboro;
                    specsLabel.TextAlign = ContentAlignment.MiddleLeft;

                    // Overall Price Label
                    Label overallPriceLabel = new Label();
                    overallPriceLabel.Text = "Total Quote Price: $" + quote.totalCost;
                    overallPriceLabel.Location = new Point(133, 300);
                    overallPriceLabel.Size = new Size(280, 23);
                    overallPriceLabel.BackColor = Color.Gainsboro;
                    overallPriceLabel.TextAlign = ContentAlignment.MiddleLeft;

                    quotePanel.Controls.Add(userNameLabel);
                    quotePanel.Controls.Add(dateLabel);
                    quotePanel.Controls.Add(specsLabel);
                    quotePanel.Controls.Add(overallPriceLabel);

                    panel1.Controls.Add(quotePanel);
                    count++;
                }
                
            }
        }
    }
}
