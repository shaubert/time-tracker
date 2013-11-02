using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public interface ProjectGroupSerializer
    {
        void Serialize(ProjectGroup projectGroup, String fileName);
        ProjectGroup Deserialize(String fileName);
    }
}
