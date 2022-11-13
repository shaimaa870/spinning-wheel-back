using spinning_wheel.Core.Domain;

namespace spinning_wheel.Core
{
    public interface ISpinningWheellRepo
    {
       Task<List<SpinningWheel>> GetSpinningWheels();

        Task<SpinningWheel> GetSpinningWheel(string id);
        Task<bool> CreateSpinningWheel(SpinningWheel spinningWheel);

        Task<bool> UpdateSpinningWheel(SpinningWheel spinningWheel);

        Task<string> DeleteSpinningWheel(string id);
        bool Save();
    }
}
