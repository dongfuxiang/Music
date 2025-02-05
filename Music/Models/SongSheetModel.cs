using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music.Models
{
    public class SongSheetModel
    {
        /// <summary>
        /// 歌单名称
        /// </summary>
        public string Header {  get; set; }
        /// <summary>
        /// 歌单图标
        /// </summary>
        public string Icon { get; set; }
        /// <summary>
        /// 歌曲
        /// </summary>
        public List<SongModel> Songs=new List<SongModel> ();
    }
}
