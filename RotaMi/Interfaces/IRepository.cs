using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotaMi.Interfaces
{
    interface IRepository<T>
    {
        void ReadData(out List<T> data);
        void WriteData(List<T> data);
        bool IsEmpty { get; set; }
    }
}
