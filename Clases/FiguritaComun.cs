namespace FiguritasHub;

public class FiguritaComun : Figurita
{
    public int Rareza {get; set;}

    public FiguritaComun(int numero, string nombreJugador, string pais, int rareza) : base (numero, nombreJugador, pais)
    {
        if(rareza < 1 || rareza > 5)
        {
            throw new ArgumentException("La rareza no puede ser menor a 1 o mayor a 5");
        }
        Rareza = rareza;
    }

    public override string ConsultarCategoria(int Numero)
    {
        return $"'Común: {Rareza}";
    }
}