using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson7_WeatherApp
{
    class City
    {
        public string Name { get; set; }
        public int TemperatureMin { get; set; }
        public int TemperatureMax { get; set; }
        public int PressureMin { get; set; }
        public int PressureMax { get; set; }

        public override string ToString()
        {
            return Name;
        }

        internal string Print()
        {
            return $"{Name, 10} :{TemperatureMin, 3} -{TemperatureMax, 3} C°, {PressureMin, 4} -{PressureMax, 4} мм рт. ст.";
        }
    }
}
