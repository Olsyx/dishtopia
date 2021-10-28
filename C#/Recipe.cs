
namespace Recipes {
    public abstract class Recipe {

        public delegate void RecipeHandle(Plate plate);
        public event RecipeHandle OnDone;

        public void Finish() {
            OnDone?.Invoke();
        }
    }
}