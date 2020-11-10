using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace TMBlazor.Module.BusinessObjects
{
    [DefaultClassOptions]
    [NavigationItem("Słowniki")]
    [DefaultProperty(nameof(Jednostka))]
    public class JednostkaMiary : XPObject
    {
        public JednostkaMiary(Session session) : base(session)
        { }


        string jednostka;

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Jednostka
        {
            get => jednostka;
            set => SetPropertyValue(nameof(Jednostka), ref jednostka, value);
        }
    }
}
