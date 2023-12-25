using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmController.Core.Models
{
    public class MilkTemperatureModel
    {
        public float Temperature { get; private set; }

        public MilkTemperatureModel(float temperature)
        {
            Temperature = temperature;
        }
    }
}
