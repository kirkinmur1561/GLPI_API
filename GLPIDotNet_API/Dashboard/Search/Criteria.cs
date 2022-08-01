using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GLPIDotNet_API.Dashboard.Search
{
    public class Criteria
    {
        public Criteria(short field,
                        bool meta,
                        Type type,
                        ESeatchType searchtype,
                        string value)
        {
            this.field = field;
            this.meta = meta;
            this.itemtype = type.Name;
            this.searchtype = searchtype;
            this.value = value;
        }

        public Criteria(short field,
                        bool meta,
                        Type type,
                        ESeatchType searchtype,
                        ELink elink,
                        string value) :
            this(field, meta, type, searchtype, value) =>
            SetLink(elink);


        public void SetLink(ELink elink) =>
            link = GetELink(elink);

        private string GetELink(ELink eLink) => eLink switch
        {
            ELink.AND => "AND",
            ELink.OR => "OR",
            ELink.AND_NOT => "AND NOT",
            ELink.OR_NOT => "OR NOT",
        };

        public short field { get; } = 0;
        public bool meta { get; } = false;
        public string itemtype { get; } = string.Empty;
        public string link { get; private set; } = string.Empty;
        public ESeatchType searchtype { get; } 
        public string value { get; } = string.Empty;
        public enum ELink
        {
            AND,
            OR,
            AND_NOT,
            OR_NOT
        }

        public enum ESeatchType
        {
            contains,
            equals,
            notequals,
            lessthan, 
            morethan,
            under, 
            notunder
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public string RU_TranslateSearchType() => searchtype switch
        {
            ESeatchType.contains => "содержит",
            ESeatchType.equals => "равно",
            ESeatchType.notequals => "не равно",
            ESeatchType.lessthan => "меньше, чем",
            ESeatchType.morethan => "больше, чем",
            ESeatchType.under => "под",
            ESeatchType.notunder => "не ниже",
            _ => throw new NotImplementedException(),
        };

        /// <summary>
        /// Сборка адреса
        /// </summary>
        /// <param name="criterias"></param>
        /// <returns></returns>
        protected internal static string GetURI(IEnumerable<Criteria> criterias)
        {
            StringBuilder sb = new StringBuilder();
            for (int index = 0; index < criterias.Count(); index++)
            {
                Criteria criteria = criterias.ToArray()[index];
                var objs = criteria.GetType().GetProperties().Where(w =>
                {
                    if (index == 0 & w.Name == "link") return false;

                    object obj = w.GetValue(criteria);

                    if (obj is string & !string.IsNullOrEmpty(obj.ToString())) return true;
                    else if (obj is not string) return true;
                    else return false;
                })
                .Select(s =>
                string.Format(string.Format("criteria[{0}][{1}]={2}",
                                            index,
                                            s.Name.ToLower(),
                                            s.GetValue(criteria))));

                sb.Append(string.Join("&", objs));
                if (index + 1 < criterias.Count()) sb.Append("&");
            }
            return sb.ToString();
        }
    }
}
