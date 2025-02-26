using FirstHW;
using System.Drawing;

namespace HtmlPages
{
    public static class Pages
    {
        public static async Task<string> GetDateTimePage()
        {
            return $@"<!DOCTYPE html>
            <html lang=""ru"">
            <head>
                <meta charset=""UTF-8"">
                <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
                <title>Информационная страница</title>
                <style>
                    body {{
                        display: flex;
                        justify-content: center;
                        align-items: center;
                        height: 100vh;
                        margin: 0;
                        background-color: #e0f2e9;
                        font-family: Arial, sans-serif;
                    }}
                    .text-block {{
                        background-color: #a5d6a7;
                        padding: 20px;
                        border-radius: 10px;
                        box-shadow: 0 0 10px rgba(46, 125, 50, 0.3);
                        text-align: center;
                    }}
                    .links {{
                        margin-top: 20px;
                    }}
                    .links a {{
                        display: block;
                        margin: 5px 0;
                        color: #2e7d32;
                        text-decoration: none;
                        font-weight: bold;
                    }}
                </style>
                <script>
                    function updateDateTime() {{
                        const now = new Date();
                        document.getElementById(""datetime"").textContent = `Сегодня: ${{now.toLocaleString()}}`;
                    }}
                    window.onload = updateDateTime;
                </script>
            </head>
            <body>
                <div class=""text-block"">
                    <h1>Добро пожаловать!</h1>
                    <p id=""datetime""></p>
                    <div class=""links"">
                        <a href=""/browser"">Информация о user агенте</a>
                        <a href=""/books"">Страница со списком всех книг</a>
                        <a href=""#"">Ссылка 3</a>
                    </div>
                </div>
            </body>
            </html>
            ";
        }
       public static async Task<string> GetBrowserInfoPage(string info)
        {
            return $@"
                <!DOCTYPE html>
                <html lang=""ru"">
                <head>
                    <meta charset=""UTF-8"">
                    <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
                    <title>Информационная страница</title>
                    <style>
                        body {{
                            display: flex;
                            justify-content: center;
                            align-items: center;
                            height: 100vh;
                            background-color: #e0f2e9;
                            color: #2e7d32;
                            font-family: Arial, sans-serif;
                            text-align: center;
                        }}
                        .container {{
                            padding: 20px;
                            background: #a5d6a7;
                            border-radius: 10px;
                            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.2);
                        }}
                    </style>
                </head>
                <body>
                    <div class=""container"">
                        <h1>Добро пожаловать!</h1>
                        <p>{info}</p>
                    </div>
                </body>
                </html>";
        }
        public static async Task<string> GetBooksPage(List<Book> books)
        {
            var html = "<html><body><h1>Список книг</h1><ul>";
            foreach (var book in books)
            {
                html += $"<li><a href='/book/{book.Id}'>{book.Title}</a> Написана автором: {book.Author}</li>";
            }
            html += "</ul></body></html>";
            return html;
        }
    }
}
