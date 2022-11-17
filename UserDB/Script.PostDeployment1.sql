if not exists( select 1 from dbo.[User])
begin
  insert into dbo.[User] (FirstName,LastName)
  values ('krishna','paruchuri'),  
  ('santhi','paruchuri'),
  ('Nithvik','paruchuri'),
  ('Dhruvika','paruchuri'), 
  ('Mahesh','alapati');
end
