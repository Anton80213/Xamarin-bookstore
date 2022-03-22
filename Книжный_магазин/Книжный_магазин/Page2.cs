using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Книжный_магазин
{
    public class Page2 : ContentPage
    {
        public Page2(Label label, Button alertButton)
        {
            Title = "Cтраница 2";
            Label header = new Label()
            {
                Text = "Стоимость выбранного товара:",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                BackgroundColor = Color.Aqua,
                TextColor = Color.Black
            };
            Button nextButton = new Button
            {
                Text = "Вперед",
                HorizontalOptions = LayoutOptions.End,
                VerticalOptions = LayoutOptions.End,
                BackgroundColor = Color.Red,
                TextColor = Color.Black
            };
            nextButton.Clicked += OnButtonClicked;
            Content = new StackLayout { Children = { header, label, alertButton, nextButton } };
        }
        private async void OnButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new BookPage1());
        }
    }
}

