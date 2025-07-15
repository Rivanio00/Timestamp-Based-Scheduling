using System;
using System.IO;
using System.Reflection;
using System.Linq;
// VOCÊ DEVE INCLUIR SEUS NAMESPACES AQUI, CASO NECESSÁRIO!!!
class Program
{
    static void Main(string[] args)
    {
        //Ler in.txt
        string inPath = "media/in.txt";
        string[] In = FileOps.ReadIn(inPath);

        //Criar os objetos
        string[] dados = In[0].Split(',', StringSplitOptions.TrimEntries); //ESSE É O VETOR QUE CONTEM AQUELA ESTRUTURA <ID-dado, TS-Read, TS-Write>
        List<ObjetoDado> objetos = new List<ObjetoDado>();
        foreach (var dado in dados)
        {
            ObjetoDado objeto = new ObjetoDado(dado);
            objetos.Add(objeto);
        }

        foreach (var objeto in objetos)
        {
            Console.WriteLine(objeto.ToString());
        }

        //Criar as transações
        int[] timestamps = In[2].Split(',', StringSplitOptions.TrimEntries)
                        .Select(int.Parse)
                        .ToArray();
        List<Transacao> transacoes = new List<Transacao>();
        for (int i = 0; i < timestamps.Length; i++)
        {
            Transacao transacao = new Transacao((i + 1), timestamps[i]);
            transacoes.Add(transacao);
        }

        foreach (var transacao in transacoes)
        {
            Console.WriteLine(transacao.ToString());
        }

        //Criar os escalonamentos
        List<Escalonamento> escalonamentos = new List<Escalonamento>();
        for (int i = 3; i < In.Length; i++)
        {
            string linha = In[i];
            string passos = linha.Substring(linha.IndexOf('-') + 1); // remove o "E_i-"
            Escalonamento escalonamento = new Escalonamento((i - 2), passos);
            escalonamentos.Add(escalonamento);
        }

        foreach (var escalonamento in escalonamentos)
        {
            Console.WriteLine(escalonamento.ToString());
        }

        //Rodar os escalonamentos
        

        //Escrever o out.txt

    }
}