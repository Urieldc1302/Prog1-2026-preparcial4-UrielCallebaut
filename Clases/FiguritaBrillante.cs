namespace FiguritasHub;

public class FiguritaBrillante : Figurita
{
    public bool EsEdicionLimitada {get; set;}

        public FiguritaBrillante(int numero, string nombreJugador, string pais, bool esEdicionLimitada) : base (numero, nombreJugador, pais)
    {
        EsEdicionLimitada = esEdicionLimitada;
    }

        public override string ConsultarCategoria(int Numero)
    {
        if (EsEdicionLimitada)
        {
            return "Brillante (Edición Limitada)";
        }
        else
        {
            return "Brillante";
        }
    }
}