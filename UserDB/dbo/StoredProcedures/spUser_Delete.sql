CREATE PROCEDURE [dbo].[spUser_Delete]
	@Id int
AS
begin
	delete
	dbo.[User]
	where Id= @Id;
end
