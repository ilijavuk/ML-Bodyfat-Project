using Bodyfat_ML_projektML.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace Bodyfat_ML_.Net_Core_projekt
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<BodyFatInfoObject> lista = new List<BodyFatInfoObject>();
        private class BodyFatInfoObject
        {
            public float Density { get; set; }
            public int Age { get; set; }
            public float Weight { get; set; }
            public float Height { get; set; }
            public float Neck { get; set; }
            public float Chest { get; set; }
            public float Abdomen { get; set; }
            public float Hip { get; set; }
            public float Thigh { get; set; }
            public float Knee { get; set; }
            public float Ankle { get; set; }
            public float Biceps { get; set; }
            public float Forearm { get; set; }
            public float Wrist { get; set; }

            public BodyFatInfoObject(string density, string age, string weight,
                string height, string neck, string chest, string abdomen,
                string hip, string thigh, string knee, string ankle, 
                string biceps, string forearm, string wrist)
            {
                Density = float.Parse(density);
                Age = int.Parse(age);
                Weight = float.Parse(weight);
                Height = float.Parse(height);
                Neck = float.Parse(neck);
                Chest = float.Parse(chest);
                Abdomen = float.Parse(abdomen);
                Hip = float.Parse(hip);
                Thigh = float.Parse(thigh);
                Knee = float.Parse(knee);
                Ankle = float.Parse(ankle);
                Biceps = float.Parse(biceps);
                Forearm = float.Parse(forearm);
                Wrist = float.Parse(wrist);
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            using (var reader = new System.IO.StreamReader(@"bodyfat.csv"))
            {
                reader.ReadLine();
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var val = line.Split(',');

                    lista.Add(new BodyFatInfoObject(val[0], val[2], val[3], val[4], val[5], val[6], val[7],
                        val[8], val[9], val[10], val[11], val[12], val[13], val[14]));
                }
            }
        }

        private void btnPredvidi_Click(object sender, RoutedEventArgs e)
        {

            // Add input data
            var input = new ModelInput();

            input.Density = float.Parse(txtDensity.Text);
            input.Age = int.Parse(txtAge.Text);
            input.Weight = float.Parse(txtWeight.Text);
            input.Height = float.Parse(txtHeight.Text);
            input.Neck = float.Parse(txtNeck.Text);
            input.Chest = float.Parse(txtChest.Text);
            input.Abdomen = float.Parse(txtAbdomen.Text);
            input.Hip = float.Parse(txtHeight.Text);
            input.Thigh = float.Parse(txtThigh.Text);
            input.Knee = float.Parse(txtKnee.Text);
            input.Ankle = float.Parse(txtAnkle.Text);
            input.Biceps = float.Parse(txtBiceps.Text);
            input.Forearm = float.Parse(txtForearms.Text);
            input.Wrist = float.Parse(txtWrist.Text);

            // Load model and predict output of sample data
            ModelOutput result = ConsumeModel.Predict(input);

            lblRezultat.Content = Math.Round(result.Score, 2).ToString()+'%';
        }

        private void nasumicnoPopuniBtn_Click(object sender, RoutedEventArgs e)
        {
            Random rnd = new Random();
            int i = rnd.Next(0, lista.Count());

            txtDensity.Text = lista[i].Density.ToString();
            txtAge.Text = lista[i].Age.ToString();
            txtWeight.Text = lista[i].Weight.ToString();
            txtHeight.Text = lista[i].Height.ToString();
            txtNeck.Text = lista[i].Neck.ToString();
            txtChest.Text = lista[i].Chest.ToString();
            txtAbdomen.Text = lista[i].Abdomen.ToString();
            txtHip.Text = lista[i].Hip.ToString();
            txtThigh.Text = lista[i].Thigh.ToString();
            txtKnee.Text = lista[i].Knee.ToString();
            txtAnkle.Text = lista[i].Ankle.ToString();
            txtBiceps.Text = lista[i].Biceps.ToString();
            txtForearms.Text = lista[i].Forearm.ToString();
            txtWrist.Text = lista[i].Wrist.ToString();
        }
    }
}
