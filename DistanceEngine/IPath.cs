namespace DistanceEngine
{
    public interface IPath
    {
        Location Destination { get; }
        int Distance { get; }
    }
}