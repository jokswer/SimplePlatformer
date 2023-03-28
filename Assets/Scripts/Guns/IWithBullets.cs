namespace Guns
{
    public interface IWithBullets
    {
        public int NumberOfBullets { get; }
        
        public void AddBullets(int value);
    }
}