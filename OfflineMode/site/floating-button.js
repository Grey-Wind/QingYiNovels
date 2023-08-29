function toggleFloatBox() {
      const floatBox = document.getElementById('floatBox');
      floatBox.classList.toggle('open');
      
      if (floatBox.classList.contains('open')) {
        // 在此处实时获取并展示最近十条commits
        fetchCommits();
      } else {
        // 清空commits内容
        document.getElementById('commitsContent').innerHTML = '';
      }
    }
    
    function fetchCommits() {
      // 使用合适的方法获取commits，并将结果展示在float-box-content中
      // 以下仅为示例代码，你需要根据实际情况进行修改
      
      const url = 'https://api.github.com/repos/Grey-Wind/Novels/commits?per_page=10';
      
      fetch(url)
        .then((response) => response.json())
        .then((data) => {
          const commitsContent = document.getElementById('commitsContent');
          
          data.forEach((commit) => {
            const commitElement = document.createElement('a');
            commitElement.href = commit.html_url; // 将链接指向 GitHub commits 页面
            commitElement.target = "_blank"; // 在新标签页打开链接
            commitElement.textContent = commit.commit.message;
            commitElement.classList.add('float-link'); // 添加样式类
            commitsContent.appendChild(commitElement);
          });
        })
        .catch((error) => console.log(error));
    }