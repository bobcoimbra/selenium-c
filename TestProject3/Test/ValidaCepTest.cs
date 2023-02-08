using NUnit.Framework;
using TestProject3.Page;

namespace TestProject3.Test
{
    class ValidaCepTest : ValidaCepPage
    {
        [Test]
        public void ValidaCep ()
        {
            PreencheCep();
            ClicaBtnBusca();
            Validaresultado();
        }

        [Test]
        public void ValidaResultadoTotal()
        {
            PreencheCep();
            ClicaBtnBusca();
            ValidaresultadoTotal();
        }

        [Test]
        public void ValidaMultiplosCenarios()
        {
            ValidaMultiplosCeps();
        }
    }
}
