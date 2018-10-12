using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakerProgram
{
    [Serializable]
    public class Foo
    {
        public Foo()
        {
        }

        public Foo(int intValue)
        {

        }

        public int IntValue { get; set; }

        public string StringValue { get; set; }

        public long LongValue { get; set; }

        public double DoubleValue { get; set; }

        public ICollection<DateTime> ICollectionValueDateTime { get; set; }

        public Foo FooValue { get; set; }

        public Bar BarValue { get; set; }
    }
}
