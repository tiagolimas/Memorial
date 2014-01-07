using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Geometry;
using NUnit.Framework;

namespace TestesNutit
{
    [TestFixture]
    class SuccessTests
    {
        [TestFixtureSetUp] public void Init()
        {
            IAoInitialize init = new AoInitializeClass();
            init.Initialize(esriLicenseProductCode.esriLicenseProductCodeAdvanced);
        }

        [TestFixtureTearDown] public void Cleanup()
        { /* ... */ }

        [Test] public void Add()
        { /* ... */ }
    }
}
