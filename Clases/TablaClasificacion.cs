using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace conceptos.Clases
{
    public static class TablaClasificacion
    {
        private static DataTable _tabla;

        static TablaClasificacion()
        {
            _tabla = new DataTable("ClasificacionConceptos");

            _tabla.Columns.Add("NumConcepto", typeof(int));

            _tabla.Columns.Add("Medido", typeof(bool));
            _tabla.Columns.Add("Uso", typeof(int));
            _tabla.Columns.Add("CuentaN5", typeof(string));

            // Puedes cargar los valores aquí o desde un método externo
            _tabla.Rows.Add(-1, false, 1, "4173-02-1-1-1"); //Consumo fijo
            _tabla.Rows.Add(-1, false, 5, "4173-02-1-1-2");
            _tabla.Rows.Add(-1, false, 2, "4173-02-1-1-3");
            _tabla.Rows.Add(-1, false, 3, "4173-02-1-1-4");
            _tabla.Rows.Add(-1, false, 4, "4173-02-1-1-5");
            _tabla.Rows.Add(-1, false, 6, "4173-02-1-1-6");
            _tabla.Rows.Add(-1, false, 7, "4173-02-1-1-7");
            _tabla.Rows.Add(-1, false, 8, "4173-02-1-1-8");
           // _tabla.Rows.Add(-1, 0, 8, "4173-02-1-1-09"); 

            _tabla.Rows.Add(-6, false, 1, "4173-02-1-3-01"); //Rezago Fijo
            _tabla.Rows.Add(-6, false, 5, "4173-02-1-3-02");
            _tabla.Rows.Add(-6, false, 2, "4173-02-1-3-03");
            _tabla.Rows.Add(-6, false, 3, "4173-02-1-3-04");
            _tabla.Rows.Add(-6, false, 4, "4173-02-1-3-05");
            _tabla.Rows.Add(-6, false, 6, "4173-02-1-3-06");
            _tabla.Rows.Add(-6, false, 7, "4173-02-1-3-07");
            _tabla.Rows.Add(-6, false, 8, "4173-02-1-3-08");


            // Puedes cargar los valores aquí o desde un método externo
            _tabla.Rows.Add(-2, false, 1, "4173-02-3-1-1"); //Alcantarillado fijo
            _tabla.Rows.Add(-2, false, 5, "4173-02-3-1-2");
            _tabla.Rows.Add(-2, false, 2, "4173-02-3-1-3");
            _tabla.Rows.Add(-2, false, 3, "4173-02-3-1-4");
            _tabla.Rows.Add(-2, false, 4, "4173-02-3-1-5");
            _tabla.Rows.Add(-2, false, 6, "4173-02-3-1-6");
            _tabla.Rows.Add(-2, false, 7, "4173-02-3-1-7");
            _tabla.Rows.Add(-2, false, 8, "4173-02-3-1-8");
            // _tabla.Rows.Add(-1, 0, 8, "4173-02-1-1-09"); 

            _tabla.Rows.Add(-8, false, 1, "4173-02-3-1-1"); //Rezago  alcantarillado Fijo
            _tabla.Rows.Add(-8, false, 5, "4173-02-3-1-2");
            _tabla.Rows.Add(-8, false, 2, "4173-02-3-1-3");
            _tabla.Rows.Add(-8, false, 3, "4173-02-3-1-4");
            _tabla.Rows.Add(-8, false, 4, "4173-02-3-1-5");
            _tabla.Rows.Add(-8, false, 6, "4173-02-3-1-6");
            _tabla.Rows.Add(-8, false, 7, "4173-02-3-1-7");
            _tabla.Rows.Add(-8, false, 8, "4173-02-3-1-8");



            // Puedes cargar los valores aquí o desde un método externo
            _tabla.Rows.Add(-3, false, 1, "4173-02-4-1-1"); //Saneamiento fijo
            _tabla.Rows.Add(-3, false, 5, "4173-02-4-1-2");
            _tabla.Rows.Add(-3, false, 2, "4173-02-4-1-3");
            _tabla.Rows.Add(-3, false, 3, "4173-02-4-1-4");
            _tabla.Rows.Add(-3, false, 4, "4173-02-4-1-5");
            _tabla.Rows.Add(-3, false, 6, "4173-02-4-1-6");
            _tabla.Rows.Add(-3, false, 7, "4173-02-4-1-7");
            _tabla.Rows.Add(-3, false, 8, "4173-02-4-1-8");
            // _tabla.Rows.Add(-1, 0, 8, "4173-02-1-1-09"); 
                                
            _tabla.Rows.Add(-9, false, 1, "4173-02-4-3-1"); //Rezago  Saneamiento Fijo
            _tabla.Rows.Add(-9, false, 5, "4173-02-4-3-2");
            _tabla.Rows.Add(-9, false, 2, "4173-02-4-3-3");
            _tabla.Rows.Add(-9, false, 3, "4173-02-4-3-4");
            _tabla.Rows.Add(-9, false, 4, "4173-02-4-3-5");
            _tabla.Rows.Add(-9, false, 6, "4173-02-4-3-6");
            _tabla.Rows.Add(-9, false, 7, "4173-02-4-3-7");
            _tabla.Rows.Add(-9, false, 8, "4173-02-4-3-8");
                                




           _tabla.Rows.Add(-1, true, 1, "4173-02-2-1-1");  //MEdidos
           _tabla.Rows.Add(-1, true, 5, "4173-02-2-1-2");
           _tabla.Rows.Add(-1, true, 2, "4173-02-2-1-3");
           _tabla.Rows.Add(-1, true, 3, "4173-02-2-1-4");
           _tabla.Rows.Add(-1, true, 4, "4173-02-2-1-5");
           _tabla.Rows.Add(-1, true, 8, "4173-02-2-1-8");

            _tabla.Rows.Add(-6, true, 1, "4173-02-2-2-1");  //Rezago MEdidos
            _tabla.Rows.Add(-6, true, 5, "4173-02-2-2-2");
            _tabla.Rows.Add(-6, true, 2, "4173-02-2-2-3");
            _tabla.Rows.Add(-6, true, 3, "4173-02-2-2-4");
            _tabla.Rows.Add(-6, true, 4, "4173-02-2-2-5");
            _tabla.Rows.Add(-6, true, 8, "4173-02-2-2-8");
                               

            _tabla.Rows.Add(-2, true, 1, "4173-02-3-2-1");  //alcantarillado MEdidos
            _tabla.Rows.Add(-2, true, 5, "4173-02-3-2-2");
            _tabla.Rows.Add(-2, true, 2, "4173-02-3-2-3");
            _tabla.Rows.Add(-2, true, 3, "4173-02-3-2-4");
            _tabla.Rows.Add(-2, true, 4, "4173-02-3-2-5");
            _tabla.Rows.Add(-2, true, 8, "4173-02-3-2-8");

            _tabla.Rows.Add(-8,true, 1, "4173-02-3-4-1");  //Rezago Alcantarillado MEdidos
            _tabla.Rows.Add(-8,true, 5, "4173-02-3-4-2");
            _tabla.Rows.Add(-8,true, 2, "4173-02-3-4-3");
            _tabla.Rows.Add(-8,true, 3, "4173-02-3-4-4");
            _tabla.Rows.Add(-8,true, 4, "4173-02-3-4-5");
            _tabla.Rows.Add(-8,true, 8, "4173-02-3-4-8");


            _tabla.Rows.Add(-3, true, 1, "4173-02-4-2-1");  //Sanemiento MEdidos
            _tabla.Rows.Add(-3, true, 5, "4173-02-4-2-2");
            _tabla.Rows.Add(-3, true, 2, "4173-02-4-2-3");
            _tabla.Rows.Add(-3, true, 3, "4173-02-4-2-4");
            _tabla.Rows.Add(-3, true, 4, "4173-02-4-2-5");
            _tabla.Rows.Add(-3, true, 8, "4173-02-4-2-8");

            _tabla.Rows.Add(-9, true, 1, "4173-02-4-4-1");  //Rezago Saneamiento MEdidos
            _tabla.Rows.Add(-9, true, 5, "4173-02-4-4-2");
            _tabla.Rows.Add(-9, true, 2, "4173-02-4-4-3");
            _tabla.Rows.Add(-9, true, 3, "4173-02-4-4-4");
            _tabla.Rows.Add(-9, true, 4, "4173-02-4-4-5");
            _tabla.Rows.Add(-9, true, 8, "4173-02-4-4-8");
        }

        public static DataTable ObtenerTabla()
        {
            return _tabla.Copy(); // así evitas modificar directamente la tabla original
        }

       

        public static string ObtenerCuentaN5(bool medido, int uso, int numconcepto, int cuenta, string rubro)
        {
            if (numconcepto==-6 || numconcepto==-1)
            {
                
                    if (cuenta == 7105)
                    {
                        return "4173-02-1-2-02";
                    }

                    if (cuenta == 7353)
                    {
                        return "4173-02-1-2-03";
                    }

                    if (cuenta == 10760)
                    {
                        return "4173-02-1-2-04";
                    }

                    if (cuenta == 11029 || cuenta == 14382 || cuenta == 16677 || cuenta == 17447)
                    {
                        return "4173-02-1-2-05";
                    }

                    if (cuenta == 15460)
                    {
                        return "4173-02-1-2-06";
                    }
                    if (cuenta == 11666)
                    {
                        return "4173-02-1-2-07";
                    }

                    if (cuenta == 572)
                    {
                        return "4173-02-1-2-08";
                    }

                    if (cuenta == 2436 || cuenta == 1299)
                    {
                        return "4173-02-1-2-09";
                    }

                    if (cuenta == 10424)
                    {
                        return "4173-02-1-2-10";
                    }
                }
            try
            {
                var rows = _tabla.Select($"medido = {medido} AND Uso = {uso} AND NumConcepto = {numconcepto}")[0]["CuentaN5"].ToString();
                if (rows.Length > 0)
                { return rows; }
            }
            catch (Exception ex)
            { 
            }


            if (rubro!=string.Empty)
            { return rubro; }


            return string.Empty;
        }
    }
}
