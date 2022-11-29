using GLPIDotNet_API.Dashboard.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Newtonsoft.Json;

namespace GLPIDotNet_API.Dashboard.Administration
{
    public class Location : Dashboard<Location>, IEquatable<Location>,IComparer<string>
    {
        public Location()
        {

        }
        
        [JsonProperty("completename")]
        public string CompleteName { get; set; }
        
        [JsonProperty("level")]
        public int Level { get; set; }
        
        [JsonProperty("ancestors_cache")]
        public string CacheAncestors { get; set; }
        
        [JsonProperty("sons_cache")]
        public string CacheSons { get; set; }
        
        [JsonProperty("address")]
        public string Address { get; set; }
        
        [JsonProperty("postcode")]
        public string Postcode { get; set; }
        
        [JsonProperty("town")]
        public string Town { get; set; }
        
        [JsonProperty("state")]
        public string State { get; set; }
        
        [JsonProperty("country")]
        public string Country { get; set; }
        
        [JsonProperty("building")]
        public string Building { get; set; }
        
        [JsonProperty("room")]
        public string Room { get; set; }
        
        [JsonProperty("latitude")]
        public string Latitude { get; set; }
        
        [JsonProperty("longitude")]
        public string Longitude { get; set; }
        
        [JsonProperty("altitude")]
        public object Altitude { get; set; }

        public override bool Equals(object obj)
        {
            return Equals(obj as Location);
        }

        public bool Equals(Location other)
        {
            return other != null &&
                   Id == other.Id &&
                   IdEntity == other.IdEntity &&
                   IsRecursive == other.IsRecursive &&
                   Name == other.Name &&
                   Comment == other.Comment &&
                   IdLocation == other.IdLocation &&
                   IdUsersTech == other.IdUsersTech &&
                   IdGroupsTech == other.IdGroupsTech &&
                   IdManufacturer == other.IdManufacturer &&
                   IsDeleted == other.IsDeleted &&
                   IsTemplate == other.IsTemplate &&
                   TemplateName == other.TemplateName &&
                   DateMod == other.DateMod &&
                   IdUser == other.IdUser &&
                   IdGroup == other.IdGroup &&
                   TicketTco == other.TicketTco &&
                   DateCreation == other.DateCreation &&
                   CompleteName == other.CompleteName &&
                   Level == other.Level &&
                   CacheAncestors == other.CacheAncestors &&
                   CacheSons == other.CacheSons &&
                   Address == other.Address &&
                   Postcode == other.Postcode &&
                   Town == other.Town &&
                   State == other.State &&
                   Country == other.Country &&
                   Building == other.Building &&
                   Room == other.Room &&
                   Latitude == other.Latitude &&
                   Longitude == other.Longitude;

        }

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(Id);
            hash.Add(IdEntity);
            hash.Add(IsRecursive);
            hash.Add(Name);
            hash.Add(Comment);
            hash.Add(IdLocation);
            hash.Add(IdUsersTech);
            hash.Add(IdGroupsTech);
            hash.Add(IdManufacturer);
            hash.Add(IsDeleted);
            hash.Add(IsTemplate);
            hash.Add(TemplateName);
            hash.Add(DateMod);
            hash.Add(IdUser);
            hash.Add(IdGroup);
            hash.Add(TicketTco);
            hash.Add(DateCreation);
            hash.Add(CompleteName);
            hash.Add(Level);
            hash.Add(CacheAncestors);
            hash.Add(CacheSons);
            hash.Add(Address);
            hash.Add(Postcode);
            hash.Add(Town);
            hash.Add(State);
            hash.Add(Country);
            hash.Add(Building);
            hash.Add(Room);
            hash.Add(Latitude);
            hash.Add(Longitude);
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
