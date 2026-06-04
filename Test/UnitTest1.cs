using NUnit.Framework;
using FiguritasHub;

namespace Test;

[TestFixture]
public class AlbumServiceTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void AgregarFigurita_ConCantidadTres_RegistraTresCopiasYObtenerRepetidasIncluyeLaFigurita()
    {
        var album = new Album { NombreDelColeccionista = "Juan" };
        var figurita = new FiguritaComun(1, "Jugador", "Argentina", 3);

        album.AgregarFigurita(figurita, 3);

        Assert.That(album.TieneRepetida(1), Is.True);
        var repetidas = album.ObtenerRepetidas();
        Assert.That(repetidas, Has.Exactly(1).Matches<Figurita>(f => f.Numero == 1));
    }

    [Test]
    public void TieneRepetida_NumeroRepetidoDevuelveTrueYUnicaCopiaDevuelveFalse()
    {
        var album = new Album { NombreDelColeccionista = "Ana" };
        var figurita = new FiguritaComun(2, "Jugador", "Argentina", 2);

        album.AgregarFigurita(figurita, 1);
        Assert.That(album.TieneRepetida(2), Is.False);

        album.AgregarFigurita(figurita, 1);
        Assert.That(album.TieneRepetida(2), Is.True);
    }

    [Test]
    public void Canjear_Valido_OrigenPierdeUnaCopiaYDestinoRecibeLaFigurita()
    {
        var origen = new Album { NombreDelColeccionista = "Origen" };
        var destino = new Album { NombreDelColeccionista = "Destino" };
        var servicio = new GestorDeCanjeService();
        var figurita = new FiguritaComun(3, "Jugador", "Argentina", 4);

        origen.AgregarFigurita(figurita, 2);
        servicio.RegistrarAlbum(origen);
        servicio.RegistrarAlbum(destino);

        servicio.Canjear(origen, destino, 3);

        Assert.That(origen.TieneRepetida(3), Is.False);
        Assert.That(destino.TieneFigurita(3), Is.True);
    }

    [Test]
    public void Canjear_DestinoYaPoseeFigurita_LanzaInvalidOperationException()
    {
        var origen = new Album { NombreDelColeccionista = "Origen" };
        var destino = new Album { NombreDelColeccionista = "Destino" };
        var servicio = new GestorDeCanjeService();
        var figuritaOrigen = new FiguritaComun(4, "Jugador", "Argentina", 3);
        var figuritaDestino = new FiguritaComun(4, "Jugador", "Argentina", 3);

        origen.AgregarFigurita(figuritaOrigen, 2);
        destino.AgregarFigurita(figuritaDestino, 1);
        servicio.RegistrarAlbum(origen);
        servicio.RegistrarAlbum(destino);

        Assert.That(
            () => servicio.Canjear(origen, destino, 4),
            Throws.InvalidOperationException);
    }

    [Test]
    public void Canjear_OrigenNoTieneFiguritaRepetida_LanzaInvalidOperationException()
    {
        var origen = new Album { NombreDelColeccionista = "Origen" };
        var destino = new Album { NombreDelColeccionista = "Destino" };
        var servicio = new GestorDeCanjeService();
        var figurita = new FiguritaComun(5, "Jugador", "Argentina", 5);

        origen.AgregarFigurita(figurita, 1);
        servicio.RegistrarAlbum(origen);
        servicio.RegistrarAlbum(destino);

        Assert.That(
            () => servicio.Canjear(origen, destino, 5),
            Throws.InvalidOperationException);
    }
}