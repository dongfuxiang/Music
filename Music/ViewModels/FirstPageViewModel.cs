using HtmlAgilityPack;
using Music.Base;
using Music.Models;
using PuppeteerSharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using static System.Net.WebRequestMethods;

namespace Music.ViewModels
{
    public class FirstPageViewModel
    {
        public ObservableCollection<AlbumModel> AlbumList { get; set; }
        public ObservableCollection<SongModel> NewList { get; set; }
        public ObservableCollection<SongModel> HotList { get; set; }
        public ObservableCollection<SongModel> Top500List { get; set; }

        public Command<SongModel> PlayCommand { get; set; }
        WebClient wc = new WebClient();
        HtmlDocument htmlDc = new HtmlDocument();
        public FirstPageViewModel()
        {
            AlbumList = new ObservableCollection<AlbumModel>();
            NewList = new ObservableCollection<SongModel>();
            HotList = new ObservableCollection<SongModel>();
            Top500List = new ObservableCollection<SongModel>();
            PlayCommand = new Command<SongModel>(Play);

            //数据来源于网络
            //网站的数据获取

            wc.Encoding = Encoding.UTF8;

            #region 初始化专辑数据
            //Task.Run(() =>
            //{
            Application.Current.Dispatcher.Invoke(() => { AlbumList = GetAlbumModels("https://music.migu.cn/v3/music/digital_album", wc, htmlDc); });
            //});

            #endregion

            #region 初始化NewLit

            //Task.Run(() =>
            //{
            Application.Current.Dispatcher.Invoke(() => { NewList = GetSongModels("https://www.kugou.com/yy/rank/home/1-52767.html?from=rank", wc, htmlDc); });
            //});

            #endregion

            #region 初始化HotList
            //Task.Run(() =>
            //{
            Application.Current.Dispatcher.Invoke(() => { HotList = GetSongModels("https://www.kugou.com/yy/rank/home/1-52144.html?from=rank", wc, htmlDc); });
            //});

            #endregion

            #region 初始化Top500List
            //Task.Run(() =>
            //{
            Application.Current.Dispatcher.Invoke(() => { Top500List = GetSongModels("https://www.kugou.com/yy/rank/home/1-8888.html?from=rank", wc, htmlDc); });

            //});

            #endregion
        }

        /// <summary>
        /// 获取歌曲榜单
        /// </summary>
        /// <returns></returns>
        private ObservableCollection<SongModel> GetSongModels(string url, WebClient wc, HtmlDocument htmlDc)
        {
            ObservableCollection<SongModel> songs = new ObservableCollection<SongModel>();

            //WebClient wc = new WebClient();
            string html = wc.DownloadString(url);
            //HtmlDocument htmlDc = new HtmlDocument();
            htmlDc.LoadHtml(html);

            //SelectSingleNode 据XPath获取唯一的一个节
            var listNode = htmlDc.DocumentNode.SelectSingleNode("//div[@class='pc_temp_songlist ']");
            var ulNode = listNode.ChildNodes[1];
            var liNodes = ulNode.SelectNodes("li");

            //一个li就是一首歌
            for (int i = 0; i < liNodes.Count; i++)
            {
                var items = liNodes[i].ChildNodes[7].Attributes["title"].Value.Split("-");
                //string[]  = li.Trim().Replace("\n", "").Replace("\t", "").Split("-");

                string herf = liNodes[i].ChildNodes[7].Attributes["href"].Value;

                string dur = liNodes[i].ChildNodes[9].ChildNodes[7].InnerText.Replace("\n", "").Replace("\t", "");

                //获取歌曲封面
                WebClient wc1 = new WebClient();
                wc1.Encoding = Encoding.UTF8;
                var html1 = wc1.DownloadString(herf);
                HtmlDocument htmlDc1 = new HtmlDocument();
                htmlDc1.LoadHtml(html1);

                string cover = htmlDc1.DocumentNode.SelectSingleNode("//div[@class='albumImg']").ChildNodes[1].Attributes["src"].Value;

                songs.Add(new SongModel
                {
                    SongName = items[1].Trim(),
                    Cover = cover,
                    Singer = items[0].Trim(),
                    Duration = dur,
                    Url = herf,
                    Index = i + 1

                });

            }


            return songs;

        }

        /// <summary>
        /// 获取专辑
        /// </summary>
        /// <returns></returns>
        private ObservableCollection<AlbumModel> GetAlbumModels(string url, WebClient wc, HtmlDocument htmlDc)
        {
            ObservableCollection<AlbumModel> albums = new ObservableCollection<AlbumModel>();

            string html = wc.DownloadString(url);
            //HtmlDocument htmlDc = new HtmlDocument();
            htmlDc.LoadHtml(html);
            //找到所有 div 的class=thumb的所有节点
            //SelectNodes 根据XPath获取一个节点集合
            HtmlNodeCollection htmlNodes = htmlDc.DocumentNode.SelectNodes("//div[@class='thumb']");

            if (htmlNodes != null && htmlNodes.Count > 0)
            {
                for (int i = 0; i < htmlNodes.Count; i++)
                {
                    //获取图片连接,一个个节点往下查
                    var node = htmlNodes[i].ChildNodes[1];
                    var a = node.ChildNodes[1];
                    //点击专辑后跳转链接
                    string href = a.Attributes["href"].Value;
                    var img = a.ChildNodes[1];
                    //找到img节点后，根据节点的属性拿出链接
                    string src = img.Attributes["data-src"].Value;


                    //获取作者和专辑名称和id
                    node = htmlNodes[i].ChildNodes[3];
                    string name = node.ChildNodes[1].ChildNodes[1].InnerText;
                    string author = node.ChildNodes[3].ChildNodes[1].InnerText;
                    var id = node.ChildNodes[5].Attributes["data-id"].Value;

                    //添加专辑
                    albums.Add(new AlbumModel
                    {
                        Id = id,
                        Title = name,
                        Author = author,
                        Cover = "https:" + src,
                        TargetUrl = "https://music.migu.cn/" + href

                    });
                }
            }
            return albums;
        }

        #region Command
        //播放音乐
        public async void Play(SongModel song)
        {
            try
            {
                //1.下载对应的mp3文件
                var options = new LaunchOptions { Headless = true };
                //await new BrowserFetcher().DownloadAsync(BrowserFetcher.DefaultChromiumRevision);
                using (var browser = await Puppeteer.LaunchAsync(options))
                {
                    using (var page = await browser.NewPageAsync())
                    {
                        await page.GoToAsync(song.Url);
                        var jsSelectAllAnchors = @"Array.from(document.querySelectorAll('audio')).map(a => a.src);";
                        var urls = await page.EvaluateExpressionAsync<string[]>(jsSelectAllAnchors);

                        if (urls.Length > 0)
                        {
                            wc.DownloadFile(urls[0], "./songs/" + song.SongName + ".mp3");
                        }
                    }
                }

                //2.添加到播放列表
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }
        #endregion



    }
}
