using System.IO;
using TestProject3.Core;

namespace TestProject3.Page
{
    class ValidaCepPage : Begin
    {
        public void PreencheCep()
        {
            EscreveTexto("//*[@id='endereco']", "22050002", " campo de cep");
        }

        public void ClicaBtnBusca() =>
            ClicaElemento("//*[@id='btn_pesquisar']", "botão de busca");

        public void Validaresultado()
        {
            ValidaDados("//*[@id='resultado-DNEC']/tbody/tr/td[1]", "Avenida Nossa Senhora de Copacabana - de 583 a 831 - lado ímpar", "o endereço");
        }

        public void ValidaresultadoTotal()
        {
            string[] dados =
            {
                "Avenida Nossa Senhora de Copacabana - de 583 a 831 - lado ímpar",
                "Copacabana",
                "Rio de Janeiro/RJ",
                "22050-002"
            };

            for (int i = 0; i < dados.Length; i++)
            {
                ValidaDados("//*[@id='resultado-DNEC']/tbody/tr/td[" + (i + 1) + "]", dados[i]);
                //System.Console.WriteLine(dados[i] + " = Indice " + i);
            }
        }

        public void ValidaMultiplosCeps()
        {
            string[] ceps = File.ReadAllLines(@"C:\Projects\Estudos\Selenium C\Aula YT\TestProject3\TestProject3\DataBase\cep.txt");

            string[] logradouros =
            {
                "Rua Ernani Agricola",
                "Rua Lupércio de Camargo",
                "Avenida Professor Mário Werneck - até 1923/1924",
                "Rua Professor Azevedo Amaral"
            };

            for (int i = 0; i < ceps.Length; i++)
            {
                EscreveTexto("//*[@id='endereco']", ceps[i]);
                ClicaElemento("//*[@id='btn_pesquisar']");
                ValidaDados("//*[@id='resultado-DNEC']/tbody/tr/td[1]", logradouros[i]);
                ClicaElemento("//*[@id='btn_nbusca']", "botão pesquisar e validou CEP " + ceps[i] + " no logradouro " + logradouros[i]);

            }
        }
    }
}
