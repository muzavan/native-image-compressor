using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageResizer.Business.Resizer.Interface
{
    interface IResizer
    {
        string Resize(string filePath, int quality = 100);
    }
}
