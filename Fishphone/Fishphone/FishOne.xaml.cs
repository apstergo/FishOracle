using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Fishphone
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FishOne : ContentPage
    {
        public FishOne(Fishcs content)
        {
            InitializeComponent();
            Picc.Source = content.pictureref;
            lableTitli.Text = content.nameitem;
            lableRod.Text = "Род:" + content.rod;
            lableFem.Text = "Семейство:" + content.fam;
            lableType.Text = "Тип:" + content.type;

            if (content.type_feed != string.Empty)
            {
                lableTypeFeed.Text = "Тип питания:" + content.type_feed;
            }
            else
            {
                lableTypeFeed.IsVisible = false;
            }

            if (content.lifestyle != string.Empty)
            {
                lableLifestyle.Text = "Образ жизни:" + content.lifestyle;
            }
            else
            {
                lableLifestyle.IsVisible = false;
            }

            if (content.areal != string.Empty)
            {
                lableAreal.Text = "Ареал обитания:" + content.areal;
            }
            else
            {
                lableAreal.IsVisible = false;
            }

            if (content.area != string.Empty)
            {
                lableArea.Text = "Среда обитания и особенности поведения:" + content.area;
            }
            else
            {
                lableArea.IsVisible = false;
            }

            if (content.reprod != string.Empty)
            {
                lableReprod.Text = "Размножение:" + content.reprod;
            }
            else
            {
                lableReprod.IsVisible = false;
            }




            lableFeed.Text = content.feed;

            lableOpis.Text = content.opis;
            lableNaj.Text = content.naj;
        }
    }
}