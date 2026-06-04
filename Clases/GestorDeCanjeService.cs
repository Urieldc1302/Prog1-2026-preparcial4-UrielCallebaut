namespace FiguritasHub;
using System.Linq;

public class GestorDeCanjeService
{
    protected List<Album> Albums = new List<Album>();

    public void RegistrarAlbum(Album album) => Albums.Add(album);


    public void Canjear(Album origen, Album destino, int numeroDeFigurita)
    {
        if (!origen.TieneRepetida(numeroDeFigurita))
        {
            throw new InvalidOperationException("El álbum origen no tiene esa figurita como repetida");
        }

        if (destino.TieneFigurita(numeroDeFigurita))
        {
            throw new InvalidOperationException("El álbum destino ya posee esa figurita");
        }

        var figurita = origen.RemoverFigurita(numeroDeFigurita);
        destino.AgregarFigurita(figurita);
    }

    public void Canjear(Album origen, Album destino, Figurita figurita)
    {
        if (!origen.TieneRepetida(figurita))
        {
            throw new InvalidOperationException("El álbum origen no tiene esa figurita como repetida");
        }

        if (destino.TieneFigurita(figurita.Numero))
        {
            throw new InvalidOperationException("El álbum destino ya posee esa figurita");
        }

        var figuritaRemovida = origen.RemoverFigurita(figurita);
        destino.AgregarFigurita(figuritaRemovida);
    }

    public Album? ObtenerAlbumConMasRepetidas()
    {
        if (!Albums.Any())
        {
            return null;
        }

        return Albums
            .OrderByDescending(a => a.ObtenerCantidadFiguritasRepetidas())
            .First();
    }
}