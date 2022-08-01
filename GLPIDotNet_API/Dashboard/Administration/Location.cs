using GLPIDotNet_API.Dashboard.Common;
using System;
using System.Collections.Generic;

namespace GLPIDotNet_API.Dashboard.Administration
{
    public class Location : Dashboard<Location>, IEquatable<Location>
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

        public static bool operator ==(Location left, Location right)
        {
            return EqualityComparer<Location>.Default.Equals(left, right);
        }

        public static bool operator !=(Location left, Location right)
        {
            return !(left == right);
        }
    }
}
