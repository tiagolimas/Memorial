using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;
using System.Data;
using System.Drawing;

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
    public class Teste : frmMemorial
    {
        ///<summary>Obtém o Azimute e a Distancia entre dois pontos.</summary>
        /// 
        ///<param name="fromPoint"></param>
        ///<param name="toPoint"></param>
        ///<param name="spatialReference"></param>
        ///  
        ///<returns></returns>
        ///  
        ///<remarks></remarks>
        public static string PegaAzimute(IPoint fromPoint, IPoint toPoint, esriSRGeoCSType spatialReference)
        {
            ISpatialReferenceFactory2 spatialReferenceFactory2 = new SpatialReferenceEnvironmentClass();
            ISpatialReference2 spatialReference2 = (ISpatialReference2)spatialReferenceFactory2.CreateSpatialReference((System.Int16)spatialReference);

            IMeasurementTool measurementTool = new MeasurementTool();
            measurementTool.SpecialGeolineType = cjmtkSGType.cjmtkSGTRhumbLine;
            measurementTool.SpecialSpatialReference = spatialReference2;

            measurementTool.ConstructByPoints(fromPoint, toPoint);

            string Mem = string.Format("Azimute: {0} Distancia: {1} \r\n", measurementTool.Angle.ToString(), measurementTool.Distance.ToString());
   
            return Mem;
        }


        /// <summary>
        /// Faz os cálculos de forma manual
        /// </summary>
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
            azimute = Math.Atan(x / y);
            string Mem = string.Format("Azimute: {0} Distancia: {1} \r\n", azimute.ToString(), distancia.ToString());

            return Mem;
        }



    }
}
