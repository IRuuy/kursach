using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Aspose.Cells;
using Aspose.Cells.Drawing;
//using DocumentFormat.OpenXml.Spreadsheet;
using WeatherMonitoring.Assets;
using WeatherMonitoring.Assets.Meteostations;

namespace WeatherMonitoring
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*            SaveDataMeteostaion.addDayData(1, new ForestMeteostation(1, 20, 70, 0.5f));
                        SaveDataMeteostaion.addDayData(2, new ForestMeteostation(1, 20, 70, 0.5f));
                        foreach (var data in SaveDataMeteostaion.Data)
                        {
                            label1.Text += data.Key.ToString() + " :\n";
                            foreach (string str in data.Value.getData())
                                label1.Text += "\t" + str + "\n";
                            label1.Text += "\n";
                        }*/
            Territory ter = new Territory( new ForestMeteostation[] { new ForestMeteostation(LocationTypes.NOVOSIBIRSK) }, LocationTypes.NOVOSIBIRSK);
            ter.StartMeteostations();
        }
    }
}
