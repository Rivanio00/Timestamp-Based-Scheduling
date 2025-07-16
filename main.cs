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
        List<ObjetoDado> objetos = new List<ObjetoDado>();
        objetos = InOps.CreateObjetos(In);

        //Criar as transações
        List<Transacao> transacoes = new List<Transacao>();
        transacoes = InOps.CreateTransacoes(In);

        //Criar os escalonamentos
        List<Escalonamento> escalonamentos = new List<Escalonamento>();
        escalonamentos = InOps.CreateEscalonamentos(In, transacoes, objetos);

        // printar as listas de operações de cada escalonamento
        foreach (var escalonamento in escalonamentos)
        {
            Console.WriteLine($"Escalonamento {escalonamento.Id}:");

            foreach (var operacao in escalonamento.Operacoes)
            {
                string func = operacao.Func.ToString();
                int transacaoId = operacao.Transacao.Id;
                string dadoNome = operacao.Dado?.Name ?? "N/A";

                Console.WriteLine($" - {func} T{transacaoId} {dadoNome}");
            }

            Console.WriteLine(); // linha em branco entre os escalonamentos
        }


        //Rodar os escalonamentos

        //Escrever o out.txt

    }
}