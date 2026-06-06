# Corrección — UrielCallebaut

> **Aviso importante:** Las soluciones se evalúan exclusivamente con los conceptos vistos en clase.

## Nota general

**Aprobado** — Puntaje: 95/100

| Área | Obtenido | Máximo |
|---|---|---|
| Punto 1 — Jerarquía de Figuritas | 17 | 20 |
| Punto 2 — Album | 25 | 25 |
| Punto 3 — GestorDeCanjeService | 25 | 25 |
| Punto 4 — Validaciones | 13 | 15 |
| Punto 5 — Tests NUnit | 10 | 10 |
| Estructura de proyecto | 5 | 5 |
| **Total** | **95** | **100** |

## Correcciones de evaluación

### Estructura del proyecto (5/5)

La estructura es correcta: existe el proyecto `Clases` con las clases del dominio y el proyecto `Test` con los tests. El archivo `Solucion.sln` está presente. Los nombres de los proyectos coinciden con lo solicitado.

### Punto 1 — Jerarquía de Figuritas (17/20)

**Lo que está bien:**
- `Figurita` es abstracta con las propiedades `Numero`, `NombreJugador` y `Pais`.
- `FiguritaComun` hereda de `Figurita` y tiene la propiedad `Rareza`.
- `FiguritaBrillante` hereda de `Figurita` y tiene `EsEdicionLimitada`.
- La lógica de `FiguritaBrillante.ConsultarCategoria` es correcta: devuelve `"Brillante (Edición Limitada)"` o `"Brillante"` según corresponda.
- El nombre del método `ConsultarCategoria` difiere del enunciado (`ObtenerCategoria`), pero la lógica es correcta, por lo que no se penaliza el nombre.

**Problemas encontrados:**

1. **Formato de retorno incorrecto en `FiguritaComun`:** El método devuelve `$"'Común: {Rareza}"` cuando el enunciado especifica `"Común (Rareza: X)"`. Hay dos errores: una comilla simple (`'`) sobrante al inicio del string, y el formato del texto no es el solicitado (faltan los paréntesis y la palabra "Rareza:"). (-3 pts)

### Punto 2 — Album (25/25)

Implementación completa y correcta.

- La lista `Figuritas` es `protected`.
- Las sobrecargas de `AgregarFigurita` están correctamente implementadas (una por figurita individual, otra con cantidad).
- Las sobrecargas de `TieneRepetida` están correctamente implementadas (por objeto `Figurita` y por número).
- `ObtenerRepetidas()` devuelve la lista de figuritas repetidas correctamente usando `GroupBy`.
- Los métodos auxiliares `RemoverFigurita` y `ObtenerCantidadFiguritasRepetidas` son una adición útil que facilita la implementación del gestor.

### Punto 3 — GestorDeCanjeService (25/25)

Implementación completa y correcta.

- La lista `Albums` es `protected`.
- `RegistrarAlbum` funciona correctamente.
- Las sobrecargas de `Canjear` están correctamente implementadas (por número y por objeto `Figurita`).
- `ObtenerAlbumConMasRepetidas()` devuelve `null` cuando la lista está vacía y el álbum correcto cuando hay datos.
- El uso de `InvalidOperationException` en las validaciones de canje es aceptado como válido.

### Punto 4 — Validaciones (13/15)

**Lo que está bien:**
- `Numero <= 0` lanza `ArgumentException` en el constructor de `Figurita`.
- `NombreJugador` vacío/nulo lanza `ArgumentException` en el constructor de `Figurita`.
- `Rareza` fuera del rango 1-5 lanza `ArgumentException` en `FiguritaComun`.
- `cantidad <= 0` lanza `ArgumentException` en `Album.AgregarFigurita`.
- Las validaciones en `GestorDeCanjeService.Canjear` usan `InvalidOperationException`, lo cual es aceptado como válido.

**Problemas encontrados:**

1. **Sin validación de `Pais`:** No se valida que `Pais` no sea nulo o vacío, aunque este campo tampoco estaba explícitamente listado en el enunciado, por lo que el impacto es mínimo. (-2 pts)

### Punto 5 — Tests NUnit (10/10)

Excelente cobertura de tests.

- Se usa `[TestFixture]` y `[Test]` correctamente.
- Se usa NUnit con las aserciones modernas (`Assert.That`, `Is.True`, `Is.False`, `Throws.InvalidOperationException`).
- Los 5 tests cubren casos relevantes y variados:
  1. Agregar con cantidad y verificar repetidas.
  2. `TieneRepetida` con una y con dos copias.
  3. Canje válido con verificación de origen y destino.
  4. Canje inválido cuando el destino ya posee la figurita.
  5. Canje inválido cuando el origen no tiene repetidas.

## Observaciones importantes

- El único problema pendiente en la jerarquía es el formato del string retornado por `FiguritaComun.ConsultarCategoria`: se esperaba `"Común (Rareza: X)"` y se obtuvo `"'Común: X"` (comilla sobrante y formato incorrecto). Prestar atención a los formatos de texto exactos que pide el enunciado.
- La implementación de `Album` y `GestorDeCanjeService` es sólida y demuestra buen manejo de listas, LINQ y sobrecargas.
- Los tests están muy bien escritos: son claros, descriptivos y cubren tanto el camino feliz como los casos de error.
