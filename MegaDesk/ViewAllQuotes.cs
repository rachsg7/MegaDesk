using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MegaDesk_Schutz
{
    public partial class ViewAllQuotes : Form
    {
        public ViewAllQuotes()
        {
            InitializeComponent();
        }

        private void allQuotesBackButton_Click(object sender, EventArgs e)
        {
            MainMenu viewMainMenu = (MainMenu)Tag;
            viewMainMenu.Show();
            this.Close();
        }

        private void ViewAllQuotes_Load(object sender, EventArgs e)
        {
            MainMenu.getAllDeskQuotes();
            int count = 0;
            foreach(DeskQuote quote in MainMenu.deskQuotes)
            {
                // Create panel
                Panel quotePanel = new Panel();
                quotePanel.Location = new System.Drawing.Point(0, (0 + (335 * count)));
                quotePanel.Size = new System.Drawing.Size(519, 321);
                quotePanel.BackColor = Color.WhiteSmoke;

                // Name Label
                Label label1 = new Label();
                label1.Text = "Name:";
                label1.Location = new Point(27, 34);
                label1.Size = new Size(42, 15);

                // User Name Label
                Label userNameLabel = new Label();
                userNameLabel.Text = quote.customerName;
                userNameLabel.Location = new Point(133, 34);
                userNameLabel.Size = new Size(280, 23);
                userNameLabel.BackColor = Color.Gainsboro;
                userNameLabel.TextAlign = ContentAlignment.MiddleLeft;

                // Width Label
                Label widthLabel = new Label();
                widthLabel.Text = "Width:";
                widthLabel.Location = new Point(27, 78);
                widthLabel.Size = new Size(42, 15);

                // User Width Label
                Label userWidthLabel = new Label();
                userWidthLabel.Text = quote.customerDesk.width.ToString(); // How to get width?
                userWidthLabel.Location = new Point(133, 75);
                userWidthLabel.Size = new Size(67, 23);
                userWidthLabel.BackColor = Color.Gainsboro;
                userWidthLabel.TextAlign = ContentAlignment.MiddleLeft;

                // In Label 1
                Label inLabel1 = new Label();
                inLabel1.Text = "in";
                inLabel1.Location = new Point(206, 83);
                inLabel1.Size = new Size(17,15);

                // Depth Label
                Label depthLabel = new Label();
                depthLabel.Text = "Depth:";
                depthLabel.Location = new Point(265, 78);
                depthLabel.Size = new Size(45, 15);

                // User Depth Label
                Label userDepthLabel = new Label();
                userDepthLabel.Text = quote.customerDesk.depth.ToString(); // How to get depth?
                userDepthLabel.Location = new Point(323, 75);
                userDepthLabel.Size = new Size(67, 23);
                userDepthLabel.BackColor = Color.Gainsboro;
                userDepthLabel.TextAlign = ContentAlignment.MiddleLeft;

                // in Label 2
                Label inLabel2 = new Label();
                inLabel2.Text = "in";
                inLabel2.Location = new Point(396, 83);
                inLabel2.Size = new Size(17, 15);

                // Total Area Label
                Label totalAreaLabel = new Label();
                inLabel2.Text = "Total Area:";
                inLabel2.Location = new Point(27, 117);
                inLabel2.Size = new Size(62, 15);

                // User Total Area Label
                Label userTotalAreaLabel = new Label();
                userTotalAreaLabel.Text = quote.area.ToString();
                userTotalAreaLabel.Location = new Point(133, 117);
                userTotalAreaLabel.Size = new Size(100, 23);
                userTotalAreaLabel.BackColor = Color.Gainsboro;
                userTotalAreaLabel.TextAlign = ContentAlignment.MiddleLeft;

                // Area Cost Label
                Label areaCostLabel = new Label();
                areaCostLabel.Text = "Area Cost:";
                areaCostLabel.Location = new Point(246, 117);
                areaCostLabel.Size = new Size(61, 15);

                // User Area Cost Label
                Label userAreaCostLabel = new Label();
                userAreaCostLabel.Text = "$" + quote.areaCost.ToString();
                userAreaCostLabel.Location = new Point(313, 117);
                userAreaCostLabel.Size = new Size(100, 23);
                userAreaCostLabel.BackColor = Color.Gainsboro;
                userAreaCostLabel.TextAlign = ContentAlignment.MiddleLeft;

                // Drawers Label
                Label drawersLabel = new Label();
                drawersLabel.Text = "Drawers:";
                drawersLabel.Location = new Point(27, 156);
                drawersLabel.Size = new Size(52, 15);

                // User Drawers Label
                Label userDrawersLabel = new Label();
                userDrawersLabel.Text = quote.drawers.ToString();
                userDrawersLabel.Location = new Point(133, 156);
                userDrawersLabel.Size = new Size(67, 23);
                userDrawersLabel.BackColor = Color.Gainsboro;
                userDrawersLabel.TextAlign = ContentAlignment.MiddleLeft;

                // Times 50 Label
                Label timesFiftyLabel = new Label();
                timesFiftyLabel.Text = "x         50         =";
                timesFiftyLabel.Location = new Point(207, 156);
                timesFiftyLabel.Size = new Size(90, 15);

                // Total Drawers Label
                Label totalDrawersLabel = new Label();
                totalDrawersLabel.Text = "$" + quote.drawerCost.ToString();
                totalDrawersLabel.Location = new Point(313, 156);
                totalDrawersLabel.Size = new Size(100, 23);
                totalDrawersLabel.BackColor = Color.Gainsboro;
                totalDrawersLabel.TextAlign = ContentAlignment.MiddleLeft;

                // Desktop Material Label
                Label desktopMaterialLabel = new Label();
                desktopMaterialLabel.Text = "Desktop Material:";
                desktopMaterialLabel.Location = new Point(27, 194);
                desktopMaterialLabel.Size = new Size(100, 15);

                // User Desktop Material Label
                Label userDesktopMaterial = new Label();
                userDesktopMaterial.Text = quote.customerDesk.material.ToString(); // Desktop material?
                userDesktopMaterial.Location = new Point(132, 194);
                userDesktopMaterial.Size = new Size(100, 23);
                userDesktopMaterial.BackColor = Color.Gainsboro;
                userDesktopMaterial.TextAlign = ContentAlignment.MiddleLeft;

                // Material Price Label
                Label materialPriceLabel = new Label();
                materialPriceLabel.Text = "$" + quote.materialCost.ToString();
                materialPriceLabel.Location = new Point(313, 194);
                materialPriceLabel.Size = new Size(100, 23);
                materialPriceLabel.BackColor = Color.Gainsboro;
                materialPriceLabel.TextAlign = ContentAlignment.MiddleLeft;

                // Rush Order Label
                Label rushOrderLabel = new Label();
                rushOrderLabel.Text = "Rush Order:";
                rushOrderLabel.Location = new Point(27, 235);
                rushOrderLabel.Size = new Size(69, 15);

                // User Rush Order
                Label userRushOrder = new Label();
                userRushOrder.Text = quote.rushDays.ToString();
                userRushOrder.Location = new Point(133, 230);
                userRushOrder.Size = new Size(100, 23);
                userRushOrder.BackColor = Color.Gainsboro;
                userRushOrder.TextAlign = ContentAlignment.MiddleLeft;

                // Days Label
                Label daysLabel = new Label();
                daysLabel.Text = "Days";
                daysLabel.Location = new Point(239, 238);
                daysLabel.Size = new Size(32, 15);

                // User Rush Order Price
                Label userRushOrderPrice = new Label();
                userRushOrderPrice.Text = "$" + quote.rushOrderCost.ToString();
                userRushOrderPrice.Location = new Point(313, 230);
                userRushOrderPrice.Size = new Size(100, 23);
                userRushOrderPrice.BackColor = Color.Gainsboro;
                userRushOrderPrice.TextAlign = ContentAlignment.MiddleLeft;

                // Total Price Label
                Label totalPriceLabel = new Label();
                totalPriceLabel.Text = "Total Price:";
                totalPriceLabel.Location = new Point(207, 282);
                totalPriceLabel.Size = new Size(62, 15);

                // User Total Price Label
                Label userTotalPriceLabel = new Label();
                userTotalPriceLabel.Text = "$" + quote.totalCost.ToString();
                userTotalPriceLabel.Location = new Point(313, 282);
                userTotalPriceLabel.Size = new Size(100, 23);
                userTotalPriceLabel.BackColor = Color.Gainsboro;
                userTotalPriceLabel.TextAlign = ContentAlignment.MiddleLeft;


                // Add Controls to panel
                quotePanel.Controls.Add(label1);
                quotePanel.Controls.Add(userNameLabel);
                quotePanel.Controls.Add(widthLabel);
                quotePanel.Controls.Add(userWidthLabel);
                quotePanel.Controls.Add(depthLabel);
                quotePanel.Controls.Add(inLabel1);
                quotePanel.Controls.Add(userDepthLabel);
                quotePanel.Controls.Add(inLabel2);
                quotePanel.Controls.Add(totalAreaLabel);
                quotePanel.Controls.Add(userTotalAreaLabel);
                quotePanel.Controls.Add(areaCostLabel);
                quotePanel.Controls.Add(userAreaCostLabel);
                quotePanel.Controls.Add(drawersLabel);
                quotePanel.Controls.Add(userDrawersLabel);
                quotePanel.Controls.Add(timesFiftyLabel);
                quotePanel.Controls.Add(totalDrawersLabel);
                quotePanel.Controls.Add(desktopMaterialLabel);
                quotePanel.Controls.Add(userDesktopMaterial);
                quotePanel.Controls.Add(materialPriceLabel);
                quotePanel.Controls.Add(rushOrderLabel);
                quotePanel.Controls.Add(userRushOrder);
                quotePanel.Controls.Add(daysLabel);
                quotePanel.Controls.Add(userRushOrderPrice);
                quotePanel.Controls.Add(totalPriceLabel);
                quotePanel.Controls.Add(userTotalPriceLabel);
                scrollPanel.Controls.Add(quotePanel);
                count++;
            }
        }
    }
}
