# SnakeGame – gra konsolowa w języku C#

Projekt gry Snake w języku C#, zrealizowany w środowisku konsolowym. Celem projektu było stworzenie prostej gry w zespole z wykorzystaniem narzędzi GitHub: gałęzi, pull requestów, przypisanych zadań oraz systemu zgłoszeń problemów (issues).

## Funkcje gry

- Tryb jednoosobowy
- Tryb dwuosobowy (lokalny multiplayer na jednej klawiaturze)
- Losowe pojawianie się jedzenia
- System punktacji dla każdego gracza
- Kolizja ze ścianą kończy grę
- Kolizja między graczami kończy grę w trybie multiplayer
- Stopniowe przyspieszanie gry po zjedzeniu jedzenia
- Menu startowe z wyborem trybu gry
- Możliwość ponownego rozpoczęcia gry po zakończeniu

## Sterowanie

| Gracz | Klawisze sterujące       |
|-------|--------------------------|
| Gracz 1 | Strzałki (↑ ↓ ← →)     |
| Gracz 2 | W, A, S, D              |

## Współpraca zespołowa

Projekt został zrealizowany zgodnie z zasadami współpracy przy użyciu systemu kontroli wersji:

- Każda funkcjonalność została zaimplementowana na osobnej gałęzi (`feature/input`, `feature/movement`, `feature/score`, `feature/collision`, `feature/menu`, `feature/multiplayer`, `feature/speedup`)
- Po zakończeniu prac nad daną funkcją tworzono Pull Request do gałęzi głównej
- Każdy PR był zatwierdzany przez uczestników zespołu
- Wykorzystano zakładkę Issues:
  - #1 – Kolizja głów dwóch graczy nie kończy gry
  - #2 – Dodanie mechaniki stopniowego przyspieszania gry

## Testowanie

Gra została przetestowana w trybie jedno- i dwuosobowym.  
Zidentyfikowano i naprawiono błędy:
- Kolizja głów nie kończyła gry – dodano odpowiednie sprawdzenie
- Jedzenie mogło pojawiać się bezpośrednio na graczu – wprowadzono losowanie z zabezpieczeniem
- W trybie multiplayer dostosowano tempo gry do dwóch graczy

Dodano również funkcję zwiększania prędkości gry po zjedzeniu jedzenia.

## Instrukcja uruchamiania

1. Otwórz projekt w środowisku Visual Studio (2022 lub nowszym)
2. Upewnij się, że projekt to aplikacja typu „Console App (.NET)”
3. Uruchom projekt skrótem `Ctrl + F5` (Start without debugging)
4. Z menu wybierz tryb gry
5. Gra sterowana za pomocą klawiatury – szczegóły w tabeli powyżej

## Struktura gałęzi

- `main` – wersja stabilna gry
- `feature/*` – osobne funkcjonalności rozwijane niezależnie
- `testing` – testy i integracja kodu

## Technologie

- Język programowania: C#
- Środowisko: Visual Studio
- Interfejs: konsola systemowa
- System kontroli wersji: Git
- Platforma współpracy: GitHub

## Status projektu

Projekt zakończony.  
Zrealizowano wszystkie wymagania, zarówno funkcjonalne, jak i dotyczące pracy zespołowej.  
Kod gotowy do dalszego rozwijania w ramach kolejnych wersji lub rozszerzeń (np. ogon węża, poziomy trudności, zapis wyników).
