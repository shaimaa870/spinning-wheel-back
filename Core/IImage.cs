namespace spinning_wheel.Core
{
    public interface IImage
    {
        Task<string> SaveImageAsync(string name, string dtoFile);
    }
}
