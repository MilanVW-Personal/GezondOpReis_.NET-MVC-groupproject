set IDENTITY_INSERT AspNetUserRoles ON;
INSERT INTO AspNetUsers (Id, Naam, Voornaam, Straat, Huisnummer, Gemeente, Postcode, GeboorteDatum, Huisdokter, ContactNummer, Email, IsHoofdMonitor, TelefoonNummer, RekeningNummer, IsActief, UserName, NormalizedUserName, NormalizedEmail, EmailConfirmed) VALUES
('user1', 'Jansen', 'Jan', 'Hoofdstraat', '1', 'Amsterdam', '1000 AA', '1980-01-01', 'Dr. Smit', '0612345678', 'jan.jansen@example.com', NULL, '0612345678', 'NL00BANK0123456789', 1, 'jan.jansen', 'JAN.JANSEN', 'JAN.JANSEN@EXAMPLE.COM', 1),
('user2', 'de Vries', 'Anna', 'Kerkstraat', '23', 'Rotterdam', '3000 BB', '1990-05-15', 'Dr. Brown', '0623456789', 'anna.devries@example.com', 1, '0623456789', 'NL00BANK9876543210', 1, 'anna.devries', 'ANNA.DEVRIES', 'ANNA.DEVRIES@EXAMPLE.COM', 1),
('user3', 'Peters', 'Peter', 'Dorpsstraat', '5', 'Utrecht', '3500 CC', '1985-03-10', 'Dr. Green', '0634567890', 'peter.peters@example.com', NULL, '0634567890', 'NL00BANK1122334455', 1, 'peter.peters', 'PETER.PETERS', 'PETER.PETERS@EXAMPLE.COM', 1),
('user4', 'Johnson', 'Maria', 'Lindenlaan', '12', 'Den Haag', '2500 DD', '1978-07-22', 'Dr. Black', '0645678901', 'maria.johnson@example.com', NULL, '0645678901', 'NL00BANK6677889900', 1, 'maria.johnson', 'MARIA.JOHNSON', 'MARIA.JOHNSON@EXAMPLE.COM', 1),
('user5', 'Smits', 'Karel', 'Stationsweg', '34', 'Eindhoven', '5600 EE', '1992-11-30', 'Dr. White', '0656789012', 'karel.smits@example.com', NULL, '0656789012', 'NL00BANK9988776655', 1, 'karel.smits', 'KAREL.SMITS', 'KAREL.SMITS@EXAMPLE.COM', 1),
('user6', 'Vermeer', 'Lisa', 'Schoolstraat', '7', 'Groningen', '9700 FF', '1988-05-05', 'Dr. Grey', '0667890123', 'lisa.vermeer@example.com', NULL, '0667890123', 'NL00BANK5544332211', 1, 'lisa.vermeer', 'LISA.VERMEER', 'LISA.VERMEER@EXAMPLE.COM', 1),
('user7', 'Klaassen', 'Tom', 'Marktplein', '9', 'Maastricht', '6200 GG', '1983-09-17', 'Dr. Blue', '0678901234', 'tom.klaassen@example.com', NULL, '0678901234', 'NL00BANK1234432112', 1, 'tom.klaassen', 'TOM.KLAASSEN', 'TOM.KLAASSEN@EXAMPLE.COM', 1),
('user8', 'Bosch', 'Iris', 'Boomstraat', '15', 'Tilburg', '5000 HH', '1995-12-25', 'Dr. Violet', '0689012345', 'iris.bosch@example.com', NULL, '0689012345', 'NL00BANK2233445566', 1, 'iris.bosch', 'IRIS.BOSCH', 'IRIS.BOSCH@EXAMPLE.COM', 1),
('user9', 'Mulder', 'Mark', 'Waterweg', '21', 'Leiden', '2300 II', '1981-04-18', 'Dr. Orange', '0690123456', 'mark.mulder@example.com', NULL, '0690123456', 'NL00BANK3344556677', 1, 'mark.mulder', 'MARK.MULDER', 'MARK.MULDER@EXAMPLE.COM', 1),
('user10', 'Visser', 'Eva', 'Molenstraat', '3', 'Nijmegen', '6500 JJ', '1986-08-29', 'Dr. Red', '0601234567', 'eva.visser@example.com', NULL, '0601234567', 'NL00BANK4455667788', 1, 'eva.visser', 'EVA.VISSER', 'EVA.VISSER@EXAMPLE.COM', 1);
set IDENTITY_INSERT AspNetUserRoles OFF;

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


