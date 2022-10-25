using System;
using System.Collections.Generic;

namespace Recipes {
    public class CerealBowl : Recipe {

        Plate _bowl = null;
        int _milkMil = 0;
        int _cerealGr = 0;

        public CerealBowl(Plate bowl, int milkMilliliters, int cerealGrams)
        {
            _bowl = bowl;
            _milkMil = milkMilliliters;
            _cerealGr = cerealGrams;
        }

        public void Cook (Appliance microwave, bool heat) 
        {
            Liquid milk = new Milk(_milkMil);
            _bowl.Add(milk);
            if (heat) 
            {
                microwave.Add(_bowl);
                microwave.Heat(minutes: _milkMil / 150);
                microwave.OnDone += AddCereal;
                return;
            }

            AddCereal();
        }

        private void AddCereal() 
        {
            _bowl.Add(new Cereal(_cerealGr));
            Finish();
        }
    }
}
