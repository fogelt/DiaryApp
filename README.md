# 📔 Dagboksappen

## Kort beskrivning
Dagboksappen är en konsolbaserad dagboksapplikation skriven i **C#** och **.NET 9**.  
Appen låter användaren skapa, visa, uppdatera och ta bort dagboksanteckningar.  
Alla anteckningar sparas lokalt i en **JSON-fil** för att bevara data mellan sessioner.

---

## 🚀 Hur man kör appen
1. Klona repositoryt:  
   ```bash
   git clone https://github.com/fogelt/DiaryApp.git
Öppna projektet i Visual Studio eller Visual Studio Code.

Bygg och kör projektet med .NET 9:

2. Kör i terminalen
   ```bash
   dotnet run
Följ instruktionerna i konsolen för att:

lägga till anteckningar

visa alla anteckningar

visa anteckningar på ett specifikt datum

uppdatera eller ta bort anteckningar

---
## 💻 Exempel på I/O

**Exempel: Skriva en ny anteckning / se anteckningar / se anteckningar (datum)**

    New entry: Läste en bra bok idag.
    Press any key to return
    
    
    2025-09-25 14:32: Läste en bra bok idag.
    2025-09-25 18:10: Gick en promenad i parken.
    Press any key to return
    
    
    Enter a date (yyyy-MM-dd): 2025-09-25
    Entries on 2025-09-25:
    - 14:32 Läste en bra bok idag.
    - 18:10 Gick en promenad i parken.
    Press any key to return


## 📝 Reflektion

Alla dagboksanteckningar lagras i en `List<DiaryEntry>` för att behålla ordningen på anteckningarna.  

För snabbare uppslag på datum används även en `Dictionary<DateTime, List<DiaryEntry>>`, vilket gör det enkelt att hantera flera anteckningar samma dag.  

JSON valdes som **I/O-format** eftersom det är enkelt, läsbart och stöds direkt i .NET med `System.Text.Json`.  

Felhantering inkluderar `try/catch` vid datuminmatning samt kontroller för tomma anteckningar, vilket gör appen robust mot användarfel.


📌 Release
Tag/release: v1.0.0
