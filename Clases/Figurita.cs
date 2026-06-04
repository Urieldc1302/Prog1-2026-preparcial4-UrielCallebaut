namespace FiguritasHub;

public abstract class Figurita
{
    public int Numero { get; set; }
    public string NombreJugador {get; set;}
    public string Pais {get; set;}

    public Figurita(int numero, string nombreJugador, string pais)
    {
        if(numero <= 0)
        {
            throw new ArgumentException("El número de figurita no puede ser menor o igual a 0");
        }
        if(string.IsNullOrWhiteSpace(nombreJugador))
        {
            throw new ArgumentException("El nombre del jugador no puede estar vacío");
        }
        Numero = numero;
        NombreJugador = nombreJugador;
        Pais = pais;
    }

    public abstract string ConsultarCategoria(int Numero);
}
