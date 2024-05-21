select * from Authors
select * from Books
select * from Genres
select * from Publishers
select * from Orders
select * from Users
select * from Reviews

insert into Authors(name)
values('Stephen King'),
 	  ('Maks Kidruk'),
	  ('William Shakespeare');

insert into Publishers(Name)
values('Bearded Tomarin'),
	  ('KSD'),
	  ('Folio')

insert into Books(ISBN, Title, Stock, PublishedYear, Price, Sheets, AuthorId, PublisherId, GenreId, Description)
values(9786179526770, 'Colony', 100, 2023, 10.0, 904, 2, 1, 2, 'Big book'),
      (9781668002179, 'Fairy Tale', 50, 2023, 12.0, 608, 1, 2, 5, 'Not a big book'),
	  (9786171256101, 'Stronghole', 65, 2013, 9.0, 560, 2, 1, 3, 'Book about jungles')

insert into Users(Username, Password, IsAdmin)
values('Vlad', 1, 0),
	  ('Olga', 1, 0),
	  ('Petya228', 1, 0)

insert into Reviews(BookId, UserId, Rating, Reviews)
values(2, 3, 5, 'Realy cool book'),
	  (2, 4, 1, 'Not interesting'),
	  (2, 2, 3, 'Not bad')