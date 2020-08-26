using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ThunderBoltStore.ViewModels
{
    public class OperationalListBase
    {
        public bool ShowOperationSuccessful { get; set; }
        public bool ShowOperationFail { get; set; }

        public String LastOperation { get; set; }
    }
}
