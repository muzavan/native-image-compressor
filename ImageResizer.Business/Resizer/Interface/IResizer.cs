using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageResizer.Business.Resizer.Interface
{
    interface IResizer
    {
        bool Resize(string filePath, int quality = 100);
    }
}
