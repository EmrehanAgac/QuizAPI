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

# Quiz API

## Proje Açıklaması

Bu proje, .NET Core Web API kullanılarak geliştirilmiş basit bir Quiz API'dir. Kullanıcılar sabit tanımlı sorulara erişebilir, rastgele soru alabilir ve cevaplarını API üzerinden gönderebilir. Cevaplar doğru/yanlış olarak değerlendirilir ve skor takibi yapılır. Projede veritabanı kullanılmaz; tüm veriler RAM üzerinde tutulur.

## Çalıştırma Talimatları

1. Projeyi klonlayın:
   `git clone <repo-link>`
2. Visual Studio veya VS Code ile projeyi açın.
3. Gerekli NuGet paketlerini yükleyin.
4. Projeyi çalıştırın. API varsayılan olarak `http://localhost:5182` adresinde aktif olacaktır.
5. Swagger arayüzü için `http://localhost:5182/swagger` adresini ziyaret edebilirsiniz.

## API Endpoint Açıklamaları

| HTTP Metodu | Endpoint              | Açıklama                                   |
| ----------- | --------------------- | ------------------------------------------ |
| GET         | /api/questions        | Tüm soruları listele                       |
| GET         | /api/questions/random | Rastgele bir soru getir                    |
| POST        | /api/questions/answer | Kullanıcının cevabını gönder ve kontrol et |

## Örnek İstek ve Yanıtlar

**GET /api/questions**
Yanıt (JSON):

```json
[
  {
    "id": 1,
    "questionText": "C# dilinde bir sınıf nasıl tanımlanır?",
    "options": [
      "function MyClass {}",
      "class MyClass {}",
      "def MyClass:",
      "MyClass() = class"
    ]
  }
]
```

**POST /api/questions/answer**
İstek:

```json
{
  "questionId": 1,
  "selectedOption": "class MyClass {}"
}
```

Yanıt:

```json
{
  "correct": true,
  "currentScore": 10,
  "correctAnswer": "class MyClass {}"
}

