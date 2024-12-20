
SET IDENTITY_INSERT Opleiding ON;
INSERT INTO Opleiding (Id, Naam, Beschrijving, Begindatum, Einddatum, AantalPlaatsen, OpleidingVereist) VALUES
(1, 'EHBO Cursus', 'Eerste Hulp Bij Ongevallen.', '2023-01-10', '2023-01-15', 20, NULL),
(2, 'Natuurgids Opleiding', 'Leer alles over de natuur.', '2023-02-01', '2023-02-10', 15, NULL),
(3, 'Kampbegeleider Training', 'Training voor kampbegeleiders.', '2023-03-05', '2023-03-12', 25, NULL),
(4, 'Veiligheidstraining', 'Omgaan met noodsituaties.', '2023-04-10', '2023-04-15', 30, NULL),
(5, 'Sportinstructeur Cursus', 'Leid sportactiviteiten.', '2023-05-20', '2023-05-25', 20, NULL),
(6, 'Kookworkshop', 'Gezonde maaltijden bereiden.', '2023-06-01', '2023-06-05', 10, NULL),
(7, 'Creatieve Vorming', 'Kunstzinnige activiteiten begeleiden.', '2023-07-15', '2023-07-20', 15, NULL),
(8, 'Muziekworkshop', 'Muzikale activiteiten organiseren.', '2023-08-10', '2023-08-15', 12, NULL),
(9, 'Techniektrainer Opleiding', 'Technische workshops geven.', '2023-09-05', '2023-09-10', 18, NULL),
(10, 'Fotografie Cursus', 'Fotografie vaardigheden ontwikkelen.', '2023-10-20', '2023-10-25', 16, NULL);
SET IDENTITY_INSERT Opleiding OFF;



set IDENTITY_INSERT Bestemming ON;
INSERT INTO Bestemming (Id, Code, Naam, Beschrijving, MinLeeftijd, MaxLeeftijd) VALUES
(1, 'D001', 'Strandvakantie', 'Een heerlijke vakantie aan het strand.', 6, 12),
(2, 'D002', 'Bergwandelen', 'Avontuurlijk wandelen in de bergen.', 8, 15),
(3, 'D003', 'Stedentrip', 'Ontdek de mooiste steden.', 10, 18),
(4, 'D004', 'Kamp in het bos', 'Survivalactiviteiten in het bos.', 7, 14),
(5, 'D005', 'Zeilkamp', 'Leer zeilen op een meer.', 9, 16),
(6, 'D006', 'Kunstkamp', 'Creatieve workshops en musea bezoeken.', 6, 13),
(7, 'D007', 'Sportkamp', 'Diverse sporten beoefenen.', 8, 15),
(8, 'D008', 'Muziekkamp', 'Muziek maken en concerten bezoeken.', 10, 17),
(9, 'D009', 'Techniekkamp', 'Leer alles over technologie.', 11, 18),
(10, 'D010', 'Fotografiekamp', 'Fotografie workshops en excursies.', 12, 18);
SET IDENTITY_INSERT Bestemming OFF;

SET IDENTITY_INSERT Foto ON;
INSERT INTO Foto (Id, Naam, BestemmingId) VALUES
(1, 'strand.jpg', 1),
(2, 'bergen.jpg', 2),
(3, 'stad.jpg', 3),
(4, 'bos.jpg', 4),
(5, 'zeilboot.jpg', 5),
(6, 'kunst.jpg', 6),
(7, 'sport.jpg', 7),
(8, 'muziek.jpg', 8),
(9, 'techniek.jpg', 9),
(10, 'fotografie.jpg', 10);
SET IDENTITY_INSERT Foto OFF;

SET IDENTITY_INSERT Groepsreis ON;
INSERT INTO Groepsreis (Id, BestemmingId, BeginDatum, EindDatum, prijs) VALUES
(1, 1, '2023-07-01', '2023-07-07', 500.0),
(2, 2, '2023-08-10', '2023-08-17', 750.0),
(3, 3, '2023-07-15', '2023-07-22', 600.0),
(4, 4, '2023-06-20', '2023-06-27', 550.0),
(5, 5, '2023-07-05', '2023-07-12', 800.0),
(6, 6, '2023-08-01', '2023-08-08', 650.0),
(7, 7, '2023-07-25', '2023-08-01', 700.0),
(8, 8, '2023-08-15', '2023-08-22', 750.0),
(9, 9, '2023-07-10', '2023-07-17', 720.0),
(10, 10, '2023-08-05', '2023-08-12', 770.0);
SET IDENTITY_INSERT Groepsreis OFF;

