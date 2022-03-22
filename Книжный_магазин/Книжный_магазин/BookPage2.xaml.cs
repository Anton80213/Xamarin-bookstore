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
	public partial class BookPage2 : ContentPage
	{
        public Book Book { get; set; }
        public BookPage2 (Book book)
		{
			InitializeComponent ();
            
            this.Book = book;
            if (book == null)
            {
                Book = new Book(); 
                button2.IsEnabled = false;
                button3.IsEnabled = false;
            }
            this.BindingContext = Book;
        }
        private async void SaveBook(object sender, EventArgs e)
        {
            var book = (Book)BindingContext;
            if (!String.IsNullOrEmpty(book.Название_книги))
            {
                await App.Database.SaveItemAsync(book);
            }
            await this.Navigation.PopAsync();
        }
        private async void DeleteBook(object sender, EventArgs e)
        {
            var book = (Book)BindingContext;
            await App.Database.DeleteItemAsync(book);
            await this.Navigation.PopAsync();
        }
        private async void OrderBook(object sender, EventArgs e)
        {
            await DisplayAlert("Уведомление", "Заказ успешно оформлен", "ОK");
        }
        private async void Cancel(object sender, EventArgs e)
        {
            await this.Navigation.PopAsync();
        }
    }
}