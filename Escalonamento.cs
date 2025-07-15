public class Escalonamento
{
    public Operacao[] operaoes;
    private int _momento;
    public string[] Passos;
    public int Id;

    public Escalonamento(int id, string passos)
    {
        Passos = passos.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        Id = id;
        _momento = 0;
        foreach (var step in Passos)
        {
            Console.WriteLine(step);
        }
    }
    public override string ToString() =>
    $"Escalonamento: Id={Id}, Passos={string.Join(" ", Passos)}, Momento={_momento}";

}