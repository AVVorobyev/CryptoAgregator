namespace CryptoAgregator.Core.Data
{
    public class Symbol
    {
        private string _name;

        public string Name
        {
            get { return _name; }
            protected set { _name = value.ToUpper(); }
        }

        public Symbol(string name)
        {
            _name = name;
        }
    }
}
