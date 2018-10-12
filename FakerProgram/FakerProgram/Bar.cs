using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakerProgram
{
    [Serializable]
    public class Bar
    {

        public int IntValue { get; set; }

        public Int64 Int64Value { get; set; }

        public float FloatValue { get; set; }

        public ICollection<int> ICollectionValueInt { get; set; }

        public ICollection<DateTime> ICollectionValueDateTime { get; set; }

        public Foo FooValue { get; set; }

        public Bar BarValue { get; set; }
    }
}
