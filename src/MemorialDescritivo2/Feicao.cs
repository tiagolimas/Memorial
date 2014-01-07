using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using ESRI.ArcGIS.ArcMapUI;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Catalog;
using ESRI.ArcGIS.CatalogUI;
using ESRI.ArcGIS.DataSourcesFile;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.DefenseSolutions;

namespace MemorialDescritivo2
{
    public static class Feicao
    {
        public static bool Valida(IFeatureClass feature)
        {
            if (feature == null)
            {
                MessageBox.Show("Feature nula!");
                return false;
            }

            if (feature.FeatureCount(null) == 0)
            {
                return false;
            }

            if (feature.ShapeType != esriGeometryType.esriGeometryPolygon)
            {
                return false;
            }

            return true;
        }

        public static string calculaGeral(IFeatureClass klass)
        {
            IQueryFilter filter = new QueryFilterClass();
            filter.WhereClause = "STATE_NAME = 'California'";
            object missing = Type.Missing;
            string resultado = string.Empty;
            var cursor = klass.Search(filter, false);
            IPolyline poly = new PolylineClass();
            IFeature feature = null;
            

            while ((feature = cursor.NextFeature()) != null)
            {
                var geometry = feature.ShapeCopy;
                IPointCollection col = (IPointCollection)geometry;

                for (var i = 0; i <= col.PointCount - 2; i++)
                {
                    var ponto = col.get_Point(i);
                    var pontoB = col.get_Point(i + 1);
                    ((IPointCollection)poly).AddPoint(ponto, ref missing, ref missing);
                    ((IPointCollection)poly).AddPoint(pontoB, ref missing, ref missing);
                    //resultado += Teste.PegaAzimute(ponto, pontoB, esriSRGeoCSType.esriSRGeoCS_NAD1983);
                    resultado += CalculaManual(ponto, pontoB);
                }
            }
            return resultado;
        }

        public static string CalculaManual(IPoint dePonto, IPoint paraPonto)
        {
            double distancia, azimute, x, y;

            //TESTE PARA DISTANCIA e AZIMUTE OK
            //dePonto.X = 801400;
            //dePonto.Y = 9836400;
            //paraPonto.X = 805300;
            //paraPonto.Y = 9839000;

            x = paraPonto.X - dePonto.X;
            y = paraPonto.Y - dePonto.Y;

            distancia = Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2));
            //azimute = Math.Atan(x / y);
            azimute = CalcularAzimute(dePonto, paraPonto);
            string Mem = string.Format("Azimute: {0} Distancia: {1} \r\n", azimute, distancia);
            return Mem;
        }

        public static double CalcularAzimute(IPoint de, IPoint para)
        {
            IVector3D vector = new Vector3DClass();
            vector.ConstructDifference(para, de);
            return CalculaGraus(vector.Azimuth); 
        }

        public static double CalculaGraus(double rad)
        {
            return rad * (180 / Math.PI);
        }

    }
}
