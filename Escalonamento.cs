public class Escalonamento
{
    public List<Operacao> Operacoes { get; set; }
    private int _momento;
    public string[] Passos;
    public int Id;

    public Escalonamento(int id, string passos, List<Transacao> transacoes, List<ObjetoDado> objetos)
    {
        Passos = passos.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        Id = id;
        _momento = 0;
        foreach (var step in Passos)
        {
            Console.WriteLine(step);
        }
        Operacoes = InOps.CreateOperacoes(Passos, transacoes, objetos);
    }
    public override string ToString() =>
    $"Escalonamento: Id={Id}, Passos={string.Join(" ", Passos)}, Momento={_momento}";

    public string TestarEscalonamento(List<ObjetoDado> objetos)
    {
        string Out;

        foreach (var operacao in Operacoes)
        {
            if (operacao.Run(objetos, _momento, Id) == true)
            {
                _momento++;
            }
            else
            {
                Out = "E_" + Id + "-ROLLBACK-" + _momento;
                return Out;
            }
        }

        Out = "E_" + Id + "-OK";
        return Out;
    }

}