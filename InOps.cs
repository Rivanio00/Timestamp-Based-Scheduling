public class InOps
{
    public static List<ObjetoDado> CreateObjetos(string[] In)
    {
        string[] dados = In[0].Split(',', StringSplitOptions.TrimEntries);
        List<ObjetoDado> objetos = new List<ObjetoDado>(); //ESSE É O VETOR QUE CONTEM AQUELA ESTRUTURA <ID-dado, TS-Read, TS-Write>
        foreach (var dado in dados)
        {
            ObjetoDado objeto = new ObjetoDado(dado);
            objetos.Add(objeto);
        }

        foreach (var objeto in objetos)
        {
            Console.WriteLine(objeto.ToString());
        }
        return objetos;
    }

    public static List<Transacao> CreateTransacoes(string[] In)
    {
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
        return transacoes;
    }

    public static List<Escalonamento> CreateEscalonamentos(string[] In,  List<Transacao> transacoes, List<ObjetoDado> objetos)
    {
        List<Escalonamento> escalonamentos = new List<Escalonamento>();
        for (int i = 3; i < In.Length; i++)
        {
            string linha = In[i];
            string passos = linha.Substring(linha.IndexOf('-') + 1); // remove o "E_i-"
            Escalonamento escalonamento = new Escalonamento((i - 2), passos, transacoes, objetos);
            escalonamentos.Add(escalonamento);
        }

        foreach (var escalonamento in escalonamentos)
        {
            Console.WriteLine(escalonamento.ToString());
        }
        return escalonamentos;
    }

    public static List<Operacao> CreateOperacoes(string[] passos, List<Transacao> transacoes, List<ObjetoDado> objetos)
{
    List<Operacao> operacoes = new List<Operacao>();

    foreach (var passo in passos)
    {
        char funcChar = passo[0];             
        int indexOpen = passo.IndexOf('('); 
        
        // Transação sempre vem depois da função, antes do parêntese
            string idStr = (indexOpen != -1)
            ? passo.Substring(1, indexOpen - 1)
            : passo.Substring(1);

        int transacaoId = int.Parse(idStr);
        Transacao transacao = transacoes.First(t => t.Id == transacaoId);

        // Detectar tipo da operação
        Funcao func = funcChar switch
        {
            'r' => Funcao.Read,
            'w' => Funcao.Write,
            'c' => Funcao.Commit,
            _ => throw new Exception($"Função desconhecida: {funcChar}")
        };

        // Dado (caso não seja commit)
        ObjetoDado? dado = null;
            if (indexOpen != -1)
            {
                int indexClose = passo.IndexOf(')');
                string dadoNome = passo.Substring(indexOpen + 1, indexClose - indexOpen - 1);
                dado = objetos.First(o => o.Name == dadoNome); // Buscar pelo nome base do dado (ajustar se necessário)

            }
            else
            {
                dado = null;
            }
        // Criar a operação
        Operacao operacao = new Operacao(func, transacao, dado);
        operacoes.Add(operacao);
    }

    return operacoes;
}

}