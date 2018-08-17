namespace AbstractMethod.Domain
{
    internal abstract class ContinenteFactory 
    {
        public abstract Herbivoro ObterHerbivoro();
        public abstract Carnivoro ObterCarnivoro();
    }

    internal class AfricaFactory : ContinenteFactory
    {
        public override Carnivoro ObterCarnivoro()
        {
            return new Leao();
        }

        public override Herbivoro ObterHerbivoro()
        {
            return new Gazela();
        }
    }

    internal class AmericaFactory : ContinenteFactory
    {
        public override Carnivoro ObterCarnivoro()
        {
            return new Lobo();
        }

        public override Herbivoro ObterHerbivoro()
        {
            return new Coelho();
        }

    }

    internal abstract class Herbivoro
    {
    }

    internal abstract class Carnivoro
    {
        public abstract string Devorar(Herbivoro v);
    }

    internal class Gazela : Herbivoro
    {

    }

    internal class Coelho : Herbivoro
    {

    }

    internal class Leao : Carnivoro
    {
        public override string Devorar(Herbivoro v) => $"{GetType().Name} devora {v.GetType().Name}";
    }

    internal class Lobo : Carnivoro
    {
        public override string Devorar(Herbivoro v) => $"{GetType().Name} devora {v.GetType().Name}";
    }

    internal class Animais
    {
        private readonly Herbivoro herbivoro;
        private readonly Carnivoro carnivoro;

        public Animais(ContinenteFactory factory)
        {
            herbivoro = factory.ObterHerbivoro();
            carnivoro = factory.ObterCarnivoro();
        }

        public string CacarComida() => carnivoro.Devorar(herbivoro);

    }
}



//1:51