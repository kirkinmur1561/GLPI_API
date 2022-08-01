using GLPIDotNet_API.Base;
using GLPIDotNet_API.Dashboard.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GLPIDotNet_API.Dashboard.Assets
{
    public class Track<T> where T : Dashboard<T>
    {
        public List<T> Tracks { get; set; }
        public GlpiBase G { get; private set; }
        public Track(GlpiBase g)
        {
            Tracks = new List<T>();
            G = g;
            
        }

        public async void Tracking() => await Task.Run(() => 
        {
            while (true)
            {

            }
        });
    }
}
