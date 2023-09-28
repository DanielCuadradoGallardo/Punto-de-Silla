namespace PuntoDeSilla
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool error = false;
            do
            {
                error = false;
                try
                {
                    Console.WriteLine("Introduce dimension m");
                    int m = int.Parse(Console.ReadLine());

                    Console.WriteLine("Introduce dimension n");
                    int n = int.Parse(Console.ReadLine());

                    int[,] array = new int[m, n];

                    for (int i = 0; i < m; i++)
                    {
                        for (int j = 0; j < n; j++)
                        {
                            Console.WriteLine("Introduce posicion[" + i + "][" + j + "]");
                            array[i, j] = int.Parse(Console.ReadLine());
                        }
                    }

                    var results = puntoDeSilla(array);
                    if (results.Item3 != false)
                    {
                        Console.WriteLine("El valor del primer punto de silla es: " + results.Item1 + " y se encuentra en la posicion " + results.Item2);
                    }
                    else
                    {
                        Console.WriteLine("No se encontró ningun punto de silla");
                    }
                }
                catch (FormatException ex)
                {
                    {
                        Console.WriteLine("\nHas introducido un valor no numerico entero, repite de nuevo\n");
                        error = true;
                    }

                }

            } while (error == true);
        }
        private static (int, string, bool) puntoDeSilla(int[,] array)
        {
            int puntoDeSilla = 0;
            bool esMenorEnSuFila = true;
            bool esMayorEnSuColumna = true;
            string posicionPuntoDeSilla = "[][]";

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    esMenorEnSuFila = true;
                    esMayorEnSuColumna = true;
                    for (int z = 0; z < array.GetLength(1); z++)
                    {
                        if (array[i, j] >= array[i, z])
                        {
                            esMenorEnSuFila = false;
                        }
                    }
                    for (int z = 0; z < array.GetLength(0); z++)
                    {
                        if (array[i, j] <= array[z, j])
                        {
                            esMayorEnSuColumna = false;
                        }
                    }
                    if (esMenorEnSuFila == true && esMayorEnSuColumna == true)
                    {
                        puntoDeSilla = array[i, j];
                        posicionPuntoDeSilla = "[" + i + "][" + j + "]";

                        return (puntoDeSilla, posicionPuntoDeSilla, true);
                    }
                }

            }

            return (0, "", false);
        }
    }
}