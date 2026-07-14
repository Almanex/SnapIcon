# Project Context - IconForge

This document provides developer-focused coding context and architecture guidelines for IconForge.

## Overview
IconForge is a native C# and WinUI 3 (Windows App SDK) desktop utility designed for batch-generating icon files for Windows and Android from a single raster (PNG) or vector (SVG) source image.

## Technology Stack
- **Language:** C# (.NET 8.0)
- **Target OS:** Windows 10/11 (`net8.0-windows10.0.26100.0` target framework)
- **UI Platform:** WinUI 3 (Windows App SDK 2.2.0)
- **Graphics Engine:** SkiaSharp (for Lanczos3 scaling and contour sharpening filters)
- **Vector Rendering:** Svg.Skia (renders SVGs into raster surfaces)

## Directory Structure
```text
icoboo/
├── Assets/              # Branding and system app icon files
├── docs/                # Project documentation and guides (Russian, German, English)
├── Helpers/             # Custom utility helpers (e.g., ShellIntegration)
├── Properties/          # Launch configurations and build settings
├── Services/            # Core processing engine (e.g., IconProcessor)
├── Strings/             # System resource dictionaries for multi-language (RU/EN/DE)
├── App.xaml             # Application startup configuration
├── IconForge.csproj     # MSBuild project file
├── MainPage.xaml        # Main workspace UI
└── MainWindow.xaml      # Main window frame
```

## Key Architectural Points
- **Unpackaged Deployment:** The app is configured with `<WindowsPackageType>None</WindowsPackageType>` and `<SelfContained>true</SelfContained>`. It runs without needing a global Windows App Runtime installation.
- **Bootstrapper:** Standard bootstrapper initialization is implicitly managed via Windows App SDK build targets.
- **Resource Copying:** The `Assets/` directory is copied next to the single-file executable using a custom MSBuild post-publish target (`CopyAssetsToPublish`). The folder must sit adjacent to the executable at runtime.
- **Localization:** UI strings are dynamically loaded using `ResourceLoader`. XAML elements are localized via `x:Uid` identifiers mapping to `Strings/{locale}/Resources.resw`.

## Common Tasks
- **Build:** `dotnet build`
- **Run:** `dotnet run`
- **Publish Release:**
  ```powershell
  dotnet publish -c Release -r win-x64 --self-contained true
  ```
