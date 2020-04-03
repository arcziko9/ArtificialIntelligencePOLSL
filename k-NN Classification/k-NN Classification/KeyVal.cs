using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace k_NN_Classification
{
    public class KeyVal<Key, Val>
    {
        public Key Name { get; set; }
        public Val Value { get; set; }

        public KeyVal() { }

        public KeyVal(Key key, Val val)
        {
            this.Name = key;
            this.Value = val;
        }
    }
}