SET IDENTITY_INSERT Activiteit ON;
INSERT INTO Activiteit (Id, Naam, Beschrijving) VALUES
(1, 'Zwemmen', 'Lekker zwemmen in het zwembad.'),
(2, 'Kampvuur', 'Gezellig kampvuur in de avond.'),
(3, 'Wandelen', 'Avontuurlijke wandeling door het bos.'),
(4, 'Fietsen', 'Fietstocht door de stad.'),
(5, 'Knutselen', 'Creatieve knutselactiviteiten.'),
(6, 'Voetbal', 'Een spannend potje voetbal.'),
(7, 'Speurtocht', 'Een uitdagende speurtocht.'),
(8, 'Koken', 'Samen lekkere gerechten maken.'),
(9, 'Dansen', 'Dansworkshop voor alle leeftijden.');
SET IDENTITY_INSERT Activiteit OFF;

SET IDENTITY_INSERT Programma ON;
INSERT INTO Programma (Id, ActiviteidId, GroepsreisId) VALUES
(1, 1, 1),
(2, 2, 1),
(3, 3, 2),
(4, 4, 2),
(5, 5, 3),
(6, 6, 3),
(7, 7, 4),
(8, 8, 4),
(9, 9, 5);
SET IDENTITY_INSERT Programma OFF;

SET IDENTITY_INSERT Onkosten ON;
INSERT INTO Onkosten (Id, GroepsreisId, Titel, Omschrijving, Bedrag, Datum, Foto) VALUES
(1, 1, 'Boodschappen', 'Boodschappen voor het kamp', 200.0, '2023-07-01', NULL),
(2, 2, 'Bus Huur', 'Huur van bus voor vervoer', 500.0, '2023-08-10', NULL),
(3, 3, 'Materialen', 'Materialen voor workshops', 150.0, '2023-07-15', NULL),
(4, 4, 'Kampeerspullen', 'Huur van tenten', 300.0, '2023-06-20', NULL),
(5, 5, 'Zeilboten', 'Huur van zeilboten', 600.0, '2023-07-05', NULL),
(6, 6, 'Musea Tickets', 'Toegang tot musea', 250.0, '2023-08-01', NULL),
(7, 7, 'Sportuitrusting', 'Aankoop sportmateriaal', 400.0, '2023-07-25', NULL),
(8, 8, 'Concertkaartjes', 'Bezoek aan concerten', 350.0, '2023-08-15', NULL),
(9, 9, 'Technische Apparatuur', 'Huur apparatuur', 500.0, '2023-07-10', NULL),
(10, 10, 'Fotocamera''s', 'Huur van camera''s', 450.0, '2023-08-05', NULL);
SET IDENTITY_INSERT Onkosten OFF;


INSERT INTO AspNetUsers (
    Id, Naam, Voornaam, Straat, Huisnummer, Gemeente, Postcode, GeboorteDatum, 
    Huisdokter, ContactNummer, Email, IsHoofdMonitor, TelefoonNummer, 
    RekeningNummer, IsActief, UserName, NormalizedUserName, NormalizedEmail, 
    EmailConfirmed, AccessFailedCount, ConcurrencyStamp, PhoneNumberConfirmed, 
    TwoFactorEnabled, LockoutEnabled, LockoutEnd, PasswordHash
) 
VALUES 
-- Gebruiker 1
('user1', 'Jansen', 'Jan', 'Hoofdstraat', '1', 'Amsterdam', '1000 AA', '1980-01-01', 
 'Dr. Smit', '0612345678', 'jan.jansen@example.com', NULL, '0612345678', 
 'NL00BANK0123456789', 1, 'jan.jansen', 'JAN.JANSEN', 'JAN.JANSEN@EXAMPLE.COM', 
 1, 0, NEWID(), 0, 0, 0, NULL, 'AQAAAAEAACcQAAAAEPA0ilNiENW5caMaSm+koWVeW4mK3JCyUBRwezLMHbBfT83eEsMdkac5Zb9NU8I3Ug=='),

-- Gebruiker 2
('user2', 'De Vries', 'Anna', 'Kerkstraat', '25', 'Rotterdam', '2000 BB', '1992-05-15', 
 'Dr. Pietersen', '0611223344', 'anna.devries@example.com', NULL, '0611223344', 
 'NL00BANK9876543210', 1, 'anna.devries', 'ANNA.DEVRIES', 'ANNA.DEVRIES@EXAMPLE.COM', 
 1, 0, NEWID(), 0, 0, 0, NULL, 'AQAAAAEAACcQAAAAEPA0ilNiENW5caMaSm+koWVeW4mK3JCyUBRwezLMHbBfT83eEsMdkac5Zb9NU8I3Ug=='),

-- Gebruiker 3
('user3', 'Bakker', 'Klaas', 'Dorpstraat', '12A', 'Utrecht', '3000 CC', '1985-10-20', 
 'Dr. Van Dijk', '0615566778', 'klaas.bakker@example.com', 1, '0615566778', 
 'NL00BANK1234567890', 1, 'klaas.bakker', 'KLAAS.BAKKER', 'KLAAS.BAKKER@EXAMPLE.COM', 
 1, 0, NEWID(), 0, 0, 0, NULL, 'AQAAAAEAACcQAAAAEPA0ilNiENW5caMaSm+koWVeW4mK3JCyUBRwezLMHbBfT83eEsMdkac5Zb9NU8I3Ug=='),

