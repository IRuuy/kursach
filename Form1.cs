using System;
using System.Windows.Forms;
using WeatherMonitoring.Assets;
using WeatherMonitoring.Assets.Factories;
using WeatherMonitoring.Assets.Meteostations;

namespace WeatherMonitoring
{
    public partial class Form1 : Form, IObserver<Meteostation>
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MetereostationFactory.get(MeteostationTypes.FOREST_METEOSTATION,
                                      LocationTypes.NOVOSIBIRSK,
                                      this,
                                      300)
                                      .Start();
        }

        public void OnCompleted()
        {
            throw new NotImplementedException();
        }

        public void OnError(Exception error)
        {
            MessageBox.Show(error.ToString());
        }

        public void OnNext(Meteostation value)
        {
            MessageBox.Show(String.Join(Environment.NewLine, value.GetData()));
        }
    }
}
