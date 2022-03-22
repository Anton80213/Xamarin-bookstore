using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Книжный_магазин
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class BookPage1 : ContentPage
	{
        List<Book> books;
        public BookPage1 ()
		{
			InitializeComponent ();
            // определяем триггер для элемента Entry
            var trigger = new Trigger(typeof(Entry))
            {
                Property = Entry.IsFocusedProperty,
                Value = true
            };
            // установка зеленого фона
            trigger.Setters.Add(new Setter
            {
                Property = Entry.BackgroundColorProperty,
                Value = Color.Green
            });
            // установка белого цвета текста
            trigger.Setters.Add(new Setter
            {
                Property = Entry.TextColorProperty,
                Value = Color.White
            });
            // добавляем триггер
            searchEntry.Triggers.Add(trigger);
            searchBtn.Clicked += (sender, e) => SearchBooks(searchEntry.Text);
        }
        protected override async void OnAppearing()
        {
            books = await App.Database.GetItemsAsync();
            // создание таблицы, если ее нет
            await App.Database.CreateTable();
            // привязка данных
            booksList.ItemsSource = books;

            base.OnAppearing();
        }
        private void SearchBooks(string text)
        {
            if (!string.IsNullOrEmpty(text))
            {
                booksList.ItemsSource = books.Where(u => u.Название_книги.Contains(text));
            }
            else
            {
               booksList.ItemsSource = books;
            }
        }
        // обработка нажатия элемента в списке
        private async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Book selectedBook = (Book)e.SelectedItem;
            BookPage2 bookPage = new BookPage2(selectedBook);
            await Navigation.PushAsync(bookPage);
        }
        // обработка нажатия кнопки добавления
        private async void CreateBook(object sender, EventArgs e)
        {
            BookPage2 bookPage = new BookPage2(null);
            await Navigation.PushAsync(bookPage);
        }
    }
}