[README_RU](README_RU.md) | [README_DE](README_DE.md) | [README_EN](../README.md) | [GUIDE_RU](GUIDE_RU.md) | [GUIDE_DE](GUIDE_DE.md) | [GUIDE_EN](GUIDE.md)

# IconForge

*Nativer Multiformat-Symbolgenerator und Bildbearbeitungsassistent für Windows 11*

[![License: MIT](https://img.shields.io/badge/License-MIT-blue.svg)](https://opensource.org/licenses/MIT)
[![Platform: Windows](https://img.shields.io/badge/Platform-Windows%2010%20%2F%2011-blue)](https://www.microsoft.com/windows)
[![Framework: .NET 10.0](https://img.shields.io/badge/Framework-.NET%2010.0-blue)](https://dotnet.microsoft.com/download)
[![UI: WinUI 3](https://img.shields.io/badge/UI-WinUI%203-blue)](https://learn.microsoft.com/windows/apps/winui/winui3/)
[![Release: v1.0.3](https://img.shields.io/badge/Release-v1.0.3-brightgreen)](https://github.com/Almanex/IconForge/releases/tag/v1.0.3)

IconForge ist eine leichte, native Windows 11-Anwendung, die mit C# und WinUI 3 (Windows App SDK) entwickelt wurde. Sie bietet vollständige dreisprachige Unterstützung (Englisch, Russisch, Deutsch) und dient zur automatisierten Erstellung von Icon-Paketen für Windows (`.ico`, `Assets`), Web (`Favicon Pack`), macOS (`.icns`) und Android (`Adaptive Icons`) aus einer einzigen Bildquelle (PNG, SVG oder ICO).

Eine detaillierte Anleitung finden Sie im [Benutzerhandbuch](GUIDE_DE.md).

---

## Hauptfunktionen

### Plattformübergreifende Icon-Generierung

* **Windows (Klassisches .ico):**
  * Multiformat-`.ico`-Datei mit den Auflösungen: `16x16`, `24x24`, `32x32`, `48x48`, `64x64`, `128x128`, `256x256` Pixel.
  * **Mikro-Schärfung:** Automatische Schärfung für kleine Größen (16-48px) zur Vermeidung von Unschärfe im Windows-Explorer.
* **Windows Modern Assets (PNG):**
  * Einzelne PNG-Dateien für WinUI/UWP-App-Manifeste in allen Systemskalierungen (`scale-100` bis `scale-400`).
* **Web & Favicon Pack:**
  * Vollständiges Paket inklusive `favicon.ico`, `apple-touch-icon.png` (180x180), `android-chrome-*.png` und `site.webmanifest`.
* **macOS App Icon (.icns):**
  * Nativer Binär-Encoder zur Erstellung von Apple-`.icns`-Dateien.
* **Android (Adaptive & Legacy Icons):**
  * Ebenentrennung (Foreground safe-zone 72dp & Background), Mipmap-Ordnerstruktur und Google Play 512x512-Symbol.

### Bildfilter & Farbanpassung

* **Helligkeit & Kontrast:** Stufenlose Regler (-100 bis +100).
* **Eckenabrundung & Abstand:** Anpassen von Eckenradius (0..50%) und Innenabstand (0..40%).
* **Effekte:** Graustufenmodus, Farbinvertierung und Schlagschatten (Drop Shadow).
* **SVG Tinting:** Einfärben von Vektor- und Raster-Icons über Hex-Farbwahl.

### Echtzeit-Vorschaugitter (Live Preview Grid)

* Gleichzeitige Anzeige aller Standardgrößen (`16x16`, `32x32`, `48x48`, `256x256`).
* **Hintergrundmodi:** Transparent (Schachbrett), Dunkel (#1F1F1F), Hell (#F3F3F3) und benutzerdefinierte Android-Farbe.

### ICO-Extraktion (Reverse ICO Extraction)

* Automatisches Erkennen und Entpacken von `.ico`-Dateien in einzelne PNG-Ebenen.

### Windows 11-Integration & Einzelne EXE-Datei

* **Mica Alt & Dark/Light Theme:** Nativer Fluent Design-Look.
* **Kontextmenü-Einbindung:** Explorer-Integration ohne Administratorrechte.
* **Einzelne Standalone-EXE:** Vollständig gebündelte Datei (`IconForge_v1.0.2_win-x64.exe`), die ohne Zusatzordner überall ausgeführt werden kann.

---

## Technologie-Stack

| Komponente | Technologie | Beschreibung |
| --- | --- | --- |
| Framework | C# (.NET 8.0) | Target `net8.0-windows10.0.26100.0` |
| UI-Framework | WinUI 3 | Windows App SDK 1.6 / 2.2 |
| Grafik-Engine | SkiaSharp | Resampling (Lanczos3) & Farbfilter |
| SVG-Engine | Svg.Skia | Vektorrasterisierung |
| Paketierung | Single-File Executable | Einzelne ausführbare `.exe` |

---

## Lizenz

Dieses Projekt ist unter der [MIT-Lizenz](LICENSE) lizenziert.
