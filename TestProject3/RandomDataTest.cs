using System;
using NUnit.Framework;
using TestProject3.Core;

namespace TestProject3
{
    public class RandomDataTest : Begin
    {
        [Test]
        public void RandomData()
        {
            string nome = GeraNomeAleatorio();
            Console.WriteLine(nome);

            string email = GeraEmailAleatorio();
            Console.WriteLine(email);

            string data = GeraDataNascimento();
            Console.WriteLine(data);

            string celular = GeraCelular();
            Console.WriteLine(celular);
        }
    }
}
