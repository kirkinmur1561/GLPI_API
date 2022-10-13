using System.Collections.Generic;
using GLPIDotNet_API.Dashboard.Administration;

namespace GLPIDotNet_API.Dashboard.Common
{
    public interface ICreatorCategory:ICreator<ITILCategory>
    {
        int StartLevelDefault { get; set; }
        int Remove(int level);
        IEnumerable<ITILCategory> GetSubLevel();
    }
}