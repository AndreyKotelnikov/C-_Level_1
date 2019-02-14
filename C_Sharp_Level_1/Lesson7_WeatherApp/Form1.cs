using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lesson7_WeatherApp
{
    public partial class FormWeatheApp : Form
    {

        Repository data;

        public FormWeatheApp()
        {
            InitializeComponent();

            data = new Repository();
        }

        private void FormWeatheApp_Load(object sender, EventArgs e)
        {
            foreach (var item in data.Cities)
            {
                lbSites.Items.Add(item);
            }
        }

        private void lbSites_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbSites.SelectedIndex == -1) { return; }

            City currentCity = (City)lbSites.SelectedItem;

            lbTemperatureValueMim.Text = $"{currentCity.TemperatureMin} C°";
            lbTemperatureValueMax.Text = $"{currentCity.TemperatureMax} C°";
            lbPressureValueMin.Text = $"{currentCity.PressureMin} мм рт. ст.";
            lbPressureValueMax.Text = $"{currentCity.PressureMax} мм рт. ст.";
        }
    }
}
