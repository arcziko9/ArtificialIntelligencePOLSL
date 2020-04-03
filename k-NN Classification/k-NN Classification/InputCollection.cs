using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace k_NN_Classification
{
    class InputCollection
    {
        private List<Object> objects = new List<Object>();

        public void AddObject(List<string> data)
        {
            objects.Add(
                new Object
                {
                    name = data.Last(),
                    parameters = RemoveLast(data).Select(Double.Parse).ToList()
                });;;
        }

        public List<Object> GetObjects()
        {
            return objects;
        }

        private List<string> RemoveLast(List<string> list)
        {
            list.RemoveAt(list.Count() - 1);
            return list;
        }
    }
}
