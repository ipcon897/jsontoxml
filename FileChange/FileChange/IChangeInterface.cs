using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ChangeWindows
{
    interface IChangeInterface
    {
        Task Writer();

        Task Reader();

        Task Change();
    }
}
