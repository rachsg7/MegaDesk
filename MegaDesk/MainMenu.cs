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
using System.Text.Json;
//using System.Text.Json.Serialization;



namespace MegaDesk_Schutz
{
    public partial class MainMenu : Form
    {
        public static List<DeskQuote> deskQuotes = new List<DeskQuote>();
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
        public static void addQuoteToList(DeskQuote quote)
        {

            deskQuotes.Add(quote);

            saveToJsonFile();
        }

        public static void saveToJsonFile()
        {
            if (File.Exists(JsonQuotesFile))
            {
               
               // string json = JsonSerializer.Serialize(deskQuotes);
               // File.AppendAllText(JsonQuotesFile, json);
               var jsonData = JsonConvert.SerializeObject(deskQuotes, Formatting.Indented);

               File.AppendAllText(@"Data\quotes.json", jsonData);
            }
            else
            {
                MessageBox.Show("Error: Could not find JSON file.");
            }
        }
    }
}
