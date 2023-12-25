using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmController.Core.Models
{
    public class WaterFlowModel
    {
        public float Flow { get; private set; }

        public WaterFlowModel(float flow)
        {
            Flow = flow;
        }
    }
}
