using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Graphics
{
    public interface IUserInterfaceManager
    {        
        void Initialize();
        void Update();
        void Render();
        void Dispose();
    }
}
