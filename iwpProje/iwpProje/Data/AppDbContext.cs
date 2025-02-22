using iwpProje.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace iwpProje.Data
{
    public class AppDbContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public AppDbContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // Connect to PostgreSQL with connection string from appsettings.json
            options.UseNpgsql(Configuration.GetConnectionString("WebApiDatabase"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // cagrikayitlari1hafta view'i keyless entity olarak tanımlanıyor
            modelBuilder.Entity<cagrikayitlari1hafta>(entity =>
            {
                entity.HasNoKey(); // Bu, birincil anahtarın olmadığını belirtiyor
                entity.ToView("CagriListesi1Hafta"); // Veritabanındaki view adı (isteğe bağlı)
            });

            modelBuilder.Entity<login>(entity =>
            {
                entity.HasNoKey(); // login sınıfı için keyless entity tanımlanıyor
            });

            /* modelBuilder.Entity<oturumacmiskullanici>(entity =>
            {
                entity.HasNoKey(); // login sınıfı için keyless entity tanımlanıyor
            });
            */

            base.OnModelCreating(modelBuilder); // Varsayılan davranış
        }

        

        // Define DbSet properties here (example)
        public DbSet<mustericagrikayitlari> mustericagrikayitlari { get; set; }
        public DbSet<itirazkayitlari> itirazkayitlari { get; set; }
        public DbSet<cagrikayitlari1hafta> CagriListesi1Hafta { get; set; }
        public DbSet<login> sistemkullanicilari { get; set; }
        public DbSet<oturumacmiskullanici> oturumacmiskullanicilar { get; set; }
        public DbSet<musteriler> musteriler { get; set; }

        public async Task ItirazEkle(string asistaninaciklamasi)
        {
            var param = new NpgsqlParameter("@_Aciklama", asistaninaciklamasi);
            await Database.ExecuteSqlRawAsync("CALL sp_itirazacevap(@_Aciklama)", param);
        }

        public async Task CagriEkle(string asistansicil, int gorusmekonusuid, DateTime gorusmetarihi, TimeSpan baslamasaati, TimeSpan bitissaati, int gorusmedurumid, string musteriid)
        {
            var formattedGorusmetarihi = gorusmetarihi.Date;

            var paramAsistansicil = new NpgsqlParameter("@_Asistansicil", asistansicil);
            var paramGorusmekonusuid = new NpgsqlParameter("@_GorusmeKonusuID", gorusmekonusuid);
            var paramGorusmetarihi = new NpgsqlParameter("@_GorusmeTarihi", NpgsqlTypes.NpgsqlDbType.Date)
            {
                Value = formattedGorusmetarihi
            };
            var paramBaslamasaati = new NpgsqlParameter("@_BaslamaSaati", NpgsqlTypes.NpgsqlDbType.Time)
            {
                Value = baslamasaati
            };

            var paramBitisSaati = new NpgsqlParameter("@_BitisSaati", NpgsqlTypes.NpgsqlDbType.Time)
            {
                Value = bitissaati
            };
            var paramGorusmedurumuid = new NpgsqlParameter("@_GorusmeDurumID", gorusmedurumid);
            var paramMusteriID = new NpgsqlParameter("@_MusteriID", musteriid);

            await Database.ExecuteSqlRawAsync(
                "CALL sp_cagriekle(@_Asistansicil, @_GorusmeKonusuID, @_GorusmeTarihi, @_BaslamaSaati, @_BitisSaati, @_GorusmeDurumID, @_MusteriID)",
                paramAsistansicil, paramGorusmekonusuid, paramGorusmetarihi, paramBaslamasaati, paramBitisSaati, paramGorusmedurumuid, paramMusteriID
            );
        }

    }
}
