using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using NUnit.Framework;

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
    [TestFixture]
    public class Teste
    {
        public Teste()
        { }

        [TestCase]
        public static void Teste90GrausCorreto()
        {
            IPoint de = new PointClass();
            de.PutCoords(0, 0);
            IPoint para = new PointClass();
            para.PutCoords(1, 0);
            Assert.AreEqual(90, Feicao.CalcularAzimute(de, para));
        }

        [TestCase]
        public void Teste180GrausCorreto()
        {
            IPoint de = new PointClass();
            de.PutCoords(0, 0);
            IPoint para = new PointClass();
            para.PutCoords(1, 0);
            Assert.AreEqual(180, Feicao.CalcularAzimute(de, para));
        }

    }
}
