public class FileOps
{
        /*
        write_out_line(id_escalonamento, string resultado <OK/ROLLBACK>, int rollback_moment)
        */
        public static String[] ReadIn(string inPath)
        {
                return File.ReadAllLines(inPath);
        }
        public static void WriteObjeto(string path, int Id, string func, int momento)
        {
                string conteudo = $"E_{Id}\n{func}\nmomento = {momento}";
                File.WriteAllText(path, conteudo);
        }
}