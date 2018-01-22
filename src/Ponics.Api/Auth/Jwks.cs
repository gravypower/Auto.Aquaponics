using System.Collections.Generic;

namespace Ponics.Api.Auth
{
    public class Key
    {
        public string alg { get; set; }
        public string kty { get; set; }
        public string use { get; set; }
        public List<string> x5c { get; set; }
        public string n { get; set; }
        public string e { get; set; }
        public string kid { get; set; }
        public string x5t { get; set; }
    }

    public class Jwks
    {
        public List<Key> keys { get; set; }
    }
}
