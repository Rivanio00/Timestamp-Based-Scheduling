public class FileOps
{
        /*
        write_objeto(id-dado, ident_esc, Function, momento)
        write_out_line(id_escalonamento, string resultado <OK/ROLLBACK>, int rollback_moment)
        */
        public static String[] ReadIn(string inPath)
        {
                return File.ReadAllLines(inPath);
        }
}