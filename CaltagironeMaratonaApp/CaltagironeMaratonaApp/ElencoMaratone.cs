using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CaltagironeMaratonaApp
{
    class ElencoMaratone
    {
        public List<Maratona> Elenco { get; set; }

        public ElencoMaratone()
        {
            Elenco = new List<Maratona>();
        }

        public void Aggiungi(Maratona unaMaratona)
        {
            Elenco.Add(unaMaratona);
        }

        public int TrasformaTempo(string oreMinuti)
        {
            int ore = int.Parse(oreMinuti.Substring(0, 2));

            int minuti = int.Parse(oreMinuti.Substring(3, 2));

            return ore * 60 + minuti;
        }

        public void LeggiDaFile()
        {
            using (FileStream flussoDati = new FileStream("maratona.txt", FileMode.Open, FileAccess.Read))

            {

                using (StreamReader ReaderDati = new StreamReader(flussoDati))

                {

                    while (!ReaderDati.EndOfStream)

                    {

                        string riga = ReaderDati.ReadLine();

                        string[] campi = riga.Split('%');



                        Maratona unaMaratona = new Maratona();

                        unaMaratona.Nome = campi[0];

                        unaMaratona.Societa = campi[1];

                        unaMaratona.TempoInMinuti = TrasformaTempo(campi[2]);

                        unaMaratona.Citta = campi[3];

                        Aggiungi(unaMaratona);

                    }
                }
            }
        }
        public string CercaAtleta(string Atleta, string Citta)
        {
            string tempo="";
            foreach (var Maratona in Elenco)
            {
                if (Maratona.Nome == Atleta && Maratona.Citta == Citta)
                {
                    tempo = Maratona.TempoInMinuti.ToString();
                }
            }
            return tempo;
        }
        public string AtletiPerCitta(string Citta)
        {
            string atleti = "";
            foreach (var Maratona in Elenco)
            {
                if (Maratona.Citta == Citta)
                {
                    atleti = Maratona.Nome;
                }
            }
            return atleti;
        }
        public void ScriviDaFile()
        {
            using (FileStream flussoDati = new FileStream("maratona.txt", FileMode.CreateNew, FileAccess.Write))
            {
                StreamWriter scrittore = new StreamWriter(flussoDati);
                foreach (var Maratona in Elenco)
                {
                    scrittore.WriteLine(Elenco.ConcatenaValori());
                }
                scrittore.Flush();
            }
        }
    }
}
