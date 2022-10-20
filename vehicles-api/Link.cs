using System;
    internal class Link
    {
        public string Href { get; }
        public string Rel { get;  }
        public string Method { get;  }

        public Link(string href, string rel, string method)
        {
            this.Href = href;
            this.Rel = rel;
            this.Method = method;
        }
    }


