using System.Globalization;

namespace Files // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] listProdutos = new string[4];

            listProdutos[0] = "TV LED,1290.99,1";
            listProdutos[1] = "Video Game Chair,350.50,3";
            listProdutos[2] = "Iphone X,900.00,2";
            listProdutos[3] = "Samsung Galaxy 9,850.00,2";



            string path = @"C:\cursoWeb\projetos\Files\Files\dados.csv";

            try
            {


                using (FileStream sr = File.Create(path)) { }

                using (StreamWriter sw = File.AppendText(path))
                {
                    foreach (string s in listProdutos)
                    {
                        sw.WriteLine(s);
                    }

                }

                string[] lines = File.ReadAllLines(path);

                string sourceFolder = Path.GetDirectoryName(path);


                var newDirectory = Directory.CreateDirectory(sourceFolder + @"\out");



                using (StreamWriter sw2 = File.AppendText(sourceFolder + @"\summary.csv"))
                {

                    foreach (string s in lines)
                    {
                        string[] produtos = s.Split(',');
                        string name = produtos[0];
                        double valor = double.Parse(produtos[1], CultureInfo.InvariantCulture);
                        double qtd = double.Parse(produtos[2]);
                        double total = valor * qtd;
                        sw2.WriteLine(name + " , " + total.ToString("F2", CultureInfo.InvariantCulture));
                    }
                }















            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}