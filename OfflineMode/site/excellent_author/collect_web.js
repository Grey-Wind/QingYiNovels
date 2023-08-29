// JavaScript Document
function bookmark() {
      var title = "灰风小说网"; // 获取网页标题
      var url = "https://gw-novels.zeabur.app/"; // 使用zeabur地址
      var iconUrl = "https://hub.ggo.icu/Grey-Wind/website-image/raw/main/Novels/main.page_icon/icon/icon.ico"; // 指定图标的URL

      if (window.chrome && window.chrome.bookmarks) { // 支持Chrome浏览器
        chrome.bookmarks.create({
          'title': title,
          'url': url,
          'faviconUrl': iconUrl
        });
      } else if (window.external && window.external.msAddSiteModeFavIcon) { // 支持Edge浏览器
        window.external.msAddSiteModeFavIcon(url, title, iconUrl);
        window.external.msSiteModeActivate();
      } else { // 其他浏览器使用Ctrl+D添加书签
        alert("请使用 Ctrl+D 将该页面加入收藏夹！");
      }
    }