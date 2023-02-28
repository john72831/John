using Cocona;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace John.Cocona
{
    class MyCommand
    {
        public void Command() {  }

        [Command("commandname")]
        public void Command2() {  }
    }
}
