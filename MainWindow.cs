using System;
using System.Windows.Forms;
using WeatherMonitoring.Assets.Utils;
using WeatherMonitoring.Assets.Meteostations;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using DocumentFormat.OpenXml.Wordprocessing;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.Spreadsheet;

namespace WeatherMonitoring
{
    public partial class MainWindow : Form, IObserver<Meteostation>
    {
        public List<Dictionary<Meteostation, Dictionary<string, string>>> meteostationsData = new List<Dictionary<Meteostation, Dictionary<string, string>>>();
        private List<int> periodSendingDataList = new List<int>() { 1, 3, 5, };
        MeteostationTypes? filtration = null;

        public MainWindow()
        {
            InitializeComponent();
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
            meteostationsData.Add(new Dictionary <Meteostation, Dictionary<string, string>>() { { value, value.GetData() } });
            if(filtration == null)
                this.data.BeginInvoke((MethodInvoker)(() => this.data.Text += String.Join(Environment.NewLine, value.GetData()) + System.Environment.NewLine + System.Environment.NewLine));
            else
                if(value.MeteostationType == filtration)
                    this.data.BeginInvoke((MethodInvoker)(() => this.data.Text += String.Join(Environment.NewLine, value.GetData()) + System.Environment.NewLine + System.Environment.NewLine));
            
            

        }

        private void Form1_Load(object sender, EventArgs e)
        {

            foreach (var elem in EnumToList<MeteostationTypes>())
                meteostationType.Items.Add(elem);

            foreach (var elem in EnumToList<MeteostationTypes>())
                meteostationType2.Items.Add(elem);

            foreach (var elem in EnumToList<LocationTypes>())
                locationMeteostation.Items.Add(elem);

            foreach (var elem in periodSendingDataList)
                periodSendingData.Items.Add(elem);
        }

        private void addMeteostation_Click(object sender, EventArgs e)
        {
            if(meteostationType.SelectedItem != null &&
                locationMeteostation.SelectedItem != null &&
                locationMeteostation.SelectedItem != null &&
                periodSendingData.SelectedItem != null
                )
            {
                var meteostation = MetereostationFactory.get(nameMeteostation.Text,
                                                            (MeteostationTypes)meteostationType.SelectedItem,
                                                            (LocationTypes)locationMeteostation.SelectedItem,
                                                            this,
                                                            (int)periodSendingData.SelectedItem);
                meteostationsData.Add(new Dictionary<Meteostation, Dictionary<string, string>>() { { meteostation, null } });
                meteostaionCombobox.Items.Add(meteostation.Name);
                meteostation.Start();
            }
        }

        private void StopMetiostationButton_Click(object sender, EventArgs e)
        {
            Meteostation meteostation = null;
            if (meteostaionCombobox.SelectedItem != null)
                meteostation = searchMetiostation(meteostaionCombobox.SelectedItem.ToString());
            if (meteostation != null) meteostation.Stop();
        }
        private void restartMeteostationButton_Click(object sender, EventArgs e)
        {
            Meteostation meteostation = null;
            if (meteostaionCombobox.SelectedItem != null)
                meteostation = searchMetiostation(meteostaionCombobox.SelectedItem.ToString());
            if (meteostation != null) meteostation.Start();
        }
        private Meteostation searchMetiostation(string name)
        {
            foreach (var items in meteostationsData)
                foreach (var item in items)
                    if (item.Key.Name == meteostaionCombobox.SelectedItem.ToString())
                        return item.Key;
            return null;
        }
        private static List<T> EnumToList<T>()
        {
            return Enum.GetValues(typeof(T))
                        .Cast<T>()
                        .ToList();
        }

        private void deleteMeteostationButton_Click(object sender, EventArgs e)
        {
            Meteostation meteostation = null;
            if (meteostaionCombobox.SelectedItem != null)
                meteostation = searchMetiostation(meteostaionCombobox.SelectedItem.ToString());

            if (meteostation != null)
            {
                meteostaionCombobox.Items.Remove(meteostation.Name);
                meteostaionCombobox.ResetText();
                meteostation.Stop();
                meteostation.Dispose();
            }
        }

        private void chooseMeteostation_Click(object sender, EventArgs e)
        {
            if(meteostationType2.SelectedItem != null)
            {
                filtration = (MeteostationTypes)meteostationType2.SelectedItem;
                data.Clear();

                int meteostationDataCount = meteostationsData.Count;
                for(int i = 0; i < meteostationDataCount; i++)
                    foreach (var item in meteostationsData[i])
                        if(item.Value != null)
                            if(item.Key.MeteostationType == (MeteostationTypes)meteostationType2.SelectedItem)
                                this.data.BeginInvoke((MethodInvoker)(() => this.data.Text += String.Join(Environment.NewLine, item.Value) + System.Environment.NewLine + System.Environment.NewLine));
            }

        }

        private void watchAllMeteostations_Click(object sender, EventArgs e)
        {
            filtration = null;
            data.Clear();

            int meteostationDataCount = meteostationsData.Count;
            for (int i = 0; i < meteostationDataCount; i++)
                foreach (var item in meteostationsData[i])
                    if (item.Value != null)
                            this.data.BeginInvoke((MethodInvoker)(() => this.data.Text += String.Join(Environment.NewLine, item.Value) + System.Environment.NewLine + System.Environment.NewLine));
        }

        private void data_TextChanged(object sender, EventArgs e)
        {
            data.Select(data.Text.Length, 0);
        }
    }
}
