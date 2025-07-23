public class FileOps
{
        public static String[] ReadIn(string inPath)
        {
                return File.ReadAllLines(inPath);
        }
        public static void WriteObjeto(string path, int Id, string func, int momento)
        {
                string conteudo = $"E_{Id}, {func}, momento = {momento}";
                using (StreamWriter writer = new StreamWriter(path, append: true))
                {
                        writer.WriteLine(conteudo);
                }
        }
        public static void CleanData()
        {
                if (File.Exists("/media/out.txt"))
                {
                        File.Delete("/media/out.txt");
                }
                if (Directory.Exists("dados") == true)
                {
                        Directory.Delete("dados", true);
                }
                Directory.CreateDirectory("dados");
        }
}