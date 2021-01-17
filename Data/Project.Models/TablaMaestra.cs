namespace Project.Models
{
    public class TablaMaestra : Base
    {
        public int IDTABLA { get; set; }
        public string STABLA { get; set; }
        public string Label1_Text { get; set; }
        public int Label1_Width { get; set; }
        public int Label1_Lenght { get; set; }
        public string Label2_Text { get; set; }
        public int Label2_Width { get; set; }
        public int Label2_Lenght { get; set; }
        public string Label3_Text { get; set; }
        public int Label3_Width { get; set; }
        public int Label3_Lenght { get; set; }
        public string Label4_Text { get; set; }
        public int Label4_Width { get; set; }
        public int Label4_Lenght { get; set; }
        public int NESTADO { get; set; }
        public int IDPADRE { get; set; }
        public string DESPADRE { get; set; }
        public int IDDETALLE { get; set; }
        public string SDETALLE { get; set; }
        public string FILLER1 { get; set; }
        public string FILLER2 { get; set; }
        public string FILLER3 { get; set; }

    }
    public class TablaMaestraIDOut
    {	
        public int IdDetalle { get; set; }
        public string SDetalle { get; set; }
        public string Filler1 { get; set; }
        public string Filler2 { get; set; }
        public string Filler3 { get; set; }
        public string Padre { get; set; }
    }
}
