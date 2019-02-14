using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson7_WeatherApp
{
    class Repository
    {
        private List<City> db = new List<City>();
        Random rand = new Random(100);

        public List<City> Cities { get => db; }

        public Repository()
        {
            for (int i = 0; i < 20; i++)
            {
                db.Add(new City()
                {
                    Name = $"Город_{i + 1}",
                    TemperatureMin = rand.Next(10, 14),
                    TemperatureMax = rand.Next(14, 19),
                    PressureMin = rand.Next(720, 745),
                    PressureMax = rand.Next(745, 760)
                });
            }
        }

        public void Print()
        {
            foreach (var item in db)
            {
                Debug.WriteLine(item.Print());
            }
        }
    }
}
