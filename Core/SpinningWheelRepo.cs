using Microsoft.EntityFrameworkCore;
using spinning_wheel.Core.Domain;

namespace spinning_wheel.Core
{
    public class SpinningWheelRepo : ISpinningWheellRepo
    {
        private readonly AppDbContext _db;
        private readonly IImage _imageService;


        public SpinningWheelRepo(AppDbContext db, IImage imageService)
        {
            _db = db;
            _imageService = imageService;
        }

        public async Task<bool> CreateSpinningWheel(SpinningWheel spinningWheel)
        {
            await _db.spinningWheels.AddAsync(spinningWheel);
            if (spinningWheel.Segments.Count > 0) 
            {
                foreach (var seg in spinningWheel.Segments)
                {
                    if (!string.IsNullOrEmpty(seg.Image))

                        seg.Image =await  _imageService.SaveImageAsync(seg.Label, seg.Image);

                }
            } 
            return Save();
        }

        public async Task<string> DeleteSpinningWheel(string id)
        {
            var wheel = await _db.spinningWheels.FirstOrDefaultAsync(e => e.Id == id);
            if (wheel == null) throw new NotImplementedException();   
            _db.spinningWheels.Remove(wheel);
            _db.SaveChanges();
            return wheel.Id;
        }

        public async Task<SpinningWheel> GetSpinningWheel(string id)
        {
            var wheel = await _db.spinningWheels.Include(e=>e.Segments).FirstOrDefaultAsync(e => e.Id == id);
            if (wheel == null)  throw new NotImplementedException();
            return wheel;
        }

       

       

        public async Task<bool> UpdateSpinningWheel(SpinningWheel spinningWheel)
        {
            var wheel = await _db.spinningWheels.Include(e=>e.Segments).FirstOrDefaultAsync(e => e.Id == spinningWheel.Id);
            if (wheel == null) throw new NotImplementedException();
            wheel.Name = spinningWheel.Name;
            if (wheel.Segments.Count>0) 
            {
                _db.wheelSegments.RemoveRange(wheel.Segments);
                _db.SaveChanges();
            }
          


            wheel.Segments = spinningWheel.Segments;
            if (wheel.Segments.Count > 0)
            {
                foreach (var seg in wheel.Segments)
                {
                    if(!string.IsNullOrEmpty(seg.Image))
                    seg.Image = await _imageService.SaveImageAsync(seg.Label, seg.Image);

                }
            }
            _db.spinningWheels.Update(wheel);
            return Save();
        }

       public async Task<List<SpinningWheel>> GetSpinningWheels()
        {
          return  await _db.spinningWheels.Include(e => e.Segments).ToListAsync();
        }
        public bool Save()
        {
            return _db.SaveChanges() >= 0 ? true : false;
        }


    }
}
