using System;
using System.Collections.Generic;

namespace Recipes {
    public class RiceAndSausages : Recipe {

        Plate _plate = null;
        List<RiceAndSausages> _sausages = new List<Sausages>();

        int _riceGrams = 0;
        bool _riceDone = false;
        bool _sausagesDone = false;

        public RiceAndSausages(Plate plate, float riceGrams, int sausageNumber) {
            _plate = plate;
            _riceGrams = riceGrams;

            // Gather ingredients
            for (int i = 0; i < sausageNumber; ++i) {
                _sausages.Add(new Sausage());
            }
        }

        public void Cook(Appliance riceMaker, Appliance pan, Liquid oil, Cutlery spoon, Cutlery fork) {
            riceMaker.Add(new Rice(_riceGrams));
            riceMaker.Cook();
            riceMaker.OnDone += TakeRiceOut;

            Liquid oilForSausages = spoon.Take(oil, 1);
            pan.Add(oilForSausages);
            for (int i = 0; i < _sausages.Count; ++i) {
                pan.Add(_sausages[i]);            
            }

            pan.OnFoodDone += TakeSausagesOut;
        }

        private void TakeRiceOut(Appliance riceMaker) {
            _plate.Add(riceMaker.Empty());
            _riceDone = true;

            if (_sausagesDone) {
                Finish();
            }
        }

        public void TakeSausagesOut(Appliance pan, int foodIndex) {
            _plate.Add(pan.Remove(foodIndex));
            _plate.Add(_breadSlices.Pop());
            _sausagesDone = true;
            
            if (_riceDone) {
                Finish();
            }
        }
    }
}