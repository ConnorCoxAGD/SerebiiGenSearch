using System.Diagnostics;
using SerebiiGenSearch;

namespace SerebiiGenSearch
{
    public partial class PokemonSearchByGen : Form
    {
        string baseUrl = "https://www.serebii.net/pokedex";
        string pokemon = "025";
        string suffix = ".shtml";
        string message = "Searching for pokemon #025";

        public Dictionary<string, string> PokeDex = new();

        public PokemonSearchByGen()
        {
            InitializeComponent();
            ParseFileIntoDictionary.CreateDictionaryFromFile(PokeDex, "pokemon.txt", l_debug);

        }

        /// <summary>
        /// Opens a website with the given URL.
        /// </summary>
        /// <param name="url"></param>
        private void OpenSite(string url)
        {
            try
            {
                Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
            }
            catch (System.ComponentModel.Win32Exception noBrowser)
            {
                if (noBrowser.ErrorCode == -2147467259)
                    MessageBox.Show(noBrowser.Message);
            }
            catch (System.Exception other)
            {
                MessageBox.Show(other.Message);
            }
        }

        private void b_gen_1_Click(object sender, EventArgs e)
        {
            OpenSite(baseUrl + "" + "/" + pokemon + suffix);
        }

        private void b_gen_2_Click(object sender, EventArgs e)
        {
            OpenSite(baseUrl + "-gs" + "/" + pokemon + suffix);
        }

        private void b_gen_3_Click(object sender, EventArgs e)
        {
            OpenSite(baseUrl + "-rs" + "/" + pokemon + suffix);
        }

        private void b_gen_4_Click(object sender, EventArgs e)
        {
            OpenSite(baseUrl + "-dp" + "/" + pokemon + suffix);
        }

        private void b_gen_5_Click(object sender, EventArgs e)
        {
            OpenSite(baseUrl + "-bw" + "/" + pokemon + suffix);
        }

        private void b_gen_6_Click(object sender, EventArgs e)
        {
            OpenSite(baseUrl + "-xy" + "/" + pokemon + suffix);
        }

        private void b_gen_7_Click(object sender, EventArgs e)
        {
            OpenSite(baseUrl + "-sm" + "/" + pokemon + suffix);
        }

        private void b_gen_8_Click(object sender, EventArgs e)
        {
            OpenSite(baseUrl + "-swsh" + "/" + pokemon + suffix);
        }

        private void b_gen_9_Click(object sender, EventArgs e) {
            OpenSite(baseUrl + "-sv" + "/" + pokemon + suffix);
        }

        private void t_name_input_TextChanged(object sender, EventArgs e)
        {
            string? value = "";

            PokeDex.TryGetValue(t_name_input.Text.ToLower(), out value);
            
            if (value != null) {
                pokemon = value;
                if (pokemon[0] == '0') {
                    pokemon = pokemon.Remove(0, 1);
                }
                message = "Searching for pokemon #" + pokemon;
                Debug.WriteLine(message);
                l_debug.Text = message;
            }
            else
            {
                pokemon = "025";
                message = t_name_input.Text + " not found in dictionary.";
                Debug.WriteLine(message);
                l_debug.Text = message;
            }
        }
    }
}