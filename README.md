# MVC Builder

### About.

This application creates a fully built, CRUD functional, MVC AspNet Core Web Server w/ EF Migration, User Authentication, and Authorization. 

### Setup.

- Create a new MySQL Schema.
- Open your terminal to your desired location, and run this command:

```bash
git clone https://github.com/littlestbrother/MVCAuthBuilder && cd MVCAuthBuilder && rm -rf .git && chmod +x build.sh && ./build.sh
```

- Follow the builder instructions, remember to capitalize the first letter of your `Project Name`,&nbsp; `Foo`,&nbsp;and `Bar`. Make sure the `SQL database name` matches the schema name previously created.

```
🏠 Project Name: Library

👤 Foo (Category): Genre

👥 Bar (Item): Book

🗂  SQL database name: db_name
```
- Change "password" for your database in your `appsettings.json` to match the password of your database. 

### That's it.

The builder should automatically create the project and run the server. Navigate to: [http://localhost:5000/](http://localhost:5000/) to use it.

### Bugs :/

MacOS's bash shell interprets this code differently and will append `-e` onto all files four times whilst duplicating them! I'm also not sure how it will work on WSL or Git Bash).
