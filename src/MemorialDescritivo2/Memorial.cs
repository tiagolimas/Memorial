using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace MemorialDescritivo2
{
    public class Memorial : ESRI.ArcGIS.Desktop.AddIns.Button
    {
        public Memorial()
        {
        }

        protected override void OnClick()
        {
            frmMemorial memorialForm = new frmMemorial();
            memorialForm.ShowDialog();
        }
        protected override void OnUpdate()
        {
            Enabled = ArcMap.Application != null;
        }
    }

}
