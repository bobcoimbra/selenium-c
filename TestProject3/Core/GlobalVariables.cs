using OpenQA.Selenium;

namespace TestProject3.Core
{
    public class GlobalVariables
    {
        // Define 'driver' como trigger para os webelements
        public IWebDriver driver;

        // Define 'fechar navegador após teste' como padrão
        public bool driverQuit = false;

        // Habilita | Desabilita modo headless
        public bool headlessTest = false;
    }
}
