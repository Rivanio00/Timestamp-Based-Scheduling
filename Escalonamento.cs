public class Escalonamento
{
    public List<Operacao> Operacoes;
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

}