using System;
using System.Collections.Generic;

namespace Recipes {
    public class Fries : Recipe {

        Plate _plate = null;
        List<Potato> _potatoes = new List<Potato>();
        int _finishedFries = 0;

        public Fries(Plate plate, int numPotatoes) 
        {
            _plate = plate;

            for (int i = 0; i < numPotatoes; ++i) 
            {
                _potatoes.Add(new Potato());
            }
        }
        
        public Fries(Plate plate, float grams) 
        {
            _plate = plate;

            int numPotatoes = grams / 350f; // Average potatoe weighs around 350g
            for (int i = 0; i < numPotatoes; ++i) 
            {
                _potatoes.Add(new Potato());
            }
        }

        public void Cook(Appliance frier, Liquid oil, Cutlery spoon, Cutlery knife) 
        {
            int wholePotatoes = _potatoes.Count;
            _finishedFries = 0;

            PreparePotatoes();
            
            frier.Add(spoon.Take(oil, wholePotatoes * 3));
            for (int i = 0; i < _potatoes.Count; ++i) {
                frier.Add(_potatoes[i]);            
            }

            frier.OnFoodDone += TakePotatoesOut;
        }

        private void PreparePotatoes(Cutlery knife) 
        {
            for (int i = _potatoes.Count - 1; i >= 0; --i) 
            {
                Potato p = _potatoes[i];
                p.Peel(knife);
                p.Cut(Axis.Z, 3, knife);
                p.Cut(Axis.Y, 3, knife);
                _potatoes.RemoveAt(i);
                _potatoes.AddRange(p.GetPieces());
            }
        }

        public void TakePotatoesOut(Appliance frier, int foodIndex) 
        {
            _plate.Add(frier.Remove(foodIndex));
            ++_finishedFries;

            if (_finishedFries >= _potatoes.Count) 
            {
                Finish();
            }
        }
    }

}
