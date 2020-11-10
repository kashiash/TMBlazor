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
    [DefaultProperty(nameof(NrFaktury))]
    public class Faktura : XPObject
    {
        public Faktura(Session session) : base(session)
        { }


        DateTime dataSprzedazy;
        decimal wartoscVat;
        decimal wartoscBrutto;
        decimal wartoscNetto;
        Klient klient;

        DateTime dataFaktury;
        string nrFaktury;

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string NrFaktury
        {
            get => nrFaktury;
            set => SetPropertyValue(nameof(NrFaktury), ref nrFaktury, value);
        }


        public DateTime DataFaktury
        {
            get => dataFaktury;
            set => SetPropertyValue(nameof(DataFaktury), ref dataFaktury, value);
        }


        
        public DateTime DataSprzedazy

        {
            get => dataSprzedazy;
            set => SetPropertyValue(nameof(DataSprzedazy), ref dataSprzedazy, value);
        }



        [Association("Klient-Faktury")]
        public Klient Klient
        {
            get => klient;
            set => SetPropertyValue(nameof(Klient), ref klient, value);
        }



        public decimal WartoscNetto
        {
            get => wartoscNetto;
            set => SetPropertyValue(nameof(WartoscNetto), ref wartoscNetto, value);
        }

        public decimal WartoscBrutto
        {
            get => wartoscBrutto;
            set => SetPropertyValue(nameof(WartoscBrutto), ref wartoscBrutto, value);
        }

        public decimal WartoscVat
        {
            get => wartoscVat;
            set => SetPropertyValue(nameof(WartoscVat), ref wartoscVat, value);
        }

      [Association,Aggregated]
        public XPCollection<PozycjaFaktury> PozycjeFaktury
        {
            get
            {
                return GetCollection<PozycjaFaktury>(nameof(PozycjeFaktury));
            }
        }

        public override void AfterConstruction()
        {
            base.AfterConstruction();
            DataFaktury  = DateTime.Now;
            DataSprzedazy = DateTime.Now;
        }

        public void WyliczSumyFaktury(bool forceChangeEvents)
        {
            decimal? oldWkwotaNetto = wartoscNetto;
            decimal? oldWkwotaVAT = wartoscVat;
            decimal? oldWkwotaBrutto = wartoscBrutto;


            decimal kwotaNettoTotal = 0m;
            decimal kwotaVATTotal = 0m;
            decimal kwotaBruttoTotal = 0m;

            foreach (var detail in PozycjeFaktury)
            {
                kwotaBruttoTotal += detail.WartoscBrutto;
                kwotaNettoTotal += detail.WartoscNetto;
                kwotaVATTotal += detail.WartoscVat;
            }
            wartoscBrutto = kwotaBruttoTotal;
            wartoscNetto = kwotaNettoTotal;
            wartoscVat = kwotaVATTotal;

            if (forceChangeEvents)
            {
                OnChanged(nameof(WartoscBrutto), oldWkwotaBrutto, wartoscBrutto);
                OnChanged(nameof(WartoscNetto), oldWkwotaNetto, wartoscNetto);
                OnChanged(nameof(WartoscVat), oldWkwotaVAT, wartoscVat);
            }

        }
    }
}
