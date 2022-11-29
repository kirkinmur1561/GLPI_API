using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GLPIDotNet_API.Dashboard.Administration;
using GLPIDotNet_API.Dashboard.Helpdesk;

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
            itemtype = type.Name;
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
            ELink.Continue => "Continue",
            _ => throw new ArgumentOutOfRangeException(nameof(eLink), eLink, null)
        };

        public short field { get; set; } = 0;
        public bool meta { get; set;} = false;
        public string itemtype { get; set;} = string.Empty;
        public string link { get;  set; } = string.Empty;
        public ESeatchType searchtype { get; set;} 
        public string value { get; set;} = string.Empty;
        public enum ELink
        {
            AND,
            OR,
            AND_NOT,
            OR_NOT,
            Continue,
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
        public static string GetURI(IEnumerable<Criteria> criterias)
        {
            StringBuilder sb = new StringBuilder();
            Criteria[] criteriaArray = criterias.ToArray();
            for (int index = 0; index < criteriaArray.Length; index++)
            {
                Criteria criteria = criteriaArray[index];
                var objs = criteria.GetType().GetProperties().Where(w =>
                {
                    if (index == 0 & w.Name == "link") return false;

                    object obj = w.GetValue(criteria);

                    if (obj is string & !string.IsNullOrEmpty(obj?.ToString())) return true;
                    if (obj is not string) return true;
                    return false;
                })
                .Select(s =>
                string.Format(string.Format("criteria[{0}][{1}]={2}",
                                            index,
                                            s.Name.ToLower(),
                                            s.GetValue(criteria))));

                sb.Append(string.Join("&", objs));
                if (index + 1 < criteriaArray.Length) sb.Append("&");
            }
            return sb.ToString();
        }

        /// <summary>
        ///  Шаблон критейрий поиска по адресу
        /// </summary>
        /// <param name="value"></param>
        /// <param name="seatchType"></param>
        /// <param name="isMeta"></param>
        /// <returns></returns>
        public static Criteria Default_Address(string value = "", ESeatchType seatchType = ESeatchType.contains,
            bool isMeta = false, ELink link = ELink.Continue) => link == ELink.Continue
            ? new(101, isMeta, typeof(Location), seatchType, value)
            : new Criteria(101, isMeta, typeof(Location), seatchType, link, value);


        /// <summary>
        /// Шаблон критейрий поиска по статусу заявки
        /// </summary>
        /// <param name="status"></param>
        /// <param name="seatchType">For ticket only SeatchType.equals</param>
        /// <param name="isMeta"></param>
        /// <param name="link"></param>
        /// <returns></returns>
        public static Criteria Default_Status_Ticket(Ticket.EStatus status = Ticket.EStatus.New,
            ESeatchType seatchType = ESeatchType.equals,
            bool isMeta = false, ELink link = ELink.Continue) => link == ELink.Continue
            ? new Criteria(12, isMeta, typeof(Ticket), seatchType, $"{(int)status}")
            : new Criteria(12, isMeta, typeof(Ticket), seatchType, link, $"{(int)status}");

        /// <summary>
        /// myself парам не подходит!
        /// </summary>
        /// <returns></returns>
        public static Criteria Delault_Myself_Ticket(long my_id = 748) =>
            new Criteria(5, false, typeof(Ticket), ESeatchType.equals, $"{my_id}");

        /// <summary>
        /// Не работает!!!
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        public static IEnumerable<Criteria> Delault_Myself_Ticket_Status(long my_id = 748,Ticket.EStatus status = Ticket.EStatus.New) =>
            new[]
            {
                new Criteria(5, false, typeof(Ticket), ESeatchType.equals,$"{my_id}"),
                new Criteria(12, false, typeof(Ticket), ESeatchType.equals, ELink.AND, ((int)status).ToString())
            };

    }
}
