namespace formRipe
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void Pulisci(TabPage tc, GroupBox gb)
        {
            foreach (var item in tc.Controls)
            {
                if (item is TextBox)
                {
                    ((TextBox)item).Clear();
                }
                if(item is ComboBox)
                {
                    ((ComboBox)item).Text = "";
                }
            }
            foreach (var item in gb.Controls)
            {
                if (item is TextBox)
                {
                    ((TextBox)item).Clear();
                }
            }
        }

        public struct Mutuo
        {
            public int codice;
            public string nome;
            public string provincia;
            public decimal importo;
            public int giorni;
            public string[] intestatari;
        }
        public Mutuo[] elemutui = new Mutuo[100];
        public int num = 0;



        public void visualizza(Mutuo[] ele, int n)
        {
            lbMutui.Items.Clear();
            for(int i = 0; i < n; i++)
            {
                lbMutui.Items.Add($"codice:{ele[i].codice} nome:{ele[i].nome} provincia: {ele[i].provincia} importo:{ele[i].importo} durata: {ele[i].giorni} intestatari:{string.Join(',', ele[i].intestatari)}");

            }
            return;
        }
        private void btnInserisci_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCodice.Text) || string.IsNullOrWhiteSpace(txtNomeBanca.Text) || string.IsNullOrWhiteSpace(comboBox1.Text) || string.IsNullOrWhiteSpace(txtImporto.Text) || string.IsNullOrWhiteSpace(txtDurata.Text) || string.IsNullOrWhiteSpace(txtIntestatario1.Text))
            {
                MessageBox.Show("inserisci tutti i dati");
                return;
            }

            Mutuo nuovoMutuo = default(Mutuo);

            if (!int.TryParse(txtCodice.Text, out nuovoMutuo.codice))
            {
                MessageBox.Show("il codice deve essere un intero");
                return;
            }
            if (!decimal.TryParse(txtImporto.Text, out nuovoMutuo.importo))
            {
                MessageBox.Show("l'im,potyo deve essere un dewciael");
                return;
            }
            if (!int.TryParse(txtDurata.Text, out nuovoMutuo.giorni))
            {
                MessageBox.Show("l'im,potyo deve essere un dewciael");
                return;
            }

            if (int.Parse(txtCodice.Text) < 0)
            {
                MessageBox.Show("codice maggiore di 0");
                return;
            }
            if (decimal.Parse(txtImporto.Text) <= 0)
            {
                MessageBox.Show("importo maggiore di 0");
                return;

            }
            if (int.Parse(txtDurata.Text) <= 0)
            {
                MessageBox.Show("giorni maggiore di 0");
                return;

            }

            if (num > 100)
            {
                MessageBox.Show("Array pieno");
                return;
            }

            for (int i = 0; i < num; i++) 
            {
                if (int.Parse(txtCodice.Text) == elemutui[i].codice)
                {
                    MessageBox.Show("codice esistente");
                    return;
                }
            }

            

            nuovoMutuo.codice = int.Parse(txtCodice.Text);
            nuovoMutuo.nome = txtNomeBanca.Text;
            nuovoMutuo.provincia = comboBox1.Text;
            nuovoMutuo.importo = decimal.Parse(txtImporto.Text);
            nuovoMutuo.giorni = int.Parse(txtDurata.Text);
            nuovoMutuo.intestatari = new string[3]
            {
                txtIntestatario1.Text,
                txtIntestatario2.Text,
                txtIntestatario3.Text
            };

            elemutui[num] = nuovoMutuo;
            num = num + 1;

            visualizza(elemutui, num);
            MessageBox.Show("dato inserito");

            Pulisci(tab_Inserimento, groupBox3);
        }

        private void btnOrdinaDurata_Click(object sender, EventArgs e)
        {
            for(int i=0;i<num; i++)
            {
                for(int j=i+1;j<num; j++)
                {

                    if (elemutui[j].giorni < elemutui[i].giorni) 
                    {
                        Mutuo temp = elemutui[i];
                        elemutui[i] = elemutui[j];
                        elemutui[j] = temp;
                    }
                }
            }
            visualizza(elemutui, num);
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnEliminaCodice_Click(object sender, EventArgs e)
        {
            int count = 0;
            for (int i = 0; i < num; i++)
            {
                if (int.Parse(txtEliminaCodice.Text) == elemutui[i].codice)
                {
                    elemutui[i] = elemutui[num - 1];
                    num=num-1;
                   count=count+1;
                }
            }
            MessageBox.Show($"sono stati eliminati {count} record");
            visualizza(elemutui, num);
            txtEliminaCodice.Clear();
        }

        public int modIndex = -1;

        private void btnCerca_Click(object sender, EventArgs e)
        {
            for(int i=0;i <num; i++)
            {
                if(int.Parse(txtCercaCodice.Text) == elemutui[i].codice)
                {
                    txtCodice_Mod.Text = elemutui[i].codice.ToString();
                    txtNomeBanca_Mod.Text = elemutui[i].nome;
                    cbProvinciaBanca_Mod.Text = elemutui[i].provincia;
                    txtImporto_Mod.Text = elemutui[i].importo.ToString();
                    txtDurata_Mod.Text = elemutui[i].giorni.ToString();
                    txtIntestatario1_Mod.Text = elemutui[i].intestatari[0];
                    txtIntestatario2_Mod.Text = elemutui[i].intestatari[1];
                    txtIntestatario3_Mod.Text = elemutui[i].intestatari[2];

                    modIndex = i;
                    btnModifica.Enabled = true;
                    txtCercaCodice.Clear();
                    return;
                }
            }
            MessageBox.Show("Nessun Mutuo trovato");
            return;
        }
        private void btnModifica_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNomeBanca_Mod.Text) || string.IsNullOrWhiteSpace(cbProvinciaBanca_Mod.Text) || string.IsNullOrWhiteSpace(txtImporto_Mod.Text) || string.IsNullOrWhiteSpace(txtDurata_Mod.Text) || string.IsNullOrWhiteSpace(txtIntestatario1_Mod.Text))
            {
                MessageBox.Show("inserisci tutti i dati");
                return;
            }

            Mutuo nuovoMutuo = default(Mutuo);
            if (!decimal.TryParse(txtImporto_Mod.Text, out nuovoMutuo.importo))
            {
                MessageBox.Show("l'im,potyo deve essere un dewciael");
                return;
            }
            if (!int.TryParse(txtDurata_Mod.Text, out nuovoMutuo.giorni))
            {
                MessageBox.Show("l'im,potyo deve essere un dewciael");
                return;
            }

            if (decimal.Parse(txtImporto_Mod.Text) <= 0)
            {
                MessageBox.Show("importo maggiore di 0");
                return;

            }
            if (int.Parse(txtDurata_Mod.Text) <= 0)
            {
                MessageBox.Show("giorni maggiore di 0");
                return;

            }

            nuovoMutuo.codice = int.Parse(txtCodice_Mod.Text);
            nuovoMutuo.nome = txtNomeBanca_Mod.Text;
            nuovoMutuo.provincia = cbProvinciaBanca_Mod.Text;
            nuovoMutuo.importo = decimal.Parse(txtImporto_Mod.Text);
            nuovoMutuo.giorni = int.Parse(txtDurata_Mod.Text);
            nuovoMutuo.intestatari = new string[3]
            {
                txtIntestatario1_Mod.Text,
                txtIntestatario2_Mod.Text,
                txtIntestatario3_Mod.Text
            };

            elemutui[modIndex] = nuovoMutuo;

            visualizza(elemutui, num);
            MessageBox.Show("dato modificato");

            modIndex = -1;

            btnModifica.Enabled = false;

            Pulisci(tabModifica, groupBox4);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            visualizza(elemutui, num);
        }
    }
}
