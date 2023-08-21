using AxMapWinGIS;
using MapWinGIS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        int providerid;
        TileProviders providers;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void AxMap2MouseDownEvet(object sender, _DMapEvents_MouseDownEvent e)
        {
            int m_layerHandle = -1;
            Shapefile sf = axMap2.get_Shapefile(m_layerHandle);

            axMap2.CursorMode = MapWinGIS.tkCursorMode.cmMeasure;
            String loc = MapWinGIS.tkCursorMode.cmMeasure.ToString();

            MapWinGIS.Point pnt = new MapWinGIS.Point();
            double x = 0;
            double y = 0;
            axMap2.PixelToProj(0, 0, ref x, ref y);
            pnt.x = e.x; pnt.y = e.y;
            Shape shp = new Shape();
            shp.Create(ShpfileType.SHP_POINT);
            int index = shp.numPoints;
            shp.InsertPoint(pnt, index);
            String a = pnt.x.ToString();
            String b = pnt.y.ToString();
            Console.WriteLine(a +  " "  + b); 
            //index = sf.NumShapes;
            /*if (!sf.EditInsertShape(shp, ref index))
            {
                MessageBox.Show("Failed to insert shape: " + sf.ErrorMsg[sf.LastErrorCode]);
                return;
            }*/
            axMap2.Redraw();
        }

        private void bindingNavigator1_RefreshItems(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            providers = axMap2.Tiles.Providers;
            providerid = (int)tkTileProvider.ProviderCustom + 1001;

            providers.Add(providerid, "map", "http://127.0.0.1/sat/z{zoom}/{y}/{x}.jpg", tkTileProjection.SphericalMercator, 0, 18);

            axMap2.Tiles.ProviderId = providerid;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            axMap2.CursorMode = MapWinGIS.tkCursorMode.cmPan;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            axMap2.CursorMode = MapWinGIS.tkCursorMode.cmZoomOut;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            axMap2.SendMouseDown = true;
            axMap2.MouseDownEvent += AxMap2MouseDownEvet;
        }

        private void button6_Click(object sender, EventArgs e)
        {
        }
    }
}
