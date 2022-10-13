using System.Collections.Generic;

namespace GLPIDotNet_API.Dashboard.Common
{
    public interface ICreator<TD>
    {
        IEnumerable<TD> SelectedPoint();
        bool Append(TD item);
        int Remove(TD item);
    }
}