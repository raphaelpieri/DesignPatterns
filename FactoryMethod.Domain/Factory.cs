using System;

namespace FactoryMethod.Domain
{
    public interface IVeiculo
    {
        string Limite(int limite);
    }

    public class Moto : IVeiculo
    {
        public string Limite(int limite) => $"Limite do veiculo MOTO: {limite}";
    }

    public class Carro : IVeiculo
    {
        public string Limite(int limite) => $"Limite do veiculo CARRO: {limite}";
    }

    public class Caminhoneta : IVeiculo
    {
        public string Limite(int limite) => $"Limite do veiculo CAMINHONETA: {limite}";
    }

    public abstract class VeiculoFactory
    {
        public abstract IVeiculo ObterVeiculo(string categoria);
    }

    public class ConcreteVeiculoFactory : VeiculoFactory
    {
        public override IVeiculo ObterVeiculo(string categoria)
        {
            switch (categoria)
            {
                case "Pesado":
                    return new Caminhoneta();
                case "Medio":
                    return new Carro();
                case "Leve":
                    return new Moto();
                default:
                    throw new ApplicationException($"Veiculo {categoria} nã pode ser criado");
            }
        }
    }

}
