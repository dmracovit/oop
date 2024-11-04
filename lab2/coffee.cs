namespace Coffee_types
{
    public abstract class Coffee
    {
        protected Intensity Intensity { get; }

        public Coffee(Intensity intensity)
        {
            Intensity = intensity;
        }

        public abstract void Make();

    }
}
