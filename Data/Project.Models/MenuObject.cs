using System.Collections.Generic;

namespace Project.Models
{
    public class MenuBar : Base
    {
        public int IdPadre { get; set; }
        public string SPadre { get; set; }
        public int IdDetalle { get; set; }
        public string SDetalle { get; set; }
    }

    public class MenuPadre
    {
        public int SectionId { get; set; }
        public string SectionName { get; set; }
        public List<MenuDetalle> DetailMenu { get; set; }
    }

    public class MenuDetalle
    {
        public int DetailId { get; set; }
        public string DetailName { get; set; }

    }
}