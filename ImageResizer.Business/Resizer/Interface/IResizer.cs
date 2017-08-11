using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageCompressor.Business.Resizer.Interface
{
    interface ICompressor
    {
        string Resize(string filePath, int quality = 100);
    }
}
