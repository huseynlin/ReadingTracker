# 📚 ReadingTracker - Şəxsi Kitab Kitabxanam

ReadingTracker, istifadəçilərin oxuduqları kitabları qeydiyyata aldığı, statuslarını izlədiyi (Oxunur/Bitirilib) və şəxsi qeydlərini saxladığı modern bir ASP.NET Core MVC tətbiqidir.

## ✨ Xüsusiyyətlər

-   **Modern UI/UX:** "Plus Jakarta Sans" şrifti və minimalist ağ dizayn ilə Apple tərzində interfeys.
-   **İstifadəçi Sistemi:** Qeydiyyat, Giriş və Çıxış funksiyaları (Cookie Authentication).
-   **Şəxsi Kitabxana:** Hər istifadəçi yalnız öz əlavə etdiyi kitabları görür.
-   **CRUD Əməliyyatları:** Kitab əlavə etmə, detallara baxma, statusu yeniləmə və silmə.
-   **JSON Data Storage:** Verilənlər bazası olaraq sadə və sürətli JSON fayllarından istifadə olunur.
-   **Responsive Dizayn:** Həm mobil, həm də masaüstü cihazlar üçün tam uyğundur.

## 🚀 Texnologiyalar

-   **Backend:** ASP.NET Core 8.0 MVC
-   **Frontend:** HTML5, CSS3 (Custom Animations), Bootstrap 5
-   **Data:** JSON (System.Text.Json)
-   **İkonlar:** Bootstrap Icons

## 📂 Qovluq Quruluşu

```text
ReadingTracker/
├── Controllers/        # Giriş və Kitab məntiqini idarə edən kontrollerlər
├── Models/             # Book, User və Enum sinifləri
├── Services/           # JSON faylı ilə əlaqə yaradan JsonDataService
├── Views/              # Səhifələrin (HTML/Razor) görünüşləri
└── Data/               # books.json və users.json faylları
