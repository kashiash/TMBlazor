using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace TMBlazor.Module.BusinessObjects
{
    [DefaultClassOptions]
    [NavigationItem("Kartoteki pomocnicze")]
    [DefaultProperty(nameof(Nazwa))]

    public class Produkt : XPObject
    {
        public Produkt(Session session) : base(session)
        { }


        StawkaVat stawka;
        JednostkaMiary jednostka;
        string uwagi;
        decimal cenaSprzedazy;
        string nazwa;

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Nazwa
        {
            get => nazwa;
            set => SetPropertyValue(nameof(Nazwa), ref nazwa, value);
        }

        public decimal CenaSprzedazy
        {
            get => cenaSprzedazy;
            set => SetPropertyValue(nameof(CenaSprzedazy), ref cenaSprzedazy, value);
        }



        public JednostkaMiary Jednostka
        {
            get => jednostka;
            set => SetPropertyValue(nameof(Jednostka), ref jednostka, value);
        }



        public StawkaVat Stawka
        {
            get => stawka;
            set => SetPropertyValue(nameof(Stawka), ref stawka, value);
        }

        [Size(SizeAttribute.Unlimited)]
        public string Uwagi
        {
            get => uwagi;
            set => SetPropertyValue(nameof(Uwagi), ref uwagi, value);
        }
    }
}
