public class Flame : Effect {
    private float Radius = 1;
    private float Damage = 1;
    private bool IsFrost = false;

    public void Enhance() {
        Radius += 3;
        Damage += 3;
    }

    public void Invert() {
        IsFrost = !IsFrost;
    }
}
