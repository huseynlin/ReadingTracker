# 📚 ReadingTracker - Modern Kitab İzləmə Platforması

ReadingTracker, kitabsevərlər üçün hazırlanmış, oxuma vərdişlərini rəqəmsallaşdıran və fərdi kitabxanalarını idarə etməyə imkan verən **ASP.NET Core MVC** əsaslı veb tətbiqidir.

![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)
![ASP.NET Core](https://img.shields.io/badge/ASP.NET%20Core%208.0-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![Bootstrap](https://img.shields.io/badge/Bootstrap%205-7952B3?style=for-the-badge&logo=bootstrap&logoColor=white)

## ✨ Əsas Xüsusiyyətlər

-   **🔐 Təhlükəsiz Giriş Sistemi:** Cookie-based Authentication vasitəsilə qeydiyyat və giriş imkanı.
-   **📖 Fərdi Kitabxana:** Hər bir istifadəçi yalnız özünə aid olan kitab siyahısını görür və idarə edir.
-   **⚡ CRUD Əməliyyatları:** Kitabların əlavə edilməsi, silinməsi, detallarına baxılması və statusunun yenilənməsi.
-   **🔍 Filtrasiya:** Kitabları "Oxunur" və ya "Bitirilib" statusuna görə süzgəcdən keçirmə funksiyası.
-   **🎨 Modern UI:** "Plus Jakarta Sans" şrifləri və Apple tərzində minimalist dizayn dili.
-   **📱 Responsive:** Bütün cihazlarda (mobil, planşet, masaüstü) qüsursuz görünüş.

## 🛠️ Texnologiyalar

-   **Backend:** C# / ASP.NET Core 8.0 MVC
-   **Məlumat Bazası:** JSON faylları (Verilənlərin sürətli oxunması üçün `System.Text.Json` istifadə olunub)
-   **Frontend:** HTML5, CSS3 (Custom Animations), Razor Pages, Bootstrap 5
-   **Dizayn:** Glassmorphism və Minimalist White Design

## 📂 Layihə Strukturu

```text
ReadingTracker/
│
├── Controllers/        # İdarəetmə məntiqi (Account, Book)
├── Models/             # Verilənlər modelləri (User, Book, Enum)
├── Services/           # JSON bazası ilə əlaqə (JsonDataService)
├── Views/              # İstifadəçi interfeysi (Razor)
└── Data/               # books.json və users.json faylları
