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

    public bool Run(List<ObjetoDado> objetos, int momento, int Id)
    {
        if (Func == Funcao.Commit)
        {
            foreach (var objeto in objetos)
            {
                if (objeto.TSRead == Transacao.Timestamp)
                {
                    objeto.TSRead = 0;
                    FileOps.WriteObjeto(objeto.filepath, Id, "Commit", momento);
                }
                if (objeto.TSWrite == Transacao.Timestamp)
                {
                    objeto.TSWrite = 0;
                    FileOps.WriteObjeto(objeto.filepath, Id, "Commit", momento);
                }
            }
            return true;
        }
        else if (Func == Funcao.Read)
        {
            if (Dado.TSWrite > Transacao.Timestamp)
            {
                return false;
            }
            else
            {
                Dado.TSRead = Transacao.Timestamp;
            }
            FileOps.WriteObjeto(Dado.filepath, Id, "Read", momento);
        }
        else
        {
            if (Transacao.Timestamp < Dado.TSRead || Transacao.Timestamp < Dado.TSWrite)
            {
                return false;
            }
            else
            {
                Dado.TSWrite = Transacao.Timestamp;
            }
            FileOps.WriteObjeto(Dado.filepath, Id, "Write", momento);
        }
        return true;
    }
}