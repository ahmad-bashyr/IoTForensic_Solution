using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace IoTForensicSolution.IoTDataStorage
{
    public class DataStorage : IDatabaseService
    {
        private readonly DataContext _context;

        public DataStorage(DataContext context)
        {
            _context = context;
        }

        public async Task SaveDataAsync(string data)
        {
            var record = new IoTDataRecord
            {
                Id = Guid.NewGuid().ToString(),
                Timestamp = DateTime.UtcNow,
                Data = data
            };
            _context.IoTDataRecords.Add(record);
            await _context.SaveChangesAsync();
        }

        public async Task<string> RetrieveDataAsync(string id)
        {
            var record = await _context.IoTDataRecords.FindAsync(id);
            return record?.Data;
        }
    }

    public class DataContext : DbContext
    {
        public DbSet<IoTDataRecord> IoTDataRecords { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Database=iot_forensic_db;Username=iot_user;Password=QWERTY;Port=5432");

        }
    }

    public class IoTDataRecord
    {
        public string Id { get; set; }
        public DateTime Timestamp { get; set; }
        public string Data { get; set; }
    }
}
