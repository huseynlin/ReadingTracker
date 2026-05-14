# 📚 ReadingTracker v2.0 (Next-Gen)

Visual Studio 2026 və ASP.NET 10 platforması üzərində inşa edilmiş, minimalist dizayn fəlsəfəsinə sahib modern kitab izləmə və idarəetmə sistemidir. 

![ASP.NET 10](https://img.shields.io/badge/ASP.NET_10-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![Visual Studio 2026](https://img.shields.io/badge/VS_2026-5C2D91?style=for-the-badge&logo=visual-studio&logoColor=white)
![License](https://img.shields.io/badge/License-MIT-green?style=for-the-badge)

## 📋 Layihə Haqqında
ReadingTracker, istifadəçilərə öz oxu vərdişlərini izləməyə kömək edən, fərdi kitabxanalarını rəqəmsallaşdıran bir platformadır. Tətbiq, "Clean Code" prinsipləri və modern UI (User Interface) trendləri əsasında hazırlanmışdır.

## 🚀 Texnoloji Stack
- **Framework:** ASP.NET 10.0 Core MVC
- **Dil:** C# 14+
- **Məlumat Saxlanılması:** JSON-based persistence (NoSQL məntiqi ilə)
- **Frontend:** - **CSS:** Custom Glassmorphism & Modern Animations
  - **Font:** Plus Jakarta Sans
  - **İkonlar:** Bootstrap Icons (CDN)
- **Təhlükəsizlik:** Cookie-based Authentication & Anti-forgery validation

## ✨ Əsas Funksional İmkanlar
- **Persistensiya:** `JsonDataService` vasitəsilə məlumatların itmədən JSON fayllarında sinxron saxlanılması.
- **İstifadəçi İdarəetməsi:** Tam funksional Register/Login/Logout axışı.
- **Dinamik Filtrasiya:** Kitabların statusuna (Oxunur/Bitirilib) görə real-time süzülməsi.
- **Təhlükəsizlik Layeri:** Hər bir istifadəçi üçün izolyasiya edilmiş data (Yalnız öz kitablarını görmə və idarə etmə).
- **Modern UI:** Aşağıdan yuxarıya süzülən animasiyalar (`fadeInUp`) və interaktiv kart dizaynı.

## 🏗️ Arxitektura (MVC Flow)
Tətbiq klassik MVC modelini izləyir:
- **Models:** `Book.cs`, `User.cs` və `BookStatus.cs` (Enum)
- **Controllers:** - `AccountController`: Kimlik doğrulaması və sessiya idarəetməsi.
  - `BookController`: Kitablar üzərində CRUD (Create, Read, Update, Delete) əməliyyatları.
- **Services:** `JsonDataService.cs` - Verilənlərin oxunması və yazılması üçün mərkəzi xidmət.