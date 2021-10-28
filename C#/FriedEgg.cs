
namespace Recipes {
    public class FriedEgg : Recipe {

        Plate _plate = null;
        List<Egg> _eggs = new List<Egg>();
        Stack<Bread> _breadSlices = new Stack<Bread>();
        List<Species> _species = new List<Species>();

        public delegate void FriedEggHandle(Plate plate);
        public event FriedEggHandle OnDone;

        public FriedEgg(Plate plate, int eggNumber) {
            _plate = plate;

            // Gather ingredients
            for (int i = 0; i < eggNumber; ++i) {
                _eggs.Add(new Egg());
                _breadSlices.Push(new Bread());
            }

            _species.Add(new Salt());
            _species.Add(new Pepper());
        }

        public void Cook(Utensil pan, Liquid oil, Utensil spoon) {
            Liquid oilForEggs = spoon.Take(oil, 3);
            pan.Add(oilForEggs);

            for (int i = 0; i < _eggs.Count; ++i) {
                _eggs[i].Crack();
                pan.Add(_eggs[i]);            
            }

            pan.OnFoodDone += PutInPlate;
        }
        
        public void PutInPlate(Utensil pan, int foodIndex) {
            _plate.Add(pan.Remove(foodIndex));
            _plate.Add(_breadSlices.Pop());

            if (_breadSlices.Count <= 0) {
                OnDone?.Invoke(_plate);
            }
        }
    }
}