SET IDENTITY_INSERT Kind ON;
INSERT INTO Kind (Id, PersoonId, Naam, Voornaam, GeboorteDatum, Allergieen, Medicatie, CustomUserId) VALUES
(1, 'user1', 'Jansen', 'Sophie', '2010-07-01', 'Pollen', 'Antihistaminica', 'user1'),
(2, 'user1', 'Jansen', 'Thomas', '2012-09-15', 'Geen', 'Geen', 'user1'),
(3, 'user2', 'de Vries', 'Emma', '2011-03-20', 'Pinda''s', 'EpiPen', 'user2'),
(4, 'user3', 'Peters', 'Lucas', '2009-11-11', 'Gluten', 'Glutenvrij dieet', 'user3'),
(5, 'user4', 'Johnson', 'Sara', '2013-05-05', 'Lactose', 'Lactosevrije voeding', 'user4'),
(6, 'user5', 'Smits', 'Mila', '2014-08-18', 'Stof', 'Geen', 'user5'),
(7, 'user6', 'Vermeer', 'Daan', '2010-12-24', 'Noten', 'EpiPen', 'user6'),
(8, 'user7', 'Klaassen', 'Lotte', '2008-02-02', 'Insectenbeten', 'Antihistaminica', 'user7'),
(9, 'user8', 'Bosch', 'Finn', '2011-06-30', 'Huisdieren', 'Geen', 'user8'),
(10, 'user9', 'Mulder', 'Sanne', '2009-10-10', 'Geen', 'Geen', 'user9');
SET IDENTITY_INSERT Kind OFF;

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

SET IDENTITY_INSERT Deelnemer ON;
INSERT INTO Deelnemer (Id, KindId, GroepsreisId, Opmerkingen) VALUES
(1, 1, 1, 'Vegetarisch'),
(2, 2, 1, NULL),
(3, 3, 2, 'Allergisch voor pinda''s'),
(4, 4, 4, 'Glutenvrij dieet'),
(5, 5, 6, 'Lactose-intolerant'),
(6, 6, 7, NULL),
(7, 7, 5, 'EpiPen meegebracht'),
(8, 8, 3, 'Medicatie om 12 uur'),
(9, 9, 8, NULL),
(10, 10, 9, NULL);
SET IDENTITY_INSERT Deelnemer OFF;

SET IDENTITY_INSERT Monitor ON;
INSERT INTO Monitor (Id, PersoonId, GroepsreisId, isHoofdMonitor) VALUES
(1, 'user2', 1, 1),
(2, 'user3', 1, 0),
(3, 'user4', 2, 1),
(4, 'user5', 2, 0),
(5, 'user6', 3, 1),
(6, 'user7', 3, 0),
(7, 'user8', 4, 1),
(8, 'user9', 4, 0),
(9, 'user10', 5, 1),
(10, 'user1', 5, 0);
SET IDENTITY_INSERT Monitor OFF;

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
(9, 9, 5),
(10, 10, 5);
SET IDENTITY_INSERT Programma OFF;

SET IDENTITY_INSERT Review ON;
INSERT INTO Review (Id, PersoonId, BestemmingId, Tekst, Score) VALUES
(1, 'user1', 1, 'Geweldige locatie voor kinderen.', 5),
(2, 'user2', 2, 'Prachtige natuur en veel te doen.', 4),
(3, 'user3', 3, 'Interessante stedentrip.', 4),
(4, 'user4', 4, 'Kinderen hebben genoten van het kamp.', 5),
(5, 'user5', 5, 'Leuke activiteiten op het water.', 5),
(6, 'user6', 6, 'Creatief en leerzaam.', 4),
(7, 'user7', 7, 'Veel sport en plezier.', 5),
(8, 'user8', 8, 'Muzieklessen waren geweldig.', 5),
(9, 'user9', 9, 'Technische workshops waren interessant.', 4),
(10, 'user10', 10, 'Veel geleerd over fotografie.', 5);
SET IDENTITY_INSERT Review OFF;


INSERT INTO OpleidingPersoon (OpleidingId, PersoonId, Id) VALUES
(1, 'user2', 1),
(2, 'user3', 2),
(3, 'user4', 3),
(4, 'user5', 4),
(5, 'user6', 5),
(6, 'user7', 6),
(7, 'user8', 7),
(8, 'user9', 8),
(9, 'user10', 9),
(10, 'user1', 10);



INSERT INTO AspNetUserRoles (UserId, RoleId) VALUES
('user1', 'role1'),
('user2', 'role2'),
('user3', 'role2'),
('user4', 'role2'),
('user5', 'role2'),
('user6', 'role2'),
('user7', 'role2'),
('user8', 'role2'),
('user9', 'role2'),
('user10', 'role2');