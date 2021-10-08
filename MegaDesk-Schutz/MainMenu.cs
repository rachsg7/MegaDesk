using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;


namespace MegaDesk_Schutz
{
    public partial class MainMenu : Form
    {
        public static List<DisplayQuote> deskQuotes = new List<DisplayQuote>();
        public const string JsonQuotesFile = @"Data\quotes.json";
        public MainMenu()
        {
           InitializeComponent();
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {

        }

        private void addQuoteButton_Click(object sender, EventArgs e)
        {
            AddQuote viewAddQuote = new AddQuote(this);
            viewAddQuote.Tag = this;
            viewAddQuote.Show(this);
            Hide();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void viewQuotesButton_Click(object sender, EventArgs e)
        {
            ViewAllQuotes viewAllQuote = new ViewAllQuotes();
            viewAllQuote.Tag = this;
            viewAllQuote.Show(this);
            Hide();
        }

        private void searchQuotesButton_Click(object sender, EventArgs e)
        {
            SearchQuotes viewSearchQuotes = new SearchQuotes();
            viewSearchQuotes.Tag = this;
            viewSearchQuotes.Show(this);
            Hide();
        }
        public static void addQuoteToList(Deskquote quote)
        {

            MainMenu.deskQuotes.Add(quote);

            saveToJsonFile();
        }

        public static void saveToJsonFile()
        {
            if (File.Exists(MainMenu.JsonQuotesFile))
            {
                var jsonData = JsonConvert.SerializeObject(MainMenu.deskQuotes, Formatting.Indented);

                File.WriteAllText(MainMenu.JsonQuotesFile, jsonData);
            }
            else
            {
                MessageBox.Show("Error: Could not find JSON file.");
            }
        }
    }
}
