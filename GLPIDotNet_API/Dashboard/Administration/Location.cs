using GLPIDotNet_API.Dashboard.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace GLPIDotNet_API.Dashboard.Administration
{
    public class Location : Dashboard<Location>, IEquatable<Location>,IComparer<string>
    {
        public Location()
        {

        }
        public string completename { get; set; }
        public int level { get; set; }
        public string ancestors_cache { get; set; }
        public string sons_cache { get; set; }
        public string address { get; set; }
        public string postcode { get; set; }
        public string town { get; set; }
        public string state { get; set; }
        public string country { get; set; }
        public string building { get; set; }
        public string room { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
        public object altitude { get; set; }

        public override bool Equals(object obj)
        {
            return Equals(obj as Location);
        }

        public bool Equals(Location other)
        {
            return other != null &&
                   Id == other.Id &&
                   IdEntities == other.IdEntities &&
                   IsRecursive == other.IsRecursive &&
                   Name == other.Name &&
                   Comment == other.Comment &&
                   IdLocations == other.IdLocations &&
                   IdUsersTech == other.IdUsersTech &&
                   IdGroupsTech == other.IdGroupsTech &&
                   IdManufacturers == other.IdManufacturers &&
                   IsDeleted == other.IsDeleted &&
                   IsTemplate == other.IsTemplate &&
                   TemplateName == other.TemplateName &&
                   DateMod == other.DateMod &&
                   IdUsers == other.IdUsers &&
                   IdGroups == other.IdGroups &&
                   TicketTco == other.TicketTco &&
                   DateCreation == other.DateCreation &&
                   completename == other.completename &&
                   level == other.level &&
                   ancestors_cache == other.ancestors_cache &&
                   sons_cache == other.sons_cache &&
                   address == other.address &&
                   postcode == other.postcode &&
                   town == other.town &&
                   state == other.state &&
                   country == other.country &&
                   building == other.building &&
                   room == other.room &&
                   latitude == other.latitude &&
                   longitude == other.longitude;

        }

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(Id);
            hash.Add(IdEntities);
            hash.Add(IsRecursive);
            hash.Add(Name);
            hash.Add(Comment);
            hash.Add(IdLocations);
            hash.Add(IdUsersTech);
            hash.Add(IdGroupsTech);
            hash.Add(IdManufacturers);
            hash.Add(IsDeleted);
            hash.Add(IsTemplate);
            hash.Add(TemplateName);
            hash.Add(DateMod);
            hash.Add(IdUsers);
            hash.Add(IdGroups);
            hash.Add(TicketTco);
            hash.Add(DateCreation);
            hash.Add(completename);
            hash.Add(level);
            hash.Add(ancestors_cache);
            hash.Add(sons_cache);
            hash.Add(address);
            hash.Add(postcode);
            hash.Add(town);
            hash.Add(state);
            hash.Add(country);
            hash.Add(building);
            hash.Add(room);
            hash.Add(latitude);
            hash.Add(longitude);
            return hash.ToHashCode();
        }

        public int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }

        public static bool operator ==(Location left, Location right)
        {
            return EqualityComparer<Location>.Default.Equals(left, right);
        }

        public static bool operator !=(Location left, Location right)
        {
            return !(left == right);
        }

        public int Compare(string x, string y)
        {
            int l;
            int r;
            if (int.TryParse(x, out l))
            {
                if (int.TryParse(y, out r)) return l == r ? 0 : l < r ? -1 : 1;
                return -1;
            }

            if (int.TryParse(y, out r)) return 1;
            return 0;
        }  
       
    }

   

    public class LocationCreator:ICreator<Location>
    {
        
        private List<Location> _selectedPoint = new List<Location>();        
        public readonly IEnumerable<Location> WorkCollection;

        public LocationCreator(IEnumerable<Location> locations) =>
            WorkCollection = locations;
        
        public IEnumerable<Location> SelectedPoint()
        {
            return null;
        }

        public bool Append(Location item)
        {
            return true;
        }

        public int Remove(Location item)
        {
            return 0;
        }

        // public IEnumerable<Location> GetSubLevel()
        // {
        //     if (_selectedPoint.Count() == 0)
        //         return WorkCollection.Select(s =>
        //             {
        //                 if (string.IsNullOrEmpty(s.building))
        //                     s.building = "Другое";
        //                 if (Regex.IsMatch(s.building, "0[0-9]"))
        //                     s.building = s.building.Replace("0", "");
        //                 return s;
        //             })
        //             .OrderBy(ob => ob.building, new Location());
        //     
        // }
    }
}
