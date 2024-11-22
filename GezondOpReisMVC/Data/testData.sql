
set identity_insert dbo.Activiteit on
insert into dbo.Activiteit (Id, Naam, Beschrijving)
values (1, 'Activiteit 1', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur lacus erat, mattis at tortor nec, volutpat maximus justo. Integer ut accumsan mi, ac mollis lectus. Nunc enim eros, vulputate a mollis sit amet, aliquet non erat.'),
	   (2, 'Activiteit 2', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur lacus erat, mattis at tortor nec, volutpat maximus justo. Integer ut accumsan mi, ac mollis lectus. Nunc enim eros, vulputate a mollis sit amet, aliquet non erat.'),
	   (3, 'Activiteit 3', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur lacus erat, mattis at tortor nec, volutpat maximus justo. Integer ut accumsan mi, ac mollis lectus. Nunc enim eros, vulputate a mollis sit amet, aliquet non erat.'),
	   (4, 'Activiteit 4', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur lacus erat, mattis at tortor nec, volutpat maximus justo. Integer ut accumsan mi, ac mollis lectus. Nunc enim eros, vulputate a mollis sit amet, aliquet non erat.'),
	   (5, 'Activiteit 5', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur lacus erat, mattis at tortor nec, volutpat maximus justo. Integer ut accumsan mi, ac mollis lectus. Nunc enim eros, vulputate a mollis sit amet, aliquet non erat.')
set identity_insert dbo.Activiteit off


set identity_insert dbo.Bestemming on
insert into dbo.Bestemming (Id, Code, Naam, Beschrijving, MinLeeftijd, MaxLeeftijd)
values (1, 'nVKRLlwk', 'TestBestemming 1', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur lacus erat, mattis at tortor nec, volutpat maximus justo. Integer ut accumsan mi, ac mollis lectus. Nunc enim eros, vulputate a mollis sit amet, aliquet non erat.', 6, 25),
	   (2, 'njY7fhmZ', 'TestBestemming 2', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur lacus erat, mattis at tortor nec, volutpat maximus justo. Integer ut accumsan mi, ac mollis lectus. Nunc enim eros, vulputate a mollis sit amet, aliquet non erat.', 12, 35),
	   (3, 'nXmAqfXy', 'TestBestemming 3', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur lacus erat, mattis at tortor nec, volutpat maximus justo. Integer ut accumsan mi, ac mollis lectus. Nunc enim eros, vulputate a mollis sit amet, aliquet non erat.', 5, 15),
	   (4, 'h35bsqPi', 'TestBestemming 4', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur lacus erat, mattis at tortor nec, volutpat maximus justo. Integer ut accumsan mi, ac mollis lectus. Nunc enim eros, vulputate a mollis sit amet, aliquet non erat.', 10, 26),
	   (5, 'nJZMkz9Q', 'TestBestemming 5', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur lacus erat, mattis at tortor nec, volutpat maximus justo. Integer ut accumsan mi, ac mollis lectus. Nunc enim eros, vulputate a mollis sit amet, aliquet non erat.', 2.5, 12)
set identity_insert dbo.Bestemming off


set identity_insert dbo.Foto on
insert into dbo.Foto (Id, Naam, BestemmingId)
values (1, 'surfen', 1),
	   (2, 'klimmen', 2),
	   (3, 'zwemmen', 3),
	   (4, 'strandvolleybal', 4),
	   (5, 'fotozoektocht', 5)
set identity_insert dbo.Foto off