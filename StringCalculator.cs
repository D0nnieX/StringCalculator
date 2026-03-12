using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Text.RegularExpressions;

namespace StringCalculator
{
    public class StringCalculator
    {
        public int Add(string numbers)
        {
            // STEP 1
            // Se la stringa è vuota o null, ritorniamo 0
            // Questo gestisce il primo caso richiesto dall'esercizio
            if (string.IsNullOrEmpty(numbers))
                return 0;

            // Delimitatore di default: la virgola
            // Verrà usato per separare i numeri se non è specificato un delimitatore custom
            string[] delimiters = { "," };

            // STEP 5-6-7
            // Verifichiamo se la stringa inizia con "//"
            // Questo indica che l'utente ha definito uno o più delimitatori personalizzati
            if (numbers.StartsWith("//"))
            {
                // Troviamo la posizione in cui termina l'header dei delimitatori
                // Il formato è: //[delimiter]//numeri
                int headerEnd = numbers.IndexOf("//", 2);

                // Estraiamo la parte che contiene i delimitatori
                // Esempio: [*][%]
                string header = numbers.Substring(2, headerEnd - 2);

                // Utilizziamo una Regex per trovare tutti i delimitatori
                // Il pattern \[(.*?)\] trova tutto ciò che è tra parentesi quadre
                var matches = Regex.Matches(header, @"\[(.*?)\]");

                // Convertiamo i risultati della Regex in un array di stringhe
                // Ogni elemento sarà un delimitatore
                delimiters = matches
                    .Cast<Match>()
                    .Select(m => m.Groups[1].Value)
                    .ToArray();

                // Rimuoviamo l'header dalla stringa per lasciare solo i numeri
                numbers = numbers.Substring(headerEnd + 2);
            }

            // STEP 2
            // Separiamo i numeri utilizzando i delimitatori trovati
            var split = numbers.Split(delimiters, StringSplitOptions.None);

            int sum = 0;

            // Lista utilizzata per raccogliere eventuali numeri negativi
            // Servirà per lanciare un'eccezione come richiesto dallo STEP 3
            List<int> negatives = new List<int>();

            foreach (var n in split)
            {
                // Convertiamo ogni valore da stringa a intero
                int num = int.Parse(n);

                // STEP 3
                // Se il numero è negativo lo aggiungiamo alla lista
                if (num < 0)
                    negatives.Add(num);

                // STEP 4
                // I numeri maggiori di 1000 devono essere ignorati
                if (num <= 1000)
                    sum += num;
            }

            // Se abbiamo trovato numeri negativi lanciamo un'eccezione
            // includendo tutti i valori negativi nel messaggio
            if (negatives.Any())
                throw new Exception("negatives not allowed: " + string.Join(",", negatives));

            // Restituiamo la somma finale
            return sum;
        }
    }
}