using System;
using System.Collections.Generic;
using System.Linq;
using GLPIDotNet_API.Dashboard.Common;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace GLPIDotNet_API.Dashboard.Administration
{
    public class ITILCategory : Dashboard<ITILCategory>, IEquatable<ITILCategory>
    {
        public ITILCategory()
        {

        }

        [JsonProperty("itilcategories_id")]
        public string IdItilCategory { get; set; }

        [JsonProperty("knowbaseitemcategories_")]
        public long? IdKnowBaseItemCategory { get; set; }

        [JsonProperty("level")]
        public int? Level { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("ancestors_cache")]
        public string AncestorsCache { get; set; }

        [JsonProperty("sons_cache")]
        public string SonsCache { get; set; }

        [JsonProperty("is_helpdeskvisible")]
        public bool? IsHelpDeskVisible { get; set; }

        [JsonProperty("tickettemplates_id_incident")]
        public string IdTicketTemplatesIncident { get; set; }

        [JsonProperty("tickettemplates_id_demand")]
        public string IdTicketTemplatesDemand { get; set; }

        [JsonProperty("changetemplates_id")]
        public string IdChangeTemplates { get; set; }

        [JsonProperty("problemtemplates_id")]
        public string IdProblemTemplates { get; set; }

        [JsonProperty("is_incident")]
        public bool? IsIncident { get; set; }

        [JsonProperty("is_request")]
        public bool? IsRequest { get; set; }

        [JsonProperty("is_problem")]
        public bool? IsProblem { get; set; }

        [JsonProperty("is_change")]
        public bool? IsChange { get; set; }

        public bool Equals(ITILCategory other) =>
            GetHashCode() == other.GetHashCode();


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
            hash.Add(TicketTco);
            hash.Add(DateCreation);
            hash.Add(IdItilCategory);
            hash.Add(IdKnowBaseItemCategory);
            hash.Add(Level);
            hash.Add(Code);
            hash.Add(AncestorsCache);
            hash.Add(SonsCache);
            hash.Add(IsHelpDeskVisible);
            hash.Add(IdTicketTemplatesIncident);
            hash.Add(IdTicketTemplatesDemand);
            hash.Add(IdChangeTemplates);
            hash.Add(IdProblemTemplates);
            hash.Add(IsIncident);
            hash.Add(IsRequest);
            hash.Add(IsProblem);
            hash.Add(IsChange);
            return hash.ToHashCode();
        }

        public static IEnumerable<ITILCategory> GetLevel_1(IEnumerable<ITILCategory> items) =>
            items.Where(w => w.Level == 1);

        public static IEnumerable<ITILCategory> GetSubLevel(IEnumerable<ITILCategory> items,ITILCategory item,int level)
        {
            if (item.SonsCache.Length < 4) return new List<ITILCategory>();
            var data = JsonSerializer.Deserialize<Dictionary<string, object>>(item
                .SonsCache).Skip(1).Select(s => s.Value.ToString());

            return items.Where(w => w.Level == level && data.Contains(w.Id.ToString()));
        }

        public static bool operator ==(ITILCategory left, ITILCategory right)
        {
            return EqualityComparer<ITILCategory>.Default.Equals(left, right);
        }

        public static bool operator !=(ITILCategory left, ITILCategory right)
        {
            return !(left == right);
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as ITILCategory);
        }
    }

    public sealed class ITILCategoryCreator:ICreatorCategory
    {         
        private List<ITILCategory> _selectedPoint = new List<ITILCategory>();        
        public readonly IEnumerable<ITILCategory> WorkCollection;
        public int StartLevelDefault { get; set; } = 1;
        
        public IEnumerable<ITILCategory> SelectedPoint() => 
            _selectedPoint;

        public bool Append(ITILCategory category)
        {
            if (_selectedPoint.Contains(category)) return false;
            if (_selectedPoint.Select(s => s.Level).Contains(category.Level))
            {
                Remove(category.Level ?? 1);
                _selectedPoint.Add(category);
            }
            else _selectedPoint.Add(category);
        
            return true;
        }

        public int Remove(ITILCategory category) =>
            Remove(category.Level ?? StartLevelDefault);        
        
        public int Remove(int level) =>
            _selectedPoint.RemoveAll(r => r.Level >= level);       

        public IEnumerable<ITILCategory> GetSubLevel()
        {
            if (_selectedPoint.Count == 0) return WorkCollection.Where(w => w.Level == StartLevelDefault);            
            ITILCategory _last = _selectedPoint!.LastOrDefault();
            
            if (_last!.SonsCache.Length < 4) return new List<ITILCategory>();
            
            var data = JsonSerializer.Deserialize<Dictionary<string, object>>(_last
                .SonsCache).Skip(1).Select(s => s.Value.ToString());
        
            return WorkCollection.Where(w => w.Level == _last.Level + 1 && data.Contains(w.Id.ToString()));
        }

        public ITILCategoryCreator(IEnumerable<ITILCategory> categories) =>
            WorkCollection = categories;
        
        public override string ToString() =>
            string.Join(" > ", _selectedPoint.Select(s => s.Name));        
        
        public string[] Selected()=>string.Join("\n", _selectedPoint.Select(s =>
        {
            if (GetSubLevel()?.Count() > 0) return s.Name + " > ";
            return s.Name;
        })).Split("\n");
        
        public string[] Position(IEnumerable<ITILCategory> categories) => categories.Select(s =>
        {
            if (s.SonsCache.Length < 4) return s.Name;
            var data = JsonSerializer.Deserialize<Dictionary<string, object>>(s
                .SonsCache)?.Skip(1).Select(s2 => s2.Value.ToString());
            if (data?.Count() > 0) return s.Name + " > ";
            return s.Name;
            // if (GetSubLevel()?.Count() > 0) return s.Name + " > ";
            // return s.Name;
        }).ToArray();
        
        // var vats = await ITILCategory.GetEnumerable(client);
        // ITILCategoryCreator creator = new ITILCategoryCreator(vats);
        //
        //     while (true)
        // {
        //     if (creator.SelectedPoint().Count() != 0)
        //         Console.WriteLine("You position: " + string.Join(" ", creator.Selected()));
        //     ITILCategory[] l1 = creator.GetSubLevel().ToArray();
        //     string[] p1 = creator.Position(l1);
        //     if (p1.Length == 0) break;
        //     Console.WriteLine($"Select point:\n{string.Join("\n", p1)}");
        //     int val = Convert.ToInt32(Console.ReadLine())-1;
        //     creator.Append(l1[val]);
        // }
        //
        // Console.WriteLine("You select: " + creator);
    }
}
