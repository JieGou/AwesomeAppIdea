namespace SIG.Model
{
    internal interface IEnemy
    {
        uint Points { get; }

        void Animate();
    }
}