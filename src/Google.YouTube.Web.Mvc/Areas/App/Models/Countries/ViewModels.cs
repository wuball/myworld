using System.Collections.Generic;

namespace Google.YouTube.Web.Areas.App.Models.Countries
{
    public class ViewModels
    {
    }






















    public class Bar
    {
        public string Official { get; set; }
        public string Common { get; set; }
    }

    public class Currencies
    {
        public EUR EUR { get; set; }
    }

    public class Cym
    {
        public string Official { get; set; }
        public string Common { get; set; }
    }

    public class Demonyms
    {
        public Fra Fra { get; set; }
        public Spa Spa { get; set; }
    }

    public class Deu
    {
        public string Official { get; set; }
        public string Common { get; set; }
    }

    public class EUR
    {
        public string Name { get; set; }
        public string Symbol { get; set; }
    }

    public class Fra
    {
        public string Official { get; set; }
        public string Common { get; set; }
        public string F { get; set; }
        public string M { get; set; }
    }

    public class Hrv
    {
        public string Official { get; set; }
        public string Common { get; set; }
    }

    public class Idd
    {
        public string Root { get; set; }
        public List<string> Suffixes { get; set; }
    }

    public class Ita
    {
        public string Official { get; set; }
        public string Common { get; set; }
    }

    public class Jpn
    {
        public string Official { get; set; }
        public string Common { get; set; }
    }

    public class Languages
    {
        public string Eng { get; set; }
    }

    public class Name
    {
        public string Common { get; set; }
        public string Official { get; set; }
        public Native Native { get; set; }
    }

    public class Native
    {
        public Bar Bar { get; set; }
    }

    public class Nld
    {
        public string Official { get; set; }
        public string Common { get; set; }
    }

    public class Por
    {
        public string Official { get; set; }
        public string Common { get; set; }
    }

    public class CountryJson
    {
        public Name Name { get; set; }
        public List<string> Tld { get; set; }
        public string Cca2 { get; set; }
        public string Ccn3 { get; set; }
        public string Cca3 { get; set; }
        public string Cioc { get; set; }
        public bool Independent { get; set; }
        public string Status { get; set; }
        public bool UnMember { get; set; }
        public Currencies Currencies { get; set; }
        public Idd Idd { get; set; }
        public List<string> Capital { get; set; }
        public List<string> AltSpellings { get; set; }
        public string Region { get; set; }
        public string Subregion { get; set; }
        public Languages Languages { get; set; }
        public Translations Translations { get; set; }
        public List<double> Latlng { get; set; }
        public Demonyms Demonyms { get; set; }
        public bool Landlocked { get; set; }
        public List<string> Borders { get; set; }
        public int Area { get; set; }
        public List<string> CallingCodes { get; set; }
        public string Flag { get; set; }
    }

    public class Rus
    {
        public string Official { get; set; }
        public string Common { get; set; }
    }

    public class Spa
    {
        public string Official { get; set; }
        public string Common { get; set; }
        public string F { get; set; }
        public string M { get; set; }
    }

    public class Translations
    {
        public Cym Cym { get; set; }
        public Deu Deu { get; set; }
        public Fra Fra { get; set; }
        public Hrv Hrv { get; set; }
        public Ita Ita { get; set; }
        public Jpn Jpn { get; set; }
        public Nld Nld { get; set; }
        public Por Por { get; set; }
        public Rus Rus { get; set; }
        public Spa Spa { get; set; }
    }


}
