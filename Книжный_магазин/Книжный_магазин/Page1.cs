using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;


namespace Книжный_магазин
{

    public class Page1 : ContentPage
    {
        Label header, header2, label;
        Picker picker, picker2;
        String text;
        Button alertButton;
        public Page1()
        {
            Title = "Cтраница 1";
            header = new Label()
            {
                Text = "Выберите канцелярский товар",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                BackgroundColor = Color.Yellow,
                TextColor = Color.Red
            };
            header2 = new Label()
            {
                Text = "Укажите количество экземпляров",
                BackgroundColor = Color.GreenYellow,
                TextColor = Color.Black
            };
            picker = new Picker
            {
                Title = "Товар"
            };
            picker.Items.Add("Ручки");
            picker.Items.Add("Карандаши");
            picker.Items.Add("Ластики");
            picker.Items.Add("Альбомы");
            picker.Items.Add("Краски");
            picker.SelectedIndexChanged += picker_SelectedIndexChanged;
            picker2 = new Picker
            {
                Title = "Количество экземпляров"
            };
            picker2.Items.Add("0");
            picker2.Items.Add("1");
            picker2.Items.Add("2");
            picker2.Items.Add("3");
            picker2.Items.Add("4");
            picker2.Items.Add("5");
            picker2.Items.Add("6");
            picker2.Items.Add("7");
            picker2.Items.Add("8");
            picker2.Items.Add("9");
            picker2.Items.Add("10");
            picker2.SelectedIndexChanged += picker2_SelectedIndexChanged;
            Button nextButton = new Button
            {
                Text = "Вперед",
                HorizontalOptions = LayoutOptions.End,
                VerticalOptions = LayoutOptions.Start,
                BackgroundColor = Color.DarkViolet,
                TextColor = Color.White
            };
            nextButton.Clicked += OnButtonClicked;
            alertButton = new Button
            {
                Text = "Заказать выбранный канцелярский товар",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.Center,
                BackgroundColor = Color.YellowGreen,
                TextColor = Color.Black
            };
            alertButton.Clicked += AlertButton_Clicked;
            Content = new StackLayout { Children = { header, header2, picker, picker2, nextButton } };
        }
        private async void OnButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Page2(label, alertButton));
        }
        private void AlertButton_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Уведомление", "Заказ успешно оформлен", "ОK");
        }

        void picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            header.Text = "Вы выбрали: " + picker.Items[picker.SelectedIndex];
            var a = picker2.SelectedItem;
            if (picker.SelectedItem.ToString() == "Ручки")
            {
                if (a != null) text = (int.Parse(a.ToString()) * 7).ToString() + " рублей";
            }
            else if (picker.SelectedItem.ToString() == "Карандаши")
            {
                if (a != null) text = (int.Parse(a.ToString()) * 5).ToString() + " рублей";
            }
            else if (picker.SelectedItem.ToString() == "Ластики")
            {
                if (a != null) text = (int.Parse(a.ToString()) * 6).ToString() + " рублей";
            }
            else if (picker.SelectedItem.ToString() == "Альбомы")
            {
                if (a != null) text = (int.Parse(a.ToString()) * 50).ToString() + " рублей";
            }
            else if (picker.SelectedItem.ToString() == "Краски")
            {
                if (a != null) text = (int.Parse(a.ToString()) * 70).ToString() + " рублей";
            }
            label = new Label()
            {
                Text = text,
                TextColor = Color.Black
            };

        }
        void picker2_SelectedIndexChanged(object sender, EventArgs e)
        {
            header2.Text = "Количество экземпляров: " + picker2.Items[picker2.SelectedIndex];
            if (picker.SelectedItem.ToString() == "Ручки")
            {
                text = (int.Parse(picker2.SelectedItem.ToString()) * 7).ToString() + " рублей";
            }
            else if (picker.SelectedItem.ToString() == "Карандаши")
            {
                text = (int.Parse(picker2.SelectedItem.ToString()) * 5).ToString() + " рублей";
            }
            else if (picker.SelectedItem.ToString() == "Ластики")
            {
                text = (int.Parse(picker2.SelectedItem.ToString()) * 6).ToString() + " рублей";
            }
            else if (picker.SelectedItem.ToString() == "Альбомы")
            {
                text = (int.Parse(picker2.SelectedItem.ToString()) * 50).ToString() + " рублей";
            }
            else if (picker.SelectedItem.ToString() == "Краски")
            {
                text = (int.Parse(picker2.SelectedItem.ToString()) * 70).ToString() + " рублей";
            }
            label = new Label()
            {
                Text = text,
                TextColor = Color.Black
            };
        }

    }
}
