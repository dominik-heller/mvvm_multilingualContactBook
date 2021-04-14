using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactBook.Helper
{
    public interface IEventHandler
    {
        event EventHandler<String> ViewChange;

        void OnViewChanged(string s);
        
    }
}
