namespace FiguritasHub;
using System.Linq;

public class Album
{
    public string ?NombreDelColeccionista { get; set; }
    protected List<Figurita> Figuritas = new List<Figurita>();

    public void AgregarFigurita(Figurita figurita) => Figuritas.Add(figurita);

    public void AgregarFigurita(Figurita figurita, int cantidad)
    {
        if (cantidad <= 0)
        {
            throw new ArgumentException("La cantidad debe ser mayor a cero");
        }

        for (int i = 0; i < cantidad; i++)
        {
            Figuritas.Add(figurita);
        }
    }

    public bool TieneFigurita(int numeroDeFigurita)
    {
        return Figuritas.Any(f => f.Numero == numeroDeFigurita);
    }

    public bool TieneRepetida(Figurita figurita)
    {
        if (figurita is null)
        {
            throw new ArgumentNullException(nameof(figurita));
        }

        return TieneRepetida(figurita.Numero);
    }

    public bool TieneRepetida(int numeroDeFigurita)
    {
        return Figuritas.Count(f => f.Numero == numeroDeFigurita) > 1;
    }

    public List<Figurita> ObtenerRepetidas()
    {
        return Figuritas
            .GroupBy(f => f.Numero)
            .Where(g => g.Count() > 1)
            .Select(g => g.First())
            .ToList();
    }

    public Figurita RemoverFigurita(Figurita figurita)
    {
        var figuritaExistente = Figuritas.FirstOrDefault(f => f.Numero == figurita.Numero);

        if (figuritaExistente is null)
        {
            throw new InvalidOperationException("La figurita no existe en el álbum");
        }

        Figuritas.Remove(figuritaExistente);
        return figuritaExistente;
    }

    public Figurita RemoverFigurita(int numeroDeFigurita)
    {
        var figurita = Figuritas.FirstOrDefault(f => f.Numero == numeroDeFigurita);

        if (figurita is null)
        {
            throw new InvalidOperationException("No se encontró la figurita en el álbum");
        }

        Figuritas.Remove(figurita);
        return figurita;
    }

    public int ObtenerCantidadFiguritasRepetidas()
    {
        return Figuritas
            .GroupBy(f => f.Numero)
            .Sum(g => Math.Max(0, g.Count() - 1));
    }
}