using Music.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music.ViewModels
{
    public class MainViewModel
    {
        public ObservableCollection<SongSheetModel> SList { get; set; }

        public MainViewModel()
        {
            SList = new ObservableCollection<SongSheetModel>
            {
                new SongSheetModel { Header="默认歌单",Icon="\ue668"},
                new SongSheetModel { Header="本地音乐",Icon="\ue668"},
                new SongSheetModel { Header="歌单AAAA",Icon="\ue668"},
            };
        }
    }
}
