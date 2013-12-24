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
        

        /// <summary>
        /// Faz validações sobre a feição
        /// </summary>
        /// <param name="feature"></param>
        /// <returns></returns>
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


        /// <summary>
        /// 
        /// </summary>
        /// <param name="klass"></param>
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
                    resultado += Teste.CalculaManual(ponto, pontoB);
                }
               
            }

            return resultado;
        }
    }
}
