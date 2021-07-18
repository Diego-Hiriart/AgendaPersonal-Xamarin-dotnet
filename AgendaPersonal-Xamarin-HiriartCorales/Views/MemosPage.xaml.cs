using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static AgendaPersonal_Xamarin_HiriartCorales.ViewModels.MemoViewModel;

namespace AgendaPersonal_Xamarin_HiriartCorales.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MemosPage : ContentPage
    {
        public MemosPage()
        {
            InitializeComponent();
            GetMemos();
        }
        public async void GetMemos()
        {
            var memos = await ReadMemos();
            foreach (var memo in memos)//Para poner el string de descripcion a cada evento
            {
                memo.AString();
            }
            this.MemosList.ItemsSource = memos;
        }
    }
}