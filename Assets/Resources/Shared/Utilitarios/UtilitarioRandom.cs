using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public static class UtilitarioRandom
{
    internal static Random Rand = new Random();

    public static int GetRandom(int valorInicial, int valorFinal)
    {
        return Rand.Next(valorInicial, valorFinal + 1);
    }

    public static int GetRandomOption(List<int> options)
    {
        var selecionado = GetRandom(0, options.Count - 1);
        return options[selecionado];
    }

    public static string SeletorOpcaoPorPorcentagem(Dictionary<string, float> options)
    {
        float totalProbability = 0f;

        foreach (var option in options)
        {
            totalProbability += option.Value;
        }

        float randomValue = (float)Rand.NextDouble() * totalProbability;
        float sum = 0f;

        foreach (var option in options)
        {
            sum += option.Value;
            if (randomValue <= sum)
            {
                return option.Key;
            }
        }

        // Caso a lista esteja vazia ou as probabilidades sejam inválidas, retornar null
        return null;
    }
}
