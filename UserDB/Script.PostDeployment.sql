if not exists (select 1 from dbo.[User])
begin
	insert into dbo.[User] (FirstName, LastName)
	values ('Steve', 'McTeague'),
	('Nick', 'Lemke'),
	('Bob', 'McNulty'),
	('Tabitha', 'Schiedel');
end
