
using System;

namespace Adapter.Domain
{
    public interface IBoleto
    {
        void ImprimirBoleto();
    }

    public class Boleto
    {
        private readonly IBoleto boleto;

        public Boleto(IBoleto boleto)
        {
            this.boleto = boleto;
        }

        public void ImprimirBoleto() => boleto.ImprimirBoleto();
    }

    public class MeuAdapter : BoletoPDF, IBoleto
    {
        public void ImprimirBoleto() => SalvarBoletoPDF();
    }

    public class BoletoPDF
    {
        public void SalvarBoletoPDF() => Console.WriteLine("Boleto salvo em PDF");
    }

    public class Adapter
    {
        public static void Execucao()
        {
            var adapter = new Boleto(new MeuAdapter());
            adapter.ImprimirBoleto();
        }
    }
}
