# Quiz API - .NET Core Web API

Bu proje, .NET Core Web API kullanılarak geliştirilmiş bir quiz sistemidir. Kullanıcılar bir oturum başlatır, sistem onlara daha önce cevaplamadıkları soruları sırasıyla gönderir. Cevaplar kontrol edilir, doğruysa puan kazanılır.

## 🔧 Kullanılan Teknolojiler

- ASP.NET Core Web API
- Entity Framework Core
- SQL Server (veya SQLite)
- Swagger UI (API testi için)
- UUID ile oturum takibi

## 📌 Özellikler

- ✅ Quiz başlatma ve UUID oluşturma
- ✅ Rastgele ve tekrarsız soru gönderme
- ✅ Cevap gönderme ve doğruluk kontrolü
- ✅ Puan takibi
- ✅ Aynı soruya ikinci kez cevap verilememesi
- ✅ Cevap zamanı (AnsweredAt) tutulması

## 🧠 Katmanlar

- `Controllers` → API endpoint’leri
- `DTOs` → Veri transfer modelleri
- `Models` → Entity sınıfları
- `Repositories` → Veri erişim katmanı (Interface + Concrete)
- `Services` → İş mantığı
- `Database` → Context ve veri işlemleri

## 📤 API Endpoint'leri

### 🔸 Oturum Başlat
`POST /api/quiz/start`

Response:
```json
{
  "sessionId": "uuid"
}
