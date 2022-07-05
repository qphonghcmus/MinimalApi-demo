If not exists (select 1 from dbo.[User])
begin
	insert into dbo.[User] (FirstName, LastName)
	values ('Cristiano', 'Ronaldo'),
	('Lionel', 'Messi'),
	('Ricardo', 'Kaka'),
	('Fernando', 'Torres');
end