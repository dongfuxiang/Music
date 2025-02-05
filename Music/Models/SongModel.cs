using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music.Models
{
    public class SongModel
    {
        public int Index { get; set; }
        /// <summary>
        /// 封面
        /// </summary>
        public string Cover { get; set; }
        /// <summary>
        /// 歌名
        /// </summary>
        public string SongName { get; set; }
        /// <summary>
        /// 本地歌曲位置
        /// </summary>
        public string FilePath { get; set; }
        /// <summary>
        /// 歌唱者
        /// </summary>
        public string Singer { get; set; }
        /// <summary>
        /// 时长
        /// </summary>
        public string Duration { get; set; }
        /// <summary>
        /// 歌曲网络位置，歌曲的详情页
        /// </summary>
        public string Url { get; set; }
    }
}
