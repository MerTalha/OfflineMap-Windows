using MapWinGIS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
            providers = axMap2.Tiles.Providers;
            providerid = (int)tkTileProvider.ProviderCustom + 1001;

            providers.Add(providerid, "map", "C:/ms4w/Apache/htdocs/sat/z{zoom/{y}/{x}.jpg", tkTileProjection.SphericalMercator, 0, 10);

            axMap2.Tiles.ProviderId = providerid;
        }

        private void bindingNavigator1_RefreshItems(object sender, EventArgs e)
        {

        }
    }
}
