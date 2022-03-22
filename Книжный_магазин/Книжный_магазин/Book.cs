using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
namespace Книжный_магазин
{
    [Table("Books")]
    public class Book
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }
        public string Жанр { get; set; }
        public string Автор { get; set; }
        public string Название_книги { get; set; }
        public string Цена { get; set; }
    }
}

