using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace TMBlazor.Module.BusinessObjects
{
    [DefaultClassOptions]
    [DefaultProperty(nameof(Symbol))]
    public class StawkaVat : XPObject
    {
        public StawkaVat(Session session) : base(session)
        { }



        decimal wartosc;
        string symbol;

        [Size(5)]
        public string Symbol
        {
            get => symbol;
            set => SetPropertyValue(nameof(Symbol), ref symbol, value);
        }


        public decimal Wartosc
        {
            get => wartosc;
            set => SetPropertyValue(nameof(Wartosc), ref wartosc, value);
        }
    }
}
