using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using System.Xml.Linq;

class Program
{
    static void Main()
    {
        Console.WriteLine("Questão 1: " + Questao1());
        Console.WriteLine("Questão 2: " + Questao2(21)); // Altere o número para testar
        Questao3();
        Questao4();
        Console.WriteLine("Questão 5: " + Questao5("Hello World"));
    }

    static int Questao1()
    {
        int INDICE = 13, SOMA = 0, K = 0;
        while (K < INDICE)
        {
            K = K + 1;
            SOMA = SOMA + K;
        }
        return SOMA;
    }

    static string Questao2(int numero)
    {
        List<int> fibonacci = new List<int> { 0, 1 };
        while (fibonacci.Last() < numero)
            fibonacci.Add(fibonacci[fibonacci.Count - 1] + fibonacci[fibonacci.Count - 2]);
        return fibonacci.Contains(numero) ? "O número pertence à sequência." : "O número não pertence à sequência.";
    }

    static void Questao3()
    {
        string jsonFile = "dados.json"; // Substituir pelo caminho correto
        string jsonString = File.ReadAllText(jsonFile);
        var dados = JsonConvert.DeserializeObject<List<Dado>>(jsonString);

        var valores = dados.Where(d => d.valor > 0).Select(d => d.valor).ToList();
        double media = valores.Average();
        int diasAcimaMedia = valores.Count(v => v > media);

        Console.WriteLine($"Menor faturamento: {valores.Min():F2}");
        Console.WriteLine($"Maior faturamento: {valores.Max():F2}");
        Console.WriteLine($"Dias com faturamento acima da média: {diasAcimaMedia}");
    }

    static void Questao4()
    {
        Dictionary<string, double> faturamento = new Dictionary<string, double>
        {
            {"SP", 67836.43},
            {"RJ", 36678.66},
            {"MG", 29229.88},
            {"ES", 27165.48},
            {"Outros", 19849.53}
        };

        double total = faturamento.Values.Sum();
        foreach (var estado in faturamento)
            Console.WriteLine($"{estado.Key}: {(estado.Value / total) * 100:F2}%");
    }

    static string Questao5(string input)
    {
        char[] reversed = new char[input.Length];
        for (int i = 0; i < input.Length; i++)
            reversed[i] = input[input.Length - 1 - i];
        return new string(reversed);
    }
}

class Dado
{
    public int dia { get; set; }
    public double valor { get; set; }
}
