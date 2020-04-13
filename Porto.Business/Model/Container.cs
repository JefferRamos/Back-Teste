
using System.Collections.Generic;
using Porto.Business.Model;

namespace Porto.Business.Model
{
    public class Container
    {
        public int Id { get; set; }
        public string Cliente { get; set; }
        public string NroConteiner { get; set; }
        public int Tipo { get; set; }
        public string Status { get; set; }
        public string Categoria { get; set; }
        public List<Movimento> Movimentos { get; set; }
    }
}