

//public class Basvuru
//{
//    public int BasvuruId { get; set; }
//    public int IlanId { get; set; }
//    public int KullaniciId { get; set; }

//    public Ilan Ilan { get; set; }
//    public Kullanici Kullanici { get; set; }

//    public ICollection<Sertifika> Sertifikalar { get; set; } = new List<Sertifika>();
//    public ICollection<Referans> Referanslar { get; set; } = new List<Referans>();
//    public ICollection<Dosya> Dosyalar { get; set; } = new List<Dosya>();
//}
//public class Degerlendirme
//{
//    public int KullaniciId { get; set; }
//    public int BasvuruId { get; set; }
//    public int Puan { get; set; }
//    public string Rapor { get; set; }

//    public Kullanici KomisyonUyesi { get; set; }
//    public Basvuru Basvuru { get; set; }
//}
//public class Dosya
//{
//    public int Id { get; set; }
//    public int BasvuruId { get; set; }
//    public string DosyaUrl { get; set; }

//    public Basvuru Basvuru { get; set; }
//}
//public class Ilan
//{
//    public int IlanId { get; set; }
//    public string IlanBaslik { get; set; }
//    public DateTime IlanYayinlanmaTarihi { get; set; }
//    public bool IlanAktif { get; set; }
//    public string IlanIsTanimi { get; set; }

//    public int YoneticiId { get; set; }
//    public Kullanici Yonetici { get; set; }

//    public ICollection<Basvuru> Basvurular { get; set; } = new List<Basvuru>();
//}

//public class Kullanici
//{
//    public int KullaniciId { get; set; }
//    public string Adi { get; set; }
//    public string Soyadi { get; set; }
//    public string Sifre { get; set; }
//    public string? ProfilFoto { get; set; }
//    public DateTime DogumTarihi { get; set; }
//    public string Cinsiyet { get; set; }

//    // Bire bir ilişki
//    public KullaniciIletisimBilgileri? IletisimBilgileri { get; set; }

//    // Bire çok ilişkiler
//    public ICollection<KullaniciEgitimBilgileri> EgitimBilgileri { get; set; } = new List<KullaniciEgitimBilgileri>();
//    public ICollection<KullaniciDeneyimi> Deneyimler { get; set; } = new List<KullaniciDeneyimi>();
//    public ICollection<KullaniciBeceriler> Beceriler { get; set; } = new List<KullaniciBeceriler>();
//    public ICollection<Ilan> YayinlananIlanlar { get; set; } = new List<Ilan>();




//    // Çoka çok ilişki (Roller)
//    public ICollection<Basvuru> Basvurular { get; set; } = new List<Basvuru>();

//    public ICollection<KullaniciRole> KullaniciRoller { get; set; } = new List<KullaniciRole>();
//    public ICollection<Degerlendirme> Degerlendirmeler { get; set; } = new List<Degerlendirme>();

//}
//public class KullaniciBeceriler
//{
//    public int Id { get; set; }
//    public int KullaniciId { get; set; }
//    public string BeceriAdi { get; set; }

//    public Kullanici Kullanici { get; set; }
//}

//public class KullaniciDeneyimi
//{
//    public int Id { get; set; }
//    public int KullaniciId { get; set; }
//    public string IsPozisyonu { get; set; }
//    public string CalismaTipi { get; set; }
//    public string IsYeriAdi { get; set; }
//    public DateTime BaslamaTarihi { get; set; }
//    public DateTime? AyrilmaTarihi { get; set; }
//    public string Konum { get; set; }
//    public string KonumTipi { get; set; }
//    public string IsTanimi { get; set; }

//    public Kullanici Kullanici { get; set; }
//}
//public class KullaniciEgitimBilgileri
//{
//    public int Id { get; set; }
//    public int KullaniciId { get; set; }
//    public string OkulAdi { get; set; }
//    public string DiplomaTipi { get; set; }
//    public string NotOrtalamasiTipi { get; set; }
//    public decimal NotOrtalamasi { get; set; }

//    public Kullanici Kullanici { get; set; }
//}

//public class KullaniciIletisimBilgileri
//{
//    public int Id { get; set; }
//    //public int KullaniciId { get; set; }
//    public string Email { get; set; }
//    public string Telefon { get; set; }
//    public string? Adres { get; set; }

//    public Kullanici Kullanici { get; set; }
//}
//public class KullaniciRole
//{
//    public int KullaniciId { get; set; }
//    public int RoleId { get; set; }

//    public Kullanici Kullanici { get; set; }
//    public Role Role { get; set; }
//}

//public class Referans
//{
//    public int Id { get; set; }
//    public int BasvuruId { get; set; }
//    public string ReferansTanimi { get; set; }

//    public Basvuru Basvuru { get; set; }
//}

//public class Role
//{
//    public int RoleId { get; set; }
//    public string RolAdi { get; set; }
//    public string RolTanimi { get; set; }

//    public ICollection<KullaniciRole> KullaniciRoller { get; set; } = new List<KullaniciRole>();
//}

//public class Sertifika
//{
//    public int Id { get; set; }
//    public int BasvuruId { get; set; }
//    public string DosyaUrl { get; set; }

//    public Basvuru Basvuru { get; set; }
//}






