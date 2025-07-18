namespace QuizApi.Models.Data
{
    public static class QuestionData
    {
        public static List<Question> Questions = new List<Question>
        {
            new Question
            {
                Id = 1,
                QuestionText = "C# dilinde bir sınıf nasıl tanımlanır?",
                Options = new List<string> { "function MyClass {}", "class MyClass {}", "def MyClass:", "MyClass() = class" },
                CorrectAnswer = "class MyClass {}"
            },
            new Question
            {
                Id = 2,
                QuestionText = ".NET Core hangi tür uygulamalar geliştirmek için kullanılır?",
                Options = new List<string> { "Sadece mobil uygulama", "Sadece web siteleri", "Web, mobil, konsol uygulamaları", "Sadece oyun geliştirme" },
                CorrectAnswer = "Web, mobil, konsol uygulamaları"
            },
            new Question
            {
                Id = 3,
                QuestionText = "Entity Framework nedir?",
                Options = new List<string> { "Bir oyun motoru", "Bir ORM aracı", "Bir frontend framework", "Bir IDE" },
                CorrectAnswer = "Bir ORM aracı"
            },
            new Question
            {
                Id = 4,
                QuestionText = "HTTP 404 hatası ne anlama gelir?",
                Options = new List<string> { "Yetkisiz erişim", "Sunucu hatası", "Kaynak bulunamadı", "Başarılı işlem" },
                CorrectAnswer = "Kaynak bulunamadı"
            },
            new Question
            {
                Id = 5,
                QuestionText = "POST isteği ne için kullanılır?",
                Options = new List<string> { "Veri silmek için", "Veri çekmek için", "Veri oluşturmak/göndermek için", "Sayfa yönlendirmesi için" },
                CorrectAnswer = "Veri oluşturmak/göndermek için"
            }
        };
    }
}
