using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Книжный_магазин
{
    public partial class StartPage : ContentPage
    {
        public StartPage()
        {
            Title = "Главная страница";
            Label header = new Label()
            {
                Text = "Добро пожаловать в книжный магазин!",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Center,
                BackgroundColor = Color.Aquamarine,
                TextColor = Color.Black
            };
            Content = new StackLayout { Children = { header } };
        }
    }
}
