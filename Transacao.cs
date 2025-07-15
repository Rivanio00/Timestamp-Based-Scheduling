public class Transacao
{
    public int Timestamp { get; set; }

    public int Id;

    public Transacao(int id, int timestamp)
    {
        Timestamp = timestamp;
        Id = id;
    }

    public override string ToString() => $"Transação: Id={Id}, Timestamp={Timestamp}";
}