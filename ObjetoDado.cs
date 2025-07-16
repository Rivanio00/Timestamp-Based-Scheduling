public class ObjetoDado
{
    private string _filepath; // nome/caminho do txt
    public string Name { get; set; }
    public int TSRead { get; set; }
    public int TSWrite { get; set; }

    public ObjetoDado(string dado)
    {
        _filepath = $"dados/{dado}.txt";
        TSRead = 0;
        TSWrite = 0;
        Name = dado;
    }

    public void Reset() //Usado quando um escalonamento termina e vamos iniciar agora
    {
        TSRead = 0;
        TSWrite = 0;
    }

    public override string ToString() => $"Objeto: {_filepath}";
}