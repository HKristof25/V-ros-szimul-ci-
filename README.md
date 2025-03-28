# Álomváros

## Leírás
Ebben a projektben egy város élete van szimulálva. Épületeket és szolgáltatásokat lehet építeni, karbantartani, lerombolni vagy törölni. Ezen műveletek végrehajtása befolyásolja a lakosok elégedettségét és a város bevételét.

## Telepítés és futtatás
A program **WPF asztali alkalmazásként** készült. A következő paranccsal lehet letölteni:

```powershell
git clone https://github.com/HKristof25/V-ros-szimul-ci-.git
```

Ezután nyisd meg a `Álomváros\Solution` fájlt, és futtasd az alkalmazást.

### 1. Főmenü
A program egy főmenüvel indul, ahol meg vannak adva néhány alap kezdőérték, de ezeket módosítani is lehet:

- Kezdő pénz
- Kezdő elégedettség
- Minimális elégedettség
- Épületek állapota
- Lakosság

A **"Szimuláció kezdése"** gombbal lehet elindítani a szimulációt.

## 2. Szimuláció     
A szimulációs ablak jobb oldalán megjelennek a város adatai, bal oldalon pedig a projektlehetőségek és a pénz.  
Minden projektlehetőség kiválasztásakor egy új ablak nyílik meg, ahol:

- Ki lehet választani a projekt részleteit.
- Megjelennek a költségek, a bevételre gyakorolt hatás, az építési idő (ha van), és az elégedettség változása.

Az **"OK"** gomb megnyomásával a kiválasztott projektek eltárolódnak (ha vannak), és visszakerülsz a **Szimuláció** ablakba.  

- Új projekteket lehet indítani.  
- A **"Következő hónap"** gombbal egy hónapot lépünk előre, és a projektek költségei hónapokra osztva levonódnak a város pénzéből.  
- Ha lejár az építési idő, az elégedettség módosul.  
- Az épületek minősége minden hónapban romlik, valamint a pénz és az elégedettség automatikusan csökken.

## 3. Vége
A szimuláció akkor ér véget, ha:  
- A város pénze elfogy, **vagy**  
- Az elégedettség a minimum alá esik.
