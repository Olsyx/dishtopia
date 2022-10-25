using System;
using System.Collections.Generic;

namespace Recipes {
    public class FriedEgg : Recipe {

        Plate _plate = null;
        List<Egg> _eggs = new List<Egg>();
        Stack<Bread> _breadSlices = new Stack<Bread>();
        List<Spice> _spices = new List<Spice>();

        public FriedEgg(Plate plate, int eggNumber) {
            _plate = plate;

            // Gather ingredients
            for (int i = 0; i < eggNumber; ++i) {
                _eggs.Add(new Egg());
                _breadSlices.Push(new Bread());
            }

            _spices.Add(new Salt());
            _spices.Add(new Pepper());
        }

        public void Cook(Appliance pan, Liquid oil, Cutlery spoon) {
            Liquid oilForEggs = spoon.Take(oil, 3);
            pan.Add(oilForEggs);

            for (int i = 0; i < _eggs.Count; ++i) {
                _eggs[i].Crack();
                pan.Add(_eggs[i]);            
            }

            pan.OnFoodDone += PutInPlate;
        }
        
        public void PutInPlate(Appliance pan, int foodIndex) {
            Egg friedEgg = pan.Remove(foodIndex);

            for (int i = 0; i < _spices.Count; ++i) {
                egg.Add(_spices.Get("pinch"));
            }
            
            _plate.Add(friedEgg);
            _plate.Add(_breadSlices.Pop());

            if (_breadSlices.Count <= 0) {
               Finish();
            }
        }
    }
}