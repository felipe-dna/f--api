namespace Migrations
open SimpleMigrations

[<Migration(202211212009L, "Create Books")>]
type CreateBooks() =
  inherit Migration()

  override __.Up() =
    base.Execute(@"CREATE TABLE Books(
      id TEXT NOT NULL,
      title TEXT NOT NULL,
      author TEXT NOT NULL
    )")

  override __.Down() =
    base.Execute(@"DROP TABLE Books")
