try
{
    string archivo = @"d:\huejutla\comprar\VCuotaUsoDetalleDatos.csv";
    var lista = CsvLoader.CargarDesdeCsv(archivo);

    if (lista.Count == 0)
    {
        Console.WriteLine("No se cargaron datos desde el archivo.");
        return;
    }

    // Nivel4 y Nivel5 deben estar definidos o cargados desde recursos
    var nivel4 = DatosNivel4.ObtenerNivel4();
    var nivel5 = DatosNivel5.ObtenerNivel5();

    string salidaCsv = "salida_contable.csv";

    ExportadorCSV.ExportarNivel4y5ACSV(lista, nivel4, nivel5, DateTime.Now, DateTime.Now, salidaCsv);

    Console.WriteLine("Archivo generado correctamente en: ");
    Console.WriteLine(Path.GetFullPath(salidaCsv));
}
catch (Exception ex)
{
    Console.WriteLine("Error: " + ex.Message);
}

