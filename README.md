# Projekt sa gospodarstvom - O. S. d.o.o

## Projektni tim (Tim - PI20-004)

Ime i prezime   | E-mail adresa (FOI) |    JMBAG   | Github korisničko ime
--------------- | ------------------- | ---------- | ---------------------
Žan Žlender     | zzlender@foi.hr     | 0016123668 | zanzlender
Helena Potočki  | hpotocki@foi.hr     | 0016129570 | HelenaPotocki
Antonio Kunštek | akunstek@foi.hr     | 0016133325 | kunstek47


## Opis domene
Poslovni cilj cijelog projekta je napraviti nacrt i arhitekturu buduće interne aplikacije za interno korištenje zaposlenika O.S.-a koja bi pomogla zaposlenicima u snalaženju u tvrtki i informiranju, te provedbi administrativnih radnji koje moraju obavljati u svome svakodnevnome radu. Također bi kroz navedenu aplikaciju mogli dobiti upute o snalaženju u radnim prostorima tvrtke, kao i drugim aktivnostima zaposlenika vezanim za rad tvrtke. Na navedeni način bi se strukturirano upravljalo aministrativnim zahtjevima zaposlenika i kroz jedan kanal komunikacije razmjenjivalo potrebne informacije sa zaposlenicima.

Zaduženje našeg tima je izrada *Sučelja za prijavu* i sustav za autentifikaciju zaposlenika, kojima će biti dodijeljene uloge (administrator, zaposlenik, voditelj...) od strane *Administratora*, te će ovisno o ulozi moći pristupiti određenom početnom sučelju i funkcionalnostima. Također, potrebno je izraditi prikaz *Sučelja za administratora*, koji će moći dodavati nove zaposlenike, brisati trenutne zaposlenike, dodavati i mijenjati uloge zaposlenika, te dodavati i mijenjati sadržaj.


## Specifikacija projekta
Zahtjevi od strane klijenta, odnosno funkcionalnosti/informacije koje aplikacija treba sadržavati:
- Administriranje zaposlenika (unos/izmjene/dodavanje uloga zaposlenih i sl.)
- Informacije i obavijesti 
- Zahtjevi za putnim nalozima
- Zahtjevi za rezervacijom službenih vozila
- Zahtjevi za godišnjim odmorima
- Prijava inovacija
- Prijava poteškoća u radu
- Upute za rad
- Prijedlog kolega za rad u O.S.-u
- Tržnica
- Dolasci i odlasci zaposlenika
- Upute o snalaženju po radnim prostorima
- Dodatne aktivnosti tvrtke (dobrovoljno darivanje krvi, tečajevi plesa, naručivanje kave, parking itd.)



## Zaduženja našeg tima:

Oznaka   | Naziv | Kratki opis | Odgovorni član tima
-------- | ----- | ----------- | -------------------
F01 | Login | Prijava u aplikaciju ovisno o ulozi (zaposlenik, administrator) | Žan Žlender
F02 | Autentifikacija i podjela uloga | Osmisliti način autentifikacije korisnika i spriječiti zlouporabu | Antonio Kunštek
F03 | Dodavanje korisnika u bazu | Sastaviti programsko rješenje za osmišljeni način dodavanja korisnika u bazu podataka | Helena Potočki
F04 | Izrada administrativnog pregleda | Osmiliti i izraditi dizajn te način dodavanja novih korisnika u bazu podataka, od strane administratora, uz mogućnost uređivanja, odnosno brisanja, istih |  Žan Žlender
F05 | Dodavanje/mijenjaje zaposlenika | Sastaviti programsko rješenje za osmišljeni način uređivanje/brisanje korisnika u bazi podataka | Helena Potočki
F06 | Spajanje rješenja | Spajanje dokumenata i programskih rješenja svih timova u jednu funkcionalnu aplikaciju | Antonio Kunštek



## Tehnologije i oprema
Glavne okruženje u kojem ćemo razvijati ovu desktop aplikaciju biti će **Microsoft Visual Studio 2017** na **Windows 10 operacijskom sustavu**. Za izradu baze podataka koristiti ćemo **MySQL Workbench**. Verzioniranje koda vršiti će se preko **GitHub**-a a dokumentacija preko **GitHub Wiki**-ja. Za sve potrebne dijagrame/slike korisiti ćemo web aplikaciju **draw.io**, a za komunikaciju između timova korisiti ćemo **Slack** odnosno **Trello**.
