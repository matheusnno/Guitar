using Xamarin.Forms;
using Afinador.ViewModels;

namespace Afinador.Views
{
    public partial class metronomePage : ContentPage
    {
        public metronomePage()
        {
            InitializeComponent();
            BindingContext = new metronomoViewModel();
        }
    }
}
