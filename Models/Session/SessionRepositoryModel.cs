using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM.Models.Session
{
    public class SessionRepositoryModel
    {
        public List<SessionModel> SessionRepo { get; set; }
        public List<vu_mapping> Mapping { get; set; }
    }
}
