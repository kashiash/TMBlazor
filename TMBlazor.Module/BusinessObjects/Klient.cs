using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace TMBlazor.Module.BusinessObjects
{

    [DefaultClassOptions]
    [NavigationItem("Kartoteki")]
    [DefaultProperty(nameof(Nazwa))]
    public class Klient : XPObject
    {

        public Klient(Session session) : base(session)
        { }



        string uwagi;
        string adres;
        string nIP;
        string nazwa;

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Nazwa
        {
            get => nazwa;
            set => SetPropertyValue(nameof(Nazwa), ref nazwa, value);
        }

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string NIP
        {
            get => nIP;
            set => SetPropertyValue(nameof(NIP), ref nIP, value);
        }


        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Adres
        {
            get => adres;
            set => SetPropertyValue(nameof(Adres), ref adres, value);
        }

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Uwagi
        {
            get => uwagi;
            set => SetPropertyValue(nameof(Uwagi), ref uwagi, value);
        }



        [Association("Klient-Faktury"), Aggregated]
        public XPCollection<Faktura> Faktury
        {
            get
            {
                return GetCollection<Faktura>(nameof(Faktury));
            }
        }
    }
}
