using Microsoft.AppCenter.Push;
using Plugin.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Fishphone
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TabbPage : TabbedPage
    {
        public static int pickerSelectId =  0;
        public string[] city_short = new string[] { "msc", "spb", "alt", "amu", "arh", "ast", "belg", "br", "vlad", "volggr", "volgdn", "vor", "eat", "zab", "ivan", "irkut", "kaliningrad", "kalugь", "kamch", "kemer", "kir", "kost", "karasnodar", "krasnoyarsk", "kurg", "kursk", "lenobl", "lip", "magadan", "mscobl", "murm", "NAO", "nijgor", "novgor", "novosib", "omsk", "orenb", "orl", "penz", "perm", "prim", "pskov", "adigeya", "altres", "bashk", "burat", "dag", "ing", "karcher", "kabbal", "kalm", "karel", "komi", "krim", "marial", "mord", "saha", "sevos", "tat", "tiva", "udmurt", "hakasia", "chechnia", "chuv", "rost", "rias", "sam", "sar", "sahalin", "sverd", "smol", "stav", "tamb", "tver", "tomsk", "tulsk", "tum", "ulyan", "hab", "yugra", "chel", "chukot", "yanao", "yaroslavsk" };

        public TabbPage ()
        {
            InitializeComponent();
            GeoLoc();
            Subscribe();
        }
        public async void GeoLoc()
        {
            try
            {
                var location =  await Geolocation.GetLastKnownLocationAsync();
                try
                {
                    var placemarksLocal =  await Geocoding.GetPlacemarksAsync(location.Latitude, location.Longitude);

                    var placemarkLocal =  placemarksLocal?.FirstOrDefault();

                    if (placemarksLocal != null)
                    {
                        if (placemarkLocal.AdminArea.Contains("Саратовская"))
                        {
                            pickerSelectId = 67;
                        }
                        else if (placemarkLocal.AdminArea.Contains("Самарская"))
                        {
                            pickerSelectId = 66;
                        }
                        else if (placemarkLocal.AdminArea.Contains("Нижегородская"))
                        {
                            pickerSelectId = 33;
                        }
                        else if (placemarkLocal.AdminArea.Contains("Ленинградская"))
                        {
                            pickerSelectId = 26;
                        }
                        else if (placemarkLocal.AdminArea.Contains("Санкт-Петербург"))
                        {
                            pickerSelectId = 2;
                        }
                        else if (placemarkLocal.AdminArea.Contains("Алтайский"))
                        {
                            pickerSelectId = 3;
                        }
                        else if (placemarkLocal.AdminArea.Contains("Амурская"))
                        {
                            pickerSelectId = 4;
                        }
                        else if (placemarkLocal.AdminArea.Contains("Архангельская"))
                        {
                            pickerSelectId = 5;
                        }
                        else if (placemarkLocal.AdminArea.Contains("Белгородская"))
                        {
                            pickerSelectId = 6;
                        }
                        else if (placemarkLocal.AdminArea.Contains("Брянская"))
                        {
                            pickerSelectId = 7;
                        }
                        else if (placemarkLocal.AdminArea.Contains("Владимирская"))
                        {
                            pickerSelectId = 8;
                        }
                        else if (placemarkLocal.AdminArea.Contains("Волгоградская"))
                        {
                            pickerSelectId = 9;
                        }
                        else if (placemarkLocal.AdminArea.Contains("Вологодская"))
                        {
                            pickerSelectId = 10;
                        }
                        else if (placemarkLocal.AdminArea.Contains("Воронежская"))
                        {
                            pickerSelectId = 11;
                        }
                        else if (placemarkLocal.AdminArea.Contains("Еврейская"))
                        {
                            pickerSelectId = 12;
                        }
                        else if (placemarkLocal.AdminArea.Contains("Забайкальский"))
                        {
                            pickerSelectId = 13;
                        }
                        else if (placemarkLocal.AdminArea.Contains("Ивановская"))
                        {
                            pickerSelectId = 14;
                        }
                        else if (placemarkLocal.AdminArea.Contains("Иркутская"))
                        {
                            pickerSelectId = 15;
                        }
                        else if (placemarkLocal.AdminArea.Contains("Калининградская"))
                        {
                            pickerSelectId = 16;
                        }
                        else if (placemarkLocal.AdminArea.Contains("Калужская"))
                        {
                            pickerSelectId = 17;
                        }
                        else if (placemarkLocal.AdminArea.Contains("Камчатский"))
                        {
                            pickerSelectId = 18;
                        }
                        else if (placemarkLocal.AdminArea.Contains("Кемеровская"))
                        {
                            pickerSelectId = 19;
                        }
                        else if (placemarkLocal.AdminArea.Contains("Кировская"))
                        {
                            pickerSelectId =  20;
                        }
                        else if (placemarkLocal.AdminArea.Contains("Костромская"))
                        {
                            pickerSelectId = 21;
                        }
                        else if (placemarkLocal.AdminArea.Contains("Краснодарский"))
                        {
                            pickerSelectId = 22;
                        }
                        else if (placemarkLocal.AdminArea.Contains("Красноярский"))
                        {
                            pickerSelectId = 23;
                        }
                        else if (placemarkLocal.AdminArea.Contains("Курганская"))
                        {
                            pickerSelectId = 24;
                        }
                        else if (placemarkLocal.AdminArea.Contains("Курская"))
                        {
                            pickerSelectId = 25;
                        }
                        else if (placemarkLocal.AdminArea.Contains("Липецкая"))
                        {
                            pickerSelectId = 27;
                        }
                        else if (placemarkLocal.AdminArea.Contains("Магаданская"))
                        {
                            pickerSelectId = 28;
                        }
                        else if (placemarkLocal.AdminArea.Contains("Московская"))
                        {
                            pickerSelectId = 29;
                        }
                        else if (placemarkLocal.AdminArea.Contains("Мурманская"))
                        {
                            pickerSelectId = 30;
                        }
                        else if (placemarkLocal.AdminArea.Contains("Ненецкий"))
                        {
                            pickerSelectId = 31;
                        }
                        else if (placemarkLocal.AdminArea.Contains("Новгородская"))
                        {
                            pickerSelectId = 33;
                        }
                        else if (placemarkLocal.AdminArea.Contains("Новосибирская"))
                        {
                            pickerSelectId = 34;
                        }
                        else if (placemarkLocal.AdminArea.Contains("Омская"))
                        {
                            pickerSelectId = 35;
                        }
                        else if (placemarkLocal.AdminArea.Contains("Оренбургская"))
                        {
                            pickerSelectId = 36;
                        }
                        else if (placemarkLocal.AdminArea.Contains("Орловская"))
                        {
                            pickerSelectId = 37;
                        }
                        else if (placemarkLocal.AdminArea.Contains("Пензенская"))
                        {
                            pickerSelectId = 38;
                        }
                        else if (placemarkLocal.AdminArea.Contains("Пермский"))
                        {
                            pickerSelectId = 39;
                        }
                        else if (placemarkLocal.AdminArea.Contains("Приморский"))
                        {
                            pickerSelectId = 40;
                        }
                        else if (placemarkLocal.AdminArea.Contains("Псковская"))
                        {
                            pickerSelectId = 41;
                        }
                        else if (placemarkLocal.AdminArea.Contains("Адыгея"))
                        {
                            pickerSelectId = 42;
                        }
                        else if (placemarkLocal.AdminArea.Contains("Алтай"))
                        {
                            pickerSelectId = 43;
                        }
                        else if (placemarkLocal.AdminArea.Contains("Башкортостан"))
                        {
                            pickerSelectId = 44;
                        }
                        else if (placemarkLocal.AdminArea.Contains("Бурятия"))
                        {
                            pickerSelectId = 45;
                        }
                        else if (placemarkLocal.AdminArea.Contains("Дагестан"))
                        {
                            pickerSelectId = 46;
                        }
                        else if (placemarkLocal.AdminArea.Contains("Ингушетия"))
                        {
                            pickerSelectId = 47;
                        }
                        else if (placemarkLocal.AdminArea.Contains("Карачаево-Черкесия"))
                        {
                            pickerSelectId = 48;
                        }
                        else if (placemarkLocal.AdminArea.Contains("Кабардино-Балкария"))
                        {
                            pickerSelectId = 49;
                        }
                        else if (placemarkLocal.AdminArea.Contains("Калмыкия"))
                        {
                            pickerSelectId = 50;
                        }
                        else if (placemarkLocal.AdminArea.Contains("Карелия"))
                        {
                            pickerSelectId = 51;
                        }
                        else if (placemarkLocal.AdminArea.Contains("Коми"))
                        {
                            pickerSelectId = 52;
                        }
                        else if (placemarkLocal.AdminArea.Contains("Крым"))
                        {
                            pickerSelectId = 53;
                        }
                        else if (placemarkLocal.AdminArea.Contains("Марий Эл"))
                        {
                            pickerSelectId = 54;
                        }
                        else if (placemarkLocal.AdminArea.Contains("Мордовия"))
                        {
                            pickerSelectId = 55;
                        }
                        else if (placemarkLocal.AdminArea.Contains("Саха"))
                        {
                            pickerSelectId = 56;
                        }
                        else if (placemarkLocal.AdminArea.Contains("Якутия"))
                        {
                            pickerSelectId = 56;
                        }
                        else if (placemarkLocal.AdminArea.Contains("Осетия"))
                        {
                            pickerSelectId = 57;
                        }
                        else if (placemarkLocal.AdminArea.Contains("Татарстан"))
                        {
                            pickerSelectId = 58;
                        }
                        else if (placemarkLocal.AdminArea.Contains("Тыва"))
                        {
                            pickerSelectId = 59;
                        }
                        else if (placemarkLocal.AdminArea.Contains("Удмуртия"))
                        {
                            pickerSelectId = 60;
                        }
                        else if (placemarkLocal.AdminArea.Contains("Хакасия"))
                        {
                            pickerSelectId = 61;
                        }
                        else if (placemarkLocal.AdminArea.Contains("Чеченская"))
                        {
                            pickerSelectId = 62;
                        }
                        else if (placemarkLocal.AdminArea.Contains("Чуваш"))
                        {
                            pickerSelectId = 63;
                        }
                        else if (placemarkLocal.AdminArea.Contains("Ростов"))
                        {
                            pickerSelectId = 64;
                        }
                        else if (placemarkLocal.AdminArea.Contains("Рязан"))
                        {
                            pickerSelectId = 65;
                        }
                        else if (placemarkLocal.AdminArea.Contains("Сахалинская"))
                        {
                            pickerSelectId = 68;
                        }
                        else if (placemarkLocal.AdminArea.Contains("Свердловская"))
                        {
                            pickerSelectId = 69;
                        }
                        else if (placemarkLocal.AdminArea.Contains("Смоленская"))
                        {
                            pickerSelectId = 70;
                        }
                        else if (placemarkLocal.AdminArea.Contains("Ставропольский"))
                        {
                            pickerSelectId = 71;
                        }
                        else if (placemarkLocal.AdminArea.Contains("Тамбовская"))
                        {
                            pickerSelectId = 72;
                        }
                        else if (placemarkLocal.AdminArea.Contains("Твер"))
                        {
                            pickerSelectId = 73;
                        }
                        else if (placemarkLocal.AdminArea.Contains("Томская"))
                        {
                            pickerSelectId = 74;
                        }
                        else if (placemarkLocal.AdminArea.Contains("Тульская"))
                        {
                            pickerSelectId = 75;
                        }
                        else if (placemarkLocal.AdminArea.Contains("Тюменская"))
                        {
                            pickerSelectId = 76;
                        }
                        else if (placemarkLocal.AdminArea.Contains("Ульяновская"))
                        {
                            pickerSelectId = 77;
                        }
                        else if (placemarkLocal.AdminArea.Contains("Хабаровск"))
                        {
                            pickerSelectId = 78;
                        }
                        else if (placemarkLocal.AdminArea.Contains("ХМАО"))
                        {
                            pickerSelectId = 79;
                        }
                        else if (placemarkLocal.AdminArea.Contains("Югра"))
                        {
                            pickerSelectId = 79;
                        }
                        else if (placemarkLocal.AdminArea.Contains("Челябинская"))
                        {
                            pickerSelectId = 80;
                        }
                        else if (placemarkLocal.AdminArea.Contains("Чукотский"))
                        {
                            pickerSelectId = 81;
                        }
                        else if (placemarkLocal.AdminArea.Contains("ЯНАО"))
                        {
                            pickerSelectId = 82;
                        }
                        else if (placemarkLocal.AdminArea.Contains("Ярославская"))
                        {
                            pickerSelectId = 83;
                        }
                        else
                        {
                            pickerSelectId = CrossSettings.Current.GetValueOrDefault("DefaultCity", 0);
                        }

                        if(CrossSettings.Current.GetValueOrDefault("DefaultCity", -1)==-1)
                        {
                            CrossSettings.Current.AddOrUpdateValue("DefaultCity", pickerSelectId);
                            DependencyService.Get<ISubcribePush>().Subcribe(city_short[pickerSelectId]);
                        }

                        picker.SelectedIndex =  pickerSelectId;
                    }
                    MessagingCenter.Send<TabbPage>(this, "FirstGeo");
                    
                }
                catch
                {
                    picker.SelectedIndex = CrossSettings.Current.GetValueOrDefault("DefaultCity", 0);
                }

            }
            catch
            {
                picker.SelectedIndex = CrossSettings.Current.GetValueOrDefault("DefaultCity", 0);
            }
            
        }

        private void Subscribe()
        {
            MessagingCenter.Subscribe<Parser>(
                this, // кто подписывается на сообщения
                "DefultCity",   // название сообщения
                (sender) => { picker.SelectedIndex = CrossSettings.Current.GetValueOrDefault("DefaultCity", 0); });    // вызываемое действие
        }

        private void Picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            var klev =  new Parser();
            pickerSelectId =  picker.SelectedIndex;
            CurrentPage =  klev;
            MessagingCenter.Send<TabbPage>(this, "CitySelect");
            
        }

        private async void MenuItem1_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SettingsPage());
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            picker.Focus();
        }

        private void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            picker.Focus();
        }

        private async void TapGestureRecognizer_Tapped_2(object sender, EventArgs e)
        {
            GeoLoc();
            
        }
    }
}