-- Gebruiker 4
('user4', 'Meijer', 'Sophie', 'Lindelaan', '7', 'Den Haag', '4000 DD', '1995-03-12', 
 'Dr. Janssen', '0622334455', 'sophie.meijer@example.com', NULL, '0622334455', 
 'NL00BANK5647382910', 1, 'sophie.meijer', 'SOPHIE.MEIJER', 'SOPHIE.MEIJER@EXAMPLE.COM', 
 1, 0, NEWID(), 0, 0, 0, NULL, 'AQAAAAEAACcQAAAAEPA0ilNiENW5caMaSm+koWVeW4mK3JCyUBRwezLMHbBfT83eEsMdkac5Zb9NU8I3Ug=='),

-- Gebruiker 5
('user5', 'Van Dam', 'Pieter', 'Breestraat', '32B', 'Leiden', '5000 EE', '1978-12-05', 
 'Dr. De Haan', '0644556677', 'pieter.vandam@example.com', NULL, '0644556677', 
 'NL00BANK0987654321', 1, 'pieter.vandam', 'PIETER.VANDAM', 'PIETER.VANDAM@EXAMPLE.COM', 
 1, 0, NEWID(), 0, 0, 0, NULL, 'AQAAAAEAACcQAAAAEPA0ilNiENW5caMaSm+koWVeW4mK3JCyUBRwezLMHbBfT83eEsMdkac5Zb9NU8I3Ug=='),

-- Gebruiker 6
('user6', 'Visser', 'Laura', 'Parklaan', '44', 'Groningen', '6000 FF', '1990-07-23', 
 'Dr. Smits', '0633445566', 'laura.visser@example.com', NULL, '0633445566', 
 'NL00BANK1122334455', 1, 'laura.visser', 'LAURA.VISSER', 'LAURA.VISSER@EXAMPLE.COM', 
 1, 0, NEWID(), 0, 0, 0, NULL, 'AQAAAAEAACcQAAAAEPA0ilNiENW5caMaSm+koWVeW4mK3JCyUBRwezLMHbBfT83eEsMdkac5Zb9NU8I3Ug==');


INSERT INTO AspNetRoles (Id, Name, NormalizedName) VALUES
(1, 'Gebruiker', 'Gebruiker'),
(2, 'Monitor', 'Monitor'),
(3, 'Ouder', 'Ouder'),
(4, 'Verantwoordelijke', 'Verantwoordelijke');

INSERT INTO AspNetUserRoles (UserId, RoleId) VALUES 
('user1', 1),
('user2', 2),
('user3', 3),
('user4', 4),
('user5', 2),
('user6', 1);

INSERT INTO OpleidingPersoon (Id, OpleidingId, PersoonId) VALUES 
(1, 1, 'user2'),
(2, 2, 'user2'),
(3, 3, 'user2'),
(4, 4, 'user5'),
(5, 5, 'user5'),
(6, 6, 'user5');

SET IDENTITY_INSERT Monitor ON;
INSERT INTO Monitor (Id, PersoonId, GroepsreisId, IsHoofdMonitor) VALUES
(1, 'user2', 1, 0),
(2, 'user5', 2, 0);
SET IDENTITY_INSERT Monitor OFF;

SET IDENTITY_INSERT Kind ON;
INSERT INTO Kind (Id, PersoonId, Naam, Voornaam, GeboorteDatum, Allergieen, Medicatie, CustomUserId) VALUES
(1, 'user3', 'Naam12Jaar', 'Admin', '2012-01-01', 'Geen', 'Geen', 'user3'),
(2, 'user3', 'naam16jaar', 'Admin', '2008-01-01', 'Geen', 'Geen', 'user3'),
(3, 'user3', 'naam18jaar', 'Admin', '2006-01-01', 'Geen', 'Geen', 'user3'),
(4, 'user3', 'naam14jaar', 'Admin', '2010-01-01', 'Geen', 'Geen', 'user3');
SET IDENTITY_INSERT Kind OFF;

SET IDENTITY_INSERT Deelnemer ON;
INSERT INTO Deelnemer (Id, KindId, GroepsreisId, Opmerkingen) VALUES
(1, 1, 1, 'Vegetarisch'),
(3, 3, 2, 'Allergisch voor pinda''s'),
(4, 4, 4, 'Glutenvrij dieet');
SET IDENTITY_INSERT Deelnemer OFF;

SET IDENTITY_INSERT Review ON;
INSERT INTO Review (Id, PersoonId, BestemmingId, Tekst, Score) VALUES
(1, 'user1', 1, 'Heel goede reis, raad het zeker aan!', 5);
SET IDENTITY_INSERT Review OFF;