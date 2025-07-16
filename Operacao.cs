public enum Funcao
{
    Read,
    Write,
    Commit
}
public class Operacao
{
    public Funcao Func { get; set; }
    public Transacao Transacao { get; set; }
    public ObjetoDado? Dado { get; set; }

    public Operacao(Funcao func, Transacao transacao, ObjetoDado? dado)
    {
        Func = func;
        Transacao = transacao;
        Dado = dado;
    }
}