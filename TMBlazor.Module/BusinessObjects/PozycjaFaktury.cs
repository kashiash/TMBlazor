using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using DevExpress.XtraExport.Xls;
using System;
using System.Collections.Generic;
using System.Text;

namespace TMBlazor.Module.BusinessObjects
{
    [DefaultClassOptions]
    public class PozycjaFaktury : XPObject
    {
        public PozycjaFaktury(Session session) : base(session)
        { }



        Faktura faktura;
        decimal wartoscVat;
        decimal wartoscBrutto;
        decimal wartoscNetto;
        decimal cenaJednostkowa;
        decimal ilosc;
        Produkt produkt;

        public Produkt Produkt
        {
            get => produkt;
            set
            {
                bool modified = SetPropertyValue(nameof(Produkt), ref produkt, value);
                if (modified && !IsLoading && !IsSaving && value != null)
                {

                    CenaJednostkowa = Produkt.CenaSprzedazy;
                    PrzeliczWartoscPozycji();
                }
            }
        }

        private void PrzeliczWartoscPozycji()
        {
            WartoscNetto = CenaJednostkowa * Ilosc;
            if (Produkt != null && Produkt.Stawka != null)
            {
                WartoscBrutto = WartoscNetto * (1 + Produkt.Stawka.Wartosc / 100);
            }
            WartoscVat = WartoscBrutto - WartoscNetto;

            if (Faktura != null)
            {
                Faktura.WyliczSumyFaktury(true);
            }
        }

        public decimal Ilosc

        {
            get => ilosc;
            set
            {
                var modified = SetPropertyValue(nameof(Ilosc), ref ilosc, value);
                if (modified && !IsLoading && !IsSaving)
                {
                    PrzeliczWartoscPozycji();
                }
            }
        }



        [Association]
        public Faktura Faktura
        {
            get => faktura;
            set
            {
                var modified = SetPropertyValue(nameof(Faktura), ref faktura, value);

            }
        }

        public decimal CenaJednostkowa

        {
            get => cenaJednostkowa;
            set => SetPropertyValue(nameof(CenaJednostkowa), ref cenaJednostkowa, value);
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


        public override void AfterConstruction()
        {
            base.AfterConstruction();
            Ilosc = 1;
        }

        protected override void OnSaving()
        {
            base.OnSaving();
        }
    }
}
