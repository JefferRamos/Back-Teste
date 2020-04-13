using System;
using Porto.Business.Model;

namespace Porto.Business.Model
{
    public class Movimento
    {
        public int Id { get; set; }
        public string Navio { get; set; }
        public string TipoMovimento { get; set; }
        public string DataInicio { get; set; }
        public string DataFim { get; set; }
        public int containerId { get; set; }
        public Container Container { get; set; }
    }
}